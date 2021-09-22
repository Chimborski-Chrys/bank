using bank.Classes;
using System;
using bank.Enum;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcao = MenuUsuario();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                       ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao = MenuUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta que recebera a transferencia: ");
            int indiceContaT = int.Parse(Console.ReadLine());

            Console.Write("Valor da transferencia: R$ ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceConta].Transferir(valorTransferencia,listContas[indiceContaT]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Valor de deposito: R$ ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }
        private static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Valor de saque: R$ ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);

        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta: ");

            Console.Write("Digite 1 para Conta Pessoa Fisica ou 2 para Juridica ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Nome do Cliente: ");
            string nomeCliente = (Console.ReadLine());

            Console.WriteLine("Saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Informar o crédito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)tipoConta,
                                        saldo: saldo,
                                        credito: credito,
                                        nome: nomeCliente);

            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista de Contas"); 
            if(listContas.Count == 0)
            {
                Console.WriteLine("Não existe conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string MenuUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("TDB - The Developer's Bank");
            Console.WriteLine("Informe a opção: ");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Nova Conta");
            Console.WriteLine("3 - Transferir Valor");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
