namespace GitHubReadmeScanner
{
    class GraphQLResponse<T>
    {
        public GraphQLResponse(T data, GraphQLError[] errors) => (Data, Errors) = (data, errors);

        public T Data { get; }

        public GraphQLError[] Errors { get; }
    }
}
