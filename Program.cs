using System;
using System.Collections.Generic;

namespace DIOBank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
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
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
            
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas.");
            Console.WriteLine("2 - Inserir nova conta.");
            Console.WriteLine("3 - Transferir.");
            Console.WriteLine("4 - Sacar.");
            Console.WriteLine("5 - Depositar.");
            Console.WriteLine("C - Limpar tela.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
        private static void InserirConta()
        {
            Console.WriteLine();
            Console.WriteLine("Inserir nova conta.");
            Console.Write("Digite 1 para pessoa física, digite 2 para pessoa jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            Conta NovaConta = new Conta(tipoConta:(TipoConta)entradaTipoConta,
                                        nome: entradaNome,
                                        saldo: entradaSaldo, 
                                        credito: entradaCredito);
            listaContas.Add(NovaConta);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas.");
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas");
                return;
            }
            else
            {
                for(int i =0; i<listaContas.Count; i++)
                {
                    Conta conta = listaContas[i];
                    Console.Write($"{i} - ");
                    Console.WriteLine(conta);

                }
            }
        }
        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta.");
            int indice = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser sacado");
            double valor = double.Parse(Console.ReadLine());
            listaContas[indice].Sacar(valor);
        }
        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta.");
            int indice = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser depositado");
            double valor = double.Parse(Console.ReadLine());
            listaContas[indice].Depositar(valor);
        }
        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de origem.");
            int indice = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o numero da conta de destino.");
            int indiceDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser transferido");
            double valor = double.Parse(Console.ReadLine());
            listaContas[indice].Transferir(valor, listaContas[indiceDestino]);
        }
    }
}
