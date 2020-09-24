using System;
using System.Collections.Generic;
namespace ExamenParcial1
{
    public class Nodo
    {
        public List<Vulnerabilidad> Vulns;
        public string Ip{get;set;}
        public string Tipo{get;set;}
        public int Puertos{get;set;}
        public int Saltos{get;set;}
        public string SO{get;set;}
    }
}