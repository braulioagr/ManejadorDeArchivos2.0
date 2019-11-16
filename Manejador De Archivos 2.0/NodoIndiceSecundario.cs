using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador_De_Archivos_2._0
{
    class NodoIndiceSecundario
    {

        #region Variables de Instancia
        private long[] apuntadores;
        private long direccion;
        private string llave;
        #endregion

        #region Constructor
        public NodoIndiceSecundario(string llave, long direccion)
        {
            this.llave = llave;
            this.direccion = direccion;
            apuntadores = new long[Constantes.tamNodoAux];
            for (int i = 0; i < apuntadores.Length; i++)
            {
                this.apuntadores[i] = -1;
            }
        }
        #endregion

        #region Gets & Sets

        public string Llave
        {
            get { return this.llave; }
        }

        public long[] Apuntadores
        {
            get { return this.apuntadores; }
        }

        public long Direccion
        {
            get { return this.direccion; }
        }
        
        #endregion

        #region Metodos
        public void alta(long direccion, string directorio)
        {
            int i;
            i = 0;
            if (this.especioLibreAuxiliares(ref i))
            {
                this.apuntadores[i] = direccion;
            }
            /**else
            {
                long dirAct;
                dirAct = MetodosAuxiliares.ultimaDireccionDeArchivo(directorio);
                nodo = new NodoAuxiliar(dirAct);
                nodo.altaDireccion(direccion);
                if(this.nodos.Count > 0)
                {
                    nodos.Last().DirSiguiente = nodo.DirAct;
                }
                this.nodos.Add(nodo);
            }*/
        }

        public override string ToString()
        {
            return MetodosAuxiliares.truncaCadena(this.llave) + "," + this.direccion.ToString();
        }

        private bool especioLibreAuxiliares(ref int j)
        {
            bool band;
            band = false;
            for(int i = 0 ;  i < this.apuntadores.Length; i++)
            {
                if (this.apuntadores[i] == -1)
                {
                    j = i;
                    band = true;
                    break;
                }
            }
            return band;
        }

        #endregion

    }
}
