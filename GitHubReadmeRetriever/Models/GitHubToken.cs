namespace GitHubReadmeRetriever
{
    class GitHubToken
    {
        public GitHubToken(string access_token, string scope, string token_type) =>
            (AccessToken, Scope, TokenType) = (access_token, scope, token_type);

        public string AccessToken { get; }

        public string Scope { get; }

        public string TokenType { get; }
    }
}
