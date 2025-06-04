using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace zadanie_1
{
    class Keno
    {
        //maximalne 10 tipov a 20 vylosovanych cisel možme jednoducho meniť rozsah
        private const int MAX_TIP = 10;
        private const int MAX_LOS = 20;

        //max RAND rozsah 1-MAX_RAND
        private const int MAX_RAND = 80;


        private int[] vylosovane = new int[MAX_LOS];
        private int[] tipovane = new int[MAX_TIP];
        private int n;

        public void Debug()
        {
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.Write(vylosovane[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(tipovane[i] + " ");
            }
            Console.WriteLine();
        }

        public void Map()
        {
            for (int i = 1; i <= MAX_RAND; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
                if (vylosovane.Contains(i) && tipovane.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write((i) + " ");
                    Console.ResetColor();
                }
                else if (vylosovane.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write((i) + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write((i) + " ");
                }
            }


        }
        private int VygenerujCislo()
        {
            Random rnd = new Random();
            return rnd.Next(1, MAX_RAND + 1);
        }
        public int[] Losovanie()
        {
            for (int i = 0; i < MAX_LOS; i++)
            {
                int num;
                //ak vygeneruje cislo a ked už bolo tak neh vygeneruje nove
                do
                {
                    num = VygenerujCislo();
                } while (vylosovane.Contains(num));

                vylosovane[i] = num;
            }
            return vylosovane;
        }

        public int[] NacitajTipy()
        {

            Console.WriteLine("\nKolko chces hadat cisel 1-10: ");
            this.n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num;
                Console.Write("Zadajte {0}. cislo: ", i + 1);

                num = int.Parse(Console.ReadLine());
                if (num < 1 || num >= 80)
                {
                    Console.WriteLine("Zadali ste nespravne cislo, zadajte znova.");
                    i--;

                }
                else if (tipovane.Contains(num))
                {
                    Console.WriteLine("Toto cislo uz bolo zadane, zadajte znova.");
                    i--;
                }
                else
                {
                    tipovane[i] = num;
                }

            }
            return tipovane;
        }

        public void Porovnanie()
        {
            int pocet = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (tipovane[i] == vylosovane[j])
                    {
                        pocet++;
                    }
                }
            }
            if (pocet == 1) Console.WriteLine("Uhadli ste {0} číslo.", pocet);
            else if (pocet >= 2 && pocet <= 4) Console.WriteLine("Uhadli ste {0} čisla.", pocet);
            else Console.WriteLine("Uhádli ste {0} čísel.", pocet);
        }

        public int GetCursor()
        {
            return Console.CursorTop;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int cursor;

            Keno keno = new Keno();
            keno.Map();

            keno.Losovanie();

            keno.NacitajTipy();

            keno.Porovnanie();
            cursor = keno.GetCursor();

            Console.SetCursorPosition(0,0);
            keno.Map();
            Console.SetCursorPosition(0, cursor);

            Console.ReadKey();
        }
    }
}
