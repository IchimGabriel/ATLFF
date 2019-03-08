using Microsoft.Extensions.Options;
using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATLFFApp.API.Repositories.Neo4j
{
    public interface IGraphRepository
    {
        IDriver Driver { get; set; }
    }
    public class GraphRepository : IGraphRepository
    {
        private readonly API.Neo4j neo4J;

        public GraphRepository(IOptions<AtlffSettings> options)
        {
            neo4J = options.Value.Neo4j;

            var url = neo4J.Uri;
            var user = neo4J.User;
            var password = neo4J.Password;

            Driver = GraphDatabase.Driver(url, AuthTokens.Basic(user, password));
        }
        public IDriver Driver { get; set; }
    }
}
