using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisher
{
    class Separacja
    {
        public int argument;
        public double wartosc;
        public int k;

        public Separacja(int arg, double wart, int k)
        {
            this.argument = arg;
            this.wartosc = wart;
            this.k = k;
        }
    }
}
