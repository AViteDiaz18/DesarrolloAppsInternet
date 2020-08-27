using System;

namespace AreaTriangulo
{
    class AreaTriangulo
    {
        static void Main(string[] args)
        {
            double Base = 0, altura = 0, area = 0;
            Console.WriteLine("Calcula el area de un triangulo");
            Console.Write("Ingrese la base del triangulo: ");
            Base = Int32.Parse(Console.ReadLine());
            Console.Write("Ingrese la altura del triangulo: ");
            altura = Int32.Parse(Console.ReadLine());
            area = (Base * altura)/2;
            Console.WriteLine("El area del triangulo es : " + area);
        }
    }
}
