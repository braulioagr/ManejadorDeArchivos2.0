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

        public Primario(string nombre, long dirAct, NodoIndicePrimario[] idx, int tamañoArreglo, long dirSig) : base(nombre, dirAct, dirSig)
        {
            this.tamañoArreglo = tamañoArreglo;
            this.idx = idx;
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
        #region Busqueda

        public override int indiceLlave(string llave)
        {
            int j;
            j = -1;
            for(int i = 0 ; i < this.idx.Length; i++)
            {
                if(idx[i].Llave.Equals(llave))
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        public override bool existeLlave(string llave)
        {
            bool band;
            band = false;
            for (int i = 0; i < this.idx.Length; i++)
            {
                if (idx[i].Llave.Equals(llave))
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        private bool vacio()
        {
            bool band;
            band = true;
            foreach(NodoIndicePrimario nodo in idx)
            {
                if(nodo.Direccion != -1)
                {
                    band = false;
                    break;
                }
            }
            return band;
        }

        #endregion

        public void alta(string llave, long dir)
        {
            NodoIndicePrimario nodoIndicePrimario;
            nodoIndicePrimario = new NodoIndicePrimario(llave, dir);
            this.idx[this.EspacioLibre] = nodoIndicePrimario;
            this.idx = idx.OrderBy(nodo => nodo.Llave).ToArray();
        }

        public void modifica(string llave, string nuevaLlave)
        {
            int i;
            i = indiceLlave(llave);
            this.idx[i].Llave = nuevaLlave;
            this.idx = idx.OrderBy(nodo => nodo.Llave).ToArray();
        }

        public bool elimina(string llave)
        {
            int i;
            i = indiceLlave(llave);
            this.idx[i].Llave = "null";
            this.idx[i].Direccion = -1;
            this.idx = idx.OrderBy(nodo => nodo.Llave).ToArray();
            return vacio();
        }
        #endregion
    }
}
