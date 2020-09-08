using System;
//Programa que calcula la desviacion estandar, la varianza, la media, el elemento mayor y menor
namespace P13VectorEstadistoicas
{
    class Program
    {
        static void Main(string[] args)
        {
            double[]a;
            int num;
            double promedio, varianza, desviacion;
            Console.WriteLine("Numero de elementos de tu arreglo: ");
            num = int.Parse(Console.ReadLine());
            a = new double[num];
            Console.WriteLine("Dame los elementos de A: "); 
            Leer(a);
            Console.Write("Arreglo A: \n");
            Imprime(a);
            Console.Write("\nEl numero menor es: "+ Minor(a)+ "\n");
            Console.Write("\nEl numero mayor es: "+ Maxim(a)+ "\n");
            promedio = Media(a);
            Console.Write("\nEl promedio es: "+ promedio + "\n");
            varianza = Varianza(a,promedio);
            Console.Write("\nLa varianza es: "+ varianza + "\n");
            desviacion = Desv(varianza);
            Console.Write("\nLa desviacion estandar es: "+ desviacion + "\n");
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
        static double Minor(double[] v){
            Array.Sort(v);
            return v[0];
        }
        static double Maxim(double[] v){
            Array.Sort(v);
            return v[v.Length-1];
        }
        static double Media(double[] v){
            double sum =0, prom=0;
            for(int i = 0; i<v.Length; i++){
                sum += v[i]; 
            }
            prom =sum/v.Length;
            return prom;
        }
        static double Varianza( double[] v, double med){
            double var=0;
            for(int i =0; i<v.Length; i++){
                var += Math.Pow((v[i]-med),2)/(v.Length-1);
            }
            return var;
        }
        static double Desv(double var){
            return Math.Sqrt(var);
        }
    }
}
