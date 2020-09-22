using System;
using System.Collections.Generic;
using System.Linq;

namespace P21Linq3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>() {
                new Estudiante{matricula=111, nombre="Juan Perez", direccion="Principal 123 Zacatecas",Calif = new List<float>{97,92,81,68}},
                new Estudiante{matricula=111, nombre="Maria Lopez", direccion="Principal 126 Fresnillo",Calif = new List<float>{75,84,91,39}},
                new Estudiante{matricula=444, nombre="Rodrigo Mata", direccion="Luis Moya 31 Rio grande",Calif = new List<float>{88,94,65,91}},
                new Estudiante{matricula=444, nombre="Miguel Mejia", direccion="Juan de tolosa 22 Zacatecas",Calif = new List<float>{70,90,60,40}},
            };
            estudiantes.Add(new Estudiante{matricula=111, nombre="Jose Sanchez", direccion="Somalia 75 Guadalupe",Calif = new List<float>{85,74,89,26}});
            
            //Todos los registros sin consulta ni filtro
            Console.WriteLine("\nTodos los estudiantes: {0}", estudiantes.Count());
            estudiantes.ForEach(est=>Console.WriteLine(est.ToString()));

            //Filtrar los estudiantes que son de Zacatecas
            var estzac = (
                from est in estudiantes 
                where est.direccion.Contains("Zacatecas") 
                select est
            ).ToList();
            Console.WriteLine("\nEstudiantes que viven en Zacatecas {0}", estzac.Count());
            estzac.ForEach(est=>Console.WriteLine(est.ToString()));  

            //Filtrar estudiantes con promedio de 8 y mostrar resultados en forma desendente
            var estprom = (
                from est in estudiantes 
                where est.Calif.Average() >= 70 
                orderby est.nombre descending 
                select est
            ).ToList();
            Console.WriteLine("\nEstudiantes con promedio de 8 de manera desendente {0}", estprom.Count());
            estprom.ForEach(est=>Console.WriteLine($"{est.ToString()}, Promedio: {est.Calif.Average()}"));

            //Consulta con datos agrupados
            var gpoest = (
                from est in estudiantes
                group est by est.matricula
            );
            Console.WriteLine("\nEstudiantes agrupados por matricula");
            foreach(var gpo in gpoest){
                Console.WriteLine(gpo.Key);
                foreach(Estudiante est in gpo){
                    Console.WriteLine(est.ToString());
                }
            }
            //Consulta del estudiante y su promedio
            var prom = (
                from est in estudiantes
                select $"Nombre: {est.nombre}, Promedio: {est.Calif.Average()}"
            ).ToList();
            Console.WriteLine("\nAlumnos y sus promedios");
            prom.ForEach(p=>Console.WriteLine(p));

        }
    }
}
