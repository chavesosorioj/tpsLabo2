using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        ///  Valida que el operador sea +, -, / o *
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>operador</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador != "*" && operador != "/" && operador != "-")
                operador = "+";

            return operador;
        }

        /// <summary>
        /// Valida y realiza la operacion pedida entre ambos numeros segun el operador pasado por parametro
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Calculo entre dos tipos de clase Numero</returns>
        public static double  Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            string auxOperador;

            auxOperador = ValidarOperador(operador);
            switch (auxOperador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
               }

            return resultado;
        }
    }
}
