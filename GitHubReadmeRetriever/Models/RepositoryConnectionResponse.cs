namespace GitHubReadmeRetriever
{
    class RepositoryConnectionResponse
    {
        public RepositoryConnectionResponse(UserResponse user) => UserResponse = user;

        public UserResponse UserResponse { get; }
    }
}
