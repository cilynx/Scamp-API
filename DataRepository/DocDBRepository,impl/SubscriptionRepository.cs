using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using DocDBRepository.dto;

namespace DocDBRepository.impl
{

    public class SubscriptionRepository
    {
        private  DocumentClient client;
        private  Database database;
        private  DocumentCollection collection;
        private static readonly string dbName="scamp";
        private static readonly string collectionName = "SubscriptionRepository";

        public  async Task InitializeDBConnection(string endpointUrl, string authKey)
        {
            var policy = new ConnectionPolicy()
            {
                ConnectionProtocol = Protocol.Tcp,
                ConnectionMode = ConnectionMode.Direct
            };
            client = new DocumentClient(new Uri(endpointUrl), authKey);//, policy);
            database = await GetOrCreateDatabaseAsync(dbName);

            //Get, or Create, the Document Collection
            collection = await GetOrCreateCollectionAsync(database.SelfLink, collectionName);

        }

		public async Task CreateSubscription(ScampSubscription newSubscription)
		{
			var created = await client.CreateDocumentAsync(collection.SelfLink, newSubscription);
		}

		public async Task<ScampSubscription> GetSubscription(string subscriptionId)
        {
            var subscriptions = from u in client.CreateDocumentQuery<ScampSubscription>(collection.SelfLink)
								where u.Id == subscriptionId
								select u;
            var subList = subscriptions.ToList();
            if (subList.Count == 0)
                return null;
            return subList[0];
           
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

        private  async Task<DocumentCollection> GetOrCreateCollectionAsync(string dbLink, string id)
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
