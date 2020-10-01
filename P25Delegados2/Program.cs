//Delegados multicast es uno que invoca a varios metodos
using System;

namespace P25Delegados2
{
    class Program
    {
        public delegate void Delegado(string msj);
        static void Main(string[] args)
        {
            Delegado Del1,Del2,Del3,D;
            Del1=Mensajes.Mensaje1;
            Del2=Mensajes.Mensaje2;
            D=Del1+Del2;
            D("El Peje");
            Del3=(string msj) => Console.WriteLine($"{msj} paga todo que no pare la fiesta");
            D+=Del3;
            D("El borolas");
            D-=Del2;
            D("Calderon");
            D-=Del1;
            D("Tello");
        }
    }
}
