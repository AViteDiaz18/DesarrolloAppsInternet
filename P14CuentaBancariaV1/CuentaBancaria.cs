using System;
namespace P14CuentaBancariaV1
{
    public class CuentaBancaria
    {
        private double saldo;

        public CuentaBancaria(double saldo){
            this.saldo = saldo;
        } 
        public double Saldo{
            get{return saldo;}
        }

        public void Depositar(double cant){
            saldo += cant;
        }

        public bool Retirar(double cant){
            if(saldo >= cant){
                saldo-=cant;
                return true;
            }
            else{
                return false;
            }
        }
    }
}