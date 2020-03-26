namespace GitHubReadmeScanner
{
    abstract class GraphQLRequest
    {
        protected GraphQLRequest(string query, string variables = "") => (Query, Variables) = (query, variables);

        public string Query { get; }

        public string Variables { get; }
    }
}
