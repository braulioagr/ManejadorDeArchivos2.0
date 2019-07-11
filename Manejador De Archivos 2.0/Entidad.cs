using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_De_Archivos_2._0
{
    class Entidad
    {
        #region Variables de Instancia
        private string nombre;//Nombre de la entidad
        private long dirActual;//Direccion en el archivo de la entidad
        private long dirAtributos;//Direccion en el archivo de los atributos
        private long dirRegistros;//Direccion en el archivo de los registros
        private long dirSig;//Direccion en el archivo de la siguiente entidad
        private List<Atributo> atributos;
        private BinaryReader reader;//Objeto para leer el archivo
        private BinaryWriter writer;//Objeto para guardar el archivo
        #endregion
        
        #region Constructores
        public Entidad(string nombre, long dirActual, long dirAtributos, long dirRegistros, long dirSig)
        {
            this.nombre = nombre;
            this.dirActual = dirActual;
            this.dirAtributos = dirAtributos;
            this.dirRegistros = dirRegistros;
            this.dirSig = dirSig;
            this.atributos = new List<Atributo>();
        }
        #endregion

        #region Gets & Sets
        public long DirActual
        {
            get { return this.dirActual; }
        }
        public long DirAtributos
        {
            get { return this.dirAtributos; }
        }
        public long DirRegistros
        {
            get { return this.dirRegistros; }
        }
        public long DirSig
        {
            get { return this.dirSig; }
            set { this.dirSig = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public List<Atributo> Atributos
        {
            get { return this.atributos; }
        }
        #endregion
        #region Metodos
        #endregion
    }
}
