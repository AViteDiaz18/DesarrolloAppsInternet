using System;
// Programa que genera numeros aleatorios y los almacena en un vector, los eleva al cubo y los guarda en otro vector
namespace P09VectorCubo
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[20];
            double[] b = new double[20];
            Random rnd = new Random();
            for(int i = 0; i<a.Length;i++){
                a[i] = rnd.Next(-10,50);
                b[i] = Math.Pow(a[i],3);
            }
            Console.WriteLine("Elementos de A \n");
            Imprime(a);
            Console.WriteLine("\nElementos al cubo \n");
            Imprime(b);
        }
        static void Imprime(double[] vec){
            for(int i = 0; i<vec.Length;i++){
                Console.Write(vec[i] + " ");
            }
        }
    }
}
