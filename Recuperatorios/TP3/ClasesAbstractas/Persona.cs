using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region enumerado

        public enum ENacionalidad { Argentino, Extranjero }
        #endregion

        #region atributos

        string nombre;
        string apellido;
        ENacionalidad nacionalidad;
        int dni;

        #endregion


        #region propiedades
        /// <summary>
        /// Propiedad lectura y escritura abributo Apellido con validacion interna
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); } 
        }
        /// <summary>
        /// Propiedad lectura y escritura abributo Dni con validacion interna
        /// </summary>
        public int Dni
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }
        /// <summary>
        /// Propiedad lectura y escritura abributo Nacionalidad 
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; } 
        }
        /// <summary>
        /// Propiedad lectura y escritura abributo Nombre con validacion interna
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); } 
        }

        /// <summary>
        ///  Propiedad lectura y escritura abributo Dni con validacion interna
        /// </summary>
        public string StringToDni
        {
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }
        #endregion

        #region contructores
        /// <summary>
        /// Constructor de instancia
        /// </summary>
       public Persona()
        {

        }
        /// <summary>
        /// Construcor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        #endregion

        #region metodos
        /// <summary>
        /// Retorna todos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}",this.apellido, this.nombre, this.nacionalidad); 
        } 

        /// <summary>
        /// Validacion de DNI pasado por parametro, lo retorna como entero. 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int ret = ValidarDni(nacionalidad, dato.ToString());
            return ret;
        }

        /// <summary>
        /// Valida qie dni de tipo string pasado por parametro perteneza a un numero Argentino o extranjero
        /// En los casos que no pase la validacion se lanza el tipo de excepcion correspondiente
        /// Ya sea NacionalidadInvalidad o dniInvalido
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int ret = 0;

            if(nacionalidad == ENacionalidad.Argentino)
            {
                if (int.TryParse(dato, out int auxDni))
                {
                    if (auxDni > 0 && auxDni < 90000000)
                        ret = auxDni;
                    else
                        throw new NacionalidadInvalidaException();
                }
                else
                    throw new DniInvalidoException();
            }
            else
            {
                if (int.TryParse(dato, out int auxDni))
                {
                    if (auxDni >= 90000000 && auxDni <= 99999999)
                        ret = auxDni;
                    else
                        throw new NacionalidadInvalidaException();
                }
                else
                    throw new DniInvalidoException();
            }

            return ret;
        }

        /// <summary>
        /// Valida si el tipo de dato nombre y apellido es correcto
        /// En caso que no pase la validacion, devuelve un string vacio.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string ret = "";
            int cant = 0;

            foreach (char item in dato)
            {
                if (char.IsLetter(item))
                    cant++;
            }
            if (cant == dato.Length)
                ret = dato;

            return ret;
        }
        #endregion



    }
}
