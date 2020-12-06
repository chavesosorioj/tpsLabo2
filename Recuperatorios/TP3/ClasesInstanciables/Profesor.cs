using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region atributos
        Queue<EClases> clasesDelDia;
        static Random random;

        #endregion

        #region constructor
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        private Profesor() : base()
        {
        }
        /// <summary>
        /// Consutructor de instancia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        #endregion

        #region metodos 
        /// <summary>
        /// Le asigna dos clases random a un profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                switch (random.Next(4))
                {
                    case 1:
                        this.clasesDelDia.Enqueue(EClases.Programacion);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(EClases.Laboratorio);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(EClases.Legislacion);
                        break;
                    case 4:
                        this.clasesDelDia.Enqueue(EClases.SPD);
                        break;

                    default:
                        break;
                }

            }
        }
        /// <summary>
        /// Muestra todos los datos del profesor. 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        ///  Retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nCLASES DEL DIA: \n");
            foreach (EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
           
            return sb.ToString();
        }

        /// <summary>
        /// ToString hará públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region operadores
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool ret = false;
            foreach (EClases item in i.clasesDelDia)
            {
                if (item == clase)
                    ret = true;
                break;
            }
            return ret;
        }
        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
