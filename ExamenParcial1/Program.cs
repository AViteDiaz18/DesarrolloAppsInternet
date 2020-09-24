using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenParcial1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Llenado de Datos
            Red red = new Red(){
                Empresa="Red Patito, S.A. de C.V.",
                Propietario="Mr Pato Macdonald",
                Domicilio="Av. Princeton 123, Orlando Florida",
                Nodos = new List<Nodo>(){
                    new Nodo{
                        Ip="192.168.0.10",
                        Tipo="servidor",
                        Puertos=5,
                        Saltos=10,
                        SO="Linux",
                        Vulns = new List<Vulnerabilidad>(){
                            new Vulnerabilidad{
                                Clave="CVE-2015-1665",
                                Vendedor="microsoft",
                                Descripcion="HTTP.sys permite a atacantes remotos ejecutar codigo arbitrario",
                                Tipo="remota",
                                Fecha= new DateTime(2015,04,14)
                            },
                            new Vulnerabilidad{
                                Clave="CVE-2017-0004",
                                Vendedor="microsoft",
                                Descripcion="El servicio LSASS permite causar una denegacion de servicio",
                                Tipo="local",
                                Fecha= new DateTime(2017,01,10)
                            }
                        }
                    },
                    new Nodo{
                        Ip="192.168.0.12",
                        Tipo="equipoactivo",
                        Puertos=2,
                        Saltos=12,
                        SO="IOS",
                        Vulns = new List<Vulnerabilidad>(){
                            new Vulnerabilidad{
                                Clave="CVE-2015-3847",
                                Vendedor="cisco",
                                Descripcion="Cisco Firepower Management Center XSS",
                                Tipo="remota",
                                Fecha= new DateTime(2017,02,21)
                            }
                        }
                    },
                    new Nodo{
                        Ip="192.168.0.20",
                        Tipo="computadora",
                        Puertos=8,
                        Saltos=5,
                        SO="Windows",
                        Vulns = new List<Vulnerabilidad>(){
                            new Vulnerabilidad{
                                Clave="CVE-2009-2504",
                                Vendedor="microsoft",
                                Descripcion="Múltiples desbordamientos de enteros en APIs Microsoft .NET 1.1",
                                Tipo="local",
                                Fecha=new DateTime(2009,11,13)
                            },
                            new Vulnerabilidad{
                                Clave="CVE-2016-7271",
                                Vendedor="microsoft",
                                Descripcion="Elevación de privilegios Kernel Segura en Windows 10 Gold",
                                Tipo="local",
                                Fecha= new DateTime(2016,12,20)
                            },
                            new Vulnerabilidad{
                                Clave="CVE-2017-2996",
                                Vendedor="adobe",
                                Descripcion="Adobe Flash Player 24.0.0.194 corrupción de memoria explotable",
                                Tipo="remota",
                                Fecha=new DateTime(2017,02,15)
                            }
                        }
                    },
                    new Nodo{
                        Ip="192.168.0.15",
                        Tipo="servidor",
                        Puertos=10,
                        Saltos=22,
                        SO="Linux"
                    }
                }
            };
            //Impresion del reporte
            Console.WriteLine($">> Datos generales de la red:\n");
            //Datos de la clase Red
            Console.WriteLine($"Empresa: {red.Empresa}");
            Console.WriteLine($"Propietario: {red.Propietario}");
            Console.WriteLine($"Domicilio: {red.Domicilio}\n");
            //Numero de la nodos por red
            Console.WriteLine($"Total de nodos en la red\t: {red.Nodos.Count()}");
            //Numero de vulnerabilidades por nodo
            Console.WriteLine($"Total de vulnerabilidades\t: {TotalVulns(red)}\n");
            //Datos generales de las listas Nodo
            Console.WriteLine(">> Datos generales de los nodos: \n");
            foreach(var n in red.Nodos){
                try{
                    Console.WriteLine($"Ip: {n.Ip}, Tipo: {n.Tipo}, Puertos: {n.Puertos}, Saltos: {n.Saltos}, SO: {n.SO}, TotVul: {n.Vulns.Count()}");
                }
                catch{
                    Console.WriteLine(
                    $"Ip: {n.Ip}, Tipo: {n.Tipo}, Puertos: {n.Puertos}, Saltos: {n.Saltos}, SO: {n.SO}, TotVul: {0}");
                }
            }
            //Numero maximo de saltos
            var saltos = from r in red.Nodos select r.Saltos ;
            Console.WriteLine($"\nMayor numero de saltos: {saltos.Max()}");

            //Numero minimo de saltos
            Console.WriteLine($"Menor numero de saltos: {saltos.Min()}");

            //Vulnerabilidades por nodo
            Console.WriteLine($"\n>> Vulnerabilidades por nodo:\n");
            foreach(var n in red.Nodos){
                Console.WriteLine($"> Ip: {n.Ip}, Tipo: {n.Tipo} :\n");
                try{
                    n.Vulns.ForEach(v=>Console.WriteLine($"Clave: {v.Clave}, Vendedor: {v.Vendedor}, Descripcion: {v.Descripcion}, Tipo: {v.Tipo}, Fecha: {(v.Fecha).ToString("d")}, Antiguedad: {(DateTime.Now.Year-v.Fecha.Year).ToString()}\n"));
                }
                catch{
                    Console.WriteLine("No tiene vulnerabilidades ..\n");
                }
            }
            
        }
        public static int TotalVulns(Red red){
            //Numero de vulnerabilidades totales
            int temp=0;
            foreach(var n in red.Nodos){
                try{
                    temp+=n.Vulns.Count();
                }
                catch{
                    temp+=0;
                }
            }
            return temp;
        }
    }
}
