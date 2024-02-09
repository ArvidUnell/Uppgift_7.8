using System;
using System.Collections.Generic;
namespace Uppgift_7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hur många koder vill du skriva in?");
            int kodTal = ReadInt();


            Dictionary<char,char> kodNyckel = new Dictionary<char,char>();

            for (int i = 0; i < kodTal; i++) //Sparar alla nycklar i dictionaryn
            {
                while (true)
                {
                    string[] dennaNyckel = Console.ReadLine().Split(' ');
                    if (dennaNyckel.Length != 2 || dennaNyckel[0].Length != 1 || dennaNyckel[1].Length != 1)
                    {
                        Console.WriteLine("Ogiltigt svar. Försök igen");
                    }
                    else
                    {
                        kodNyckel[dennaNyckel[0][0]] = dennaNyckel[1][0]; //Sparar nyckeln i dictionaryn
                        break;
                    }
                }
            }


            Console.WriteLine("Skriv in ditt hemliga meddelande");
            char[] meddelande = Console.ReadLine().ToCharArray();

            bool klar = false;
            while (!klar)
            {
                klar = true;
                for (int i = 0;i < meddelande.Length;i++)
                {
                    if (kodNyckel.ContainsKey(meddelande[i]))
                    {
                        meddelande[i] = kodNyckel[meddelande[i]];
                        klar = false;
                    }
                }
            }


            Console.WriteLine("Här är ditt avkodade meddelande:");
            foreach (char c in meddelande)
            {
                Console.Write(c);
            }


            Console.WriteLine("\n\nTryck på valfri knapp för att avsluta");
            Console.ReadKey();
        }
        /// <summary>
        /// Läser in ett int-tal från användaren
        /// </summary>
        /// <returns>Talet användaren skrev</returns>
        static int ReadInt()
        {
            int tal;
            while (!int.TryParse(Console.ReadLine(), out tal))
            {
                Console.WriteLine("Ogiltigt svar. Försök igen");
            }
            return tal;
        }
    }
}