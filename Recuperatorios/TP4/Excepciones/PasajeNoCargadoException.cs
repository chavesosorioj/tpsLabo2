using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class PasajeNoCargadoException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando ocurre un error al ingresar un nuevo pasaje
        /// </summary>
        /// <param name="e"></param>
        public PasajeNoCargadoException() : base("Error al cargar el pasaje")
        {

        }
    }
}
