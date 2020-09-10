using System;
namespace P15CuentaBancariaV2
{
    class CuentaCheques : CuentaBancaria
    {
        private double psobregiro;

        public CuentaCheques(double saldo, double psobregiro): base(saldo){
            this.psobregiro = psobregiro;
        }

        public override bool Retirar(double cant){
            bool resultado = true;
            double prequerida = cant-saldo;
            if(psobregiro < prequerida){
                return false;
            }
            else{
                saldo = 0.0;
                psobregiro -= prequerida;
                return resultado;
            }
        }
    }
}