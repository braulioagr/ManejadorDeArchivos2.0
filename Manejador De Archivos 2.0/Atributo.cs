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
            if (this.indices.Count > 0)
            {
                this.dirIndice = this.indices.First().DirAct;
            }
            else
            {
                this.dirIndice = -1;
            }
            foreach (Indice idx in this.indices)
            {
                this.grabaIndicePrimario((Primario)idx, directorio);
            }
        }

        #endregion

        #region Secundario

        public void altaIndiceSecundario(string llave, long direccion, string directorio)
        {
            bool band;
            band = this.tipo.Equals('C');
            if (this.dirIndice == -1)
            {
                Secundario secunadrio;
                secunadrio = new Secundario(this.nombre, this.dirIndice, MetodosAuxiliares.calculaTamIdxPrim(this.longitud),this.longitud, -1, band);
                this.indices.Add(secunadrio);
                for (int i = 0; i < secunadrio.Direcciones.Length; i++)
                {
                    secunadrio.Direcciones[i] = MetodosAuxiliares.ultimaDireccionDeArchivo(directorio);
                    this.grabaApuntadoresSecundario(directorio, secunadrio, secunadrio.Direcciones[i], i);
                }
                this.dirIndice = MetodosAuxiliares.ultimaDireccionDeArchivo(directorio);
                this.grabaDireccionesSecundario(directorio, secunadrio);
            }
            int idx;
            idx = ((Secundario)this.indices.First()).alta(llave, direccion);
            this.grabaApuntadoresSecundario(directorio, ((Secundario)this.indices.First()), ((Secundario)this.indices.First()).Direcciones[idx], idx);
            this.grabaDireccionesSecundario(directorio, ((Secundario)this.indices.First()));
        }

        public void modificaIndiceSecundario(string llaveOriginal, string nuevallave, long dirAct, string archivoIdx)
        {
            int[] direcciones;
            bool esCadena;
            Secundario secundario;
            esCadena = this.tipo.Equals('C');
            secundario = ((Secundario)this.indices.First());
            direcciones = secundario.modificacion(llaveOriginal, nuevallave, dirAct,esCadena, this.longitud-1);
            for (int i = 0; i < direcciones.Length; i++)
            {
                this.grabaApuntadoresSecundario(archivoIdx, secundario, secundario.Direcciones[direcciones[i]], direcciones[i]);
            }
            this.grabaDireccionesSecundario(archivoIdx, secundario);
        }

        public void elimminaSecundario(string llave, long direccion,string directorio)
        {
            bool band;
            int idx;
            Secundario secundario;
            band = this.tipo.Equals('C');
            secundario = ((Secundario)this.indices.First());
            idx = secundario.baja(llave, direccion,this.tipo.Equals('C'),this.longitud-1);
            this.grabaApuntadoresSecundario(directorio, secundario, secundario.Direcciones[idx], idx);
            this.grabaDireccionesSecundario(directorio, secundario);
            if (secundario.estaVacio())
            {
                this.dirIndice = -1;
                this.indices.Remove(secundario);
            }

        }
        #endregion

        #region Las cantantes
        public void altaHash(string llave, long direccion, string directorio)
        {
            bool band;
            band = false;
            if(this.dirIndice == -1)
            {
                HashEstatica hash;
                hash = new HashEstatica(this.nombre, this.dirIndice, -1);
                this.indices.Add(hash);
                for(int i = 0 ;  i < hash.Direcciones.Length; i++)
                {
                    hash.Direcciones[i] = MetodosAuxiliares.ultimaDireccionDeArchivo(directorio);
                    this.grabaApuntadoresHash(directorio, hash, hash.Direcciones[i], i);
                }
                this.dirIndice = MetodosAuxiliares.ultimaDireccionDeArchivo(directorio);
                this.grabaDireccionesHash(directorio, hash);
            }
            band = this.tipo.Equals('C');
            int idx;
            idx = ((HashEstatica)this.indices.First()).alta(band, MetodosAuxiliares.truncaCadena(llave).ToCharArray(), direccion);
            this.grabaApuntadoresHash(directorio, ((HashEstatica)this.indices.First()), ((HashEstatica)this.indices.First()).Direcciones[idx], idx);
        }

        public void modificaHashEstatica(string llaveOriginal, string nuevallave, long dirAct, string archivoIdx)
        {
            int[] direcciones;
            bool esCadena;
            HashEstatica hash;
            esCadena = this.tipo.Equals('C');
            hash = ((HashEstatica)this.indices.First());
            direcciones = hash.modifica(esCadena, llaveOriginal.ToCharArray(), nuevallave.ToCharArray(), dirAct);
            for (int i = 0; i < direcciones.Length; i++)
            {
                this.grabaApuntadoresHash(archivoIdx, hash, hash.Direcciones[direcciones[i]], direcciones[i]);
            }
            //this.grabaDireccionesHash(archivoIdx, hash);
        }

        public void elimminaHash(string llave, long direccion, string directorio)
        {
            if (this.dirIndice != -1)
            {
                bool band;
                int idx;
                band = this.tipo.Equals('C');
                idx = ((HashEstatica)this.indices.First()).baja(band, MetodosAuxiliares.truncaCadena(llave).ToCharArray(), direccion);
                this.grabaApuntadoresHash(directorio, ((HashEstatica)this.indices.First()), ((HashEstatica)this.indices.First()).Direcciones[idx], idx);
            }
        }

        #endregion

        #endregion

        #region Lectura y Grabado de Datos

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
                        this.leeSecundario(directorio);
                    }
                break;
                case 5:
                    if(this.dirIndice != -1)
                    {
                        this.leeHashEstatica(directorio);
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
                        reader.BaseStream.Seek(this.dirIndice, SeekOrigin.Current);
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

        private void grabaApuntadoresSecundario(string directorio, Secundario secunadrio, long dir, int i)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    this.writer.Seek((int)dir, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    for (int j = 0; j < Constantes.tamNodoAux; j++)
                    {
                        writer.Write(secunadrio.Apuntadores[i, j]);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void grabaDireccionesSecundario(string directorio, Secundario secundario)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    //this.writer.Seek((int)this.dirIndice, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    this.writer.BaseStream.Position = this.dirIndice;
                    for (int i = 0; i < secundario.Direcciones.Length; i++)
                    {
                        if(this.tipo.Equals('C'))
                        {
                            writer.Write(secundario.Llaves[i]);
                        }
                        else if(this.tipo.Equals('E'))
                        {
                            writer.Write(Int32.Parse(secundario.Llaves[i]));
                        }
                        writer.Write(secundario.Direcciones[i]);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        private void leeSecundario(string directorio)
        {
            try
            {
                Secundario secundario;
                bool band;
                band = this.tipo.Equals('C');
                int tamaño;
                tamaño = MetodosAuxiliares.calculaTamIdxPrim(this.longitud);
                secundario = new Secundario(this.nombre, this.dirIndice, tamaño, this.longitud,-1,band);
                using (reader = new BinaryReader(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    reader.BaseStream.Position = this.dirIndice;
                    for (int i = 0; i < secundario.Direcciones.Length; i++)
                    {
                        if(band)
                        {
                            secundario.Llaves[i] = reader.ReadString();
                        }
                        else
                        {
                            secundario.Llaves[i] = reader.ReadInt32().ToString();
                        }
                        secundario.Direcciones[i] = reader.ReadInt64();
                    }
                }
                for (int i = 0; i < secundario.Direcciones.Length; i++)
                {
                    this.LeeApuntadoresSecundario(directorio, i, secundario);
                }
                this.indices.Add(secundario);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LeeApuntadoresSecundario(string directorio, int i, Secundario secundario)
        {
            try
            {
                using (reader = new BinaryReader(new FileStream(directorio, FileMode.Open)))
                {
                    reader.BaseStream.Position = secundario.Direcciones[i];
                    for (int j = 0; j < Constantes.tamNodoAux; j++)
                    {
                        secundario.Apuntadores[i, j] = reader.ReadInt64();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        #endregion

        #region Hash Estatica


        private void grabaApuntadoresHash(string directorio, HashEstatica hash, long dir, int i)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    this.writer.Seek((int)dir, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    for (int j = 0; j < Constantes.tamNodoAux ; j++)
                    {
                        writer.Write(hash.Apuntadores[i, j]);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void grabaDireccionesHash(string directorio, HashEstatica hash)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    this.writer.Seek((int)this.dirIndice, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    for (int i = 0; i < hash.Direcciones.Length ; i++)
                    {
                        writer.Write(hash.Direcciones[i]);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void leeHashEstatica(string directorio)
        {
            try
            {
                HashEstatica hash;
                hash = new HashEstatica(this.nombre, this.dirIndice, -1);
                using (reader = new BinaryReader(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    reader.BaseStream.Position = this.dirIndice;
                    for(int i = 0 ; i < hash.Direcciones.Length ; i++)
                    {
                        hash.Direcciones[i] = reader.ReadInt64();
                    }
                }
                for (int i = 0; i < hash.Direcciones.Length; i++)
                {
                    this.LeeApuntadoresHash(directorio,i,hash);
                }
                this.indices.Add(hash);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LeeApuntadoresHash(string directorio, int i, HashEstatica hash)
        {
            try
            {
                using (reader = new BinaryReader(new FileStream(directorio, FileMode.Open)))
                {
                    reader.BaseStream.Position=hash.Direcciones[i];
                    for (int j = 0; j < Constantes.tamNodoAux; j++)
                    {
                        hash.Apuntadores[i, j] = reader.ReadInt64();
                    }
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

    }
}
