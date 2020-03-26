using System;
using System.Net;
using System.Net.Http;
using GitHubReadmeScanner;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;

[assembly: FunctionsStartup(typeof(Startup))]
namespace GitHubReadmeScanner
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddRefitClient<IGitHubGraphQLApi>()
              .ConfigureHttpClient(client => client.BaseAddress = new Uri(GitHubConstants.GitHubAuthBaseUrl))
              .ConfigurePrimaryHttpMessageHandler(config => new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
              .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(3, sleepDurationProvider));

            builder.Services.AddRefitClient<IGitHubUserContentApi>()
              .ConfigureHttpClient(client => client.BaseAddress = new Uri(GitHubConstants.GitHubUserContentUrl))
              .ConfigurePrimaryHttpMessageHandler(config => new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
              .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(1, sleepDurationProvider));

            builder.Services.AddSingleton<GitHubGraphQLApiService>();
            builder.Services.AddSingleton<GitHubUserContentApiService>();

            static TimeSpan sleepDurationProvider(int attemptNumber) => TimeSpan.FromSeconds(Math.Pow(2, attemptNumber));
        }
    }
}
