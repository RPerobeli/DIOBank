using System;

namespace DIOBank
{
    public class Conta
    {
        private string nome{get; set; }
        private TipoConta tipoConta;
        private double saldo;
        private double credito;

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.tipoConta = tipoConta;
            this.nome = nome;
            this.saldo = saldo;
            this.credito = credito;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.saldo - valorSaque < -1*this.credito)
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            else{
                this.saldo -= valorSaque;
                Console.WriteLine($"Saldo atual da conta de {this.nome} e {this.saldo}");
                return true;
            }
        }
        public void Depositar(double valorDeposito)
        {
            this.saldo += valorDeposito;
            Console.WriteLine($"Saldo atual da conta de {this.nome} e {this.saldo}");
        }
        public void Transferir(double valor, Conta contaDestino)
        {
            if(this.Sacar(valor))
            {
                contaDestino.Depositar(valor);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.tipoConta + " | ";
            retorno += "Nome "+ this.nome + " | ";
            retorno += "Saldo " + this.saldo + " | ";
            retorno += "Credito "+ this.credito + " | ";
            return retorno;
        }
    }
}