namespace GitHubReadmeScanner
{
    class Repository
    {
        public Repository(string name, RepositoryOwner owner, string url)
        {
            OwnerLogin = owner.Login;
            Url = url;
            Name = name;
        }

        public string OwnerLogin { get; }
        public string Name { get; }
        public string Url { get; }
    }

    class RepositoryOwner
    {
        public RepositoryOwner(string login) => Login = login;

        public string Login { get; }
    }
}
