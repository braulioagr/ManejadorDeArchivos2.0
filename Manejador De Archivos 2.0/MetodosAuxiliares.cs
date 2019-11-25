using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_De_Archivos_2._0
{
    class MetodosAuxiliares
    {

        #region Archivos

        public static long ultimaDireccionDeArchivo(string directorio)
        {
            long direccion;
            FileStream abierto;
            abierto = new FileStream(directorio, FileMode.Append);//abre el archivo en un file stream
            direccion = (long)abierto.Seek(0, SeekOrigin.End);//Calcula la direccion final del archivo y lo mete en un long
            abierto.Close();
            return direccion;
        }

        #endregion

        #region Manipulacion de Cadenas
        public static string ajustaCadena(string cadena, int tam)
        {
            if (cadena.Length < tam)
            {
                do
                {
                    cadena += "&";
                } while (cadena.Length < tam);
            }
            if (cadena.Length > tam)
            {
                cadena = cadena.Substring(0, tam);
            }
            return cadena;
        }

        public static string truncaCadena(string cad)
        {
            String aux;
            aux = cad.Replace("&", "");
            return aux;
        }
        #endregion

        #region Indices
        public static string traduceIndice(int i)
        {
            string indice;
            indice = "";
            switch (i)
            {
                case 0:
                    indice = "0: Sin indice";
                    break;
                case 1:
                    indice = "1: Clave de Busqueda";
                    break;
                case 2:
                    indice = "2: Llave Primaria";
                    break;
                case 3:
                    indice = "3: Llave Foranea";
                    break;
                case 4:
                    indice = "4: Indice Secundario";
                    break;
                case 5:
                    indice = "5: Hash Estatica";
                    break;
            }
            return indice;
        }
        public static int calculaTamIdxPrim(int tamllave)
        {
            int tamaño;
            tamaño = -1;
            tamllave += 8;
            tamaño = (int)Math.Floor((decimal)(Constantes.tamIdx / tamllave));
            while (tamaño * tamllave + 8 >= Constantes.tamIdx)
            {
                tamaño--;
            }
            return tamaño;
        }
        #endregion

    }
}
