﻿namespace GitHubReadmeScanner
{
    class UserResponse
    {
        public UserResponse(RepositoryConnection repositories, string name)
        {
            RepositoryConnection = repositories;
            Name = name;
        }

        public RepositoryConnection RepositoryConnection { get; }

        public string Name { get; }
    }
}
