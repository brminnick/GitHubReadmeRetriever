using System.Threading.Tasks;
using Refit;

namespace GitHubReadmeRetriever
{
    [Headers("User-Agent: " + nameof(GitHubReadmeRetriever))]
    public interface IGitHubGraphQLApi
    {
        [Post("")]
        Task<GraphQLResponse<RepositoryResponse>> RepositoryQuery([Body] RepositoryQueryContent request, [Header("Authorization")] string authorization);

        [Post("")]
        Task<GraphQLResponse<RepositoryConnectionResponse>> RepositoryConnectionQuery([Body] RepositoryConnectionQueryContent request, [Header("Authorization")] string authorization);
    }

    public class RepositoryQueryContent : GraphQLRequest
    {
        public RepositoryQueryContent(string repositoryOwner, string repositoryName)
            : base("query { repository(owner:\"" + repositoryOwner + "\" name:\"" + repositoryName + "\"){ name, url, owner { login }")
        {

        }
    }

    public class RepositoryConnectionQueryContent : GraphQLRequest
    {
        public RepositoryConnectionQueryContent(string repositoryOwner, string endCursorString, int numberOfRepositoriesPerRequest = 100)
            : base("query{ user(login: \"" + repositoryOwner + "\"){ repositories(first:" + numberOfRepositoriesPerRequest + endCursorString + ") { nodes { name, url, owner { login } }, pageInfo { endCursor, hasNextPage, hasPreviousPage, startCursor } } } }")
        {

        }
    }
}
