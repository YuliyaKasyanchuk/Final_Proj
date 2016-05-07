using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InternetApp.Models.ModelLogick;
using NUnit.Framework;

namespace UnitTests.ModelTest
{
    [TestFixture]
    class UserTest
    {
        [Test]
        public void UserCreation()
        {
            string name = "Petro";
            string password = "ololo";

            User user = new User(name, password);

            user.Name = name;
            user.Password = password;

            Assert.AreEqual(user.Name,name);
            Assert.AreEqual(user.Password, password);
        }
    }
}
