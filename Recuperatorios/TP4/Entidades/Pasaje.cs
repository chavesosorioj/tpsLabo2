using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Entidades
{
    public class Pasaje 
    {
        #region Delegado
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region Evento
        public event DelegadoEstado InformaEstado;
        #endregion
        #region enumerado
        public enum EProvincia
        {
            BuenosAires,
            Mendoza,
            SanLuis,
            Salta,
            Jujuy
        }
        public enum EEstadoViaje
        {
            vendido,
            abordar,
            cancelado,
            destino
        }
        #endregion

        #region atributos
        Pasajero pasajero;
        static Random random;
        int numeroVuelo;
        EProvincia prov;
        EEstadoViaje estado;
        int precioVuelo;
        #endregion


        #region propiedades

        public EEstadoViaje Estado { get => estado; set => estado = value; }
        public int NumeroVuelo { get => precioVuelo; set => precioVuelo = value; }
        public EProvincia Prov { get => prov; set => prov = value; }
        public Pasajero Pasajero { get => pasajero; set => pasajero = value; }
        public int PrecioVuelo { get => precioVuelo; set => precioVuelo = value; }

        #endregion

        #region constructor
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Pasaje()
        {
            Pasaje.random = new Random();
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="pasajero"></param>
        /// <param name="prov"></param>
        public Pasaje(Pasajero pasajero, EProvincia prov) : this()
        {
            this.pasajero = pasajero;
            this.prov = prov;
            this.estado = EEstadoViaje.vendido;
            this.PrecioDeVuelo(prov);
            this.NumeroDeVuelo(prov);
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="pasajero"></param>
        /// <param name="prov"></param>
        public Pasaje(Pasajero pasajero, EProvincia prov, EEstadoViaje estado, int precio, int numeroV) : this(pasajero,prov)
        {
            this.pasajero = pasajero;
            this.prov = prov;
            this.estado = estado;
            this.precioVuelo = precio;
            this.numeroVuelo = numeroV;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Metodo que establece el precio de vuelo correspondiente segun el lugar de destino
        /// </summary>
        /// <param name="prov"></param>
        /// <returns>Retorna un int con el precio</returns>
        public void PrecioDeVuelo(EProvincia prov) 
        {
            switch(prov.ToString()) 
            {
                case "BuenosAires":
                    this.precioVuelo = 10000;
                    break;
                case "Mendoza":
                    this.precioVuelo = 11000;
                    break;
                case "SanLuis":
                    this.precioVuelo = 12000;
                    break;
                case "Salta":
                    this.precioVuelo = 13000;
                    break;
                default:
                    this.precioVuelo = 14000;
                    break;

            }

         }
        /// <summary>
        /// Metodo que genera un numero de vuelo de manera random, con un rango distinto para cada uno
        /// de las provincias a donde se seleccione un vuelo
        /// </summary>
        /// <param name="prov"></param>
        /// <returns>Retorna un int, el numero de vuelo</returns>
        public void NumeroDeVuelo(EProvincia prov)
        {
              switch (prov.ToString())             
              {
                case "BuenosAires":
                    this.numeroVuelo= random.Next(3500,6000);
                    break;
               case "Mendoza":
                    this.numeroVuelo = random.Next(6001, 9000);
                    break;
                case "SanLuis":
                    this.numeroVuelo = random.Next(9001, 11000);
                    break;
                case "Salta":
                    this.numeroVuelo = random.Next(11001, 12000);
                    break;
                default:
                    this.numeroVuelo = random.Next(12001, 13000);
                    break;

            }
        }
      
  
        /// <summary>
        /// Metodo que devuelve toda la informacion de un pasaje
        /// </summary>
        /// <returns></returns>
        public string DatosPasaje()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(pasajero.DatosPasajero());
            sb.AppendLine($"Numero de vuelo: {numeroVuelo}");
            sb.AppendLine($"Provincia: {prov}");
            sb.AppendLine($"Precio: {precioVuelo}");

            return sb.ToString();
        }
        /// <summary>
        /// Metodo que devuelve en un string solo la informacion del numero de vuelo y la provincia de destino
        /// </summary>
        /// <returns></returns>
        public string VuelosInformacion()
        {
            return string.Format($"{random}, {prov}");
        }

        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto.   // HAGO OTRO METODO CON ESTO ASI NO SE PARECE AL XML?
        /// </summary>
        /// <param name="pasaje"></param>
        /// <returns></returns>
        public static bool Guardar(Pasaje pasaje)
        {
            bool rtn = false;
            string path = AppDomain.CurrentDomain.BaseDirectory;

            Texto auxTexto = new Texto();
            rtn = auxTexto.Guardar(path + @"Pasajes.txt", pasaje.DatosPasaje());

            return rtn;
        }

        /// <summary>
        /// Metodo que calcula la provincia para que se compro mas pasajes de avion
        /// </summary>
        /// <param name="listaPasaje"></param>
        /// <returns>String con la provincia a la que mas vuelos se compro</returns>
        public string ProvinciaMasVendido(List<Pasaje> listaPasaje)
        {
            int contBA = 0, contMend = 0, contJu = 0, contSA = 0, contSANL = 0;
            string ret = "";
            foreach (Pasaje item in listaPasaje)
            {
                if (item.prov == EProvincia.BuenosAires)
                    contBA++;
                if (item.prov == EProvincia.Mendoza)
                    contMend++;
                if (item.prov == EProvincia.Jujuy)
                    contJu++;
                if (item.prov == EProvincia.Salta)
                    contSA++;
                if (item.prov == EProvincia.SanLuis)
                    contSANL++;
            }
            if ((contBA > contMend) && (contBA > contJu) && (contBA > contSA) && (contBA > contSANL))
                ret = "La provincia con mas vuelos es Buenos Aires";
            if ((contMend > contBA) && (contMend > contJu) && (contMend > contSA) && (contMend > contSANL))
                ret = "La provincia con mas vuelos es Mendoza";
            if ((contJu > contBA) && (contJu > contMend) && (contJu > contSA) && (contBA > contSANL))
                ret = "La provincia con mas vuelos es Jujuy";
            if ((contSA > contBA) && (contSA > contMend) && (contSA > contJu) && (contSA > contSANL))
                ret = "La provincia con mas vuelos es Salta";
            if ((contSANL > contBA) && (contSANL > contMend) && (contSANL > contJu) && (contSANL > contSA))
                ret = "La provincia con mas vuelos es San Luis";

            return ret;
        }


        #endregion

    }
}
