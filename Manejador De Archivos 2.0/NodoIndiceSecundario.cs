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
        private List<NodoAuxiliar> nodos;
        private long direccion;
        private string llave;
        #endregion

        #region Constructor
        public NodoIndiceSecundario(string llave, long direccion)
        {
            this.llave = llave;
            this.direccion = direccion;
            this.nodos = new List<NodoAuxiliar>();
        }
        #endregion

        #region Gets & Sets

        public string Llave
        {
            get { return this.llave; }
        }

        public List<NodoAuxiliar> Nodos
        {
            get { return this.nodos; }
        }

        public long Direccion
        {
            get { return this.direccion; }
        }
        
        #endregion

        #region Metodos
        public void alta(long direccion, string directorio)
        {
            NodoAuxiliar nodo;
            nodo = null;
            if (this.especioLibreAuxiliares(ref nodo))
            {
                if (this.direccion == -1)
                {
                    this.direccion = MetodosAuxiliares.ultimaDireccionDeArchivo(directorio);
                }
                nodo.altaDireccion(direccion);
            }
            else
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
            }
            this.direccion = this.nodos.First().DirAct;
        }

        public override string ToString()
        {
            return MetodosAuxiliares.truncaCadena(this.llave) + "," + this.direccion.ToString();
        }

        private bool especioLibreAuxiliares(ref NodoAuxiliar nodo)
        {
            bool band;
            band = false;
            foreach(NodoAuxiliar nodo1 in this.nodos)
            {
                if (nodo1.existeEspacioLibre())
                {
                    band = true;
                    nodo = nodo1;
                    break;
                }
            }
            return band;
        }

        #endregion

    }
}
