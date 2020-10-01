//Ejemplo de un delegado generico
using System;

namespace P27Delegados4
{
    public delegate T Suma<T>(T p1, T p2);
    class Program
    {
        static void Main(string[] args)
        {
            Suma<int> S1;
            Suma<string> S2;
            S1= Sumar;
            S2= Concatenar;
            Console.WriteLine($"La suma es {S1(3,4)}");
            Console.WriteLine($"La concatenacion es: {S2("Hola mundo"," Cruel")}");
            Console.WriteLine($"Diferentes tipos de parametros {Imposible("El resultado es:", 3)}");
        }

        public static int Sumar(int a, int b) => a+b;
        public static string Concatenar(string a, string b) => a+b; 
        public static string Imposible(string a, int b) => $"{a} {b.ToString()}";
    }
}
