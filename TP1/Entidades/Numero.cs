using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /////////////////////////////////////////////////////////////////////////////
        //                                                                              CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto, aigna 0 al atributo numero
        /// </summary>
        public Numero()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) : this(numero.ToString())
        {
        }
        /// <summary>
        /// Crea un Numero con valor pasado por parametro.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.SetNumero = numero;

        }
        /// <summary>
        /// Comprueba que el numero recibido sea numerico y lo retorna en formato double
        /// Caso contrario retorna 0
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>un numero double o un cero</returns>
        public double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double retorno) == false)
                retorno = 0;

            return retorno;
        }
        /////////////////////////////////////////////////////////////////////////////
        //                                                                              PROPIEDADES
        /// <summary>
        /// Asigna un valor al atributo numero, previa validacion
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        /////////////////////////////////////////////////////////////////////////////
        //                                                                              METODOS
        /// <summary>
        /// Valida que la cadena de caracteres este compuesta de caracteres '0' y '1'
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool ret = false;
            int cont = 0;
            char[] cadena = binario.ToCharArray();
            
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] =='0' || cadena[i]=='1')  
                    cont++;
            }

            if (cont == cadena.Length)
                ret = true;

            return ret;
        }
     
        /// <summary>
        /// Valida que se trate de un binario y luego lo convierte a decimal
        /// Caso contrario retorna "valor invalido"
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Un numero decimal o "valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            string ret;
            char[] array;
            int suma=0;

            if(EsBinario(binario)==false)
               ret = "Valor Invalido";
            else 
            {
                array = binario.ToCharArray();
                Array.Reverse(array);

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                        suma += (int)Math.Pow(2,i); // Retorna el numero [i] elevado a la potencia
                }

                ret = suma.ToString();
            }
            return ret;
        }
        /// <summary>
        /// Convierte un numero decimal a binario, en caso de no ser posible retorNa "Valor invalido"
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Un numero binario o "Valor invalido"</returns>
        public string DecimalBinario(string numero) // dividir x 2, el resto es el num binario
        {
            string ret="";
            
            if (int.TryParse(numero, out int num) == false) 
                ret = "Valor invalido";
            else
            {
                if (num < 0)
                    ret = "Valor invalido";
                else if (num == 0)
                    ret = "0";
                else
                {
                    do {
                        if (num % 2 == 0)
                            ret = "0" + ret;
                        else
                            ret = "1" + ret;

                        num = (int)(num / 2);                                               
                        
                    } while (num>0);
                }
            }
            return ret;
        }
        /// <summary>
        /// Convierte un numero decimal a binario, en caso de no ser posible retora "Valor invalido"
        /// Reutiliza codigo
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Un numero binario o "Valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            string ret;
            string aux = numero.ToString();

            ret = DecimalBinario(aux);

            return ret;
        }

        /////////////////////////////////////////////////////////////////////////////////
        //                                                                              SOBRECARGA DE OPERADORES

        /// <summary>
        /// Suma dos tipos de clase Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>el resultado de la suma</returns>
        public static double operator +(Numero num1, Numero num2)
        {
            double retorno = num1.numero + num2.numero;

            return retorno;
        }

        /// <summary>
        /// Resta dos tipos de clase Numero. Si se trata de una division por cero, retorna double.MinValue
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>el resultado de la resta o double.MinValue</returns>
        public static double operator -(Numero num1, Numero num2)
        {
            double retorno = num1.numero - num2.numero;

            return retorno;
        }
        /// <summary>
        /// Divide dos tipos de clase Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>el resultado de la division</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double retorno;

            if (num2.numero == 0)
                retorno = double.MinValue;
            else
                retorno = num1.numero / num2.numero;

            return retorno;
        }
        /// <summary>
        /// Multiplica dos tipos de clase Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>el resultado de la multiplicacion</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            double retorno = num1.numero * num2.numero;

            return retorno;
        }
    }
}
