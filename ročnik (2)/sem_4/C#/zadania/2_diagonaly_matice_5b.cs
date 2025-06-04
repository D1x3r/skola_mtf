using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_2
{
    class Matica
    {
        private int n;
        private int[,] m;
        private int[,] m_90;

        public void Nacitaj_rnd()
        {
            System.Console.WriteLine("Zadaj velkost matice štvrocovej 1-10: ");
            //ošetrenie spravneho vstupu
            do
            {
                n = int.Parse(System.Console.ReadLine());
                if (n < 1 || n >= 10)
                {
                    System.Console.WriteLine("Zadaj velkost matice štvrocovej 1-10: ");
                }
            } while (n < 1 || n >= 10);

            
            m = new int[n, n];

            Random rnd = new Random();


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = rnd.Next(100);
                }
            }
        }

        public void Map()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    if(this.m[i, j] < 10)
                    {
                        Console.Write(this.m[i, j] + "  ");
                    }
                    else
                    {
                        Console.Write(this.m[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Nacitaj()
        {
            System.Console.WriteLine("Zadaj velkost matice štvrocovej: ");
            n = int.Parse(System.Console.ReadLine());

            m = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    System.Console.WriteLine("Zadaj čisla matice: ");
                    m[i,j] = int.Parse((string)System.Console.ReadLine());
                }
            }
        }

        private int Sucet_hl_dg(int[,] mati)
        {
            int sucet_hl = 0;
            for (int i = 0; i < this.n; i++)
            {
                sucet_hl += mati[i,i];
            }
            return sucet_hl;
        }

        private int Sucet_vl_dg(int[,] mati)
        {
            int sucet_vl = 0;
            int j = this.n;
            for(int i = 0;i < this.n; i++)
            {
                j--;
                sucet_vl += mati[i,j];
            }
            return sucet_vl;
        }

        private void porovnaj(int[,] mati)
        {
            if (Sucet_hl_dg(mati) > Sucet_vl_dg(mati))
            {
                Console.WriteLine("Sucet hlavnej diagonaly je: {0} a je vačši ako sučet vedlajšej diagonaly: {1}.", Sucet_hl_dg(mati), Sucet_vl_dg(mati));
            }

            if (Sucet_hl_dg(mati) < Sucet_vl_dg(mati))
            {
                Console.WriteLine("Sucet vedlajšej diagonaly je: {0} a je vačši ako sučet hlavnej diagonaly: {1}.", Sucet_vl_dg(mati), Sucet_hl_dg(mati));
            }

            if (Sucet_hl_dg(mati) == Sucet_vl_dg(mati))
            {
                Console.WriteLine("Sucet hlavnej: {0} aj vedlajšej: {1} diagonaly je rovnaky.", Sucet_hl_dg(mati), Sucet_vl_dg(mati));
            }
        }
        public void Vypis()
        {
            this.Map();
            porovnaj(this.m);
            this.Otoc_maticu();
            this.Map();
            porovnaj(this.m);


        }

        private void Otoc_maticu() {
            m_90 = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m_90[j, n - 1 - i] = m[i, j];
                }
            }
            m = m_90;

        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Matica matica = new Matica();

            matica.Nacitaj_rnd();
            matica.Vypis();


            

        }
    }
}
