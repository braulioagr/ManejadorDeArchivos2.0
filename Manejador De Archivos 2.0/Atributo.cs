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
        #endregion

        #region Metodos
        public void altaIndicePrimario(string llave, long dir, string directorio)
        {
            int longitud;
            long dirIdx;
            Indice indice;
            FileStream abierto;
            dirIdx = -1;
            longitud = MetodosAuxiliares.calculaTamIdxPrim(this.longitud);
            abierto = new FileStream(directorio, FileMode.Append);//abre el archivo en un file stream
            dirIdx = (long)abierto.Seek(0, SeekOrigin.End);//Calcula la direccion final del archivo y lo mete en un long
            if (this.indices.Count == 0)
            {
                indice = new Primario(this.nombre, dirIdx, longitud, -1);
                indice.alta(llave, dir);
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
                        idx.alta(llave, dir);
                        band = true;
                        break;
                    }
                }
                if (!band)
                {
                    indice = new Primario(this.nombre, dirIdx, longitud, -1);
                    indice.alta(llave, dir);
                    this.indices.Last().DirSig = indice.DirAct;
                    this.indices.Add(indice);
                }
            }
            foreach (Indice idx in this.indices)
            {
                this.grabaIndicePrimario((Primario)idx,directorio);
            }

        }
        #region Lectura y Grabado de Datos
        private void grabaIndicePrimario(Primario indice, string directorio)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    this.writer.Seek((int)indice.DirAct, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    for (int i = 0; i < indice.Idx.Length; i++)
                    {
                        this.writer.Write(indice.Idx[i].Llave);
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
                List<string> informacion = new List<string>();
                long dirSig;
                int largo;
                string llave;
                long direccion;
                llave = "null";
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
                            llave = this.reader.ReadString();
                            direccion = this.reader.ReadInt64();
                            nodo = new NodoIndicePrimario(llave, direccion);
                            nodos[i] = nodo;
                        }
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
    }
}
