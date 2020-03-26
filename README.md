<div class="header" align="center">
  <h1 align="center">GitHub Readme Retriever</h1>
</div>
  </a>
</p>

The GitHub Readme APIs help you retrive a `README.md` from any GitHub Repo

## GET Readme

Retrieve the `README.md` file from any public GitHub Repository.

**Request**

The API request requires two parameters: `ownerName` and `repositoryName`. 

Both values be extracted from the GitHub repository's url:

`https://github.com/{ownerName}/{repositoryName}`

```bash
curl --request GET 'https://githubreadmeretriever.azurewebsites.net/api/GetReadme/{ownerName}/{repositoryName}'
```

**Response**

```json
{
    "readme": "string",
    "repositoryName": "string",
    "repositoryOwner": "string"
}
```

### Example

To retrieve `GitHubReadmeRetriever`'s `README.md`, we'll use the following parameters:
- ownerName: `brminnick`
- repositoryName: `GitHubReadmeRetriever`

```bash
curl --request GET 'https://githubreadmeretriever.azurewebsites.net/api/GetReadme/brminnick/GitHubReadmeRetriever'
```

```json
{
    "readme": "<div class=\"header\" align=\"center\">\n  <h1 align=\"center\">GitHub Readme Retriever</h1>\n</div>..."
    "repositoryName": "GitHubReadmeRetriever",
    "repositoryOwner": "brminnick"
}
```


## Resources

Cloud Backend
- [.NET Core](https://docs.microsoft.com/dotnet/core/?WT.mc_id=gittrends-github-bramin) - an [open-source](https://github.com/dotnet/core), general-purpose development platform maintained by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core)
- [Azure Functions](https://docs.microsoft.com/azure/azure-functions/?WT.mc_id=gittrends-github-bramin) - a serverless compute service that lets you run event-triggered code without having to explicitly provision or manage infrastructure
- [Azure Functions Dependency Injection](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection?WT.mc_id=gittrends-github-bramin) - Azure Functions supports the dependency injection (DI) software design pattern, which is a technique to achieve [Inversion of Control (IoC)](https://docs.microsoft.com/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles?WT.mc_id=gittrends-github-bramin#dependency-inversion) between classes and their dependencies
- [Polly + HttpClientFactory](https://docs.microsoft.com/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly?WT.mc_id=gittrends-github-bramin) - the recommended approach for retries with exponential backoff is to take advantage of more advanced .NET libraries
- [Refit + HttpClientFactory](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?WT.mc_id=gittrends-github-bramin#generated-clients) - `IHttpClientFactory` can be used in combination with third-party libraries such as Refit

## Author

👤 **Brandon Minnick**

-   Twitter: [@TheCodeTraveler](https://twitter.com/TheCodeTraveler)
-   Blog: https://codetraveler.io
-   Github: [@brminnick](https://github.com/brminnick)

## Show your support

⭐️ [Star the GitHub Repo](https://github.com/brminnick/GitHubReadmeRetriever/) <br/>
