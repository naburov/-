using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        //Write bool functions in lexic-graphical order
        static void Main(string[] args)
        {
            for (int i = 0; i < 64; i++)
            {
                char [] vector = new char[8];             //bool's function vector
                string doubleI = Convert.ToString(i, 2);  
                int nullNumber = 8 - doubleI.Length;

                for (int j = 0; j < nullNumber; j++)
                    vector[j] = '0';

                int index = 0;
                for (int j = nullNumber; j < vector.Length; j++)
                    vector[j] = doubleI[index++];


                bool ok = false;
                for (int j = 0; j < 4 && !ok; j++)
                {
                    if (vector[j] == vector[7 - j])
                    {
                        ok = true;
                        Console.WriteLine(vector);
                    }
                }                
            }

            Console.ReadKey();

        }
    }
}
