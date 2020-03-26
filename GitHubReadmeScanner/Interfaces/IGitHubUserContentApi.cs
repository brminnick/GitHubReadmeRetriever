﻿using System.Threading.Tasks;
using Refit;

namespace GitHubReadmeScanner
{
    [Headers("User-Agent: " + nameof(GitHubReadmeScanner))]
    interface IGitHubUserContentApi
    {
        [Get("/{owner}/{repository}/master/README.md")]
        Task<string> GetReadme_UpperCase(string owner, string repository);

        [Get("/{owner}/{repository}/master/readme.md")]
        Task<string> GetReadme_LowerCase(string owner, string repository);

        [Get("/{owner}/{repository}/master/ReadMe.md")]
        Task<string> GetReadme_PascalCase(string owner, string repository);
    }
}