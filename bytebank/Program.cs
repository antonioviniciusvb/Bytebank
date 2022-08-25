using bytebank;

ContaCorrente contaCorrente = new();

contaCorrente.Titular = "Antonio Vinicius";
contaCorrente.Agencia = 2314;
contaCorrente.NomeDaAgencia = "Central";
contaCorrente.Conta = "58144-7";
contaCorrente.Saldo = 93.50;

//ContaCorrente contaCorrente2 = new()
//{
//    Titular = "Ísis de Souza Veras",
//    Agencia = 2314,
//    NomeDaAgencia = "Flórida",
//    Conta = "14526-x",
//    Saldo = 10142.33
//};

Console.WriteLine("Boas Vindas ao seu banco, ByteBank!");

Util.PulaLinhas();

Console.WriteLine(contaCorrente.ToString());

//Util.PulaLinhas();

//Console.WriteLine(contaCorrente2.ToString());

//Um exemplo usando o String.Format dentro da string interpolada
//Console.WriteLine($"Saldo: R$ {String.Format("{0:0.00}", contaCorrente2.Saldo)}");
Util.PulaLinhas(2);


#region Testes

//Valores para Saque e Depósito
double valorDoSaque = 50.33;
double valorDoDeposito = 14000;

try
{
    //Saque
    contaCorrente.Sacar(valorDoSaque);

    Console.WriteLine($"(-) Saque: {valorDoSaque:c}");
    Console.WriteLine(contaCorrente.ToString());

    Util.PulaLinhas(2);

    //Depósito
    Console.WriteLine($"(+) Depósito: {valorDoDeposito:c}");
    contaCorrente.Depositar(valorDoDeposito);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Util.PulaLinhas();
    Console.WriteLine("****** Conta Corrente ******");
    Console.WriteLine(contaCorrente.ToString());
}

#endregion

Console.ReadKey();