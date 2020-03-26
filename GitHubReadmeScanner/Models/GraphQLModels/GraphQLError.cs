﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GitHubReadmeScanner
{
    class GraphQLError
    {
        public GraphQLError(string message, GraphQLLocation[] locations) => (Message, Locations) = (message, locations);

        public string Message { get; }

        public GraphQLLocation[] Locations { get; }

        [JsonExtensionData]
        public IDictionary<string, JToken>? AdditonalEntries { get; set; }
    }

    class GraphQLLocation
    {
        public long Line { get; }

        public long Column { get; }
    }
}
