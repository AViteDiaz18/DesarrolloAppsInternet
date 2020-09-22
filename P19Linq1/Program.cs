using System;
using System.Collections.Generic;
using System.Linq;

namespace P19Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[] {10,25,-1,10,0,320,22,65,800,-4,20,20,1000,2000,-233};
            //Crear consulta
            IEnumerable<int> qrypares = from num in numeros where (num % 2)==0 select num;
            //Ejectutar la consulta
            Console.WriteLine($"\nNumeros Pares {qrypares.Count()}");
            foreach (int n in qrypares){
                Console.Write($"{n} ");
            }

            //Crear consulta impares
            var qryimpares = (from num in numeros where (num%2)!=0 select num).ToArray();
            Console.WriteLine($"\nNumeros Impares {qryimpares.Count()}");
            for(int i=0;i<qryimpares.Count();i++){
                Console.Write($"{qryimpares[i]} ");
            }
            //Crear consulta de numeros mayores a 100 y ponerlos en una lista
            var mayores = (from num in numeros where num>=100 select num).ToList();
            Console.WriteLine($"\nNumeros Mayores a 100 {mayores.Count()}");
            mayores.ForEach(n=>Console.Write($"{n} "));
        }
    }
}
