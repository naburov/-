using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class TestsForTask1
    {
        [TestMethod]
        public void countLetters1()
        {
            Dictionary<char, int> basic = new Dictionary<char, int>();  //Create cheklist Dictionary
            basic.Add('a', 5);basic.Add('d', 2);                        //Add elements to cheklist dictionary
            basic.Add('f', 5);basic.Add('k', 2);
            basic.Add('g', 1);basic.Add('c', 2);
            Dictionary<char, int> real = Task_1.Program.countLetters("aaaaafffffgccdkdk");
            bool ok = basic.Equals(real);

            Assert.AreEqual(ok, true);
        }

        [TestMethod]
        public void countLetters2()
        {
            Dictionary<char, int> basic = new Dictionary<char, int>();  //Create cheklist Dictionary
            basic.Add('a', 5); 
            Dictionary<char, int> real = Task_1.Program.countLetters("aaaaa");
            bool ok = basic.Equals(real);
            Assert.AreEqual(ok, true);
        }

        [TestMethod]

        public void createPassword1()
        {
            string seq = "ThisIsUnitTest";
            string mask = "00000000000001";
            string pass = Task_1.Program.createPassword(seq, mask);
            Assert.AreEqual("t", pass);
        }
        [TestMethod]
        public void createPassword2()
        {
            string seq = "ThisIsUnitTest";
            string mask ="00000000000111";
            string pass = Task_1.Program.createPassword(seq, mask);
            Assert.AreEqual("tse", pass);
        }
        [TestMethod]
        public void createPassword3()
        {
            string seq = "ThisIsUnitTest";
            string mask = "10000000000000";
            string pass = Task_1.Program.createPassword(seq, mask);
            Assert.AreEqual("T", pass);
        }
        [TestMethod]
        public void createPassword4()
        {
            string seq = "ThisIsUnitTest";
            string mask = "11000000000000";
            string pass = Task_1.Program.createPassword(seq, mask);
            Assert.AreEqual("hT", pass);
        }
        [TestMethod]
        public void createPassword5()
        {
            string seq = "ThisIsUnitTest";
            string mask = "00010110000011";
            string pass = Task_1.Program.createPassword(seq, mask);
            Assert.AreEqual("tsUss", pass);
        }
    }
}
