//Ejemplo del delegado simple
using System;

namespace P24Delegados1
{
    public delegate void MiDelegado(string msj);
    class mensaje{
        public static void mensaje1(string msj)=> Console.WriteLine($"{msj} Lleva el pastel");
        public static void mensaje2(string msj)=> Console.WriteLine($"{msj} Fue el culpable se cancela la fiesta");
    }
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado D;
            D = mensaje.mensaje1;
            D("Juan");
            D = mensaje.mensaje2;
            D("Jose");
            D = (string msj) => Console.WriteLine($"{msj} paga todo que no pare la fiesta");
            D("Carlos");
        }
    }
}
