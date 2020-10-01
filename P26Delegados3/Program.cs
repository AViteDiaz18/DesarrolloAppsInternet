//Ejemplo de delegado multicast con parametros
using System;

namespace P26Delegados3
{
    public delegate int Delegado(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            Delegado Del1,Del2,D;
            Del1=A.MetodoA;
            Del2=B.MetodoB;
            Console.WriteLine($"La suma es: {Del1(8,5)}");
            Console.WriteLine($"La multiplicacion es: {Del2(3,4)}");
            D = Del1+Del2;
            Console.WriteLine($"El resultado es: {D(5,2)}");
        }
    }

    public class A{
        public static int MetodoA(int a, int b) => a+b; 
    }

    public class B{
        public static int MetodoB(int a, int b) => a*b;
    }
}
