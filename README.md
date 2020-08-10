<div class="header" align="center">
  <h1 align="center">GitHub Readme Retriever</h1>
</div>
<p align="center">
  <a href="https://twitter.com/TheCodeTraveler">
    <img alt="Twitter: TheCodeTraveler" src="https://img.shields.io/twitter/follow/TheCodeTraveler.svg?style=social" target="_blank" />
  </a>
</p>

The GitHub Readme Retriever APIs allow you retrieve the `README.md` from any GitHub Repo.

## GET README

Retrieve the `README.md` file from any public GitHub Repository.

**Request**

The API request requires two parameters: `ownerName` and `repositoryName`:
- `ownerName` is the name of the GitHub user who owns the repository
- `repositoryName` is the name of the GitHub Repository

Both values be extracted from the GitHub repository's url:

`https://github.com/{ownerName}/{repositoryName}`

```bash
curl --request GET 'https://githubreadmeretriever.azurewebsites.net/api/GetReadme/{ownerName}/{repositoryName}'
```

**Response**

```javascript
{
    "readme": "string",
    "repositoryName": "string",
    "repositoryOwner": "string"
}
```

### Example

To retrieve this repo's `README.md`, we'll use the following parameters:

- ownerName: `brminnick`
- repositoryName: `GitHubReadmeRetriever`

```bash
curl --request GET 'https://githubreadmeretriever.azurewebsites.net/api/GetReadme/brminnick/GitHubReadmeRetriever'
```

```javascript
{
    "readme": "<div class=\"header\" align=\"center\">\n  <h1 align=\"center\">GitHub Readme Retriever</h1>\n</div>..."
    "repositoryName": "GitHubReadmeRetriever",
    "repositoryOwner": "brminnick"
}
```

## GET ALL READMEs

Retrieve the `README.md` file from all private and public GitHub Repositories owned by the user.

**Request**

The API request requires two parameters: `ownerName` and `token`:
- `ownerName` is your GitHub username / login
- `token` is your Personal Access Token [generated by following these steps](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/#creating-a-token) 

```bash
curl --request GET 'https://githubreadmeretriever.azurewebsites.net/api/GetReadmes/{ownerName}/{token}'
```

**Response**

```javascript
[
  {
      "readme": "string",
      "repositoryName": "string",
      "repositoryOwner": "string"
  }
  {
      "readme": "string",
      "repositoryName": "string",
      "repositoryOwner": "string"
  }
]
```

### Example

To retrieve the `README.md` for all of my repositories, we will use the following parameters:
- ownerName: `brminnick`
- token: `debddf126115d5f193526a7f29fe980e525e497e`

> **Note:** This example is not using a real token. You can [create your token by following these steps](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/#creating-a-token).

```bash
curl --request GET 'https://githubreadmeretriever.azurewebsites.net/api/GetReadmes/brminnick/debddf126115d5f193526a7f29fe980e525e497e'
```

```javascript
[
  {
      "readme": "# AsyncAwaitBestPractices\n\n[![Build Status](https://brminnick.visualstudio.com/AsyncAwaitBestPractices/_apis/build/status/AsyncAwaitBestPractices-.NET Desktop-CI?WT.mc_id=githubreadmeretriever-github-bramin)](https://brminnick.visualstudio.com/AsyncAwaitBestPractices/_build/latest?definitionId=5&WT.mc_id=githubreadmeretriever-github-bramin)\n\n...",
      "repositoryName": "AsyncAwaitBestPractices",
      "repositoryOwner": "brminnick"
  }
  {
      "readme": "<div class=\"header\" align=\"center\">\n  <h1 align=\"center\">GitTrends: GitHub Insights</h1>\n</div>\n<p align=\"center\">\n  <a href=\"https://twitter.com/GitTrendsApp\">\n...",
      "repositoryName": "GitTrends",
      "repositoryOwner": "brminnick"
  }
  {
      "readme": "<div class=\"header\" align=\"center\">\n  <h1 align=\"center\">GitHub Readme Retriever</h1>\n</div>...",
      "repositoryName": "GitHubReadmeRetriever",
      "repositoryOwner": "brminnick"
  }
]
```


## Resources

Cloud Backend
- [.NET Core](https://docs.microsoft.com/dotnet/core/?WT.mc_id=githubreadmeretriever-github-bramin) - an [open-source](https://github.com/dotnet/core), general-purpose development platform maintained by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core)
- [Azure Functions](https://docs.microsoft.com/azure/azure-functions/?WT.mc_id=githubreadmeretriever-github-bramin) - a serverless compute service that lets you run event-triggered code without having to explicitly provision or manage infrastructure
- [Azure Functions Dependency Injection](https://docs.microsoft.com/azure/azure-functions/functions-dotnet-dependency-injection?WT.mc_id=githubreadmeretriever-github-bramin) - Azure Functions supports the dependency injection (DI) software design pattern, which is a technique to achieve [Inversion of Control (IoC)](https://docs.microsoft.com/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles?WT.mc_id=githubreadmeretriever-github-bramin#dependency-inversion) between classes and their dependencies
- [Polly + HttpClientFactory](https://docs.microsoft.com/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly?WT.mc_id=githubreadmeretriever-github-bramin) - the recommended approach for retries with exponential backoff is to take advantage of more advanced .NET libraries
- [Refit + HttpClientFactory](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?WT.mc_id=githubreadmeretriever-github-bramin#generated-clients) - `IHttpClientFactory` can be used in combination with third-party libraries such as Refit

## Author

👤 **Brandon Minnick**

-   Twitter: [@TheCodeTraveler](https://twitter.com/TheCodeTraveler)
-   Blog: https://codetraveler.io
-   Github: [@brminnick](https://github.com/brminnick)

## Show your support

⭐️ [Star the GitHub Repo](https://github.com/brminnick/GitHubReadmeRetriever/) <br/>
