using System;

namespace P14CuentaBancariaV1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco mibanco = new Banco("El cochinito","Alejandro Vite");
            mibanco.AgregarCliente(new Cliente("Jessica Alba"));
            mibanco.AgregarCliente(new Cliente("Juan Camaney"));
            mibanco.AgregarCliente(new Cliente("Tony Soprano"));
            mibanco.AgregarCliente(new Cliente("Jack Bauer"));

            mibanco.Clientes[0].Cuenta = new CuentaBancaria(100);
            mibanco.Clientes[1].Cuenta = new CuentaBancaria(200);
            mibanco.Clientes[2].Cuenta = new CuentaBancaria(300);
            mibanco.Clientes[3].Cuenta = new CuentaBancaria(0);

            mibanco.Clientes[2].Cuenta.Retirar(100);
            mibanco.Clientes[3].Cuenta.Depositar(50);

            Console.WriteLine("Reporte General \n");
            Console.WriteLine("Banco: " + mibanco.Nombre + " propietario: " + mibanco.Propietario);

            foreach(Cliente cte in mibanco.Clientes){
                Console.WriteLine($"El cliente de nombre {cte.Nombre}");
                Console.WriteLine($"Tiene una cuenta con un saldo de {cte.Cuenta.Saldo}");
            }
        }
    }
}
