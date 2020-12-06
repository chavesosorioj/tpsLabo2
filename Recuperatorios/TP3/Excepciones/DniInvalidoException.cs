using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public DniInvalidoException():base("DNI invalido")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e):base(e.ToString())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message):base(message)
        { 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e):base(message + e.ToString())
        {
        }

    }
}
