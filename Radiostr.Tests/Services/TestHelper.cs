using System;
using System.IO;
using Moq;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Model.Entities;
using Radiostr.Repositories;
using Radiostr.Services;

namespace Radiostr.Tests.Services
{
    public class TestHelper
    {
        readonly string _uid = Path.GetRandomFileName();

        public User GetTestUser()
        {
            var mockSecurityHelper = new Mock<ISecurityHelper>();
            var repository = new RadiostrRepository<User>(new RadiostrDbConnection());
            var service = new RadiostrService<User>(mockSecurityHelper.Object, repository);
            var user = new User
            {
                Username = "NewUser_" + GetUid(),
                FullName = "New User " + GetUid(),
                Email = "newuser@" + GetUid(),
                WhenCreated = DateTime.Now
            };

            int id = service.Create(user);

            user.Id = id;

            return user;
        }

        public string GetUid()
        {
            return _uid;
        }
    }
}