using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException :Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando un alumno se encuentra repetido
        /// </summary>
        public AlumnoRepetidoException():base("Alumno repetido")
        {

        }
    }
}
