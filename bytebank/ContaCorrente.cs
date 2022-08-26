using bytebank.Titular;
using System.Text.RegularExpressions;

namespace bytebank
{
    public class ContaCorrente
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ContaCorrente()
        {
            TotalContas++;
        }

        /// <summary>
        /// Sobrecarga de construtor
        /// </summary>
        /// <param name="titular"></param>
        /// <param name="agencia"></param>
        /// <param name="nomeDaAgencia"></param>
        /// <param name="conta"></param>
        /// <param name="saldo"></param>
        public ContaCorrente(Cliente titular, int agencia, string nomeDaAgencia, string conta)
        {
            TotalContas++;
            Cliente = titular;
            Agencia = agencia;
            NomeDaAgencia = nomeDaAgencia;
            Conta = conta;
            Saldo = saldo;
        }

        public static int TotalContas { get; private set; }

        public Cliente Cliente { get; set; }

        private int _agencia;
        public int Agencia
        {
            get { return _agencia; }

            set
            {
                if((Regex.IsMatch($"{value}", @"^\d{2,5}$")))
                {

                    _agencia = value;
                }
                else
                {
                    Console.WriteLine("Agencia deve ter entre 2 até 5 dígitos, Exemplo: 1254");
                }
            }
        }

        public string NomeDaAgencia { get; set; }

        private string _conta;
        public string Conta
        {
            get { return _conta; }

            set
            {
                if (Regex.IsMatch($"{value}", @"^\d{5}-[\dxX]$"))
                {
                    _conta = value;
                }
                else
                {
                    _conta = String.Empty;
                    Console.WriteLine("Conta deve ter 5 dígitos, seguido de traço e 1 dígito ou X, Exemplo: 12345-9");
                }
            }
        }


        private double _saldo;
        public double Saldo
        {
            get { return _saldo; }

            set
            {
                if ((Util.EhMenorOuIgualZero(value)))
                {
                    _saldo = 0;
                }
                else
                {
                    _saldo = value;
                }
            }
        }

        /// <summary>
        /// Método para Saque 
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Sacar(double valorDeSaque)
        {
            if (ValidaSaque(valorDeSaque))
            {
                Saldo -= valorDeSaque;
            }

            return true;
        }

        /// <summary>
        /// Método para Depósito
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool Depositar(double valorDeposito)
        {
            if (ValidaDeposito(valorDeposito))
            {
                Saldo += valorDeposito;
            }

            return true;
        }

        /// <summary>
        /// Método para Transferir os valores de Saldo
        /// </summary>
        /// <param name="valorDeTransferencia"></param>
        /// <param name="contaDestino"></param>
        /// <returns></returns>
        public bool Transferir(double valorDeTransferencia, ContaCorrente contaDestino)
        {
            if (ValidaTransferencia(valorDeTransferencia))
            {
                contaDestino.Saldo += valorDeTransferencia;
                Saldo -= valorDeTransferencia;
            }

            return true;
        }

        /// <summary>
        /// Método para validar Transferencia de Saldo
        /// </summary>
        /// <param name="valorTransferencia"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool ValidaTransferencia(double valorDeTransferencia)
        {
            if (Util.EhMenorOuIgualZero(valorDeTransferencia))
            {
                throw new Exception($"Valor de {valorDeTransferencia:c} para Tranferencia é inválido.");
            }
            else
            if (valorDeTransferencia > Saldo)
            {
                throw new Exception($"Valor de {valorDeTransferencia:c} para Tranferencia é maior que Saldo em Conta Corrente.");
            }

            return true;
        }

        /// <summary>
        /// Método de validação de Saque
        /// </summary>
        /// <param name="valorDeSaque"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool ValidaSaque(double valorDeSaque)
        {
            if (valorDeSaque > Saldo)
            {
                throw new Exception($"Valor de {valorDeSaque:c} para Saque é maior que Saldo em Conta Corrente.");

            }
            else if (Util.EhMenorOuIgualZero(valorDeSaque))
            {
                throw new Exception($"Valor de {valorDeSaque:c} para Saque é inválido.");
            }

            return true;
        }

        /// <summary>
        /// Método para exibir os valores dos campos 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"****** Conta Corrente ******" + Environment.NewLine +
                   $"Titular: {Cliente.Nome}" + Environment.NewLine +
                   $"Agência: {Agencia} - {NomeDaAgencia}, conta: {Conta}" + Environment.NewLine +
                   $"Saldo: {Saldo:c}";
        }

        /// <summary>
        /// Método para validação de Depósito
        /// </summary>
        /// <param name="valorDeDeposito"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool ValidaDeposito(double valorDeDeposito)
        {
            if (Util.EhMenorOuIgualZero(valorDeDeposito))
            {
                throw new Exception($"Valor de {valorDeDeposito:c} para Depósto é inválido.");
            }

            return true;
        }

        

    }
}
