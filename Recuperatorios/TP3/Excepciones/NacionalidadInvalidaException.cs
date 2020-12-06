using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando la nacionalidad no coincide con el numero de DNI
        /// </summary>
        public NacionalidadInvalidaException() : base("Nacionalidad invalida, no coincide con el numero de DNI")
        {
        }
        /// <summary>
        ///  Excepcion que se lanza cuando la nacionalidad no coincide con el numero de DNI con el mensaje pasado por parametro
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
    }
}
