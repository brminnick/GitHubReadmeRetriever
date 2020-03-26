using System.Collections.Generic;
using System.Linq;

namespace GitHubReadmeRetriever
{
    class RepositoryConnection
    {
        public RepositoryConnection(IEnumerable<Repository>? nodes, PageInfo pageInfo)
        {
            RepositoryList = nodes?.ToList() ?? Enumerable.Empty<Repository>().ToList();
            PageInfo = pageInfo;
        }
        
        public List<Repository> RepositoryList { get; }

        public PageInfo PageInfo { get; }
    }
}
