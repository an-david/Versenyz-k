using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Versenyzők
{
    class Program
    {
        static void Main(string[] args)
        {
            // Itt van eltárolva a pilotak.csv fájl tartalma.
            string[] pilotak = File.ReadAllLines("pilotak.csv");
            List<Versenyzők> versenyzok = new List<Versenyzők>();

            for (int i = 1; i < pilotak.Length; i++)
            {
                string[] jelenlegi_sor = pilotak[i].Split(';');

                Versenyzők uj_versenyzo = new Versenyzők(jelenlegi_sor[0], jelenlegi_sor[1], jelenlegi_sor[2], jelenlegi_sor[3]);
                versenyzok.Add(uj_versenyzo);
            }

            // 3 Feladat.
            Console.WriteLine("3. Feladat: " + (pilotak.Length - 1));

            // 4. Feladat.
            Console.WriteLine("4. Feladat: " + pilotak[pilotak.Length - 1].Substring(0, pilotak[pilotak.Length - 1].IndexOf(";")));

            // 5. Feladat.
            Console.WriteLine("5. Feladat:");
            for (int i = 1; i < pilotak.Length; i++)
            {
                string ev = pilotak[i].Substring(pilotak[i].IndexOf(";") + 1, 10);
                if (Convert.ToInt32(ev.Substring(0, 4)) <= 1901)
                {
                    Console.WriteLine("\t" + versenyzok[i].Nev + " (" + versenyzok[i].Szul + ")");
                }
            }

            // 6. Feladat.
            int l_rajtszam = 100;
            int l_rajtszam_index = 0;
            for (int i = 1; i < versenyzok.Count; i++)
            {
                if (!versenyzok[i].Rajtszam.Equals(""))
                {
                    if (Convert.ToInt32(versenyzok[i].Rajtszam) < l_rajtszam)
                    {
                        l_rajtszam = Convert.ToInt32(versenyzok[i].Rajtszam);
                        l_rajtszam_index = i;
                    }
                }
            }
            Console.WriteLine("6. Feladat: " + versenyzok[l_rajtszam_index].Nemzetiseg);

            // 7. Feladat.
            HashSet<int> egyedi_rajtszamok = new HashSet<int>();
            for (int i = 1; i < versenyzok.Count; i++)
            {
                if (!versenyzok[i].Rajtszam.Equals(""))
                {
                    egyedi_rajtszamok.Add(Convert.ToInt32(versenyzok[i].Rajtszam));
                }
            }


            int rajtszam_db = 0;
            List<int> tobbet_megkapott_rajtszamok = new List<int>();
            foreach (var rajtszam in egyedi_rajtszamok)
            {
                for (int j = 1; j < versenyzok.Count; j++)
                {
                   if (!versenyzok[j].Rajtszam.Equals(""))
                    {
                        if (rajtszam == Convert.ToInt32(versenyzok[j].Rajtszam))
                        {
                            rajtszam_db++;
                        }
                    }
                }
                if (rajtszam_db > 1)
                {
                    tobbet_megkapott_rajtszamok.Add(rajtszam);
                }
                rajtszam_db = 0;
            }

            Console.Write("7. Feladat: ");
            for (int i = 0; i < tobbet_megkapott_rajtszamok.Count; i++)
            {
                Console.Write(tobbet_megkapott_rajtszamok[i]);
                if (i + 1 < tobbet_megkapott_rajtszamok.Count)
                {
                    Console.Write(", ");
                }
            }

            Console.ReadKey();
        }
    }
}
