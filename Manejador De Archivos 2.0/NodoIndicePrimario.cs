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
            get { return this.llave; }
        }

        public long Direccion
        {
            get { return this.direccion; }
        }
        
        #endregion

    }
}
