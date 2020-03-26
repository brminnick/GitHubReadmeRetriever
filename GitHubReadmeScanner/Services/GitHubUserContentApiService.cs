using System.Threading.Tasks;

namespace GitHubReadmeScanner
{
    class GitHubUserContentApiService
    {
        readonly IGitHubUserContentApi _gitHubUserContentApi;

        public GitHubUserContentApiService(IGitHubUserContentApi gitHubUserContentApi) => _gitHubUserContentApi = gitHubUserContentApi;

        public async Task<ReadmeModel> GetReadme(string owner, string repository)
        {
            string readme;

            var getUpperCaseReadmeTask = _gitHubUserContentApi.GetReadme_UpperCase(owner, repository);
            var getLowerCaseReadmeTask = _gitHubUserContentApi.GetReadme_LowerCase(owner, repository);
            var getPascalCaseReadmeTask = _gitHubUserContentApi.GetReadme_PascalCase(owner, repository);

            try
            {
                readme = await getUpperCaseReadmeTask.ConfigureAwait(false);
            }
            catch
            {
                try
                {
                    readme = await getLowerCaseReadmeTask.ConfigureAwait(false);
                }
                catch
                {
                    readme = await getPascalCaseReadmeTask.ConfigureAwait(false);
                }
            }

            return new ReadmeModel(readme, repository, owner);
        }
    }
}
