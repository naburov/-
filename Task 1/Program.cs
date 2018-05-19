using System;
using System.Collections.Generic;
using System.IO;

namespace Task_1
{
    //Protected password
    public class Program
    {
        //This method counts the number of every letter in the sequence
        public static Dictionary<char,int> countLetters(string s)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();  //key - letter from initial sequence,
                                                                          //value - how many times this letter appears in the seq
            foreach(char letter in s)
            {
                if (letters.ContainsKey(letter)) { letters[letter]++; }   //if the letter already exist, increase number of times
                else letters.Add(letter, 1);                              //if it isn't, create new pair
            }
            return letters;
        }

        //This method checks the criteria of max number of reapiting letters
        public static bool isGoodPassword(Dictionary<char, int> letters, int limit)
        {
            bool ok = true;
            foreach(var pair in letters)
            {
                if (pair.Value > limit) { ok = false; break; }
            }
            return ok;
        }

        public static string createPassword(string seq, string mask)
        {
            char[] maskArr = mask.ToCharArray();
            Array.Reverse(maskArr);

            char[] seqArr = seq.ToCharArray();
            Array.Reverse(seqArr);

            mask = new string(maskArr);
            seq = new string(seqArr);

            string pass = null;
            for (int i = 0; i<mask.Length; i++)
            {
                if (mask[i] == '1')
                    if (pass != null) pass = String.Concat(pass, seq[i]);
                    else pass = seq[i].ToString();                       
            }
            return pass;
        }

        static string Input(out int length, out int k)
        {
            //FileStream f = new FileStream("input.txt",FileMode.Open);
            StreamReader sr = new StreamReader("input.txt");
            string[] str = sr.ReadToEnd().Replace("\r\n", " ").Split(' ');
            length = int.Parse(str[0]); k = int.Parse(str[1]);
            sr.Dispose();
            return str[2];
        }

        static void Output(int number)
        {
            StreamWriter sw = new StreamWriter("output.txt");
            sw.WriteLine(number);
            sw.Dispose();
        }

        static void Main(string[] args)
        {
            //int length, k;
            //string seq;
            int count = 0;                                //how many passwords are good
            //length = 4; k = 1; seq = "ayay";              //input data
            string seq = Input(out int length, out int k);
            for (int i = 1; i <= seq.Length; i++)         //from 1 to the length of sequence
            {
                int beg = 0;                              //start index
                do
                {
                    string pass = seq.Substring(beg, i);  //eject substrings with nessesetive length
                    Dictionary<char, int> letters = countLetters(pass);
                    if (isGoodPassword(letters, k)) { count++; Console.WriteLine(pass); }
                    beg++;
                } while (i + beg - 1< seq.Length);    //the cycle executes, while total of i and beg not equal to the last index in sequence
            }
            Output(count);

        }
    }
}
