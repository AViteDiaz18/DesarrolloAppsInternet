using System;
namespace P15CuentaBancariaV2
{
    public class CuentaBancaria
    {
       protected double saldo;

        public CuentaBancaria(double saldo){
            this.saldo = saldo;
        } 
        public double Saldo{
            get{return saldo;}
        }

        public void Depositar(double cant){
            saldo += cant;
        }

        public virtual bool Retirar(double cant){
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