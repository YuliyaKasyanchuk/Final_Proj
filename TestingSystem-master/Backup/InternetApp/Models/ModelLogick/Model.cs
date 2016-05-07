using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;

namespace InternetApp.Models.ModelLogick
{
    public class Model : IDisposable
    {
        private DataBaseContext mTestsBaseContext;

        private List<TestBlock> mListOfTestBlocks;
        public List<TestBlock> ListOfTestBlocks
        {
            get { return mListOfTestBlocks; }
        }

        public Test GetTest(string blockName,string testName)
        {
            return (mListOfTestBlocks.Find(block => block.Name == testName)).Tests.ToList().Find(test => test.Name == testName);
        }

        public void AddTest(string blockName,Test test)
        {
            TestBlock currBlock = mListOfTestBlocks.Find(block => block.Name == blockName);
            if(currBlock != null)
                if(!currBlock.Tests.Contains(test) && !currBlock.Tests.ToList().Exists(tst => tst.Name == test.Name))
                    currBlock.Tests.Add(test);
        }
        // для первого дэмо он не нужен, но в последствии понадобится для админа
        public void CopyTest(Test test)
        {
            
        }

        public void Dispose()
        {
            mTestsBaseContext.SaveChanges();
        }

        public Model()
        {
            mTestsBaseContext = new DataBaseContext();
            TestPreparation();
            mListOfTestBlocks = mTestsBaseContext.TestBlocks.ToList<TestBlock>();
        }

        private void TestPreparation()
        {
            Test test1 = new Test();
            test1.Name = "bla-bla-bla";
            Test test2 = new Test();
            test2.Name = "bla-bla-2";

            TestBlock block1 = new TestBlock();
            block1.Name = "block1";
            block1.Tests.Add(test1);
            block1.Tests.Add(test2);

            mTestsBaseContext.TestBlocks.Add(block1);
            mTestsBaseContext.SaveChanges();
        }
    }
}