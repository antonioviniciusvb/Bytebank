using bytebank;
using System.Linq.Expressions;

ContaCorrente conta_1 = new()
{ 
    Cliente = new(nome: "Antonio Vinicius", cpf: "999.999.999-14", profissao: "Desenvolvedor .NET"),
    Agencia = 2314,
    NomeDaAgencia = "Central",
    Conta = "58144-7",
    Saldo = 93.50
};

ContaCorrente conta_2 = new()
{
    Cliente = new (nome: "Iris", cpf: "555.555.555-47", profissao: "Desenvolvedor Java"),
    Agencia = 2314,
    NomeDaAgencia = "Flórida",
    Conta = "14526-x",
    Saldo = -10
};

Console.WriteLine("Boas Vindas ao seu banco, ByteBank!");

Util.PularLinhas(2);

Console.WriteLine(conta_1.ToString());

Util.PularLinhas();

Console.WriteLine(conta_2.ToString());

//Um exemplo usando o String.Format dentro da string interpolada
//Console.WriteLine($"Saldo: R$ {String.Format("{0:0.00}", conta_2.Saldo)}");



#region Testes

//Valores para Saque e Depósito
double valorDoSaque = 50.33;
double valorDoDeposito = 14000;
double valorDaTransferencia = 4587.52;

try
{
    #region Saque
    Util.PularLinhas(2);

    //Saque
    conta_1.Sacar(valorDoSaque);

    //Log - Saque
    Console.WriteLine($"(-) Saque: {valorDoSaque:c}");
    Console.WriteLine(conta_1.ToString());

    #endregion

    #region Depósitos

    Util.PularLinhas(2);

    //Depósito
    conta_1.Depositar(valorDoDeposito);

    //Log - Depósito
    Console.WriteLine($"(+) Depósito: {valorDoDeposito:c}");
    Console.WriteLine(conta_1.ToString());

    #endregion

    #region Transferências

    Util.PularLinhas(2);

    //Transferencia - Conta 2 para Conta 1
    conta_2.Transferir(valorDaTransferencia, conta_1);

    //Log - Transferencia
    Console.WriteLine($"(-/+) Transferencia: {valorDaTransferencia:c}  - De: {conta_2.Cliente.Nome} - Para: {conta_1.Cliente.Nome}");

    Util.PularLinhas();

    Console.WriteLine($"(-) Transferencia: {valorDaTransferencia:c}");
    Console.WriteLine(conta_2.ToString());

    Util.PularLinhas();

    Console.WriteLine($"(+) Transferencia: {valorDaTransferencia:c}");
    Console.WriteLine(conta_1.ToString());


    valorDaTransferencia = 13198.78;

    Util.PularLinhas();

    //Transferencia - Conta 1 para Conta 2
    conta_1.Transferir(valorDaTransferencia, conta_2);

    //Log - Transferencia
    Console.WriteLine($"(-/+) Transferencia: {valorDaTransferencia:c}  - De: {conta_1.Cliente.Nome} - Para: {conta_2.Cliente.Nome}");

    Util.PularLinhas();

    Console.WriteLine($"(-) Transferencia: {valorDaTransferencia:c}");
    Console.WriteLine(conta_1.ToString());

    Util.PularLinhas();

    Console.WriteLine($"(+) Transferencia: {valorDaTransferencia:c}");
    Console.WriteLine(conta_2.ToString());

    #endregion

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

#endregion

Console.ReadKey();