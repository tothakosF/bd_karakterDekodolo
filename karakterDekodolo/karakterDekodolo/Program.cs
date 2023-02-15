using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karakterDekodolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] beolvas = File.ReadAllLines("bank.txt");
            string kar;
            string matrix = "";
            List<Karakter> adatok = new List<Karakter>();
            for (int i = 0; i < beolvas.Length; i+=8)
            {
                kar = beolvas[i];
                for (int j = 1; j < 8; j++)
                {
                    matrix += beolvas[i + j];
                }
                adatok.Add(new Karakter(kar, matrix));
                matrix = "";
            }

            Console.WriteLine($"5. feladat: Karakterek száma: {adatok.Count}");

            List<string> abc = new List<string>();
            for (char i = 'A'; i != 'Z'; i++)
            {
                abc.Add(i.ToString());
            }

            string input;
            do
            {
                Console.Write("6. feladat: Kérek egy angol nagybetűt: ");
                input = Console.ReadLine();
            } while (!abc.Contains(input));


            Console.WriteLine("7. feladat:");


            bool exists = false;
            foreach (var i in adatok)
            {
                if (i.kar == input)
                {
                    Karakter.Kiir(i);
                    exists = true;
                }
            }
            if (!exists)
            {
                Console.WriteLine("Nincs ilyen karakter a bankban!");
            }

            string[] ujbeolvas = File.ReadAllLines("dekodol.txt");
            List<Karakter> ujadatok = new List<Karakter>();
            for (int i = 0; i < ujbeolvas.Length; i += 8)
            {
                kar = ujbeolvas[i];
                for (int j = 1; j < 8; j++)
                {
                    matrix += ujbeolvas[i + j];
                }
                ujadatok.Add(new Karakter(kar, matrix));
                matrix = "";
            }

            string titok = "";
            for (int i = 0; i < ujadatok.Count; i++)
            {
                bool ismert = false;
                for (int j = 0; j < adatok.Count; j++)
                {
                    if (Karakter.Felismer(adatok[j], ujadatok[i]))
                    {
                        ismert = true;
                        titok += adatok[j].kar;
                    }
                }
                if (!ismert)
                {
                    titok += "?";
                }
            }
            Console.WriteLine("9. feladat: Dekódolás");
            Console.WriteLine(titok);

            Console.ReadLine();
        }
    }
}
