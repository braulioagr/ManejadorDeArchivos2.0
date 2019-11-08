using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador_De_Archivos_2._0
{
    class Atributo
    {

        #region Variables de Instancia
        private string entidad;//Nombre de la entidad en la que pertenece
        private long dirActual;//Direccion en el archivo
        private string nombre;//Nombre del atributo
        private char tipo;//Tipo de dato de este atributo
        private int indice;//Tipo de indice al que pertenece
        private int longitud;//Longitud del tipo de dato
        private long dirIndice;//Direccion del inicio del indice de este atributo en el archivo
        private long dirSig;//Dirección en e archivo del siguiente atributo
        private List<Indice> indices;
        private BinaryWriter writer;
        private BinaryReader reader;
        #endregion

        #region Constructores
        public Atributo(string entidad, string nombre, long dirActual, char tipo, int indice, int longitud, long dirIndice, long dirSig)
        {
            this.dirActual = dirActual;
            this.entidad = entidad;
            this.nombre = nombre;
            this.tipo = tipo;
            this.indice = indice;
            this.longitud = longitud;
            this.dirIndice = dirIndice;
            this.dirSig = dirSig;
            this.indices = new List<Indice>();
        }
        #endregion

        #region Gets & Sets

        public long DirActual
        {
            get { return this.dirActual; }
            //set { this.dirActual = value; }
        }

        public string Entidad
        {
            get { return this.entidad; }
            //set { this.entidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            //set { this.nombre = value; }
        }

        public char Tipo
        {
            get { return this.tipo; }
            //set { this.tipo = value; }
        }

        public int Indice
        {
            get { return this.indice; }
            //set { this.indice = value; }
        }

        public int Longitud
        {
            get { return this.longitud; }
            //set { this.longitud = value; }
        }

        public long DirIndice
        {
            get { return this.dirIndice; }
            //set { this.dirIndice = value; }
        }

        public long DirSig
        {
            get { return this.dirSig; }
            set { this.dirSig = value; }
        }

        public List<Indice> Indices
        {
            get { return this.indices; }
        }
        #endregion

        #region Metodos

        #region Indices

        #region Primario
        public void altaIndicePrimario(string llave, long dir, string directorio)
        {
            int longitud;
            long dirIdx;
            Indice indice;
            dirIdx = -1;
            longitud = MetodosAuxiliares.calculaTamIdxPrim(this.longitud);
            dirIdx = MetodosAuxiliares.ultimaDireccionDeArchivo(directorio);
            if (this.indices.Count == 0)
            {
                indice = new Primario(this.nombre, dirIdx, longitud, -1);
                ((Primario)indice).alta(llave, dir);
                this.indices.Add(indice);
            }
            else
            {
                bool band;
                band = false;
                foreach(Indice idx in this.indices)
                {
                    if(((Primario)idx).EspacioLibre !=-1)
                    {
                        ((Primario)idx).alta(llave, dir);
                        band = true;
                        break;
                    }
                }
                if (!band)
                {
                    indice = new Primario(this.nombre, dirIdx, longitud, -1);
                    ((Primario)indice).alta(llave, dir);
                    this.indices.Last().DirSig = indice.DirAct;
                    this.indices.Add(indice);
                }
            }
            this.dirIndice = this.indices.First().DirAct;
            foreach (Indice idx in this.indices)
            {
                this.grabaIndicePrimario((Primario)idx,directorio);
            }

        }
        
        public void modificaIndicePrimario(string llave, string nuevaLlave, string directorio)
        {
            foreach(Indice indice in this.indices)
            {
                if (((Primario)indice).existeLlave(llave))
                {
                    ((Primario)indice).modifica(llave,nuevaLlave);
                    break;
                }
            }
            this.dirIndice = this.indices.First().DirAct;
            foreach (Indice idx in this.indices)
            {
                this.grabaIndicePrimario((Primario)idx, directorio);
            }
        }

        public void eliminaIndicePrimario(string llave, string directorio)
        {
            foreach (Indice indice in this.indices)
            {
                if (((Primario)indice).existeLlave(llave))
                {
                    if(((Primario)indice).elimina(llave))
                    {
                        this.indices.Remove(indice);
                        for(int i = 0 ; i < this.indices.Count - 1 ; i++)
                        {
                            this.indices[i].DirSig = this.indices[i + 1].DirAct;
                        }
                    }
                    break;
                }
            }
            this.dirIndice = this.indices.First().DirAct;
            foreach (Indice idx in this.indices)
            {
                this.grabaIndicePrimario((Primario)idx, directorio);
            }
        }

        #endregion

        #region Secundario

        public void altaIndiceSecundario(string llave, long direccion, string directorio)
        {
            int longitud;
            long dirIdx;
            Secundario indice;
            dirIdx = -1;
            indice = null;
            longitud = MetodosAuxiliares.calculaTamIdxPrim(this.longitud);
            dirIdx = MetodosAuxiliares.ultimaDireccionDeArchivo(directorio);
            if (this.indices.Count == 0)
            {
                indice = new Secundario(this.nombre, dirIdx, longitud, -1);
                this.grabaIndiceSecundario(indice, directorio);
                indice.alta(llave, direccion,directorio);
                this.indices.Add(indice);
            }
            else
            {
                bool band;
                band = this.buscaLlaveIndiceSecundario(llave, ref indice);
                if(band)
                {
                    indice.alta(llave, direccion,directorio);
                }
                else
                {
                    band = this.buscaEspacioLibre(ref indice);
                    if (band)
                    {
                        indice.alta(llave, direccion, directorio);
                    }
                    else
                    {
                        indice = new Secundario(this.nombre, dirIdx, longitud, -1);
                        this.grabaIndiceSecundario(indice, directorio);
                        indice.alta(llave, direccion, directorio);
                        //this.indices.Last().DirSig = indice.DirAct;
                        this.indices.Add(indice);
                    }
                }
            }
            this.dirIndice = this.indices.First().DirAct;
            foreach(Indice idx in this.indices)
            {
                this.grabaIndiceSecundario(indice, directorio);
            }
        }

        private bool buscaEspacioLibre(ref Secundario indice)
        {
            bool band;
            band = false;
            foreach(Indice idx in this.indices)
            {
                if(((Secundario)idx).existeEspacioLibre())
                {
                    indice = (Secundario)idx;
                    band = true;
                    break;
                }
            }
            return band;
        }

        private bool buscaLlaveIndiceSecundario(string llave, ref Secundario idx)
        {
            bool band;
            band = false;
            foreach (Indice idx1 in this.indices)
            {
                if (((Secundario)idx1).existeLlave(llave))
                {
                    idx = ((Secundario)idx1);
                    band = true;
                    break;
                }
            }
            return band;
        }

        #endregion

        #endregion

        #region Lectura y Grabado de Datos

        #region Indices

        public void leeIndices(string directorio)
        {
            switch(this.indice)
            {
                case 2:
                    if(this.dirIndice != -1)
                    {
                        this.leeIndicePrimario(directorio);
                    }
                break;
                case 4:
                    if (this.dirIndice != -1)
                    {
                        this.leeIndiceSecundario(directorio);
                    }
                break;
            }
        }

        #region Primario
        private void grabaIndicePrimario(Primario indice, string directorio)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    this.writer.Seek((int)indice.DirAct, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    for (int i = 0; i < indice.Idx.Length; i++)
                    {
                        if (this.tipo == 'C')
                        {
                            if (indice.Idx[i].Llave.Length != this.longitud)
                            {
                                MetodosAuxiliares.ajustaCadena(indice.Idx[i].Llave,this.longitud -1);
                            }
                            this.writer.Write(indice.Idx[i].Llave);
                        }
                        else if (this.tipo == 'E')
                        {
                            this.writer.Write(Int32.Parse(indice.Idx[i].Llave));
                        }
                        this.writer.Write(indice.Idx[i].Direccion);
                    }
                    this.writer.Write(indice.DirSig);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void leeIndicePrimario(string directorio)
        {
            try
            {
                Indice indice;
                long dirSig;
                int largo;
                string llave;
                long direccion;
                llave = "-1";
                direccion = -1;
                dirSig = this.dirIndice;
                largo = MetodosAuxiliares.calculaTamIdxPrim(this.longitud);
                NodoIndicePrimario[] nodos;
                nodos = new NodoIndicePrimario[largo];
                NodoIndicePrimario nodo;
                while (dirSig != -1)
                {
                    using (reader = new BinaryReader(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                    {
                        for( int i = 0; i < largo; i++ )
                        {
                            if (this.tipo == 'C')
                            {
                                llave = this.reader.ReadString();
                            }
                            else
                            {
                                llave = this.reader.ReadInt32().ToString();
                            }
                            direccion = this.reader.ReadInt64();
                            nodo = new NodoIndicePrimario(llave, direccion);
                            nodos[i] = nodo;
                        }
                        indice = new Primario(this.nombre, dirSig, nodos,largo, -1);
                        this.indices.Add(indice);
                        dirSig = reader.ReadInt64();
                    }
                }
                for(int i = 0 ; i< this.Indices.Count - 1 ; i++)
                {
                    this.indices[i].DirSig = this.indices[i + 1].DirAct;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region Secundario
        public void grabaIndiceSecundario(Secundario indice, string directorio)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    this.writer.Seek((int)indice.DirAct, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    for (int i = 0; i < indice.Nodos.Length; i++)
                    {
                        if (this.tipo == 'C')
                        {
                            if (indice.Nodos[i].Llave.Length != this.longitud)
                            {
                                MetodosAuxiliares.ajustaCadena(indice.Nodos[i].Llave, this.longitud - 1);
                            }
                            this.writer.Write(indice.Nodos[i].Llave);
                        }
                        else if (this.tipo == 'E')
                        {
                            this.writer.Write(Int32.Parse(indice.Nodos[i].Llave));
                        }
                        this.writer.Write(indice.Nodos[i].Direccion);
                    }
                    this.writer.Write(indice.DirSig);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void leeIndiceSecundario(String directorio)
        {
            try
            {
                Indice indice;
                long dirSig;
                int largo;
                string llave;
                long direccion;
                llave = "-1";
                direccion = -1;
                dirSig = this.dirIndice;
                largo = MetodosAuxiliares.calculaTamIdxPrim(this.longitud);
                NodoIndiceSecundario[] nodos;
                nodos = new NodoIndiceSecundario[largo];
                NodoIndiceSecundario nodo;
                while (dirSig != -1)
                {
                    using (reader = new BinaryReader(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                    {
                        reader.ReadBytes((int)dirSig);//Se posciona en la posición del iterador
                        for (int i = 0; i < largo; i++)
                        {
                            if (this.tipo == 'C')
                            {
                                llave = this.reader.ReadString();
                            }
                            else
                            {
                                llave = this.reader.ReadInt32().ToString();
                            }
                            direccion = this.reader.ReadInt64();
                            nodo = new NodoIndiceSecundario(llave, direccion);
                            nodos[i] = nodo;
                        }
                        indice = new Secundario(this.nombre, dirSig, nodos, -1);
                        this.indices.Add(indice);
                        dirSig = reader.ReadInt64();
                    }
                }
                for (int i = 0; i < this.Indices.Count - 1; i++)
                {
                    this.indices[i].DirSig = this.indices[i + 1].DirAct;
                }
                foreach (Indice idx in this.Indices)
                {
                    ((Secundario)idx).leeNodosAuxiliares(directorio);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #endregion

        #endregion

        #endregion

    }
}
