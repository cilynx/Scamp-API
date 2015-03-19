using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentDbRepositories.Implementation;

namespace DocumentDbRepositories.Implementation
{
    public class RepositoryFactory
    {
        private readonly string _authKey;
        private readonly string _endpoint;
        private readonly string _databaseName;
        private readonly string _collectionName;

        //public RepositoryFactory(IConfiguration configuration)
        //{
        //    _endpoint = configuration["DocDb:endpoint"];
        //    _authKey = configuration["DocDb:authkey"];
        //    _databaseName = configuration["DocDb:databaseName"];
        //    _collectionName = configuration["DocDb:collectionName"];
        //}


        



        public async Task<UserRepository> GetUserRepositoryAsync()
        {
            var repo = new UserRepository();
            await repo.InitializeDBConnection(_endpoint, _authKey, _databaseName, _collectionName);
            return repo;
        }
        public async Task<GroupRepository> GetGroupRepositoryAsync()
        {
            var repo = new GroupRepository();
            await repo.InitializeDBConnection(_endpoint, _authKey, _databaseName, _collectionName);
            return repo;
        }
        public async Task<ResourceRepository> GetResourceRepositoryAsync()
        {
            var repo = new ResourceRepository();
            await repo.InitializeDBConnection(_endpoint, _authKey, _databaseName, _collectionName);
            return repo;
        }
        public async Task<SubscriptionRepository> GetSubscriptionRepositoryAsync()
        {
            var repo = new SubscriptionRepository();
            await repo.InitializeDBConnection(_endpoint, _authKey, _databaseName, _collectionName);
            return repo;
        }
    }
}
