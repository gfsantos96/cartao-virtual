using System;
using System.Collections.Generic;

namespace VirtualCard
{
    class Program
    {
        private static List<Cartao> cartoes = new List<Cartao>();

        static void Main(string[] args)
        {
            string opcao = "";

            while (opcao != "X")
            {
                opcao = OpcaoUsuario();
                switch (opcao)
                {
                    case "1":
                        ListarCartoes();
                        continue;
                    case "2":
                        Adicionar();
                        continue;
                        case "3":
                        Sacar();
                        continue;
                        case "4":
                        Depositar();
                        continue;
                        case "5":
                        Transferir();
                        continue;
                        case "6":
                        Pagar();
                        continue;
                        case "7":
                        Quitar();
                        continue;
                    case "C":
                        Console.Clear();
                        continue;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        continue;
                }
            }

            Console.WriteLine("Saindo...");
        }

        private static string OpcaoUsuario()
        {
            Console.WriteLine("Virtual Card; qual sua opção?");
            Console.WriteLine("1. Listar cartões");
            Console.WriteLine("2. Criar novo cartão");
            Console.WriteLine("3. Sacar valor");
            Console.WriteLine("4. Depositar valor");
            Console.WriteLine("5. Transferir valor para outra conta");
            Console.WriteLine("6. Pagar com o cartão de crédito");
            Console.WriteLine("7. Quitar cartão de crédito");
            Console.WriteLine("C. Limpar a tela");
            Console.WriteLine("X. Sair");
            return Console.ReadLine().ToUpper();
        }

        private static Cartao ObtemCartao()
        {
            Console.Write("Informe o número do cartão: ");
            int numCartao = int.Parse(Console.ReadLine());
            return cartoes[numCartao];
        }

        private static double ObtemValor(string mensagem)
        {
            Console.Write(mensagem);
            return double.Parse(Console.ReadLine());
        }
        private static void ListarCartoes()
        {
            if (cartoes.Count == 0)
            {
                Console.WriteLine("Não existem cartões cadastrados!");
                return;
            }

            Console.WriteLine("Mostrando {0} cartões", cartoes.Count);
            for (int index = 0; index < cartoes.Count; index++)
            {
                Console.WriteLine("Nº {0}", index);
                Console.WriteLine(cartoes[index]);
            }
        }

        private static void Adicionar()
        {
            Console.Write("Informe o tipo do cartão: (1) Pessoa física; (2) Pessoa jurídica");
            int tipoCartao = int.Parse(Console.ReadLine());
            Console.Write("Informe o nome do titular: ");
            string nomeTitular = Console.ReadLine();
            Console.Write("Informe o saldo inicial: ");
            double saldoInicial = double.Parse(Console.ReadLine());
            Console.Write("Informe o crédito inicial: ");
            double creditoInicial = double.Parse(Console.ReadLine());
            cartoes.Add(new Cartao(tipoCartao: (TipoCartao)tipoCartao, nomeTitular: nomeTitular, saldoInicial: saldoInicial, creditoInicial: creditoInicial));
            Console.WriteLine("Cartão criado!");
        }

        private static void Sacar()
        {
            var cartao = ObtemCartao();
            double valor = ObtemValor("Informe o valor a sacar: ");
            if(cartao.Sacar(valor))
            Console.WriteLine("Operação realizada com sucesso!");
            else
            Console.WriteLine("Falha na operação!");
              }

private static void Depositar()
{
    var cartao = ObtemCartao();
    double valor = ObtemValor("Informe o valor a depositar: ");
    cartao.Depositar(valor);
    Console.WriteLine("Operação realizada com sucesso!");
}

private static void Transferir()
{
    Console.WriteLine("Informe o cartão que sairá o valor");
    var cartaoOrigem = ObtemCartao();
    Console.WriteLine("Informe o cartão que receberá o valor: ");
    var cartaoDestino = ObtemCartao();
    double valor = ObtemValor("Informe o valor a transferir: ");
    if(cartaoOrigem.Transferir(cartaoDestino, valor))
    Console.WriteLine("Operação realizada com sucesso!");
    else
    Console.WriteLine("Falha na operação!");
}

private static void Pagar()
{
var cartao = ObtemCartao();
double valor = ObtemValor("Informe o valor a pagar via crédito: ");
if(cartao.Pagar(valor))
Console.WriteLine("Operação realizada com sucesso!");
else
Console.WriteLine("Falha na operação!");
}

private static void Quitar()
{
var cartao = ObtemCartao();
double valor = ObtemValor("Informe o valor a quitar do cartão de crédito; ");
if(cartao.Quitar(valor))
Console.WriteLine("Operação realizada com sucesso!");
else
Console.WriteLine("OFalha na operação");
}
    }
}