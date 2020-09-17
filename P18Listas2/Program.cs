using System;
using System.Collections.Generic;
namespace P18Listas2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crear una lista con elementos del tipo pieza
            List<Pieza> mp = new List<Pieza>();
            //Agregar piezas a la lista
            mp.Add(new Pieza(1234, "Tornillo 1/4"));
            mp.Add(new Pieza(5678, "Tornillo 1/2"));
            mp.Add(new Pieza(1657, "Martillo de goma"));

            //Agregar un rango de piezas
            var prov = new List<Pieza>(){
                new Pieza(5555,"Pega piso 20 kg"),
                new Pieza(8888,"Cemento Cruzazul 50 kg"),
                new Pieza(8889,"Mortero Cruzazul 50 kg")
            };
            mp.AddRange(prov);
            //Usar el metodo foreach integrado a las listas para imprimir su contenido
            mp.ForEach(p=>Console.WriteLine(p.ToString()));

            //Eliminar el ultimo elemento de la lista
            mp.RemoveAt(mp.Count-1);

            //Insertar elemento en una posicion especifica
            Console.WriteLine("\nInsercion en la pocision especificada");
            mp.Insert(1,new Pieza(2222,"Pala Truper"));
            mp.ForEach(p=>Console.WriteLine(p.ToString()));

            //Buscar las ocurrencias 
            Console.WriteLine("\nPiezas que contengan la palabra tornillo");
            var pza = mp.FindAll(p=>p.Nom.Contains("Tornillo"));
            pza.ForEach(p=>Console.WriteLine(p.ToString()));

            //Buscar las piezas cuyo id es menor a 5000
            Console.WriteLine("\nPiezas menor a 5000");
            var pzas = mp.FindAll(p=>p.Id < 5000);
            pzas.ForEach(p=>Console.WriteLine(p.ToString()));

        }
    }
}
