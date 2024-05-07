using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    public class PolyMorphism
    {
        public int Add(int a,int b,int c)
        {
            return a + b + c;
        }
        public int Add(int a,int b)
        {
            return a + b;
        }
        public int Add(string a,string b)
        {
            int lnA = 0;
            int lnB = 0;
            lnA = int.Parse(a);
            lnB = int.Parse(b);
            return lnA+ lnB;
        }
    }
}
