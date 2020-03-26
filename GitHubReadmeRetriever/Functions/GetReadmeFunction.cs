using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace GitHubReadmeRetriever
{
    class GetReadmeFunction
    {
        readonly GitHubUserContentApiService _gitHubUserContentApiService;

        public GetReadmeFunction(GitHubUserContentApiService gitHubUserContentApiService) => _gitHubUserContentApiService = gitHubUserContentApiService;

        [FunctionName(nameof(GetReadmeFunction))]
        public Task<ReadmeModel> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetReadme/{ownerName}/{repositoryName}")] HttpRequest req, string ownerName, string repositoryName, ILogger log)
        {
            log.LogInformation($"Retrieving Readme for {repositoryName} by {ownerName}");

            return _gitHubUserContentApiService.GetReadme(ownerName, repositoryName);
        }
    }
}
