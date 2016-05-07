using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApp.Models.ModelLogick
{
    public class User
    {
        private readonly int mId;
        public int ID
        {
            get { return mId; }
        }

        private string mName;
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        private string mPassword;
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        private Test mCurrentTest;
        public Test CurrentTest
        {
            get { return mCurrentTest; }
            set { mCurrentTest = value; }
        }

        public User(string name, string password)
        {
            mName = name;
            mPassword = password;
        }
    }
}