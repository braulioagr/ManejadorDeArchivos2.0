using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_De_Archivos_2._0
{
    class NodoAuxiliar
    {

        #region Variables de Instancia
        private long[] apuntadores;
        private long dirAct;
        #endregion

        public NodoAuxiliar(long dirAct)
        {
            this.dirAct = dirAct;
            apuntadores = new long[Constantes.tamNodoAux];
            for (int i = 0; i < apuntadores.Length; i++)
            {
                apuntadores[i] = -1;
            }
        }

        #region Gets & Region

        public long[] Apuntadores
        {
            get { return this.apuntadores; }
        }

        public long DirSiguiente
        {
            get { return this.apuntadores.Last(); }
            set { this.apuntadores[this.apuntadores.Length - 1] = value; }
        }

        public long DirAct
        {
            get { return this.dirAct; }
        }

        #endregion

        #region Metodos

        public bool existeEspacioLibre()
        {
            bool band;
            band = false;
            foreach(long apuntador in this.Apuntadores)
            {
                if(apuntador == -1)
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        public int espacioLibre()
        {
            int index;
            index = -1;
            for(int i = 0 ; i < this.apuntadores.Length -1 ; i++)
            {
                if (this.apuntadores[i] == -1)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void altaDireccion(long direccion)
        {
            int i;
            i = this.espacioLibre();
            this.apuntadores[i] = direccion;
        }

        #endregion

    }
}
