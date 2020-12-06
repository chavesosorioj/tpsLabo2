using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using static ClasesInstanciables.Universidad;
    
namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region enumerado
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        #endregion
        #region atributos

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Alumno()
        {
                
        }
        /// <summary>
        /// Constructor de instancia, hereda de la base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQuetoma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQuetoma):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQuetoma;
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQuetoma"></param>
        /// <param name="estadoDeCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQuetoma, EEstadoCuenta estadoDeCuenta) :this(id, nombre,apellido, dni, nacionalidad, claseQuetoma)
        {
            this.estadoCuenta = estadoDeCuenta;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestra los datos completos de un objeto de tipo alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA {0}",this.estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool ret = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                ret = true;
            return ret;
        }
        /// <summary>
        /// Un Alumno será distinto a un EClase si no toma esa clase 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool ret = false;
            if (a.claseQueToma != clase)
                ret = true;
            return ret;
        }
        /// <summary>
        /// Retorna la clase que toma un alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("TOMA CLASES DE: {0}\n", this.claseQueToma);
            return sb.ToString();
        }
        /// <summary>
        /// ToString hará públicos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

    }
}
