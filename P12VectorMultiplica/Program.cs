using System;

namespace P12VectorMultiplica
{
    class Program
    {
        static void Main(string[] args)
        {
            double[]a = new double[10];
            double[]b = new double[10];
            double[]c = new double[10];
            Console.WriteLine("Dame los elementos de A: "); 
            Leer(a);
            Console.WriteLine("Dame los elementos de B: "); 
            Leer(b);
            Array.Reverse(b);
            for(int i = 0; i<c.Length;i++){
                c[i] = a[i]*b[i];
            }
            Console.Write("Arreglo A: \n");
            Imprime(a);
            Console.Write("\nArreglo B: \n");
            Array.Reverse(b);
            Imprime(b);
            Console.Write("\nArreglo C: \n");
            Imprime(c);
        }
        static void Imprime(double[] vec){
            for(int i = 0; i<vec.Length;i++){
                Console.Write(vec[i] + " ");
            }
        }

        static void Leer(double[] v){
            for(int i = 0; i<v.Length;i++){
                Console.Write("Elemento[" + i +"]: ");
                v[i] = double.Parse(Console.ReadLine());
            }
        }
    }
}
