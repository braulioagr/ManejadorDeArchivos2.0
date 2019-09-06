using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_De_Archivos_2._0
{
    class Registro
    {

        #region Variables de Instancia
        private long dirAct;
        private List<string> datos;
        private long dirSig;
        #endregion

        #region Constructores
        public Registro(long dirAct,List<string> datos)
        {
            this.dirAct = dirAct;
            this.datos = datos;
            this.dirSig = -1;
        }
        #endregion

        #region Gets & Sets
        public long DirAct
        {
            get { return this.dirAct; }
        }

        /*
        public string ClaveDeBusqueda
        {
            get { return this.claveDeBusqueda; }
        }
        */

        public List<string> Datos
        {
            get { return this.datos; }
        }


        public long DirSig
        {
            set { this.dirSig = value; }
            get { return this.dirSig; }
        }

        #endregion
        
    }
}
