using System;
using System.Collections.Generic;
using System.IO;

namespace Toodet_Viblyy
{
    internal class Kvitung
    {
        private List<string> toodet;
        private List<int> hinnad;
        private int summa;

        public Kvitung(List<string> Toodet, List<int> Hinnad, int Summa)
        {
            toodet = Toodet;
            hinnad = Hinnad;
            summa = 0; // Инициализация суммы

            string kaustatee = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\arved\");
            string failiNime = $"Check_{DateTime.Now:yyyyMMddHHmmss}.txt";
            string failiTee = Path.Combine(kaustatee, failiNime);

            try
            {
                if (!Directory.Exists(kaustatee))
                {
                    Directory.CreateDirectory(kaustatee);
                }

                using (StreamWriter kirjutaja = new StreamWriter(failiTee))
                {
                    kirjutaja.WriteLine("=====================================");
                    kirjutaja.WriteLine("|           Ostutšekk               |");
                    kirjutaja.WriteLine("=====================================");
                    kirjutaja.WriteLine("| Toode        |      Hind       |");
                    kirjutaja.WriteLine("|--------------|-----------------|");
                    for (int i = 0; i < toodet.Count; i++)
                    {
                        kirjutaja.WriteLine($"| {toodet[i],-12} | {hinnad[i],14:f2} |");
                        summa += hinnad[i];
                    }
                    kirjutaja.WriteLine("=====================================");
                    kirjutaja.WriteLine($"|{"Kokku:",-12} | {summa,14:f2} |");
                    kirjutaja.WriteLine("=====================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Tsekk tsekk = new Tsekk("C:\\Users\\Administrator\\source\\repos\\online-shop-windowsform-app\\Toodet_Viblyy\\arved\\" + failiNime, failiNime);
            tsekk.ShowDialog();
        }

    }
}
