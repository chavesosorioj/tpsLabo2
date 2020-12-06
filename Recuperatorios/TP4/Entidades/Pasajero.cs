using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pasajero
    {
        #region atributos
        string nombre;
        string apellido;
        int dni;
        #endregion

        #region  propiedades
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
       public int Dni { get => dni; set => dni = value; }

        #endregion

        #region constructor
        public Pasajero(string nombre, string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
           this.dni = dni;
        }
               
        #endregion

        #region metodos

        public string DatosPasajero()
        {
           return string.Format("{0}, {1}, DNI {2}", this.nombre, this.apellido, this.dni);
        }


        #endregion
    }
}
