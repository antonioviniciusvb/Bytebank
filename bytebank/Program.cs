using Bytebank;

ContaCorrente contaCorrente = new ContaCorrente();

contaCorrente.Titular = "Antonio Vinicius";
contaCorrente.Agencia = 2314;
contaCorrente.NomeDaAgencia = "Central";
contaCorrente.Conta = "58144-7";
contaCorrente.Saldo = 93.50;

ContaCorrente contaCorrente2 = new()
{
    Titular = "Ísis de Souza Veras",
    Agencia = 2314,
    NomeDaAgencia = "Flórida",
    Conta = "14526-x",
    Saldo = 10142.33
};

Console.WriteLine("Boas Vindas ao seu banco, ByteBank!");
Console.WriteLine("************");
Console.WriteLine($"Titular: {contaCorrente.Titular}");
Console.WriteLine($"Agência: {contaCorrente.Agencia} - {contaCorrente.NomeDaAgencia}, conta: {contaCorrente.Conta}");
Console.WriteLine($"Saldo: {contaCorrente.Saldo:c}");

Console.WriteLine("************");
Console.WriteLine($"Titular: {contaCorrente2.Titular}");
Console.WriteLine($"Agência: {contaCorrente2.Agencia} - {contaCorrente2.NomeDaAgencia}, conta: {contaCorrente2.Conta}");
Console.WriteLine($"Saldo: {contaCorrente2.Saldo:c}");

//Um exemplo usando o String.Format dentro da string interpolada
//Console.WriteLine($"Saldo: R$ {String.Format("{0:0.00}", contaCorrente2.Saldo)}");


//Efetuando Teste de  Saque 
double valorDoSaque = 100;

Console.WriteLine();
Console.WriteLine();

try
{
   var sacou = contaCorrente.Sacar(valorDoSaque);

    if (sacou)
    {
        Console.WriteLine($"Foram sacados {valorDoSaque:c} do Titular: {contaCorrente.Titular}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{

    Console.WriteLine();
    Console.WriteLine("****** Conta Corrente ******");
    Console.WriteLine(contaCorrente.ToString());
    //Console.WriteLine($"Titular: {contaCorrente.Titular}");
    //Console.WriteLine($"Agência: {contaCorrente.Agencia} - {contaCorrente.NomeDaAgencia}, conta: {contaCorrente.Conta}");
    //Console.WriteLine($"Saldo: {contaCorrente.Saldo:c}");
}

Console.ReadKey();