using System;
/* 
Desarrollo de Aplicaciones en internet
Programa que permite pedir una pizza en base a la elecion de un usuario
Alejandro Vite Diaz
*/
namespace Pizza
{
    class Program
    {
        static int Main(string[] args)
        {
            char tam, cub, don; // declaracion de variables para tomar los datos de args en terminal
            string tama="", ingredientes="", cubierta="", donde=""; // declaracion de variables para asignar los valores a imprimir
            string[] ing; // arreglo de cadenas
            Console.Clear(); // Limpia consola
            if(args.Length == 0 ){ //Validacion en consola por si no escribe nada
                Menu(); // funcion que muestra el menu
                return 1;
            }
            tam = char.Parse(args[0].ToUpper()); // asigna el valor de args a tam y hace el cambio a mayusculas y a char
            if(tam == 'P'){ // if para ver si es pequeña
                tama = "Pequeña";
            }
            else if(tam == 'M'){ // else if para ver si es mediana
                tama = "Mediana";
            }
            else{ // si llego aqui es grande
                tama = "Grande";
            }

            ing = args[1].Split("+"); // separa la cadena contenida en args con el separador +
            foreach(string i in ing){ // foreach para cada cadena en el arreglo de cadenas separadas
                switch(char.Parse(i.ToUpper())){ // cast de cada cadena a char en mayuscula
                    case 'A': ingredientes+="ExtraQueso "; break; // selecciones de ingredientes
                    case 'B': ingredientes+="Champiñones "; break;
                    case 'C': ingredientes+="Clavo "; break;
                    case 'D': ingredientes+="Cebolla "; break;
                    case 'E': ingredientes+="Cominos "; break;
                    case 'F': ingredientes+="Tomate "; break;

                }
            }
            cub = char.Parse(args[2].ToUpper()); //cast de args[2] a char en mayusculas
            cubierta = cub == 'H' ? "Delgada" : "Gruesa"; // if rudo

            don = char.Parse(args[3].ToUpper()); // cast de args[3] a char en mayusculas
            donde = don == 'J' ? "Comer Aqui" : "Para Llevar";

            Console.WriteLine("La pizza que pediste fue: "); // integra lo que se pidio
            Console.WriteLine("Tamaño: " + tama);
            Console.WriteLine("Ingredientes: " + ingredientes);
            Console.WriteLine("Cubierta: " + cubierta);
            Console.WriteLine("Donde se consume: " + donde);
            return 0;
        }
        static void Menu(){ // Menu
            Console.Clear();
            Console.WriteLine("Elige las opciones segun deseas tu pizza:");
            Console.WriteLine("Tamaño: [P] Pequeña [M] Mediana [G] Grande");
            Console.WriteLine("Ingredientes: [A] Queso Extra [B] Champiñon [C] Clavos [D] Cebolla [E] Cominos [F] Tomates");
            Console.WriteLine("Cubierta: [H] Delgada [I] Grande");
            Console.WriteLine("Donde se consume: [J] Comer Aqui [K] Para Llevar");
            Console.WriteLine("");

        }
    }
}
