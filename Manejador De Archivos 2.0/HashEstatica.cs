using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_De_Archivos_2._0
{
    class HashEstatica : Indice
    { 
        #region Variables de Instancia
        private long[] direcciones;
        private long[,] apuntadores;
        private string[,] llaves;
        private int longitud;
        #endregion

        #region Constructores
        public HashEstatica(string nombre, long dir, int longitud, long dirSig, bool esCadena) : base(nombre, dir, dirSig)//OH no las cantantes!!!
        {
            this.direcciones = new long[Constantes.valorHash];
            this.longitud = MetodosAuxiliares.calculaTamIdxPrim(longitud);
            this.llaves = new string[Constantes.valorHash, this.longitud];
            this.apuntadores = new long[Constantes.valorHash, this.longitud];
            for(int i = 0 ; i < Constantes.valorHash ; i++)
            {
                this.direcciones[i] = -1;
                for (int j = 0; j < this.longitud; j++)
                {
                    this.llaves[i, j] = "-1";
                    this.apuntadores[i,j] = -1;
                    if (esCadena)
                    {
                        llaves[i, j] = MetodosAuxiliares.ajustaCadena(llaves[i, j], longitud);
                    }
                }
            }
        }
        #endregion

        #region Metodos

        public int alta(bool esCadena, char[] llave, int longitud,long dirección)
        {
            int i;
            int j;
            i = this.calculaCajon(esCadena, llave);
            j = this.buscaEspacioLibre(i);
            if(j > -1)
            {
                this.apuntadores[i, j] = dirección;
                this.llaves[i, j] = new string(llave);
                if (esCadena)
                {
                    llaves[i, j] = MetodosAuxiliares.ajustaCadena(llaves[i,j],longitud);
                }
            }
            return i;
        }

        public int[] modifica(bool esCadena, char[] llave, char[] nuevallave, long direccion, int longitud)
        {
            int[] refrencias;
            refrencias = new int[2];
            refrencias[0] = this.baja(esCadena, llave,longitud,direccion);
            refrencias[1] = this.alta(esCadena,nuevallave,longitud,direccion);
            return refrencias;
        }

        public int baja(bool esCadena, char[] llave, int longitud,long direccion)
        {
            int i;
            int j;
            i = this.calculaCajon(esCadena, llave);
            j = this.indiceLlave(i,direccion);
            if(j > -1)
            {
                this.apuntadores[i, j] = -1;
                llaves[i, j] = "-1";
                if(esCadena)
                {
                    llaves[i, j] = MetodosAuxiliares.ajustaCadena(llaves[i, j], longitud);
                }
            }
            return i;
        }

        private int indiceLlave(int i, long direccion)
        {
            int j;
            j = -1;
            for (int k = 0; k < Constantes.tamNodoAux; k++)
            {
                if (this.apuntadores[i, k] == direccion)
                {
                    j = k;
                    break;
                }
            }
            return j;
        }

        private int buscaEspacioLibre(int i)
        {
            int j;
            j = -1;
            for(int k = 0;  k < Constantes.tamNodoAux; k++)
            {
                if(this.apuntadores[i,k] == -1)
                {
                    j = k;
                    break;
                }
            }
            return j;
        }

        public int calculaCajon(bool esCadena, char[] llave)
        {
            int i;
            i = 0;
            for (int j = 0; j < llave.Length; j++)
            {
                if (llave[j] != '.' | esCadena)
                {
                    i += (int)llave[j];
                    if(!esCadena)
                    {
                        i -= 48;
                    }
                }
            }
            i %= Constantes.valorHash;
            return i;
        }

        public override int indiceLlave(string llave)
        {
            throw new NotImplementedException();
        }

        public override bool existeLlave(string llave)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region gets & sets

        public long[] Direcciones
        {
            get { return this.direcciones; }
        }

        public long[,] Apuntadores
        {
            get { return this.apuntadores; }
        }
        public string[,] Llaves
        {
            get { return this.llaves; }
        }
        public int Longitud
        {
            get { return this.longitud; }
        }

        public bool vacio()
        {
            bool band;
            band = true;
            for(int i = 0 ; i < Constantes.valorHash; i++)
            {
                for (int j = 0; j < this.longitud; j++)
                {
                    if (this.apuntadores[i, j] != -1)
                    {
                        band = false;
                        break;
                    }
                }
                if (!band)
                {
                    break;
                }
            }
            return band;
        }
        #endregion

    }
}
