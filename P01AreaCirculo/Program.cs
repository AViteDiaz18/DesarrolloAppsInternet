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
            radio = float.Parse(Console.ReadLine());
            area = Math.PI * Math.Pow(radio,2);
            Console.WriteLine("El area del circulo es : " + area);
        }
    }
}
