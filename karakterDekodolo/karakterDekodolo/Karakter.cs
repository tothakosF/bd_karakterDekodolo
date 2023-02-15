using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karakterDekodolo
{
    internal class Karakter
    {
        public string kar;
        public string matrix;

        public Karakter(string kar, string matrix)
        {
            this.kar = kar;
            this.matrix = matrix;
        }

        public static void Kiir(Karakter adott)
        {
            int j = 0;
            foreach (var item in adott.matrix)
            {
                if (item == '1')
                {
                    Console.Write('X');
                }
                else 
                {
                    Console.Write(' ');
                }
                j++;
                if (j%4 == 0)
                {
                    Console.WriteLine();
                }

            }
        }

        public static bool Felismer(Karakter kod, Karakter kodolando)
        {
            bool ismer = false;
            if (kod.matrix == kodolando.matrix)
            {
                ismer = true;
            }
            return ismer;
        }
    }
}
