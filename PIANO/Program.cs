using System.Linq;
using System.IO;
using System.Runtime.Serialization;


namespace PIANO
{
    internal class Program
    {
        public static int nasobic;
        public static int trvani;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Piano v1.1.0");
                Console.WriteLine("* [Multiply] -> nastavení");
                string cteni = Convert.ToString(Console.ReadKey(true).Key);

                ConfigTest();
                Načítání();

                Čtení(cteni);
                Config(cteni);
            }
        }

        public static void ConfigTest()
        {
            if (!File.Exists("Config.txt"))
            {
                Zápis(500, 200);
            }
        }

        public static void Config(string klávesa)
        {
            Console.Clear();
            if (klávesa == "Multiply")
            {
                Console.WriteLine($"Zadej násobič frekvence");
                Console.WriteLine("Aktualně: " + nasobic);
                Console.WriteLine("Min: 37 ; Max: 1258 ");

                int test;
                string vstup = Console.ReadLine();

                if (int.TryParse(vstup, out test))
                {
                    int zadano = Convert.ToInt32(vstup);

                    if (zadano >= 37 && zadano <= 1258)
                    {
                        Zápis(zadano, trvani);
                        Načítání();
                        Console.Clear();
                    }
                    else
                    {
                        Config("Multiply");
                    }
                }
                else
                {
                    Config("Multiply");
                }
            }
        }

        public static void Načítání()
        {
            using (StreamReader sr = new StreamReader("Config.txt"))
            {
                nasobic = Convert.ToInt32(sr.ReadLine());
                trvani = Convert.ToInt32(sr.ReadLine());
            }

            if (nasobic <= 36 || nasobic >= 1259)
            {
                nasobic = 500;
            }

            if (trvani <= 0)
            {
                trvani = 200;
            }
        }


        public static void Čtení(string klávesa)
        {
            string[] pole = { "Q", "W", "E", "R", "T", "Z", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Y", "X", "C", "V", "B", "N", "M" };
            int frekvence = 0;
            int index = -1;

            if (pole.Contains(klávesa))
            {
                do
                {
                    index++;
                    frekvence++;
                } while (klávesa != pole[index]);
                Console.Beep(frekvence * nasobic, trvani);
            }

        }
        public static void Zápis(int frek, int delka)
        {
            using (StreamWriter sw = new StreamWriter("Config.txt"))
            {
                sw.WriteLine(frek);
                sw.WriteLine(delka);
                sw.WriteLine("def: 500 ; 200");
                sw.Flush();
            }
        }
    }
}