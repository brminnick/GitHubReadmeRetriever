namespace GitHubReadmeRetriever
{
    public class ReadmeModel
    {
        public ReadmeModel(string readme, string repositoryName, string repositoryOwner) =>
            (Readme, RepositoryName, RepositoryOwner) = (readme, repositoryName, repositoryOwner);

        public string Readme { get; }
        public string RepositoryName { get; }
        public string RepositoryOwner { get; }
    }
}
