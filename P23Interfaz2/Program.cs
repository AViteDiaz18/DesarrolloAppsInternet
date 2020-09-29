using System;

namespace P23Interfaz2
{
    public class Organismo{
        public void Respiracion() => Console.WriteLine("Respirando");
        public void Movimiento() => Console.WriteLine("Moviendose");
        public void Crecimiento() => Console.WriteLine("Creciendo");
    }
    public interface IAnimales{
        void Cromosomas();
        void Temperatura();
    }
    public interface ICuadrupedo : IAnimales{
        void Correr();
        void CuatroPatas();
    }

    public interface IAves : IAnimales{
        void Volar();
        void DosPatas();
    }
    public class Perro : Organismo, ICuadrupedo{
        public void Cromosomas()=> Console.WriteLine("El perro tiene 39 pares cromosomas");
        public void Temperatura()=> Console.WriteLine("El perro esta a una temperatura de 38 grados");
        public void Correr()=> Console.WriteLine("Puede Correr");
        public void CuatroPatas()=> Console.WriteLine("Tiene 4 patas");
    }
    public class Perico : Organismo, IAves{
        public void Cromosomas()=> Console.WriteLine("El perico tiene 46 pares cromosomas");
        public void Temperatura()=> Console.WriteLine("El perico esta a una temperatura de 27 grados");
        public void Volar()=> Console.WriteLine("Puede Volar");
        public void DosPatas()=> Console.WriteLine("Tiene 2 Patas");
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Segundo ejemplo de interfaces:\n********************");

            Perro miperro = new Perro();
            Console.WriteLine("Caracteristicas del perro:");
            miperro.Respiracion();
            miperro.Movimiento();
            miperro.Crecimiento();
            miperro.Cromosomas();
            miperro.Temperatura();
            miperro.CuatroPatas();
            miperro.Correr();

            Perico miperico = new Perico();
            Console.WriteLine("\nCaracteristicas del perico:");
            miperico.Respiracion();
            miperico.Movimiento();
            miperico.Crecimiento();
            miperico.Cromosomas();
            miperico.Temperatura();
            miperico.DosPatas();
            miperico.Volar();
        }
    }
}
