using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_De_Archivos_2._0
{
    public class Primario : Indice
    {
        #region Variables de Instancia
        private int tamañoArreglo;
        private NodoIndicePrimario[] idx;
        #endregion

        #region Constructor
        public Primario(string nombre, long dirAct, int tamañoArreglo, long dirSig) : base(nombre, dirAct, dirSig)
        {
            this.tamañoArreglo = tamañoArreglo;
            this.idx = new NodoIndicePrimario[tamañoArreglo];
            for (int i = 0; i < tamañoArreglo; i++)
            {
                idx[i] = new NodoIndicePrimario("null", -1);
            }
        }
        #endregion

        #region Gets & Sets

        public NodoIndicePrimario[] Idx
        {
            get { return this.idx; }
        }

        public int EspacioLibre
        {
            get
            {
                int indice = -1;
                for (int i = 0; i < this.tamañoArreglo; i++)
                {
                    if (this.idx[i].Direccion == -1)
                    {
                        indice = i;
                        break;
                    }
                }
                return indice;
            }
        }

        #endregion

        #region Metodos
        public override void alta(string llave, long dir)
        {
            NodoIndicePrimario nodoIndicePrimario;
            nodoIndicePrimario = new NodoIndicePrimario(llave, dir);
            this.idx[this.EspacioLibre] = nodoIndicePrimario;
            this.idx = idx.OrderBy(nodo => nodo.Llave).ToArray();
        }
        #endregion
    }
}
