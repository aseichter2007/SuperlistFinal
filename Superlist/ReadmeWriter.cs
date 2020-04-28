using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Superlist
{
    public static class ReadmeWriter
    {
        public static void WriteReadme()
        {
            String currentdir = Directory.GetCurrentDirectory();
            StreamWriter fileStream = new StreamWriter(currentdir + "\\MiusOperatorReadme.txt", false);
            fileStream.WriteLine("");
            fileStream.WriteLine("Superlist<T> Minus Operator Override metheod");
            fileStream.WriteLine("      -     -   -   -  -   -    -     -");
            fileStream.WriteLine("Overrides the - operator to work with SuperList<T>");
            fileStream.WriteLine("_____________________________________________________________________________________");
            fileStream.WriteLine("public static SuperList<T> operator -(SuperList<T> list, SuperList<T> list2subtract)");
            fileStream.WriteLine("_____________________________________________________________________________________");
            fileStream.WriteLine("");
            fileStream.WriteLine("Paraameters:");
            fileStream.WriteLine("-----------");
            fileStream.WriteLine("'list' is the list to remove objects from");
            fileStream.WriteLine("'list2subtract' countains the objects to remove from 'list'");
            fileStream.WriteLine("_____________________________________________");
            fileStream.WriteLine("");
            fileStream.WriteLine("");
            fileStream.WriteLine("");
            fileStream.WriteLine("Returns:");
            fileStream.WriteLine("-------");
            fileStream.WriteLine("returns a SuperList<T> with the objects remaining in 'list' after removal of items in 'list2subtract");
            fileStream.WriteLine("_____________________________________________________________________________________");
            fileStream.WriteLine("");
            fileStream.WriteLine("");
            fileStream.WriteLine("");
            fileStream.WriteLine("Implements:");
            fileStream.WriteLine("--------");
            fileStream.WriteLine("Add()");
            fileStream.WriteLine("Remove()");
            fileStream.WriteLine("Contains()");
            fileStream.WriteLine("RemoveAt()");
            fileStream.WriteLine("____________");
            fileStream.WriteLine("");
            fileStream.WriteLine("");
            fileStream.WriteLine("");
            fileStream.WriteLine("Examples:");
            fileStream.WriteLine("------");
            fileStream.WriteLine("The folowing demonstrates how to remove objects from a Superlist<T> using the overloaded operator");
            fileStream.WriteLine("__________________________________________________________________________");
            fileStream.WriteLine("");
            fileStream.WriteLine("//declare two Superlist<T> objects with contents");
            fileStream.WriteLine("SuperList<char> superList = new SuperList<char>() { 'a', 'b', 'c', 'd', 'e', 'a'};");
            fileStream.WriteLine("SuperList<char> supersubtract = new SuperList<char>() { 'c', 'a', 'b' };");
            fileStream.WriteLine("");
            fileStream.WriteLine("//subtract and capture the result");
            fileStream.WriteLine("SuperList<char> result = superlist - supersubtract;     //result = { 'd', 'e', 'a' } ");
            fileStream.WriteLine("");
            fileStream.WriteLine("//or subtract directly");
            fileStream.WriteLine("superlist -= supersubtract;     //superlist = { 'd', 'e', 'a' } ");
            fileStream.WriteLine("");
            fileStream.WriteLine("");
            fileStream.WriteLine("");




        }
    }
}
