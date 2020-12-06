using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        /// <summary>
        ///  Instancia con los atributos que se le pasa por parametro
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) :base(marca, chasis, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected new ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion
        #region Metodo
        /// <summary>
        ///  Retorna toda la informacion de Vechiculo y los atributos
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}
