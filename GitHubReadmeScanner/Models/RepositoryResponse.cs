namespace GitHubReadmeScanner
{
    class RepositoryResponse
    {
        public RepositoryResponse(Repository repository) => Repository = repository;

        public Repository Repository { get; }
    }
}
