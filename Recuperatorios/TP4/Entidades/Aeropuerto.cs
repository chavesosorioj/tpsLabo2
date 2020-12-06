using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Excepciones;

namespace Entidades
{
    public class Aeropuerto
    {

        #region atributos
        List<Pasaje> listaPasajes;
        List<Thread> hilosAeropuerto; // mm cambiar nombre

       #endregion

        #region propiedades

        public List<Pasaje> ListaPasajes { get => listaPasajes; set => listaPasajes = value; }

        #endregion

        #region constructor

        public Aeropuerto()
        {
            this.listaPasajes = new List<Pasaje>();
            this.hilosAeropuerto = new List<Thread>();
        }

        #endregion

        #region metodos


        #endregion

        #region operadores

        public static Aeropuerto operator +(Aeropuerto aeropuerto, Pasaje pasaje)
        {
            bool repetido = false;
            if(!pasaje.Equals(null))
            {
                foreach (Pasaje item in aeropuerto.listaPasajes)
                {
                    if(item.Equals(pasaje))
                    {
                        repetido = true;
                        throw new PasajeRepetido();
                    }
                }
            }
            if(repetido is false)
            {
                aeropuerto.listaPasajes.Add(pasaje); 
                PasajeDAO.GuardoPasajeBase(pasaje);
            }
                

            return aeropuerto;

        }




        #endregion
    }
}
