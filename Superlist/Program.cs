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
            //as a developer, write the documentation to desctribe the minus operator overload.
            // ReadmeWriter.WriteReadme();
            SuperList<int> superlist = new SuperList<int>() { 9, 1, 8,2, 2, 7, 3, 6, 4, 5 };
            superlist.SortDown();


            Console.ReadLine();
        }
    }
}
