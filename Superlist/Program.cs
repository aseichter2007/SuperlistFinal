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
            SuperList<char> superList = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e' };
            SuperList<char> superList2 = new SuperList<char>() { 'c', 'a', 'b', };
            SuperList<char> result = superList - superList2;

            Console.ReadLine();
        }
    }
}
