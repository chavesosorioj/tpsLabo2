using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Excepciones;
using Entidades;

namespace Entidades
{
    public class PasajeDAO
    {
        const string conexionStr = "Data Source=DESKTOP-MACDNF9\\SQLEXPRESS;Initial Catalog=Pasajes;Integrated Security=True"; 

        #region atributos

        static SqlConnection conexionBD;

        #endregion

        #region constructor
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        static PasajeDAO()
        {
            conexionBD = new SqlConnection();
            conexionBD.ConnectionString = conexionStr;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Metodo que guarda en la base de datos un pasaje
        /// En caso que no se haya podido guardar, se lanza la excepcion ArchivosException
        /// </summary>
        /// <param name="pasaje"></param>
        public static void GuardoPasajeBase(Pasaje pasaje)
        {
            string sql = "INSERT INTO ListaPasajes([Nombre], [Apellido], [DNI], [NumeroVuelo], [Provincia], [Precio], [Estado]) VALUES (@auxNombre, @auxApellido, @auxDni, @auxNumVuelo, @auxProvincia, @auxPrecio, @auxEstado)";
            try
            {
             
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexionBD;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
             
                comando.Parameters.Add(new SqlParameter("@auxNombre",pasaje.Pasajero.Nombre));
                comando.Parameters.Add(new SqlParameter("@auxApellido",pasaje.Pasajero.Apellido));
                comando.Parameters.Add(new SqlParameter("auxDni",pasaje.Pasajero.Dni));
                comando.Parameters.Add(new SqlParameter("auxNumVuelo",pasaje.NumeroVuelo));
                comando.Parameters.Add(new SqlParameter("auxProvincia",pasaje.Prov.ToString()));
                comando.Parameters.Add(new SqlParameter("auxPrecio",pasaje.PrecioVuelo));
                comando.Parameters.Add(new SqlParameter("auxEstado",pasaje.Estado.ToString()));
                
                comando.CommandText = sql;
                if (conexionBD.State != ConnectionState.Open)
                    conexionBD.Open();

             
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw new PasajeNoCargadoException();
            }
            finally
            {
                conexionBD.Close();
            }

        }
        /// <summary>
        /// Recibe un string por parametro y devuelve el un enumerado de tipo provincia
        /// </summary>
        /// <param name="auxProv"></param>
        /// <returns></returns>
        public static Pasaje.EProvincia MapeoProvincia(string auxProv)
        {
            switch(auxProv)
            {
                case "BuenosAires":
                    return Pasaje.EProvincia.BuenosAires;
                case "Mendoza":
                    return Pasaje.EProvincia.Mendoza;
                case "Jujuy":
                    return Pasaje.EProvincia.Jujuy;
                case "SanLuis":
                    return Pasaje.EProvincia.SanLuis;
                default:
                    return Pasaje.EProvincia.Salta; 
            }

        }
        /// <summary>
        /// Recibe un string por parametro y devuelve un enum de tipo EEstado
        /// </summary>
        /// <param name="auxEstado"></param>
        /// <returns></returns>
        public static Pasaje.EEstadoViaje MapeoEstado(string auxEstado)
        {
            switch (auxEstado)
            {
                case "vendido":
                    return Pasaje.EEstadoViaje.vendido;
                case "cancelado":
                    return Pasaje.EEstadoViaje.cancelado;
                case "abordar":
                    return Pasaje.EEstadoViaje.abordar;
                default:
                    return Pasaje.EEstadoViaje.destino;
            }
        }

        public static List<Pasaje> GetPasajes()
        {
            List<Pasaje> auxLista = new List<Pasaje>();
            Pasajero auxPasajero;

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexionBD;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM ListaPasajes";

                if (conexionBD.State != ConnectionState.Open)
                    conexionBD.Open();

                SqlDataReader pasajesLista = comando.ExecuteReader();

                while(pasajesLista.Read())
                {
                    auxPasajero = new Pasajero(pasajesLista["Nombre"].ToString(), 
                                                pasajesLista["Apellido"].ToString(), 
                                                int.Parse(pasajesLista["DNI"].ToString()));

                    auxLista.Add(new Pasaje(auxPasajero,
                                MapeoProvincia(pasajesLista["Provincia"].ToString()),
                                MapeoEstado(pasajesLista["Estado"].ToString()),
                                int.Parse(pasajesLista["Precio"].ToString()),
                                int.Parse(pasajesLista["NumeroVuelo"].ToString())
                                ));
              
                }

            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            finally
            {
                conexionBD.Close();
            }


            return auxLista;
        }

        /*
        public static bool CancelarPasaje(Pasaje pasaje)
        {
            bool ret = false;

            string sqlUpdate = "UPDATE ListaPasaje SET Estado = @auxEstado WHERE ";

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexionBD;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sqlUpdate;

                comando.Parameters.Add(new SqlParameter("@auxNombre", pasaje.Pasajero.Nombre));
                comando.Parameters.Add(new SqlParameter("@auxApellido", pasaje.Pasajero.Apellido));
                comando.Parameters.Add(new SqlParameter("auxDni", pasaje.Pasajero.Dni));
                comando.Parameters.Add(new SqlParameter("auxNumVuelo", pasaje.NumeroVuelo));
                comando.Parameters.Add(new SqlParameter("auxProvincia", pasaje.Prov.ToString()));
                comando.Parameters.Add(new SqlParameter("auxPrecio", pasaje.PrecioVuelo));
                comando.Parameters.Add(new SqlParameter("auxEstado", pasaje.Estado.ToString()));

                if (conexionBD.State != ConnectionState.Open)
                    conexionBD.Open();


                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
           



            return ret;
        }

        */
        #endregion
    }
}
