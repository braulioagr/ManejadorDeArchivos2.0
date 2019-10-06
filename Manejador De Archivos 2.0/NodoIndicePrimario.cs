using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_De_Archivos_2._0
{
    public class NodoIndicePrimario
    {
        #region Variables de Instanica
        private string llave;
        private long direccion;
        #endregion

        #region Constructor
        public NodoIndicePrimario(string llave, long direccion)
        {
            this.llave = llave;
            this.direccion = direccion;
        }
        #endregion

        #region Gets & Sets

        public string Llave
        {
            set { this.llave = value; }
            get { return this.llave; }
        }

        public long Direccion
        {
            set { this.direccion = value; }
            get { return this.direccion; }
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return MetodosAuxiliares.truncaCadena(this.llave) + "," + this.direccion.ToString();
        }
        #endregion

    }
}
