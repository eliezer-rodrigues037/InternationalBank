using System;
using System.Threading.Tasks; //Delay

namespace international.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            bool appState = true;
            while (appState)
            {
                switch (Menu())
                {
                    case "1":
                        //Inserir
                        break;
                    case "2":
                        //Transferir
                        break;
                    case "3":
                        //sacar
                        break;
                    case "4":
                        //depositar
                        break;
                    case "X":
                        //sair
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

        public static String Menu()
        {
            Console.Clear();
            Console.WriteLine("\nInternational Bank");
            Console.WriteLine("Informe a ação a ser realizada:");
            Console.WriteLine("1- Inserir nova conta");
            Console.WriteLine("2- Transferir");
            Console.WriteLine("3- Sacar");
            Console.WriteLine("4- Depositar");
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
