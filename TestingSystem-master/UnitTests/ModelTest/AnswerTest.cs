using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using InternetApp.Models.ModelLogick;

namespace UnitTests.ModelTest
{
    [TestFixture]
    public class AnswerTest
    {
        [Test]
        public void AnswerCreation()
        {
            Answer ans = new Answer();
            string str = "Odessa";

            ans.Text = str;
            ans.IsRight = false;

            Assert.AreEqual(ans.IsRight, false);
            Assert.AreEqual(ans.Text, str);
        }
    }
}
