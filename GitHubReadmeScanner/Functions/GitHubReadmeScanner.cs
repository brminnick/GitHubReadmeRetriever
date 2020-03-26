using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace GitHubReadmeScanner
{
    class GetReadmeListFunction
    {
        readonly GitHubGraphQLApiService _gitHubGraphQLApiService;
        readonly GitHubUserContentApiService _gitHubUserContentApiService;

        public GetReadmeListFunction(GitHubGraphQLApiService gitHubGraphQLApiService, GitHubUserContentApiService gitHubUserContentApiService) =>
            (_gitHubGraphQLApiService, _gitHubUserContentApiService) = (gitHubGraphQLApiService, gitHubUserContentApiService);

        [FunctionName(nameof(GetReadmeListFunction))]
        public async IAsyncEnumerable<ReadmeModel> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetReadmes/{ownerName}/{token}")] HttpRequest req, string ownerName, string token, ILogger log)
        {
            log.LogInformation($"Retrieving Repositories for {ownerName}");

            var repositoryList = new List<Repository>();

            await foreach (var returnedRepositories in _gitHubGraphQLApiService.GetRepositories(ownerName, new GitHubToken(token, string.Empty, "Bearer")).ConfigureAwait(false))
            {
                repositoryList.AddRange(returnedRepositories);
            }

            await foreach (var readme in GetReadmes(repositoryList).ConfigureAwait(false))
            {
                yield return readme;
            }
        }

        async IAsyncEnumerable<ReadmeModel> GetReadmes(IEnumerable<Repository> repositories)
        {
            var getReadmeTaskList = new List<Task<ReadmeModel>>(repositories.Select(x => _gitHubUserContentApiService.GetReadme(x.OwnerLogin, x.Name)));

            while (getReadmeTaskList.Any())
            {
                var completedReadmeTask = await Task.WhenAny(getReadmeTaskList).ConfigureAwait(false);
                getReadmeTaskList.Remove(completedReadmeTask);

                yield return await completedReadmeTask.ConfigureAwait(false);
            }
        }
    }
}
