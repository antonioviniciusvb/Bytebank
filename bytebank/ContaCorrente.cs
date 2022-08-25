namespace Bytebank
{
    public class ContaCorrente
    {

        public ContaCorrente()
        {

        }

        public ContaCorrente(string titular, int agencia, string nomeDaAgencia, string conta, double saldo)
        {
            this.Titular = titular;
            this.Agencia = agencia;
            this.NomeDaAgencia = nomeDaAgencia;
            this.Conta = conta;
            this.Saldo = saldo;
        }

        public string Titular { get; set; }
        public int Agencia { get; set; }

        public string NomeDaAgencia { get; set; }

        public string Conta { get; set; }

        public double Saldo { get; set; }

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
            else if (EhMenorOuIgualZero(valorDeSaque))
            {
                throw new Exception($"Valor de {valorDeSaque:c} para Saque é inválido.");
            }

            return true;
        }


        public override string ToString()
        {
            return $"Titular: {Titular}" + Environment.NewLine +
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
            if (EhMenorOuIgualZero(valorDeDeposito))
            {
                throw new Exception($"Valor de {valorDeDeposito:c} para Depósto é inválido.");
            }

            return true;
        }

        /// <summary>
        /// Método para retornar value <= 0
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private bool EhMenorOuIgualZero(double valor)
        {
            return valor <= 0;
        }
    }
}
