using System;

namespace P15CuentaBancariaV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco mibanco = new Banco("Banamex","Alejandro Vite");
            mibanco.AgregarCliente(new Cliente("Jessica Alba"));
            mibanco.AgregarCliente(new Cliente("Juan Camaney"));
            mibanco.AgregarCliente(new Cliente("Tony Soprano"));
            mibanco.AgregarCliente(new Cliente("Jack Bauer"));

            mibanco.Clientes[0].AgregarCuenta(new CuentaAhorro(500,0.10));
            mibanco.Clientes[0].AgregarCuenta(new CuentaCheques(1500,300));
            mibanco.Clientes[1].AgregarCuenta(new CuentaCheques(1500,200));
            mibanco.Clientes[2].AgregarCuenta(new CuentaAhorro(2500,0.8));
            mibanco.Clientes[2].AgregarCuenta(new CuentaCheques(500,30));
            mibanco.Clientes[3].AgregarCuenta(new CuentaAhorro(1500,0.9));
            mibanco.Clientes[3].AgregarCuenta(mibanco.Clientes[2].Cuentas[1]);

            mibanco.CalcularIntereses();

            
            Console.WriteLine("Reporte Bancario \n");
            Console.WriteLine($"{mibanco.Nombre} - {mibanco.Propietario} \n");
            Console.WriteLine($"Total de clientes {mibanco.Clientes.Count} \n");
            foreach(Cliente cte in mibanco.Clientes){
                Console.WriteLine($"Cliente: {cte.Nombre} tiene {cte.Cuentas.Count} cuentas que son: \n ");
                foreach(CuentaBancaria cta in cte.Cuentas){
                    Console.Write((cta is CuentaAhorro)? "Cuenta de ahorro: " : "Cuenta de cheques: ");
                    Console.WriteLine($"{cta.Saldo}");
                }
                Console.WriteLine();
            }
        }
    }
}
