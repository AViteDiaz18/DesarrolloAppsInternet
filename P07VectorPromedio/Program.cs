using System;
//Programa que con un vector generado saca su promedio y separa los numeros mayores al promedio
namespace P07VectorPromedio
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = 0, nmp = 0;
            double prom;
            int[] a = {10,20,30,40,50,60,70,80,90,100,10,20,30,40,50,60,70,80,90,100,10,20,30,40,50,60,70,80,90,100,10,20,30,40,50,60,70,80,90,100,10,20,30,40,50,60,70,80,90,100};
            Array.Sort(a);
            for(int i = 0; i<a.Length; i++){
                Console.Write(a[i] + " ");
                res += a[i];
            }
            prom = res/a.Length;
            Console.WriteLine("\nEl promedio es: " + prom);
            foreach(int v in a){
                if(v>prom){
                    Console.Write(v +" ");
                    nmp++;
                }
            }
            Console.WriteLine("\nElementos mayores que el promedio: " + nmp);
        }
    }
}
