using System;
/*
Desarrollo de aplicaciones en internet 
Programa que calcula las tablas de multiplicar segun la opcion que el usuario elija
Alejandro Vite Diaz
*/
namespace Tablas
{
    class Program
    {
        static int Main(string[] args)
        {
            int opc, ini, fin, tab;
            if(args.Length == 0 ){ //Validacion en consola por si no escribe nada
                Menu(); // funcion que muestra el menu
                return 1;
            }
            opc = int.Parse(args[0]); // Cast a entero de args[0]
            tab = int.Parse(args[1]); // Cast a entero de args[1]
            ini = int.Parse(args[2]); // Cast a entero de args[2]
            fin = int.Parse(args[3]); // Cast a entero de args[3]
            switch(opc){
                case 1:
                    for(int i = ini; i<= fin; i++){
                        Console.WriteLine(tab + " * " + i + " = " + tab*i); //Imprime las tablas desde un inicio a un fin de una sola tabla
                    }
                    break;
                case 2:
                    for(int t =1; t<= tab; t++){
                        for(int a =ini; a<= fin; a++){
                           Console.WriteLine(t + " * " + a + " = " + t*a); //Imprime todas las tablas desde un inicio a un fin, hasta llegar a la tabla solicitada
                        }
                        Console.WriteLine(" ");
                    }
                    break;

            }
            return 0;
        }
         static void Menu(){ // Menu
            Console.Clear();
            Console.WriteLine("[1] Imprime la tabla que quieres hasta cierto numero [ej. 5 1 10]");
            Console.WriteLine("[2] Imprime todas las tablas hasta donde quieras comenzando en 1 [ej. 5 1 10]");
        }
    }
}
