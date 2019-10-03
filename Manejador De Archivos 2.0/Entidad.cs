using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador_De_Archivos_2._0
{
    class Entidad
    {
        #region Variables de Instancia
        private string nombre;//Nombre de la entidad
        private long dirActual;//Direccion en el archivo de la entidad
        private long dirAtributos;//Direccion en el archivo de los atributos
        private long dirRegistros;//Direccion en el archivo de los registros
        private long dirSig;//Direccion en el archivo de la siguiente entidad
        private List<Atributo> atributos;
        private Dictionary<string,Registro> registros;
        private BinaryReader reader;//Objeto para leer el archivo
        private BinaryWriter writer;//Objeto para guardar el archivo
        #endregion
        
        #region Constructores
        public Entidad(string nombre, long dirActual, long dirAtributos, long dirRegistros, long dirSig)
        {
            this.nombre = nombre;
            this.dirActual = dirActual;
            this.dirAtributos = dirAtributos;
            this.dirRegistros = dirRegistros;
            this.dirSig = dirSig;
            this.atributos = new List<Atributo>();
            this.registros = new Dictionary<string,Registro>();
        }
        #endregion

        #region Gets & Sets

        public long DirActual
        {
            get { return this.dirActual; }
        }

        public long DirAtributos
        {
            get { return this.dirAtributos; }
        }

        public long DirRegistros
        {
            get { return this.dirRegistros; }
        }

        public long DirSig
        {
            get { return this.dirSig; }
            set { this.dirSig = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public List<Atributo> Atributos
        {
            get { return this.atributos; }
        }

        public List<Registro> Registros
        {
            get { return this.registros.Values.ToList(); }
        }

        public List<string> LlavePrimaria
        {
            get { return this.registros.Keys.ToList(); }
        }

        #endregion

        #region Metodos

        #region Busqueda

        public Atributo buscaAtributo(string nombre)
        {
            Atributo atributo;
            atributo = null;
            foreach (Atributo atrib in this.atributos)
            {
                if (atrib.Nombre.Equals(nombre))
                {
                    atributo = atrib;
                    break;
                }
            }
            return atributo;
        }


        public Atributo buscaAtributoForaneo()
        {
            Atributo atributo;
            atributo = null;
            foreach (Atributo atrib in this.atributos)
            {
                if (atrib.Indice == 2)
                {
                    atributo = atrib;
                    break;
                }
            }
            return atributo;
        }

        public Registro buscaRegistro(string llavePrimaria)
        {
            if (this.atributos[this.buscaIncideClavePrimaria()].Tipo.Equals('C'))
            {
                llavePrimaria = MetodosAuxiliares.ajustaCadena(llavePrimaria, this.atributos[this.buscaIncideClavePrimaria()].Longitud-1);
            }
            return this.registros[llavePrimaria];
        }

        public bool existeAtributo(string nombre)
        {
            bool band;
            band = false;
            foreach(Atributo atributo in this.atributos)
            {
                if(nombre.Equals(atributo.Nombre))
                {
                    band = true;
                    break;
                }
            }
            return band;

        }

        private bool existeClaveDeBusqueda()
        {
            bool band;
            band = false;
            foreach (Atributo atributo in this.atributos)
            {
                if (atributo.Indice == 1)
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        public bool existeIndicePrimario()
        {
            bool band;
            band = false;
            foreach (Atributo atributo in this.atributos)
            {
                if (atributo.Indice == 2)
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        private int buscaIndiceClaveDeBusqueda()
        {
            int indice;
            indice = -1;
            for (int i = 0; i < this.atributos.Count; i++)
            {
                if (this.atributos[i].Indice == 1)
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        private int buscaIncideClavePrimaria()
        {
            int indice;
            indice = -1;
            for (int i = 0; i < this.atributos.Count; i++)
            {
                if (this.atributos[i].Indice == 2)
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        #endregion

        #region Atributos
        public void altaAtributo(string nombre, char tipo, int longitud, int indice, long dirIndice, long dir)
        {
            if (this.dirRegistros == -1)
            {
                if (!this.existeAtributo(nombre))
                {
                    if (indice != 1 || !this.existeClaveDeBusqueda())
                    {
                        if (indice != 2 || !this.existeIndicePrimario())
                        {
                            Atributo atributo;
                            atributo = new Atributo(this.nombre, nombre, dir, tipo, indice, longitud, dirIndice, -1);
                            this.atributos.Add(atributo);
                            this.ajustaDireccionesAtributos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe una clave de busqueda", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un atributo con ese nombre", "Error");
                }
            }
            else
            {
                MessageBox.Show("Esta entidad ya tiene registros", "Error");
            }
        }

        public void modificaAtributo(string nombre,string nuevoNombre, char tipo, int longitud, int indice, long dirIndice)
        {
            if (this.dirRegistros == -1)
            {
                if (!this.existeAtributo(nuevoNombre))
                {
                    Atributo atributo;
                    atributo = buscaAtributo(nombre);
                    if (indice != 1|| !this.existeClaveDeBusqueda() || indice == atributo.Indice)
                    {
                        if (this.dirRegistros == -1)
                        {
                            this.atributos.Remove(atributo);
                            atributo = new Atributo(this.nombre, nuevoNombre, atributo.DirActual, tipo, indice, longitud, dirIndice, -1);
                            this.atributos.Add(atributo);
                            this.ajustaDireccionesAtributos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe una clave de busqueda", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un atributo con ese nombre", "Error");
                }
            }
            else
            {
                MessageBox.Show("Esta entidad ya tiene registros", "Error");
            }
        }

        public void eliminaAtributo(string nombre)
        {
            if (this.dirRegistros == -1)
            {
                Atributo atributo;
                atributo = this.buscaAtributo(nombre);
                this.atributos.Remove(atributo);
                this.ajustaDireccionesAtributos();
            }
            else
            {
                MessageBox.Show("Esta entidad ya tiene registros", "Error");
            }
        }

        private void ajustaDireccionesAtributos()
        {
            if (this.atributos.Count > 0)
            {
                this.atributos = this.atributos.OrderBy(atrib => atrib.Nombre).ToList();
                for (int i = 0; i < this.atributos.Count - 1; i++)
                {
                    this.atributos[i].DirSig = this.atributos[i + 1].DirActual;//Iguala la direccion siguiente a la direccion actual de la siguiente entidad en la lista
                }
                this.atributos.Last().DirSig = -1;//Iguala a -1 la direccion siguiente del ultimo elemento de la lista
                this.dirAtributos = this.atributos.First().DirActual;//A la cabecera le asigna el valor de la primera entidad
            }
            else
            {
                this.dirAtributos = -1;
            }
        }

        #endregion

        #region Registros


        public void altaRegistro(string directorio, List<string> informacion)
        {
            try
            {
                if (this.existeClaveDeBusqueda() && this.existeIndicePrimario())
                {
                    int indiceClaveBusqueda;
                    long dir;
                    string archivoDat;
                    Registro registro;
                    FileStream abierto;
                    archivoDat = directorio + "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".dat";
                    indiceClaveBusqueda = this.buscaIncideClavePrimaria();
                    abierto = new FileStream(archivoDat, FileMode.Append);//abre el archivo en un file stream
                    dir = (long)abierto.Seek(0, SeekOrigin.End);//Calcula la direccion final del archivo y lo mete en un long
                    abierto.Close();//Cierra el file Strea
                    registro = new Registro(dir, informacion);
                    this.registros.Add(informacion[indiceClaveBusqueda], registro);
                    this.ajustaDireccionesRegistros();
                    foreach (Registro registroAux in this.registros.Values)
                    {
                        this.grabaRegistro(registroAux, archivoDat);
                    }
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void modificaRegistro(string llavePrimaria, List<string> datos, string directorio)
        {
            string archivoDat;
            Registro registro1;
            registro1 = new Registro(this.registros[llavePrimaria].DirAct, datos);
            this.registros.Remove(llavePrimaria);
            this.registros.Add(datos[this.buscaIncideClavePrimaria()], registro1);
            archivoDat = directorio + "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".dat";
            this.ajustaDireccionesRegistros();
            foreach(Registro registro in this.registros.Values)
            {
                this.grabaRegistro(registro, archivoDat);
            }
        }

        public void eliminarRegistro(string directorio, string llavePrimaria)
        {
            try
            {
                directorio += "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".dat";
                if (this.atributos[this.buscaIndiceClaveDeBusqueda()].Tipo.Equals('C'))
                {
                    llavePrimaria = MetodosAuxiliares.ajustaCadena(llavePrimaria, this.atributos[this.buscaIncideClavePrimaria()].Longitud-1);
                };
                this.registros.Remove(llavePrimaria);
                this.ajustaDireccionesRegistros();
                foreach (Registro registroAux in this.registros.Values)
                {
                    this.grabaRegistro(registroAux, directorio);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private void ajustaDireccionesRegistros()
        {
            if (this.registros.Count > 0)
            {
                this.registros = this.registros.OrderBy(registro => registro.Value.Datos[this.buscaIndiceClaveDeBusqueda()]).ToDictionary(registro => registro.Key,registro => registro.Value);
                for (int i = 0; i < this.registros.Count - 1; i++)
                {
                    this.registros.Values.ElementAt(i).DirSig = this.registros.Values.ElementAt(i + 1).DirAct;//Iguala la direccion siguiente a la direccion actual de la siguiente entidad en la lista
                }
                this.registros.Last().Value.DirSig = -1;//Iguala a -1 la direccion siguiente del ultimo elemento de la lista
                this.dirRegistros = this.registros.First().Value.DirAct;//A la cabecera le asigna el valor de la primera entidad
            }
            else
            {
                this.dirRegistros = -1;
            }
        }

        #endregion

        #region Grabado y Lectura de Datos


        private void grabaRegistro(Registro registro, string directorio)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    this.writer.Seek((int)registro.DirAct, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    for(int i = 0 ; i < this.atributos.Count ; i++)
                    {
                        if (this.atributos[i].Tipo.Equals('E'))
                        {
                            this.writer.Write(Int32.Parse(registro.Datos[i]));
                        }
                        else if (this.atributos[i].Tipo.Equals('C'))
                        {
                            this.writer.Write(registro.Datos[i]);
                        }
                    }
                    this.writer.Write(registro.DirAct);
                    this.writer.Write(registro.DirSig);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void leeRegistros(string directorio)
        {
            try
            {
                Registro registro;
                List<string> informacion = new List<string>();
                int i;
                long dirSig;
                directorio += "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".dat";
                i = 0;
                dirSig = this.dirRegistros;
                while (dirSig != -1)
                {
                    using (reader = new BinaryReader(new FileStream(directorio, FileMode.Open)))//Abre el archivo con el BinaryWriter
                    {
                        this.reader.ReadBytes((int)dirSig);//Posiciona el grabado del archivo en la dirección actual
                        foreach (Atributo atributo in this.Atributos)
                        {
                            if (atributo.Tipo.Equals('E'))
                            {
                                informacion.Add(this.reader.ReadInt32().ToString());
                            }
                            else if (atributo.Tipo.Equals('C'))
                            {
                                informacion.Add(this.reader.ReadString());
                            }
                            i++;
                        }
                        registro = new Registro(dirSig, informacion);
                        dirSig = registro.DirSig = this.reader.ReadInt64();
                        dirSig = registro.DirSig = this.reader.ReadInt64();
                        this.registros.Add(informacion[this.buscaIncideClavePrimaria()],registro);
                        informacion = new List<string>();
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
