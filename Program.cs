using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
    }
}
