using System;
using System.Collections.Generic;

namespace P16Diccionario
{
    class Program
    {
        static void Main(string[] args)
        {
            //Definicion del diccionario y reserva del espacio de memoria
            //Dictionary<string,string> midic = new Dictionary<string, string>();
            SortedDictionary<string,string> midic = new SortedDictionary<string, string>();

            //Agregar elementos al diccionario 
            midic.Add("txt","Archivo de texto");
            midic.Add("jpg","Archivo de imagen");
            midic.Add("mp3","Archivo de sondio");
            midic.Add("html","Archivo de texto HTML");
            midic.Add("exe","Archivo de ejecutable");
            midic.Add("lll","Archivo de tipo desconocido");

            //Acceder a elemento atravez de la llave
            Console.WriteLine(midic["html"]);

            //Verificar si una llave existe, si no agregarla
            if(midic.ContainsKey("elf"))
                Console.WriteLine("La llave ya existe en el diccionario.");
            else
                midic.Add("elf","Archivo ejecutable en Linux");

            //Borrar una entrada del diccionario desde una llave
            if(midic.ContainsKey("elf"))
                midic.Remove("elf");

            //Recorrer el diccionario, imprimir la llave y su valor
            Console.WriteLine("\nTabla Completa del Diccionario");
            foreach(KeyValuePair<string,string> val in midic){
                Console.WriteLine(val.Key + "\t| "+ val.Value);
            }

            //Imprimir solo las llaves del diccionario
            Console.WriteLine("\nTabla de llaves del diccionario");
            foreach(KeyValuePair<string,string> key in midic){
                Console.WriteLine(key.Key);
            }

            //Imprimir solo las entradas del diccionario
            Console.WriteLine("\nTabla valores del diccionario");
            foreach(KeyValuePair<string,string> val in midic){
                Console.WriteLine(val.Value);
            }

            //Borrar todas las entradas del diccionario
            midic.Clear();
        }
    }
}
