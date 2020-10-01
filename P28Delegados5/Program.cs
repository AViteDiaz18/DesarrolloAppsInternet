//Delegados como parametros
using System;

namespace P28Delegados5
{
    public delegate void Delegado(string msj);
    class Program
    {
        static void Main(string[] args)
        {
            Delegado D1,D2,D3;
            D1 = A.MetodoA;
            D1("Tradicional");
            Invocar(D1);

            D2 = B.MetodoB;
            D2("Tradicional B");
            Invocar(D2);

            D3 = (string msj) => Console.WriteLine($"Llamando al metodo con expresion lambada: {msj}");
            D3("Tradicional Lambada");
            Invocar(D3);
        }
        static void Invocar(Delegado del){
            del("Hola desde el invocador: ");
        }
    }
    public class A{
        public static void MetodoA(string msj) => Console.WriteLine($"Llamando al MetodoA de la claseA: {msj}");
    }
    public class B{
        public static void MetodoB(string msj) => Console.WriteLine($"Llamando al MetodoB de la claseB: {msj}");
    }
}
