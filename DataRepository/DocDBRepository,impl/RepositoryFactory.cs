using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocDBRepository.impl;

namespace DocDBRepository.impl
{
    public class RepositoryFactory
    {
        private readonly string _authKey;
        private readonly string _endpoint;

        public RepositoryFactory(string endpoint, string authKey)
        {
            _endpoint = endpoint;
            _authKey = authKey;
        }
        public async Task<UserRepository> GetUserRepositoryAsync()
        {
            var repo = new UserRepository();
            await repo.InitializeDBConnection(_endpoint, _authKey);
            return repo;
        }
        public async Task<GroupRepository> GetGroupRepositoryAsync()
        {
            var repo = new GroupRepository();
            await repo.InitializeDBConnection(_endpoint, _authKey);
            return repo;
        }
        public async Task<ResourceRepository> GetResourceRepositoryAsync()
        {
            var repo = new ResourceRepository();
            await repo.InitializeDBConnection(_endpoint, _authKey);
            return repo;
        }
        public async Task<SubscriptionRepository> GetSubscriptionRepositoryAsync()
        {
            var repo = new SubscriptionRepository();
            await repo.InitializeDBConnection(_endpoint, _authKey);
            return repo;
        }
    }
}
