using System;

namespace VirtualCard
{
    public class Cartao
    {
private TipoCartao TipoCartao {get; set;}
private double Saldo {get; set;}
private double Credito {get; set;}
private string Titular {get; set;}

public Cartao(TipoCartao tipoCartao, double saldoInicial, double creditoInicial, string nomeTitular)
{
TipoCartao = tipoCartao;
Saldo = saldoInicial;
Credito = creditoInicial;
Titular = nomeTitular;
}

public bool Sacar(double valor)
{
    if((Saldo - valor) >= 0)
    {
        Saldo -= valor;
        return true;
    }
return false;
}

public void Depositar(double valor)
{
    Saldo += valor;
}

public bool Transferir(Cartao cartao, double valor)
{
if(Sacar(valor))
{
    cartao.Depositar(valor);
    return true;
}

return false;
}

public bool Pagar(double valor)
{
    if(valor < Credito)
    {
        Credito -= valor;
        return true;
    }

    return false;
}

public bool Quitar(double valor)
{
    if(Sacar(valor))
    {
    Credito += valor;
    return true;
    }

    return false;
}

        public override string ToString()
        {
            string text = "";

text = "Tipo do cartão: " + TipoCartao + Environment.NewLine;
text += "Titular: " + Titular + Environment.NewLine;
text += "Saldo: " + Saldo + Environment.NewLine;
text += "Crédito: " + Credito + Environment.NewLine;

            return text;
        }
    }
}