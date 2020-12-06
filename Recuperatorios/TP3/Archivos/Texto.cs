using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo <string>
    {
        /// <summary>
        /// Guarda el tipo de dato pasado por parametro en el archivo indicado por parametro
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si se pudo escribir, caso contrario retorna false</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter auxEscribir = new StreamWriter(archivo))
                         auxEscribir.Write(datos);
               
            }
            catch (Exception e)
            {
                return false;
                throw new ArchivosException(e);
            }
            return true;
        }
        /// <summary>
        /// Lee los archivos de tipo string pasados por parametro
        /// </summary>
        /// <param name="archivos"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si se pudieron cargar, caso contrario retorna false</returns>
        public bool Leer(string archivos, out string datos)
        {
            datos = "";
            try
            {
                using (StreamReader leeArhivo = new StreamReader(archivos))
                    datos = leeArhivo.ReadToEnd();
            }
            catch (Exception e)
            {
                return false;
                throw new ArchivosException(e);
            }

            return true;
        }
    }
}
