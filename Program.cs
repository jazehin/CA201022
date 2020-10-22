using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace CA201022
{
    class Program
    {
        static Random rnd = new Random();
        static string ki = "Üdvözlet a győzőnek!";
        static void Main()
        {
            
            //tömbök feltöltése
            int[] a = new int[100]; TombFeltolt(a, 30);
            int[] b = new int[500]; TombFeltolt(a, 1234);
            int[] c = new int[2020]; TombFeltolt(a, 1022);

            //permutáció
            int[] d = new int[10]; PermutacioN(d, d.Length);
            int[] e = new int[4321]; PermutacioN(e, e.Length);

            //téglalapok
            
            Teglalap(78, 23, ConsoleColor.Red);
            Teglalap(74, 19, ConsoleColor.Blue);
            Teglalap(70, 15, ConsoleColor.Green);
            Teglalap(66, 11, ConsoleColor.Cyan);
            Teglalap(62, 7, ConsoleColor.DarkMagenta);
            Teglalap(58, 3, ConsoleColor.DarkYellow);

            Console.ReadKey();
            Console.Clear();

            //osztók
            Console.Write("Adjon meg egy egész számot: ");
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> osztok = Osztok(n);
            foreach (int elem in osztok)
            {
                Console.Write($"{elem} ");
            }
            Console.WriteLine($"\nEnnek a számnak {OsztokSzama(n)} db osztója van");

            //prímszámok
            if (PrimSzam(n)) Console.WriteLine($"{n} prímszám");
            else Console.WriteLine($"{n} nem prímszám");
            if (PrimSzam(29)) Console.WriteLine("29 prímszám");
            else Console.WriteLine($"29 nem prímszám");

            Console.ReadKey();
            Console.Clear();

            //prímkeresés
            for (int i = 2; i < 6; i++)
            {
                Console.WriteLine($"Az első 1-re végződő {i}-jegyű prímszám a(z) {PrimKeres(i)}");
            }

            Console.ReadKey();
            Console.Clear();

            //lnko
            Console.WriteLine($"A(z) 100 és a(z) 150 legnagyobb közös osztója a(z) {KozosOszto(100, 150)}.");
            Console.WriteLine($"A(z) 200 és a(z) 340 legnagyobb közös osztója a(z) {KozosOszto(200, 340)}.");
            Console.WriteLine($"A(z) 1000 és a(z) 1368 legnagyobb közös osztója a(z) {KozosOszto(1000, 1368)}.");

            Console.ReadKey();
            Console.Clear();

            //megszámlálás
            int[] f = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };
            Console.WriteLine($"A tömbben található {Megszamlalas(f, 1)} db 1-es");
            Console.WriteLine($"A tömbben található {Megszamlalas(f, 2)} db 2-es");
            Console.WriteLine($"A tömbben található {Megszamlalas(f, 3)} db 3-as");
            Console.WriteLine($"A tömbben található {Megszamlalas(f, 4)} db 4-es");
            Console.WriteLine($"A tömbben található {Megszamlalas(f, 8)} db 8-as");

            Console.ReadKey();
            Console.Clear();

            //megegyezik
            Console.WriteLine($"A(z) él és a(z) élet szavakban {Megegyezes("él", "élet")} db betű egyezik meg.");
            Console.WriteLine($"A(z) vágy és a(z) ágy szavakban {Megegyezes("vágy", "ágy")} db betű egyezik meg.");
            Console.WriteLine($"A(z) álmatlanság és a(z) bizalmatlanság szavakban {Megegyezes("álmatlanság", "bizalmatlanság")} db betű egyezik meg.");

            Console.ReadKey();
            Console.Clear();
            
            //hány százaléka telt el az évnek?
            DateTime time = DateTime.Now;
            Console.WriteLine($"Ennek az évnek eddig eltelt a(z) {Eltelt(time.Year, time.Month, time.Day, time.Hour, time.Minute)}%-a");
            Console.WriteLine($"1999. Május 23-án, 13:26-kor az év {Eltelt(1999, 5, 23, 13, 26)}%-a telt el");

            Console.ReadKey();
            Console.Clear();
            
            //hangrend
            Hangrend("autó");
            Hangrend("teniszütő");
            Hangrend("ez az utolsó előtti feladat :)");
            

            Console.ReadKey();
        }

        static int[] TombFeltolt(int[] tomb, int max)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(max);
            }
            return tomb;
        }

        static int[] PermutacioN(int[] tomb, int n)
        {
            List<int> volt = new List<int>();
            for (int i = 0; i < tomb.Length; i++)
            {
                int elem;
                do
                {
                    elem = rnd.Next(0, n);
                } while (volt.Contains(elem));
                tomb[i] = elem;
                volt.Add(elem);
            }
            return tomb;
        }

        static void Teglalap(int hossz, int magassag, ConsoleColor szin = ConsoleColor.Gray)
        {
            Console.ForegroundColor = szin;

            int x = Console.CursorLeft;
            int startX = x;
            int y = Console.CursorTop;
            int startY = y;

            for (int i = 0; i < hossz; i++)
            {
                x = i;
                Console.SetCursorPosition(x, y);
                Console.Write('*');
                Thread.Sleep(25);
            }
            for (int i = y; i < startY + magassag; i++)
            {
                y = i;
                Console.SetCursorPosition(x, y);
                Console.Write('*');
                Thread.Sleep(25);
            }
            for (int i = x; i >= startX; i--)
            {
                x = i;
                Console.SetCursorPosition(x, y);
                Console.Write('*');
                Thread.Sleep(25);
            }
            for (int i = y; i >= startY; i--)
            {
                y = i;
                Console.SetCursorPosition(x, y);
                Console.Write('*');
                Thread.Sleep(25);
            }

            Console.SetCursorPosition(startX + hossz / 2 - ki.Length / 2, startY + magassag / 2);
            Console.Write(ki);

            Console.ResetColor();
            Console.SetCursorPosition(startX, startY + magassag + 1);
        }

        static List<int> Osztok(int n)
        {
            List<int> osztok = new List<int>();
            osztok.Add(1);
            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0) osztok.Add(i);
            }
            return osztok;
        }

        static int OsztokSzama(int n)
        {
            return Osztok(n).Count;
        }

        static bool PrimSzam(int n)
        {
            return Osztok(n).Count == 2;
            
        }

        static int PrimKeres(int n)
        {
            string min = "1";
            string max = "9";
            for (int i = 1; i < n; i++)
            {
                min += "0";
                max += "9";
            }
            int index = Convert.ToInt32(min);
            int maxSzam = Convert.ToInt32(max);
            do
            {
                index++;
            } while (index <= maxSzam && !PrimSzam(index) && !(index % 10 == 1));
            return index;
        }

        static int KozosOszto(int a, int b)
        {
            int lnko = 1;
            int kisebb = a < b ? a : b;
            for (int i = 1; i < kisebb; i++)
            {
                if (a % i == 0 && b % i == 0) lnko = i;
            }
            return lnko;
        }

        static int Megszamlalas(int[] tomb, int elem)
        {
            int c = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] == elem) c++;
            }
            return c;
        }

        static int Megegyezes(string a, string b)
        {
            int c = 0;
            int rovidebb = a.Length < b.Length ? a.Length : b.Length;
            for (int i = 0; i < rovidebb; i++)
            {
                if (a[i] == b[i]) c++;
            }
            return c;
        }

        static double Eltelt(int ev, int honap, int nap, int ora, int perc)
        {
            double szazalek = 0;
            szazalek += (double)honap / 12 * 100;
            szazalek += ((double)nap-1) / DateTime.DaysInMonth(ev, honap) * 100 / 12;
            szazalek += (double)ora / 24 * 100 / 12 / DateTime.DaysInMonth(ev, honap);
            szazalek += (double)perc / 60 * 100 / 12 / DateTime.DaysInMonth(ev, honap) / 24;
            return szazalek;
        }

        static void Hangrend(string a)
        {
            a = a.ToLower();
            bool magas = false, mely = false;

            //magas teniszütő, mély autó
            if (a.Contains("e") || a.Contains("é") || a.Contains("i") || a.Contains("í") || a.Contains("ü") || a.Contains("ű") || a.Contains("ö") || a.Contains("ő")) magas = true;
            if (a.Contains("a") || a.Contains("á") || a.Contains("u") || a.Contains("ú") || a.Contains("o") || a.Contains("ó")) mely = true;

            if (magas && mely) Console.WriteLine($"\"{a}\" : vegyes hangrendű");
            else if (magas) Console.WriteLine($"\"{a}\" : magas hangrendű");
            else Console.WriteLine($"\"{a}\" : mély hangrendű");
        }
    }
}
