using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versenyzők
{
    class Versenyzők
    {
        string nev;
        string szul;
        string nemzetiseg;
        string rajtszam;

        public Versenyzők(string nev, string szul, string nemzetiseg, string rajtszam)
        {
            this.Nev = nev;
            this.Szul = szul;
            this.Nemzetiseg = nemzetiseg;
            this.Rajtszam = rajtszam;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Szul { get => szul; set => szul = value; }
        public string Nemzetiseg { get => nemzetiseg; set => nemzetiseg = value; }
        public string Rajtszam { get => rajtszam; set => rajtszam = value; }
    }
}
