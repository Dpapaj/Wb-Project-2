using System;
using System.Linq;
using System.Threading;


namespace Projekt
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //V poli používáme funkci pro náhodné vytvoření hodnot a poté dané hdonoty vypíšeme v consoli. 
            int Rozsah= 10;       //Určení kolik hodnot v daném poli budeme mít
            int MinPole= -10;      //Určení minimální hodnoty v daném poli
            int MaxPole = 1000;   //Určení maximální hodnoty v daném poli
            Random rnd = new Random();
            //Využíváme funkce Enumerable.Range a pomocí funkce .OrderBy můžeme randomizovat jejich pořadí
            int[] pole = Enumerable.Range(MinPole, MaxPole).OrderBy(x => rnd.Next()).Take(Rozsah).ToArray();

            //Vytiskneme dané pole do konzole, aby jsme měly věděli jaké čísla v daném poli je. 
            Console.Write("Dané pole má hodnotu : ");
            foreach (int i in pole)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
          
            // Vypsání první a poslední hodnoty v daném poli, pomocí funkce .lenght. 
            int x = pole.Length - 1;
            Console.WriteLine($"První hodnota v poli je {pole[0]} a poslední hodnota v poli je {pole[x]}");

            //Vypsání největší hodnoty pomocí našeho kodu a pomocí vzestavěné funkce
            int Max1 = pole[0];
            //Postupně porovnáváme dané čísla v poli dokud nedostaneme nevjvětsí hodnotu
            for (int i = 0; i < pole.Length; i++)
            {
                int cislo = pole[i];
                if (cislo > Max1)
                {
                    Max1 = cislo;
                }
            }
            int Max = pole.Max();   //Vzestavěná funkce 
            Console.WriteLine($"Naprogramované :Největší hodnota v poli je {Max1} // Vzestavěné funkce :Největší hodnota v poli je {Max}");

            //Vypsání nejmenší hodnoty pomocí našeho kodu a pomocí vzestavěné funkce
            int Min1 = pole[0];
            //Postupně porovnáváme dané čísla v poli dokud nedostaneme nejmenší hodnotu
            for (int i = 0; i < pole.Length; i++)
            {
                int cislo1 = pole[i];
                if (cislo1 < Min1)
                {
                    Min1 = cislo1;
                }
            }
            int Min = pole.Min();   //Vzestavěná funkce 
            Console.WriteLine($"Naprogramované :Nejmenší hodnota v poli je {Min1} // Vzestavěné funkce :Nejmenší hodnota v poli je {Min}");

            //Vypsání průměru hodnot pomocí našeho kodu a pomocí vzestavěné funkce
            int sum = 0;
            //Vypočítáme sumu všech čísel v poli.A vlastnosti ve funkci .Lenght v poli vrací délku pole.
            for (int i = 0; i < pole.Length; i++)
            {
                sum += pole[i];
            }
            //Najdeme průměrnou hodnotu a protože průměr může být v desetinných čísel. Pak tedy dáme danou proměnnou do typu float a získáme průměr a daný výstup "vytiskneme" 
            float Avg1 = (float)sum / pole.Length;

            double Avg = pole.Average();   //Vzestavěná funkce 
            Console.WriteLine($"Naprogramované :Průměrná hodnota v poli je {Avg1} // Vzestavěné funkce :Průměrná hodnota v poli je {Avg}");

            // Vypsání sumy hodnot pomocí našeho kodu a pomocí vzestavěné funkce
            int suma1 = 0;
            //Vyvoláváme postupně čísla z pole a poté postupně dané čísla sčítáme 
            for (int a = 0; a < pole.Length; a++)
            {
                int prvek = pole[a];
                suma1 += prvek;
            }
            int suma = pole.Sum();   //Vzestavěná funkce 
            Console.WriteLine($"Naprogramované :Suma prvku v poli je {suma1} // Vzestavěné funkce :Suma hodnota v poli je {suma}");

            //Medián
            //Napřeď musíme seřaďit dané pole a vezme prostřední číslo/čísla, poté vynásobíme dané hodnoty dvěma.
            //Pro c# jsem nemohl najít žádnou knihvní funkci pro vypočítání mediánu.
            int[] pole2 = pole;  //uděláme kopii daného pole z důvodu problému, které se ukazovaly když byl použit pole(dalsší funkce pro výpočet poté dotávaly pole s žádnými hodnotami).
            int pocet = pole2.Length;
            Array.Sort(pole2); //seřazení pole
            decimal Median1 = 0;

            if (pocet % 2 == 0)
            {
                // Počet je sudý, potřebujeme dvě prostřední čísla.Poté je přidáme k sobě a vydělíme číslem 2.
                int ProstredniCislo1 = pole2[(pocet / 2) - 1];
                int ProstredniCislo2 = pole2[(pocet / 2)];
                Median1 = (ProstredniCislo1 + ProstredniCislo2) / 2;
            }
            else
            {
                // Počet je lichý, musíme vzít jenom jeden prostřední číslo.
                Median1 = pole2[(pocet / 2)];
            }
            
            Console.WriteLine($"Naprogramované :Medián prvku v poli je {Median1}");

            //Rozptyl
            //Rozptyl vypočítáme součtem rozdílů od průměru poděleno počtem prvků
            //Vypočítáme průměr čísel v poli, které pak využijeme v funkci pro vypočítání rozptylu 
            double sum2 = 0;
            int n = pole.Length;
            float Rozptyl1;
            for (int i = 0; i < n; i++)
                sum2 += pole[i];

            double mn = (double)sum2 /
                          (double)n;

            // Vypočítání součtu na druhou s rozdílným průměrem.  
            double sqDiff = 0;

            for (int i = 0; i < n; i++)
                sqDiff += (pole[i] - mn) *
                          (pole[i] - mn);

            Rozptyl1= (float)sqDiff / n;
            //---------------------------------------------------------------------------
            
            double Rozptyl = 0.0;
            foreach (int value in pole)
            {
                Rozptyl += Math.Pow(value - Avg, 2.0);// Využití funkci pro výpočet průměru 
            }
             
            Console.WriteLine($"Naprogramované :Rozptyl prvku v poli je {Rozptyl}// Vzestavěné funkce :Rozptyl hodnota v poli je {Rozptyl}");

            //Směrodatnou odchylku
            //Zjistíme průměr čísel z pole.U každého čísla oděčteme průměr a výsledek umocníme na druhou.Vypočítáme průměr čtvr. rozdílu.Vezmeme druhou odmocninu průměru rozdílu.
            double s = 0, m, sd = 0;

            for (int i = 0; i < pole.Length; ++i)
            {
                s += pole[i];
            }

            m = s / pole.Length;

            for (int i = 0; i < pole.Length; ++i)
                sd += Math.Pow(pole[i] - m, 2);

            double SmOd1 =  Math.Sqrt(sd / pole.Length);


            double SmOd = Math.Sqrt(pole.Average(z => z * z) - Math.Pow(pole.Average(), 2));   //Kod s využitím vzestavěných funkcí 
            Console.WriteLine($"Naprogramované :Směrodatná odchylka v poli je {SmOd1} // Vzestavěné funkce :Směrodatná odchylka v poli je {SmOd}");
        }
    }

}

