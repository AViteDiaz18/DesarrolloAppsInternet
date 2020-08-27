using System;

namespace AreaCirculo
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = 0, radio = 0;
            Console.WriteLine("Calcula el area de un circulo");
            Console.Write("Ingrese el radio del circulo: ");
            radio = Int32.Parse(Console.ReadLine());
            area = Math.PI * radio * radio;
            Console.WriteLine("El area del circulo es : " + area);
        }
    }
}
