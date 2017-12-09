using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wielomiany
{
    class Program
    {
        static void Main(string[] args)
        {
            var wielomian = new Wielomian<int>(new int[] { 1, 2, 3 });
            var wielomian2 = new Wielomian<int>(new int[] { 1, 2, 3 });

            Console.WriteLine(wielomian2.GetValue(1));
            Console.WriteLine((wielomian+wielomian2).ToString());
        }
    }
}
