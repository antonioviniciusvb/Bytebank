using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank
{
    public static class Util
    {
        public static void PulaLinhas(int saltos = 1)
        {
            for (int i = 0; i < 10; i++)
            {

            }

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
