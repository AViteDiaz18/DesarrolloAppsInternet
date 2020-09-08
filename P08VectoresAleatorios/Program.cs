using System;
// Genera dos vectores aleatorios y los suma
namespace P08VectoresAleatorios
{
    class Program
    {
        static void Main(string[] args)
        {
            int[]a = new int [15];
            int[]b = new int [15];
            int[]c = new int [15];
            Random rnd = new Random();
            for(int i = 0; i<a.Length;i++){
                a[i] = rnd.Next(0,100);
                b[i] = rnd.Next(0,100);
                c[i] = a[i]+b[i];
            }
            Console.WriteLine("Elementos de A \n");
            Imprime(a);
            Console.WriteLine("\nElementos de B \n");
            Imprime(b);
            Console.WriteLine("\nElementos de C \n");
            Imprime(c);
        }
        static void Imprime(int[] vec){
            for(int i = 0; i<vec.Length;i++){
                Console.Write(vec[i] + " ");
            }
        }
    }
}
