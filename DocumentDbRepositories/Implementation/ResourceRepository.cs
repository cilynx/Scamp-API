using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace DocumentDbRepositories.Implementation
{

    public class ResourceRepository
    {
        private DocumentClient client;
        private Database database;
        private DocumentCollection collection;

        public async Task InitializeDBConnection(string endpointUrl, string authKey, string databaseName, string collectionName)
        {
            var policy = new ConnectionPolicy()
            {
                ConnectionProtocol = Protocol.Tcp,
                ConnectionMode = ConnectionMode.Direct
            };
            client = new DocumentClient(new Uri(endpointUrl), authKey);//, policy);
            database = await GetOrCreateDatabaseAsync(databaseName);

            //Get, or Create, the Document Collection
            collection = await GetOrCreateCollectionAsync(database.SelfLink, collectionName);

        }

        public Task<ScampResource> GetResource(string resourceId)
        {
            var resources = from u in client.CreateDocumentQuery<ScampResource>(collection.SelfLink)
                            where u.Id == resourceId
                            select u;
            var resourceList = resources.ToList();
            if (resourceList.Count == 0)
                return Task.FromResult((ScampResource)null);
            return Task.FromResult(resourceList[0]);
        }

        public Task<IEnumerable<ScampResourceGroup>> GetResources()
        {
            var resources = from u in client.CreateDocumentQuery<ScampResourceGroup>(collection.SelfLink)
                            select u;
            var resourceList = resources.ToList();
            return Task.FromResult((IEnumerable<ScampResourceGroup>)resourceList[0]);
        }

        public Task<IEnumerable<ScampResourceGroup>> GetResourcesByOwner(string userId)
        {
            //TODO: need to add "join" to get by owner relationship
            var resources = from u in client.CreateDocumentQuery<ScampResourceGroup>(collection.SelfLink)
                            select u;
            var resourceList = resources.ToList();
            return Task.FromResult((IEnumerable<ScampResourceGroup>)resourceList);
        }

        public Task<IEnumerable<ScampResourceGroup>> GetResourcesByGroup(string userId)
        {
            //TODO: need to add "join" to get by group relationship
            var resources = from u in client.CreateDocumentQuery<ScampResourceGroup>(collection.SelfLink)
                            select u;
            var resourceList = resources.ToList();
            return Task.FromResult((IEnumerable<ScampResourceGroup>)resourceList);
        }

        public Task AddResource(string groupID)
        {
            //TODO: stuff
            throw new NotImplementedException();
        }

        public void AddOwner(string groupID)
        {
            //TODO: stuff
            throw new NotImplementedException();
        }

        private async Task<Database> GetOrCreateDatabaseAsync(string id)
        {
            Database database = client.CreateDatabaseQuery().Where(db => db.Id == id).ToArray().FirstOrDefault();
            if (database == null)
            {
                database = await client.CreateDatabaseAsync(new Database { Id = id });
            }

            return database;
        }

        private async Task<DocumentCollection> GetOrCreateCollectionAsync(string dbLink, string id)
        {
            DocumentCollection collection = client.CreateDocumentCollectionQuery(dbLink).Where(c => c.Id == id).ToArray().FirstOrDefault();
            if (collection == null)
            {
                collection = await client.CreateDocumentCollectionAsync(dbLink, new DocumentCollection { Id = id });
            }

            return collection;
        }

    }
}
