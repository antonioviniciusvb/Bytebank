using bytebank;

ContaCorrente contaCorrente = new()
{
    Titular = "Antonio Vinicius",
    Agencia = 2314,
    NomeDaAgencia = "Central",
    Conta = "58144-7",
    Saldo = 93.50
};

ContaCorrente contaCorrente2 = new()
{
    Titular = "Iris",
    Agencia = 2314,
    NomeDaAgencia = "Flórida",
    Conta = "14526-x",
    Saldo = 10142.33
};

Console.WriteLine("Boas Vindas ao seu banco, ByteBank!");

Util.PularLinhas();

Console.WriteLine("");
Console.WriteLine(contaCorrente.ToString());

Util.PularLinhas();

Console.WriteLine(contaCorrente2.ToString());

//Um exemplo usando o String.Format dentro da string interpolada
//Console.WriteLine($"Saldo: R$ {String.Format("{0:0.00}", contaCorrente2.Saldo)}");



#region Testes

//Valores para Saque e Depósito
double valorDoSaque = 50.33;
double valorDoDeposito = 14000;
double valorDaTransferencia = 277337.52;

try
{
    Util.PularLinhas(2);

    //Saque
    contaCorrente.Sacar(valorDoSaque);

    //Log - Saque
    Console.WriteLine($"(-) Saque: {valorDoSaque:c}");
    Console.WriteLine(contaCorrente.ToString());

    Util.PularLinhas(2);

    //Depósito
    contaCorrente.Depositar(valorDoDeposito);

    //Log - Depósito
    Console.WriteLine($"(+) Depósito: {valorDoDeposito:c}");
    Console.WriteLine(contaCorrente.ToString());

    Util.PularLinhas(2);

    //Transferencia - Conta 2 para Conta 1
    contaCorrente2.Transferir(valorDaTransferencia, contaCorrente);

    //Log - Transferencia
    Console.WriteLine($"(-/+) Transferencia: {valorDaTransferencia:c}  - De: {contaCorrente2.Titular} - Para: {contaCorrente.Titular}");

    Util.PularLinhas();

    Console.WriteLine($"(-) Transferencia: {valorDoDeposito:c}");
    Console.WriteLine(contaCorrente2.ToString());

    Util.PularLinhas();

    Console.WriteLine($"(+) Transferencia: {valorDoDeposito:c}");
    Console.WriteLine(contaCorrente.ToString());

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

#endregion

Console.ReadKey();