using System;
using System.Collections.Generic;
using System.Linq;

namespace P20Linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] frutas = new string[] {"Pera","Melon","Sandia","Durazno","Manzana","Platano","Kiwi","Naranja"};
            //Frutas que empiezen con M
            var mfrutas = from f in frutas where f.StartsWith('M') select f;
            Console.WriteLine($"\nFrutas que su primera letra es M: {mfrutas.Count()}");
            foreach(var f in mfrutas){
                Console.Write($"{f} ");
            }

            var xfrutas = (from f in frutas where f.Contains("an") select f).ToArray();
            Console.WriteLine($"\n\nFrutas que contienen las letras an: {xfrutas.Count()}");
            foreach(string f in xfrutas){
                Console.Write($"{f} ");
            }

            var yfrutas = (from f in frutas where f.EndsWith('a') select f).ToList();
            Console.WriteLine($"\n\nFrutas que terminan en a: {yfrutas.Count()}");
            yfrutas.ForEach(f=>Console.Write($"{f} "));
        }
    }
}
