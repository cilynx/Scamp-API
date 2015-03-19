using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocDBRepository.impl;
using System.Threading.Tasks;

namespace DocDBRepository.tests
{
    [TestClass]
    public class UserTests
    {
        private static readonly string connectionString = "<db>";
        private static readonly string authKey = "<key>";
        private static UserRepository repository;

        [TestInitialize]
        public void initDocDB()
        {
            repository = new UserRepository();
            repository.InitializeDBConnection(connectionString, authKey).Wait();
        }
        [TestMethod]
        public async Task GetNonExistentUser()
        {
            var user = await repository.GetUser("bogus");
            Assert.IsNull(user);

        }
        [TestMethod]
        public async Task GetValidUser()
        {
            // this will fail unless you pre-populate with this item
            var user = await repository.GetUser("david");
            Assert.IsNotNull(user);

        }
    }
}
