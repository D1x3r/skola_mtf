using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            //na slovensky font resp čiarky v hodnotach
            var skCulture = new CultureInfo("sk-SK");

            //string filePath = "C:\\Users\\ahreh\\source\\repos\\zadanie3\\zadanie3\\vstupny.txt";

            // Získanie aktuálneho adresára aplikácie
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Relatívne cesty k vstupnému a výstupnému súboru
            string inputFilePath = Path.Combine(baseDirectory, "vstupny.txt");
            string outputFilePath = Path.Combine(baseDirectory, "vystupny.txt");

            try
            {
                string[] lines = File.ReadAllLines(inputFilePath);

                string vystupText = "";

                foreach (string line in lines)
                {
                    string[] cast = line.Split(' ');

                    int dlzka = cast.Length;

                    string datum = cast[0];
                    string cas = cast[1];

                    double[] hodnoty = new double[dlzka - 2];

                    for (int i = 2; i < dlzka; i++)
                    {
                        hodnoty[i - 2] = double.Parse(cast[i], skCulture);
                    }

                    int pocetHodnot = dlzka - 2;

                    double priemer = 0;
                    for (int i = 0; i < pocetHodnot; i++)
                    {
                        priemer += hodnoty[i];
                    }
                    priemer /= pocetHodnot;

                    Console.WriteLine($"{datum} {cas} \t {pocetHodnot} \t {priemer.ToString("F2", skCulture)}");
                    //File.AppendAllText("C:\\Users\\ahreh\\source\\repos\\zadanie3\\zadanie3\\vystupny.txt", $"{datum} {cas} \t {pocetHodnot} \t {priemer.ToString("F2", skCulture)}\n");

                    vystupText += $"{datum} {cas} \t {pocetHodnot} \t {priemer.ToString("F2", skCulture)}\n";



                }
                File.WriteAllText(outputFilePath, vystupText);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Súbor nebol nájdený: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Chyba formátu: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nastala chyba: " + ex.Message);

            }
        }
    }
}
