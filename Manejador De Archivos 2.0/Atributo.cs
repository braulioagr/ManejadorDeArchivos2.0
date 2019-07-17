using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_De_Archivos_2._0
{
    class Atributo
    {

        #region Variables de Instancia
        private string entidad;//Nombre de la entidad en la que pertenece
        private long dirActual;//Direccion en el archivo
        private string nombre;//Nombre del atributo
        private char tipo;//Tipo de dato de este atributo
        private int indice;//Tipo de indice al que pertenece
        private int longitud;//Longitud del tipo de dato
        private long dirIndice;//Direccion del inicio del indice de este atributo en el archivo
        private long dirSig;//Dirección en e archivo del siguiente atributo
        //private List<Indice> indices;
        #endregion

        #region Constructores
        public Atributo(string entidad, string nombre, long dirActual, char tipo, int indice, int longitud, long dirIndice, long dirSig)
        {
            this.dirActual = dirActual;
            this.entidad = entidad;
            this.nombre = nombre;
            this.tipo = tipo;
            this.indice = indice;
            this.longitud = longitud;
            this.dirIndice = dirIndice;
            this.dirSig = dirSig;
        }
        #endregion

        #region Gets & Sets

        public long DirActual
        {
            get { return this.dirActual; }
            //set { this.dirActual = value; }
        }

        public string Entidad
        {
            get { return this.entidad; }
            //set { this.entidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            //set { this.nombre = value; }
        }

        public char Tipo
        {
            get { return this.tipo; }
            //set { this.tipo = value; }
        }

        public int Indice
        {
            get { return this.indice; }
            //set { this.indice = value; }
        }

        public int Longitud
        {
            get { return this.longitud; }
            //set { this.longitud = value; }
        }

        public long DirIndice
        {
            get { return this.dirIndice; }
            //set { this.dirIndice = value; }
        }

        public long DirSig
        {
            get { return this.dirSig; }
            set { this.dirSig = value; }
        }
        #endregion
        
        #region Metodos
        #endregion
    }
}
