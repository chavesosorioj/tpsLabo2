using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Enumerador
        public enum ETipo { CuatroPuertas, CincoPuertas }
        #endregion

        #region Atributo
        private  ETipo tipo;
        #endregion
        #region Constructor

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas, se instancia con los atributos pasados por parametro
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : base(marca, chasis, color)
        {
           tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Se instancia con los atributos pasados por parametro
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(marca, chasis, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected new ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
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

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }

}
        