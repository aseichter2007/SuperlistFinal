using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Superlist;

namespace SuperlistTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SuperlistStoresInitialValue()
        {
            SuperList<int> superint = new SuperList<int>();
            superint.Add(1);
            int test = superint[0];
            int expected = 1;

            Assert.AreEqual(test, expected);
        }
        [TestMethod]
        public void SuperlistStoresAdditionalValues()
        {
            SuperList<string> superList = new SuperList<string>();
            superList.Add("is");
            superList.Add("this");
            superList.Add("working");
            superList.Add("is");
            superList.Add("this");
            superList.Add("working");
            //I like it, it's staying ugly.
            Assert.IsTrue(superList[0] == superList[3] && superList[1] == superList[4] && superList[2] == superList[5] && superList[0] != superList[1]);

        }
        [TestMethod]
        public void SuperlistCanStoreManyTypes()
        {
            SuperList<string> superstring = new SuperList<string>() { "0.025", "2" };
            SuperList<double> superDouble = new SuperList<double>() { 0.025, 2.0 };
            double test1 = double.Parse(superstring[0]);

            Assert.AreEqual(superDouble[0],test1);

        }
        [TestMethod]
        public void SuperlistCounts()
        {
            SuperList<int> superList = new SuperList<int>();
            superList.Add(1);
            superList.Add(2);
            superList.Add(3);
            int count = 3;
            
            Assert.AreEqual(superList.Count, count);
            
        }
        [TestMethod]

        public void SuperAddCapacity()
        {
            SuperList<int> superList = new SuperList<int>();
            int test1 = superList.Capacity;
            for (int i = 0; i < 10; i++)
            {
                superList.Add(i);
            }
            int test2 = superList.Capacity;

            Assert.AreNotEqual(test1, test2);
        }
        [TestMethod]
        public void SuperListCopiesDataCorrectly()
        {
            SuperList<int> superList = new SuperList<int>() { 1, 2, 3 };
            for (int i = 0; i < 10; i++)
            {
                superList.Add(5);
            }

            Assert.AreEqual(superList[0] , 1);

        }
        [TestMethod]
        public void SuperListCopiesDataCorrectly2()
        {
            SuperList<int> superList = new SuperList<int>() { 1, 2, 3 };
            for (int i = 0; i < 10; i++)
            {
                superList.Add(5);
            }

            Assert.AreEqual(superList[1], 2);
        }
        [TestMethod]
        public void RemoveAtTest()
        {
            SuperList<int> superList = new SuperList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            superList.RemoveAt(3);
            int test = superList[3];
            int expeted = 5;
            Assert.AreEqual(test, expeted);
        }

        [TestMethod]
        public void SuperlistRemovesOne()
        {
            SuperList<int> superList = new SuperList<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            superList.Remove(9);
            int test = 9;
            Assert.AreNotEqual(superList[0], test);
        }
        [TestMethod]
        public void SuperlistRemoveValueExpected()
        {
            SuperList<int> superList = new SuperList<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            superList.Remove(9);
            int? test = 8;
            Assert.AreEqual(superList[0], test);
        }
        [TestMethod]
        public void SuperlistRemoveAdjustsCount()
        {
            SuperList<int> superList = new SuperList<int>() { 0, 1, 0, 1, 0, 1 };
            int test1 = superList.Count;
            superList.Remove(1);
            int test2 = superList.Count;
            Assert.IsTrue(test1 == test2 + 1);

        }
        [TestMethod] 
        public void SuperListcountdecrementssOnRemove()
        {
            SuperList<int> superList = new SuperList<int>() { 0, 1, 0, 1, 0, 1 };
            int test1 = 3;
            superList.Remove(1);
            superList.Remove(1);
            superList.Remove(1);
            int test2 = superList.Count;
            Assert.AreEqual(test1, test2);
        }
        [TestMethod]
        public void SuperListCleanWorks()
        {
            SuperList<int> superList = new SuperList<int>() { 5, 4, 3, 2, 1 };
            superList.RemoveAt(0);
            superList.RemoveAt(0);
            superList.RemoveAt(0);
            superList.CleanArray();
            int test1 = superList.Capacity;
            Assert.AreEqual(test1, 2);
        }
        [TestMethod]
        public void ContainmentTest()
        {
            SuperList<char> superList = new SuperList<char>() { 'a', 'b', 'c', 'd' };
            int test = superList.Contains('c');
            Assert.AreEqual(test, 2);
        }
        [TestMethod]
        public void MinusOperatorTest1()
        {
            SuperList<char> superList = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e' };
            SuperList<char> superList2 = new SuperList<char>() { 'c', 'a', 'b' };
            SuperList<char> result = superList - superList2;
            SuperList<char> expected = new SuperList<char>() { 'd', 'e' };
            Assert.AreEqual(result[1], expected[1]);
        }
        [TestMethod]
        public void MinusEqualsTest()
        {
            SuperList<char> superList = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e' };
            SuperList<char> superList2 = new SuperList<char>() { 'c', 'a', 'b' };
            superList -= superList2;
            SuperList<char> epected = new SuperList<char>() {'d', 'e' };
            Assert.AreEqual(superList[0], epected[0]);
        }
        [TestMethod]
        public void AddOperatorTest1()
        {
            SuperList<char> superList = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e' };
            SuperList<char> superList2 = new SuperList<char>() { 'c', 'a', 'b', 'd', 'e' };
            SuperList<char> result = superList + superList2;
            SuperList<char> epected = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e', 'c', 'a', 'b', 'd', 'e' };
            Assert.AreEqual(result[1], epected[1]);
        }
        [TestMethod]
        public void AddOperatorTest2()
        {
            SuperList<char> superList = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e' };
            SuperList<char> superList2 = new SuperList<char>() { 'c', 'a', 'b', 'd', 'e' };
            SuperList<char> result = superList + superList2;
            SuperList<char> epected = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e', 'c', 'a', 'b', 'd', 'e' };
            Assert.AreEqual(result[8], epected[8]);
        }
        [TestMethod]
        public void AddEqualsTest()
        {
            SuperList<char> superList = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e' };
            SuperList<char> superList2 = new SuperList<char>() { 'c', 'a', 'b', 'd', 'e' };
            superList += superList2;
            SuperList<char> epected = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e', 'c', 'a', 'b', 'd', 'e' };
            Assert.AreEqual(superList[6], epected[6]);
        }
        [TestMethod]
        public void SuperListStringtest1()
        {
            //i have to figure out how to detect types if I am going to be able to make the numbers format how I like.
            SuperList<int> superlist = new SuperList<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            string result = superlist.ToString();
            string expected = "10, 9, 8, 7, 6, 5, 4, 3, 2, 1";
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void SuperListStringtest2()
        {
            SuperList<char> superlist = new SuperList<char>() { 'i', 't', 's', 'w', 'o', 'r', 'k', 'i', 'n', 'g' };
            string result = superlist.ToString();
            string expected = "itsworking";
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void SuperListStringtest3()
        {
            SuperList<string> superlist = new SuperList<string>() { "it's ", "definitely ", "working!" };
            string result = superlist.ToString();
            string expected = "it's definitely working!";
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void SuperZiptest()
        {
            SuperList<int> superlist = new SuperList<int>() { 1, 3, 5 };
            SuperList<int> superadd = new SuperList<int>() { 2, 4, 6 };
            SuperList<int> superresult = superlist.Zip(superlist, superadd);
            SuperList<int> expected = new SuperList<int>() { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < superresult.Count; i++)
            {
                Assert.AreEqual(superresult[i], expected[i]);
            }
        }
    }
}
