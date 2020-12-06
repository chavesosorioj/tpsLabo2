using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class PasajeRepetido : Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando dos pasajes son iguales
        /// </summary>
        public PasajeRepetido():base("Pasaje repetido")
        {

        }
    }
}
