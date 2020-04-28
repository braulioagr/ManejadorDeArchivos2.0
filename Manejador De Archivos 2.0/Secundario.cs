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
        private string[] llaves;
        private long[] direcciones;
        private long[,] apuntadores;
        #endregion

        #region Constructores

        public Secundario(string nombre, long dirAct, int tamañoArreglo, int longitud,long dirSig,bool esCadena) : base(nombre, dirAct, dirSig)
        {
            llaves = new string[tamañoArreglo];
            this.direcciones = new long[tamañoArreglo];
            this.apuntadores = new long[tamañoArreglo, Constantes.tamNodoAux];
            for (int i = 0; i < llaves.Length; i++)
            {
                if (esCadena)
                {
                    this.llaves[i] = MetodosAuxiliares.ajustaCadena("-1", longitud);
                }
                else
                {
                    this.llaves[i] = "-1";
                }
                this.direcciones[i] = -1;
                for (int j = 0; j < Constantes.tamNodoAux; j++)
                {
                    this.apuntadores[i, j] = -1;
                }
            }
        }
        #endregion

        #region Gets & Sets
        public string[] Llaves
        {
            get { return this.llaves; }
        }
        public long[,] Apuntadores
        {
            get { return this.apuntadores; }
        }
        public long[] Direcciones
        {
            get { return this.direcciones; }
        }
        public bool estaVacio()
        {
                bool band;
                band = true;
                foreach(string llave in this.llaves)
                {
                    if(!("-1").Equals(MetodosAuxiliares.truncaCadena(llave)))
                    {
                        band = false;
                        break;
                    }
                }
                return band;
        }
        #endregion

        #region Metodos

        #region Busqueda

        public override int indiceLlave(string llave)
        {
            int band;
            band = -1;
            for(int i = 0;  i < this.llaves.Length; i++)
            {
                if (this.llaves[i].Equals(llave))
                {
                    band = i;
                    break;
                }
            }
            return band;
        }

        public override bool existeLlave(string llave)
        {
            bool band;
            band = false;
            foreach(string key  in this.llaves)
            {
                if(key.Equals(llave))
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        private int espacioLibre(int i)
        {
            int j;
            j = -1;
            for (int k = 0; k < Constantes.tamNodoAux; k++)
            {
                if (this.apuntadores[i, k] == -1)
                {
                    j = k;
                    break;
                }
            }
            return j;
        }

        private int espacioLibre()
        {
            int j;
            j = -1;
            for(int i = 0; i < this.llaves.Length; i++)
            {
                if(MetodosAuxiliares.truncaCadena(this.llaves[i]).Equals("-1"))
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        private bool estaVacio(int i)
        {
            bool band;
            band = true;
            for (int j = 0; j < Constantes.tamNodoAux; j++)
            {
                if (this.apuntadores[i, j] != -1)
                {
                    band = false;
                    break;
                }
            }
            return band;
        }

        private int espacioDireccion(int i, long direccion)
        {
            int band;
            band = -1;
            for (int j = 0; j < Constantes.tamNodoAux; j++)
            {
                if (this.apuntadores[i, j] == direccion)
                {
                    band = j;
                    break;
                }
            }
            return band;
        }


        #endregion

        public int alta(string llave, long direccion)
        {
            int i;
            int j;
            i = -1;
            j = -1;
            if (this.existeLlave(llave))
            {
                i = this.indiceLlave(llave);
                j = this.espacioLibre(i);
                if (j != -1)
                {
                    this.apuntadores[i, j] = direccion;
                }
            }
            else
            {
                i = this.espacioLibre();
                if (i != -1)
                {
                    j = this.espacioLibre(i);
                    if (j != -1)
                    {
                        llaves[i] = llave;
                        this.apuntadores[i, j] = direccion;
                    }
                }
            }
            return i;
        }


        public int baja(string llave, long direccion,bool esCadena,int longitud)
        {
            int i;
            int j;
            i = -1;
            j = -1;
            if (this.existeLlave(llave))
            {
                i = this.indiceLlave(llave);
                j = this.espacioDireccion(i,direccion);
                if (j != -1)
                {
                    this.apuntadores[i, j] = -1;
                    if (this.estaVacio(i))
                    {
                        if (esCadena)
                        {
                            this.llaves[i] = MetodosAuxiliares.ajustaCadena("-1", longitud);
                        }
                        else
                        {
                            this.llaves[i] = "-1";
                        }
                        
                    }
                }
            }
            return i;
        }

        public int[] modificacion(string llave, string nuevallave, long direccion,bool esCadena,int longitud)
        {
            int[] direcciones;
            direcciones = new int[2];
            direcciones[0] = this.baja(llave, direccion, esCadena,longitud);
            direcciones[1] = this.alta(nuevallave, direccion);
            return direcciones;
        }

        #endregion

    }
}
