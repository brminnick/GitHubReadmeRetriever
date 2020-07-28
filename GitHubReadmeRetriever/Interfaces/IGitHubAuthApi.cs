﻿using System.Threading.Tasks;
using Refit;

namespace GitHubReadmeRetriever
{
    [Headers("User-Agent: " + nameof(GitHubReadmeRetriever), "Accept-Encoding: gzip", "Accept: application/json")]
    public interface IGitHubAuthApi
    {
        [Get("/login/oauth/access_token")]
        Task<GitHubToken> GetAccessToken([AliasAs("client_id")] string clientId, [AliasAs("client_secret")] string clientSecret, [AliasAs("code")] string loginCode, [AliasAs("state")] string state);
    }
}
