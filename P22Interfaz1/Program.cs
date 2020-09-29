using System;

namespace P22Interfaz1
{
    class Program
    {
        public interface IAnimal{
            string nombre {get;set;}
            void llorar();
        }

        class Perro : IAnimal{
            public Perro(string ndog) => nombre = ndog;
            public string nombre {get;set;}
            public void llorar() => Console.WriteLine("Woff Woff");
        }

        class Gato : IAnimal{
            public Gato(string ncat) => nombre = ncat;
            public string nombre {get;set;}
            public void llorar() => Console.WriteLine("Miau Miau");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Primer ejemplo de uso de interfaces");
            
            Perro miperro = new Perro("Sabueso");
            Console.WriteLine($"El perro {miperro.nombre}");
            miperro.llorar();

            Gato migato = new Gato("Misifu");
            Console.WriteLine($"El gato {migato.nombre}");
            migato.llorar();
        }
    }
}
