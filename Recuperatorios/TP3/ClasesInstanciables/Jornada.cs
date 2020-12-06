using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region atributos

        List<Alumno> alumnos;
        EClases clase;
        Profesor instructor;

        #endregion

        #region propiedades

        /// <summary>
        /// Propiedad de lectura y escritura del atributo lista alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo clase
        /// </summary>
        public EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region constructor

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.Instructor = instructor;
        
        }
        #endregion

        #region metodos
        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool rtn = false;
            string path = AppDomain.CurrentDomain.BaseDirectory;

            Texto auxTexto = new Texto();
            rtn = auxTexto.Guardar(path + @"Jornada.txt", jornada.ToString());

            return rtn;
        }

        /// <summary>
        /// Retorna los datos de la Jornada como texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto auxTexto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (!auxTexto.Leer(path + @"Jornada.txt", out string ret))
            {
                ret = null;
            }

            return ret.ToString();
        }

        /// <summary>
        /// Muestra todos los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Alumnos.Count > 0)
            {
                sb.AppendLine("\n JORNADA:\n");
                
                sb.AppendFormat("CLASE DE {0}. POR {1}\n ALUMNOS:\n", this.clase, this.instructor);
                foreach (Alumno item in this.Alumnos)
                {
                    sb.AppendFormat("{0}\n", item.ToString());
                }
                sb.AppendLine("<--------------------------------------------->\n");
            }
          
            return sb.ToString();
        }

        #endregion

        #region operadores
        /// <summary>
        ///  Una Jornada será igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool ret = false;
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        /// <summary>
        ///  Una Jornada será distinto a un Alumno si el mismo no participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega Alumnos a la clase por medio del operador +, validando que no estén previamente cargados
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);

            return j;
        }

        #endregion
    }
}
