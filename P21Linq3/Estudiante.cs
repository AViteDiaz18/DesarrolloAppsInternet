using System;
using System.Collections.Generic;
namespace P21Linq3
{
    class Estudiante
    {
        public int matricula {get; set;}
        public string nombre {get; set;}
        public string direccion{get; set;}

        public List<float> Calif;
        public override string ToString() => 
        $"Matricula: {matricula}, Nombre: {nombre}, Domicilio: {direccion}, Calificaciones: {string.Join(",",Calif)}";

    }
}