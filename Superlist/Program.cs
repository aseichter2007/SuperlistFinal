using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superlist
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperList<int> superlist = new SuperList<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            foreach (int item in superlist)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
