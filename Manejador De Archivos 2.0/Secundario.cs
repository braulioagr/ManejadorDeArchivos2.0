using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador_De_Archivos_2._0
{
    class Secundario : Indice
    {

        #region Variables de Instancia
        private NodoIndiceSecundario[] nodos;
        private BinaryReader reader;
        private BinaryWriter writer;
        #endregion

        #region Constructores

        public Secundario(string nombre, long dirAct, int tamañoArreglo, long dirSig) : base(nombre, dirAct, dirSig)
        {
            this.nodos = new NodoIndiceSecundario[tamañoArreglo];
            NodoIndiceSecundario nodo;
            for (int i = 0; i < nodos.Length; i++)
            {
                nodo = new NodoIndiceSecundario("-1", -1);
                this.nodos[i] = nodo;
            }
        }

        public Secundario(string nombre, long dirAct, NodoIndiceSecundario[] idx, long dirSig) : base(nombre, dirAct, dirSig)
        {
            this.nodos = idx;
        }
        #endregion

        #region Gets & Sets
        public NodoIndiceSecundario[] Nodos
        {
            get { return this.nodos; }
        }
        #endregion

        #region Metodos

        #region Busqueda

        public int espacioLibre()
        {
            int idx;
            idx = -1;
            for (int i = 0; i < this.nodos.Length; i++)
            {
                if (this.nodos[i].Direccion == -1)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }

        public override bool existeLlave(string llave)
        {
            bool band;
            band = false;
            foreach (NodoIndiceSecundario nodo1 in this.nodos)
            {
                if (nodo1.Llave.Equals(llave))
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        public override int indiceLlave(string llave)
        {
            int idx;
            idx = -1;
            for (int i = 0; i < this.nodos.Length; i++)
            {
                if (llave.Equals(this.nodos[i].Llave))
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }

        public bool existeEspacioLibre()
        {
            bool band;
            band = false;
            for (int i = 0; i < this.nodos.Length; i++)
            {
                if (nodos[i].Direccion == -1)
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        #endregion

        #region Operaciones
        public void alta(string llave, long direccion, string directorio)
        {
            int i;
            i = -1;
            if (this.existeLlave(llave))
            {
                i = this.indiceLlave(llave);
                this.nodos[i].alta(direccion,directorio);
            }
            else
            {
                //////if (this.existeEspacioLibre())
                {
                    i = this.espacioLibre();
                    long dir;
                    dir = MetodosAuxiliares.ultimaDireccionDeArchivo(directorio);
                    this.nodos[i] = new NodoIndiceSecundario(llave, dir);
                    this.grabaNodosAuxiliares(this.nodos[i], directorio);
                    this.nodos[i].alta(direccion,directorio);
                }
            }
            this.nodos = this.nodos.OrderBy(nodo => nodo.Llave).ToArray();
            this.grabaNodosAuxiliares(this.nodos[i],directorio);
        }

        #endregion

        #region Lectura y Grabado de Datos

        public void grabaNodosAuxiliares(NodoIndiceSecundario nodo,string directorio)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    long dirSiguiente;
                    this.writer.Seek((int)nodo.Direccion, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    foreach(NodoAuxiliar nodoAuxiliar in nodo.Nodos)
                    {
                        for(int i = 0 ;  i < nodoAuxiliar.Apuntadores.Length ; i++)
                        {
                            this.writer.Write(nodoAuxiliar.Apuntadores[i]);
                        }
                        dirSiguiente = nodoAuxiliar.Apuntadores.Last();
                        if(dirSiguiente!= -1)
                        {
                            this.writer.Seek((int)dirSiguiente, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void leeNodosAuxiliare(string directorio)
        {

        }

        #endregion

        #endregion

    }
}
