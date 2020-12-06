using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region atributo
        int legajo;
        #endregion

        #region contructores
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Universitario()
        { }

        /// <summary>
        /// Constructor de instancia, hereda de la clase base persona
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Comprueba que el objeto pasado por parametro sea de tipo Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
                return true;

            return false;
        }
        /// <summary>
        /// Muestra todos los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return string.Format("{0} LEGAJO NUMERO: {1}", base.ToString(), this.legajo);
        }

        /// <summary>
        /// Firma del metodo, implementa en clases hijas
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region sobrecarga
        /// <summary>
        /// Dos universitarios son iguales si tienen el mismo DNI o legajo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
       {
            if(!(pg1 is null || pg2 is null))
            {
                if (pg1.GetType() == pg2.GetType())
                {
                    if (pg1.Dni == pg2.Dni || pg1.legajo == pg2.legajo)
                        return true;
                }
            }
             return false;
        }

        /// <summary>
        /// Dos universitarios son distintos si tienen diferente DNI o legajo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
