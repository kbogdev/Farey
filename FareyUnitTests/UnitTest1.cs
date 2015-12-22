using System;
using Farey;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FareyUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FareyNumbers nums = new FareyNumbers(1);
            Assert.IsTrue(nums.Count == 2);

            string result = "0/1,1/1";
            Assert.IsTrue(0 == nums.ToString().CompareTo(result));
        }

        [TestMethod]
        public void TestMethod2()
        {
            FareyNumbers nums = new FareyNumbers(2);
            Assert.IsTrue(nums.Count == 3);

            string result = "0/1,1/2,1/1";
            Assert.IsTrue(0 == nums.ToString().CompareTo(result));
        }

        [TestMethod]
        public void TestMethod5()
        {
            FareyNumbers nums = new FareyNumbers(5);
            Assert.IsTrue(nums.Count == 11);

            string result = "0/1,1/5,1/4,1/3,2/5,1/2,3/5,2/3,3/4,4/5,1/1";
            Assert.IsTrue(0 == nums.ToString().CompareTo(result));
        }
    }
}
