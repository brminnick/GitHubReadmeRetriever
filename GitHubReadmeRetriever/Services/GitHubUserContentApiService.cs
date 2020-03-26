using System.Threading.Tasks;

namespace GitHubReadmeRetriever
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
                    try
                    {
                        readme = await getPascalCaseReadmeTask.ConfigureAwait(false);
                    }
                    catch
                    {
                        readme = "Unable to locate a readme with the following name: README.md, ReadMe.md, readme.md";
                    }
                }
            }

            return new ReadmeModel(readme, repository, owner);
        }
    }
}
