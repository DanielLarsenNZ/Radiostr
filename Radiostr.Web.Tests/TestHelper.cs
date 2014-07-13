using System;
using System.IO;
using Radiostr.Entities;
using Radiostr.Web.Controllers;

namespace Radiostr.Web.Tests
{
    public class TestHelper
    {
        readonly string _uid = Path.GetRandomFileName();

        public User GetTestUser()
        {
            var controller = new UserController();
            
            var user = new User
            {
                Username = "NewUser_" + GetUid(),
                FullName = "New User " + GetUid(),
                Email = "newuser@" + GetUid(),
                WhenCreated = DateTime.Now
            };

            int id = controller.Post(user);

            user.Id = id;

            return user;
        }

        public string GetUid()
        {
            return _uid;
        }
    }
}