using bank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(double saque)
        {
            if(Saldo - saque < Credito * -1)
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            Saldo -= saque;
            Console.WriteLine("Saldo atual da conta de {0} é R$ {1}", Nome, Saldo);
            return true;
        }

        public void Depositar(double deposito)
        {
            Saldo += deposito;
            Console.WriteLine("Saldo atual da conta de {0} é R$ {1}", Nome, Saldo);
        }

        public void Transferir(double vTransferencia, Conta destino)
        {
            if (Sacar(vTransferencia))
            {
                destino.Depositar(vTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta: " + TipoConta + " | ";
            retorno += "Nome: " + Nome + " | ";
            retorno += "Saldo: " + Saldo + " | ";
            retorno += "Crédito: " + Credito + " | ";
            return retorno;
        }
    }
}
