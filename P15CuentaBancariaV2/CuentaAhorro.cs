using System;
namespace P15CuentaBancariaV2
{
    class CuentaAhorro : CuentaBancaria{
        private double tasadeinteres;
    
        public CuentaAhorro(double saldo,double tasadeinteres): base(saldo){
            this.tasadeinteres = tasadeinteres;
        }
        public void CalcularInteres(){
            saldo+=(saldo+tasadeinteres);
        }

    }

}