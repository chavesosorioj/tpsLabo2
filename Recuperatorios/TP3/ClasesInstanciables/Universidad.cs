using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using ClasesInstanciables;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region enumerados

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        #endregion
        #region atributos
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        #endregion

        #region propiedades

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornada
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
       public Jornada this[int i]
        {
            get { return this.jornada.ElementAt(i); }
            set { this.jornada.Insert(i, value); }
        }
        #endregion


        #region constructor
        /// <summary>
        /// Constructor de clase que inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornada = new List<Jornada>();
        }
        #endregion

        #region metodos
        /// <summary>
        /// Guarda la informacion de la universidad en un archivo xml. Si el guardado fue exitoso, retorna true.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if(!(uni is null))
            {
                Xml<Universidad> auxArchivo = new Xml<Universidad>();
                return auxArchivo.Guardar(path + @"Universidad.xml", uni);
            }
            return false;
        }
        /// <summary>
        /// lee un archivo xml con la informacion de la universidad. Retorna la informacion.       VER SI LE PONGO ALGUNA VALIDACION
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static Universidad Leer()
        {
           // Universidad auxUni = new Universidad();
            Xml<Universidad> auxArchivo = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            auxArchivo.Leer(path + @"Universidad.xml", out Universidad auxUni);

            return auxUni;
        }

        /// <summary>
        /// Metodo de clase privado que muestra la informacion de la clase Universidad recibida como parametro
        /// </summary>
        /// <param name="uni"> Universidad </param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in uni.jornada)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Retorna la informacion de la Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region operadores
        /// <summary>
        /// Al agregar una clase a una Universidad se genera y agrega una nueva jornada indicando la clase
        /// un profesor que pueda darla (segun el atributo clase del dia) y la lista de alumnos que la toman 
        /// (los que coinciden en su campo con ClaseDelDia)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor auxProf = g == clase;

            if (auxProf != null)
            {
                Jornada auxJornada = new Jornada(clase, auxProf);
                foreach (Alumno item in g.Alumnos)
                {
                    if (item == clase)
                         auxJornada= auxJornada + item;
                }
                g.jornada.Add(auxJornada);
            }
                return g;

        }
        /// <summary>
        /// Agrega un alumno a la universidad, se constata que no este agregado
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
                     return u;
            }
            else
                throw new AlumnoRepetidoException();

        }
        /// <summary>
        /// Agrega un profesor a la universidad constantando que no este previamente cargado
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                 u.profesores.Add(i);
            else
                Console.WriteLine("PROFESOR REPETIDO");

            return u;
        }
        
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool ret = false;
            foreach (Alumno item in g.Alumnos)
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
        ///  Un Universidad será distinto a un Alumno si el mismo no está inscripto en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está inscripto en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool ret = false;
            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        ///  Un Universidad será distinto a un profesor si el mismo no trabaja en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// El operador igual entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        // Sino, lanzará la Excepción SinProfesorException
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor aux = null;
            foreach (Profesor item in u.Instructores)
            {
                if(item == clase)
                {
                    aux = item;
                    break;
                }
            }
            if (aux != null)
                return aux;
            else
                throw new SinProfesorException();
           }

        /// <summary>
        ///  El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor aux = null;

            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    aux = item;
                    break;
                }
            }
            return aux;
        }
        #endregion
    }
}
