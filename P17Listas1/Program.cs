using System;
using System.Collections.Generic;
namespace P17Listas1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Definir la lista con valores iniciales
            List<string> mat = new List<string>(){
                "Calculo 1", "Redaccion Avanzada" , "Introduccion a la ingenieria"
            };

            //Agregar elementos a la lista
            mat.Add("Matematicas Discretas");
            mat.Add("Compiladores e interpretadores");
            imprime(mat);

            //Agregar rango de materias
            string[] mopt = {
                "Seguridad de redes (op)",
                "Topicos selectos de redes (op)",
                "Criptografia avanzada (op)"
            };
            mat.AddRange(mopt);
            imprime(mat);

            //Ordenar la lista 
            mat.Sort();
            imprime(mat);

            //Invertir los elementos de la lista
            mat.Reverse();
            imprime(mat);
        
            //Busqueda de un elemento en la lista en base a una condicion
            Console.WriteLine("Materias que tengan la palabra Discretas");
            string mate = mat.Find(x=>x.Contains("Discretas"));
            Console.WriteLine(mate);

            //Buscar las materias optativas
            Console.WriteLine("\nMaterias Optativas");
            var ms = mat.FindAll(x=>x.Contains("(op)"));
            imprime(ms);

            //Remover un elemento de una lista
            /*mat.Remove("Seguridad de redes (op)");
            imprime(mat);*/
        }


        static void imprime(List<string> lista){
            lista.ForEach(m=>Console.WriteLine(m));
            Console.WriteLine();
        }
    }
}
