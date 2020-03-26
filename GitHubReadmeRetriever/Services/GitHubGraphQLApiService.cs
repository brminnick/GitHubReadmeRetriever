using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubReadmeRetriever
{
    class GitHubGraphQLApiService
    {
        readonly IGitHubGraphQLApi _gitHubGraphQLClient;

        public GitHubGraphQLApiService(IGitHubGraphQLApi gitHubGraphQLApiClient) => _gitHubGraphQLClient = gitHubGraphQLApiClient;

        public async Task<Repository> GetRepository(string repositoryOwner, string repositoryName, GitHubToken token, CancellationToken? cancellationToken = null)
        {
            cancellationToken ??= CancellationToken.None;

            var data = await ExecuteGraphQLRequest(() => _gitHubGraphQLClient.RepositoryQuery(new RepositoryQueryContent(repositoryOwner, repositoryName), CreateBearerTokenString(token))).ConfigureAwait(false);

            return data.Repository;
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
            var data = await ExecuteGraphQLRequest(() => _gitHubGraphQLClient.RepositoryConnectionQuery(new RepositoryConnectionQueryContent(repositoryOwner, GetEndCursorString(endCursor), numberOfRepositoriesPerRequest), CreateBearerTokenString(token))).ConfigureAwait(false);

            return data.UserResponse.RepositoryConnection;
        }

        async Task<T> ExecuteGraphQLRequest<T>(Func<Task<GraphQLResponse<T>>> action)
        {
            var response = await action().ConfigureAwait(false);

            if (response.Errors != null)
                throw new AggregateException(response.Errors.Select(x => new Exception(x.Message)));

            return response.Data;
        }

        static string CreateBearerTokenString(GitHubToken token) => $"{token.TokenType} {token.AccessToken}";

        static string GetEndCursorString(string? endCursor) => string.IsNullOrWhiteSpace(endCursor) ? string.Empty : "after: \"" + endCursor + "\"";
    }
}
