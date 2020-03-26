using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubReadmeScanner
{
    class GitHubGraphQLApiService
    {
        readonly IGitHubGraphQLApi _gitHubGraphQLClient;

        public GitHubGraphQLApiService(IGitHubGraphQLApi gitHubGraphQLApiClient) => _gitHubGraphQLClient = gitHubGraphQLApiClient;

        public async Task<Repository> GetRepository(string repositoryOwner, string repositoryName, GitHubToken token, CancellationToken? cancellationToken = null)
        {
            cancellationToken ??= CancellationToken.None;

            var response = await _gitHubGraphQLClient.RepositoryQuery(new RepositoryQueryContent(repositoryOwner, repositoryName), CreateBearerTokenString(token)).ConfigureAwait(false);

            return response.Data.Repository;
        }

        public async IAsyncEnumerable<IEnumerable<Repository>> GetRepositories(string repositoryOwner, GitHubToken token, int numberOfRepositoriesPerRequest = 100)
        {
            RepositoryConnection? repositoryConnection = null;

            do
            {
                repositoryConnection = await GetRepositoryConnection(repositoryOwner, token, repositoryConnection?.PageInfo?.EndCursor, numberOfRepositoriesPerRequest).ConfigureAwait(false);
                yield return repositoryConnection?.RepositoryList ?? Enumerable.Empty<Repository>();
            }
            while (repositoryConnection?.PageInfo?.HasNextPage is true);
        }

        async Task<RepositoryConnection> GetRepositoryConnection(string repositoryOwner, GitHubToken token, string? endCursor, int numberOfRepositoriesPerRequest = 100)
        {
            var response = await _gitHubGraphQLClient.RepositoryConnectionQuery(new RepositoryConnectionQueryContent(repositoryOwner, GetEndCursorString(endCursor), numberOfRepositoriesPerRequest), CreateBearerTokenString(token)).ConfigureAwait(false);

            return response.Data.UserResponse.RepositoryConnection;
        }

        static string CreateBearerTokenString(GitHubToken token) => $"{token.TokenType} {token.AccessToken}";

        static string GetEndCursorString(string? endCursor) => string.IsNullOrWhiteSpace(endCursor) ? string.Empty : "after: \"" + endCursor + "\"";
    }
}
