using System;

namespace Ciclos
{
    class Program
    {
        static int Main(string[] args)
        {   
            int opcion;
            int control;
            int suma = 0;
            Console.Clear();
            if(args.Length == 0){
                Menu();
                return 1;
            }
            opcion = int.Parse( args[0]);
            
            switch(opcion){
                case 1:
                    control = 1;
                    Console.WriteLine("While");
                    while(control <= 100){
                        Console.Write(control + " ");
                        suma += control;
                        control ++;
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("La suma es: " + suma);
                    break;

                case 2: 
                    control = 100;
                    Console.WriteLine("Do While");
                    do{
                        Console.Write(control + " ");
                        suma += control;
                        control --;
                    } while (control >= 1);
                    Console.WriteLine(" ");
                    Console.WriteLine("La suma es: " + suma);
                    break;
                
                case 3:
                    Console.WriteLine("For");
                    for(control = 50; control <= 200; control++){
                        Console.Write(control + " ");
                        suma += control;
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("La suma es: " + suma);
                    break;

                case 4:
                    Console.WriteLine("For de pares");
                    for(control = 2; control <= 100; control+=2){
                        Console.Write(control + " ");
                        suma += control;
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("La suma es: " + suma);
                    break;

                case 5:
                    Console.WriteLine("For de impares");
                    for(control = 99; control >= 1; control-=2){
                        Console.Write(control + " ");
                        suma += control;
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("La suma es: " + suma);
                    break;

                case 6:
                    control = 272;
                    Console.WriteLine("While decrementos de 4");
                    while(control >= 40){
                        Console.Write(control + " ");
                        suma += control;
                        control -= 4;
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("La suma es: " + suma);
                    break;
            }
            return 0;
        }
        static void Menu(){
            Console.Clear();
            Console.WriteLine("=======Ejemplos de Ciclos=======");
            Console.WriteLine("[1] Numeros del 1 al 100 con ciclo while");
            Console.WriteLine("[2] Numeros del 100 al 1 con ciclo do while");
            Console.WriteLine("[3] Numeros del 50 al 200 con ciclo for");
            Console.WriteLine("[4] Numeros del 2 al 100 solo pares con ciclo for");
            Console.WriteLine("[5] Numeros del 99 al 1 solo impares con ciclo for");
            Console.WriteLine("[6] Numeros del 272 al 40 en decrementos de 4 con ciclo while");
            
        }
    }
}
