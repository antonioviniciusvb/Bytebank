using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank
{
    public static class Util
    {

        /// <summary>
        /// Método para pula linhas no console
        /// </summary>
        /// <param name="saltos"></param>
        public static void PulaLinhas(int saltos = 1)
        {
            if (saltos > 0)
            {
                for (int i = 0; i < saltos; i++)
                {
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Método para retornar value <= 0
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static bool EhMenorOuIgualZero(double valor)
        {
            return valor <= 0;
        }
    }
}
