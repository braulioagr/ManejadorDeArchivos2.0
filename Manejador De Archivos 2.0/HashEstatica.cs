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
        #endregion

        #region Constructores
        public HashEstatica(string nombre, long dir, long dirSig) : base(nombre, dir, dirSig)//OH no las cantantes!!!
        {
            this.direcciones = new long[Constantes.valorHash];
            this.apuntadores = new long[Constantes.valorHash, Constantes.tamNodoAux];
            for(int i = 0 ; i < Constantes.valorHash ; i++)
            {
                this.direcciones[i] = -1;
                for (int j = 0; j < Constantes.tamNodoAux; j++)
                {
                    this.apuntadores[i,j] = -1;
                }
            }
        }
        #endregion

        #region Metodos

        public int alta(bool esCadena, char[] llave, long dirección)
        {
            int i;
            int j;
            i = this.calculaCajon(esCadena, llave);
            j = this.buscaEspacioLibre(i);
            if(j > -1)
            {
                this.apuntadores[i, j] = dirección;
            }
            return i;
        }

        public void modifica(bool esCadena, char[] llave, char[] nuevallave, long direccion)
        {
            this.baja(esCadena, llave, direccion);
            this.alta(esCadena,nuevallave,direccion);
        }

        public int baja(bool esCadena, char[] llave, long direccion)
        {
            int i;
            int j;
            i = this.calculaCajon(esCadena, llave);
            j = this.indiceLlave(i,direccion);
            if (j > -1)
            {
                this.apuntadores[i, j] = -1;
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
            return i;
        }

        private int buscaEspacioLibre(int i)
        {
            int j;
            j = -1;
            for(int k = 0;  k < Constantes.tamNodoAux; i++)
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
            if (esCadena)
            {
                for (int j = 0; j < llave.Length; j++)
                {
                    i += (int)llave[j];
                }
            }
            else
            {
                for (int j = 0; j < llave.Length; j++)
                {
                    i += ((int)llave[j])-48;
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

        #endregion

    }
}
