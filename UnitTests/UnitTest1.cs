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
        public static int Passwords(string seq, int length, int k)
        {
            int count = 0;
            List<char> lettres = new List<char>();
            for (int i = 0; i < length; i++)
                if (!lettres.Contains(seq[i])) lettres.Add(seq[i]);

            int letCount = lettres.Count;
            int[,] matrix = new int[letCount, length];

            for (int i = 0; i < letCount; i++)
            {
                count = 0;
                for (int j = 0; j < length; j++)
                    if (seq[j] == lettres[i])
                        matrix[i, j] = ++count;
                    else matrix[i, j] = count;
            }
            count = length;

            for (int i = 2; i <= k; i++)
                count += length - i + 1;

            for (int i = 0; i < length - k; i++)
            {
                bool ok = true;
                for (int j = i + k; j < length && ok; j++)
                {

                    for (int l = 0; l < letCount; l++)
                        if (matrix[l, j] > k) ok = false;
                    if (ok) count++;
                }

                for (int l = 0; l < letCount; l++)
                    if (matrix[l, i] != 0)
                        for (int x = i + 1; x < length; x++)
                        {
                            matrix[l, x]--;
                        }
            }
            return count;
        }

        [TestMethod]
        public void checkCount1()
        {
            string seq = "ayay";
            int length = 4; int k = 1;
            Assert.AreEqual(Passwords(seq, length, k), 7);
        }

        [TestMethod]
        public void checkCount2()
        {
            Assert.AreEqual(Passwords("7aaarr", 6,2 ), 15);
        }

        public void checkCount3()
        {
            Assert.AreEqual(Passwords("", 6, 2), 15);
        }

    }
}
