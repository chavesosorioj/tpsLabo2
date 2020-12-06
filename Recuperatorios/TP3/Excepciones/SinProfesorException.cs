using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando una clase no tiene profesor
        /// </summary>
        public SinProfesorException():base("Clase sin profesor")
        {

        }
    }
}
