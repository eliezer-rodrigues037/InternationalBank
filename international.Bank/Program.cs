using System;
using System.Collections.Generic;
using System.Threading.Tasks; //Delay

namespace international.Bank
{
    class Program
    {
        static List<Conta> Contas = new List<Conta>();
        static void Main(string[] args)
        {
            Contas.Add(new Conta(nome: "Eliezer Rodrigues", tipoConta: TipoConta.PessoaFisica, saldo: 1000.0, credito: 500.0));
            Contas.Add(new Conta(nome: "Diego Gomes", tipoConta: TipoConta.PessoaFisica, saldo: 1000.0, credito: 500.0));
            Contas.Add(new Conta(nome: "Rafael Magalhães", tipoConta: TipoConta.PessoaFisica, saldo: 1000.0, credito: 500.0));

            bool appState = true;
            while (appState)
            {
                switch (Menu())
                {
                    case "1":
                        Console.Clear();
                        InserirConta();
                        break;
                    case "2":
                        Console.Clear();
                        Transferir();
                        break;
                    case "3":
                        Console.Clear();
                        Sacar();
                        break;
                    case "4":
                        Console.Clear();
                        Depositar();
                        break;
                    case "5":
                        Console.Clear();
                        ListarContas();
                        break;
                    case "X":
                        Console.Clear();
                        Console.WriteLine("Obrigado por utilizar nossos serviços!");
                        appState = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!\n");
                        delay();
                        Console.Clear();
                        break;
                }
            }
        }

        
        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem;
            while (!int.TryParse(Console.ReadLine(), out indiceContaOrigem))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.Write("Digite o número da conta de origem: ");
            }

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino;
            while (!int.TryParse(Console.ReadLine(), out indiceContaDestino))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.Write("Digite o número da conta de destino: ");
            }

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia;

            while (!double.TryParse(Console.ReadLine(), out valorTransferencia))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.Write("Digite o valor a ser transferido: ");
            }

            Contas[indiceContaOrigem].Transferir(valorTransferencia, Contas[indiceContaDestino]);
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta;
            while (!int.TryParse(Console.ReadLine(), out indiceConta))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.Write("Digite o número da conta: ");
            }

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito;
            while (!Double.TryParse(Console.ReadLine(), out valorDeposito))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.Write("Digite o valor a ser depositado: ");
            }

            Contas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta;
            while (!int.TryParse(Console.ReadLine(), out indiceConta))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.Write("Digite o número da conta: ");
            }

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque;
            while (!double.TryParse(Console.ReadLine(), out valorSaque))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.Write("Digite o valor a ser sacado: ");
            }

            Contas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("Listar contas");

            if (Contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < Contas.Count; i++)
            {
                Conta conta = Contas[i];
                Console.Write("Numero da conta: {0} - ", i);
                Console.WriteLine(conta);
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        private static void InserirConta()
        {
            int entradaTipoConta;
            Console.Clear();
            Console.WriteLine("Digite 1 para Pessoa Físca ou 2 para pessoa Juridica: ");
            while (!int.TryParse(Console.ReadLine(), out entradaTipoConta))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.WriteLine("Digite 1 para Pessoa Físca ou 2 para pessoa Juridica: ");
            }

            Console.WriteLine("Digite o nome do cliente");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial: ");
            double entradaSaldo;
            while (!double.TryParse(Console.ReadLine(), out entradaSaldo))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.WriteLine("Digite o Saldo Inicial: ");
            }

            Console.WriteLine("Digite o Crédito: ");
            double entradaCredito;

            while (!double.TryParse(Console.ReadLine(), out entradaCredito))
            {
                Console.WriteLine("Digite Apenas números!");
                delay();
                Console.Clear();
                Console.WriteLine("Digite o Crédito: ");
            }


            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            Contas.Add(novaConta);
        }


        public static String Menu()
        {
            Console.Clear();
            Console.WriteLine("\nInternational Bank");
            Console.WriteLine("Informe a ação a ser realizada:");
            Console.WriteLine("1- Inserir nova conta");
            Console.WriteLine("2- Transferir");
            Console.WriteLine("3- Sacar");
            Console.WriteLine("4- Depositar");
            Console.WriteLine("5- Listar contas");
            Console.WriteLine("X- Sair\n");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("\n");
            return opcaoUsuario;

        }

        public static void delay()
        {
            var t = Task.Run(async delegate
                {
                    await Task.Delay(1500); //Tempo de delay em milisegundos
                    return 42;
                });

            t.Wait();
        }
    }
}
