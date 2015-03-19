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

    public class GroupRepository
    {
        private  DocumentClient client;
        private  Database database;
        private  DocumentCollection collection;
        private static readonly string dbName="scamp";
        private static readonly string collectionName = "groupdata";

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

        public  async Task<ScampResourceGroup> GetGroup(string groupID)
        {
            var groups = from u in client.CreateDocumentQuery<ScampResourceGroup>(collection.SelfLink)
                        where u.Id == groupID
						select u;
            var grouplist = groups.ToList();
            if (grouplist.Count == 0)
                return null;
            return grouplist[0];
           
        }

		public async Task<ScampResourceGroup> GetGroups()
		{
			var groups = from u in client.CreateDocumentQuery<ScampResourceGroup>(collection.SelfLink)
						 select u;
			var grouplist = groups.ToList();
			if (grouplist.Count == 0)
				return null;
			return grouplist[0];

		}

		public async void AddResource(string groupID)
		{
			//TODO: stuff
		}

		public async void AddMember(string groupID)
		{
			//TODO: stuff
		}
		public async void AddAdmin(string groupID)
		{
			//TODO: stuff
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
