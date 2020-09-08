using System;
// Programa que llena un vector con numeros aleatorios distingue los ceros, negativos y positivos y suma los positivos y negativos.
//Alejandro Vite Diaz
namespace P10VectorSumas
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[30];
            int cero=0, neg=0, pos=0;
            double sumneg=0, sumpos=0;
            Random rnd = new Random();
            for(int i = 0; i<a.Length;i++){
                a[i] = rnd.Next(-50,50);
                Console.Write(a[i] + " ");
                if(a[i] == 0){
                    cero++;
                }
                else if(a[i] < 0){
                    neg++;
                    sumneg += a[i];
                }
                else{
                    pos++;
                    sumpos += a[i];
                }
            }
            Console.WriteLine("\nEl numero de ceros en el vector es: " + cero);
            Console.WriteLine("El numero de negativos en el vector es: " + neg); 
            Console.WriteLine("La suma de negativos en el vector es: " +sumneg);
            Console.WriteLine("El numero de positivos en el vector es: " + pos); 
            Console.WriteLine("La suma de positivos en el vector es: " +sumpos);
        }
    }
}
