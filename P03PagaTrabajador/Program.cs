using System;
// Programa que calcula la paga de un trabajador, dado nombre, horas, paga y tasa de impuesto
// Alejandro Vite Diaz
namespace PagaTrabajador
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            int horas;
            double paga, tasa = 0.10f;
            double impuesto, pagabruta, paganeta;

            Console.WriteLine("Calculando la paga de un trabajador");
            Console.WriteLine("Dame el nombre"); nombre = Console.ReadLine();
            Console.WriteLine("Dame las horas"); horas = int.Parse(Console.ReadLine());
            Console.WriteLine("Dame la paga"); paga = double.Parse(Console.ReadLine());
            
            pagabruta = horas * paga;
            impuesto  = pagabruta*tasa;
            paganeta = pagabruta - impuesto;

            Console.WriteLine("El trabajador de nombre: " + nombre);
            Console.WriteLine("Trabajo " + horas + " horas");
            Console.WriteLine("Con una paga de " + paga + " pesos");
            Console.WriteLine("Por lo cual recibe una paga bruta de  " + pagabruta + " pesos");
            Console.WriteLine("Esto genera un impuesto de " + impuesto + " pesos");
            Console.WriteLine("Al final llega a su casa con la miserable cantidad de " + paganeta + " pesos");
        }
    }
}
