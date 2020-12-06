using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml <T> : IArchivo<T>
    {

        #region metodos
        /// <summary>
        /// Guarda serializado el tipo de dato que se le pase por parametro
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter escrArchivo = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializa = new XmlSerializer(typeof(T));
                    serializa.Serialize(escrArchivo, datos);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee un archivo serializado el tipo de clase por parametro
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si se logro levantar el archivo</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader leeArchivo = new XmlTextReader(archivo))
                {
                    XmlSerializer serializa = new XmlSerializer(typeof(T));
                    datos = (T)serializa.Deserialize(leeArchivo);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        #endregion
    }
}
