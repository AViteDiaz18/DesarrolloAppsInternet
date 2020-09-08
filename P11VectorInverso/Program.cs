using System;
//Programa que llena un vector de numeros aleatorios, y almacena el inverso en otro vector
namespace P11VectorInverso
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[15];
            double[] b = new double[15];
            Random rnd = new Random();
            for(int i = 0; i<a.Length;i++){
                a[i] = rnd.Next(-50,50);
                b[(a.Length-1)-i] = a[i];
            }
            Console.Write("Arreglo Original: \n");
            Imprime(a);
            Console.Write("\n Arreglo invertido: \n");
            Imprime(b);
            Console.Write("\n Arreglo Original ordenado: \n");
            Array.Sort(a);
            Imprime(a);

        }
        static void Imprime(double[] vec){
            for(int i = 0; i<vec.Length;i++){
                Console.Write(vec[i] + " ");
            }
        }
    }
}
