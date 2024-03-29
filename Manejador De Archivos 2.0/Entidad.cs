﻿using System;
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
        public delegate void ModificaLLaveForanea(long dirReferencia, string oldKey, string newKey, string directorio);
        public event ModificaLLaveForanea modificaLLaveForanea;
        public delegate bool ExisteReferenciaForanea(long dirReferencia, string Key);
        public event ExisteReferenciaForanea existeReferenciaForanea;
        public delegate bool EsLlaveForanea(long dirReferencia, ref string referencias);
        public event EsLlaveForanea esLlaveForanea;
        public delegate void GrabaAtributo(Atributo atributo);
        public event GrabaAtributo grabaAtributo;
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

        public List<Registro> Valores
        {
            get { return this.registros.Values.ToList(); }
        }

        public Dictionary<string, Registro> Registros
        {
            get { return this.registros; }
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
            if (this.atributos[this.buscaIndiceClavePrimaria()].Tipo.Equals('C'))
            {
                llavePrimaria = MetodosAuxiliares.ajustaCadena(llavePrimaria, this.atributos[this.buscaIndiceClavePrimaria()].Longitud);
            }
            return this.registros[llavePrimaria];
        }

        public Registro buscaRegistro(long direccion)
        {
            Registro registro;
            registro = null;
            foreach (Registro reg in this.Valores)
            {
                if (direccion.Equals(reg.DirAct))
                {
                    registro = reg;
                    break;
                }
            }
            return registro;
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

        public bool existeClaveDeBusqueda()
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

        public int buscaIndiceClavePrimaria()
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

        public int buscaIndiceAtributo(string nombre)
        {
            int indice;
            indice = -1;
            for (int i = 0; i < this.atributos.Count; i++)
            {
                if (this.atributos[i].Nombre.Equals(nombre))
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        public int buscaIndiceAtributo(string nombre, string entidad)
        {
            int indice;
            indice = -1;
            for (int i = 0; i < this.atributos.Count; i++)
            {
                if (this.atributos[i].Nombre.Equals(nombre) && this.atributos[i].Entidad.Equals(entidad))
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        public bool existeAtributoInnerJoin(string entidad, string atributo)
        {
            bool band;
            band = false;
            foreach (Atributo atributo1 in this.atributos)
            {
                if (entidad.Equals(atributo1.Entidad) & atributo.Equals(atributo1.Nombre))
                {
                    band = true;
                    break;
                }
            }
            return band;
        }



        internal int buscaIndiceAtributoInnerJoin(string entidad, string atributo)
        {
            int i;
            i = -1;
            for (int j = 0; j < this.atributos.Count; j++)
            {
                if (entidad.Equals(this.atributos[j].Entidad) & atributo.Equals(this.atributos[j].Nombre))
                {
                    i = j;
                    break;
                }
            }
            return i;
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
                        else
                        {
                            MessageBox.Show("Ya existe una llave primaria", "Error");
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

        public bool modificaAtributo(string nombre,string nuevoNombre, char tipo, int longitud, int indice, long dirIndice)
        {
            bool band;
            band = false;
            if (this.dirRegistros == -1)
            {
                if (!this.existeAtributo(nuevoNombre) | nombre.Equals(nuevoNombre))
                {
                    Atributo atributo;
                    string referencias;
                    referencias = "";
                    atributo = buscaAtributo(nombre);
                    if (atributo.Indice != 2 | !this.esLlaveForanea(this.dirActual, ref referencias))
                    {
                        if (indice != 1|| !this.existeClaveDeBusqueda() || indice == atributo.Indice)
                        {
                            if (indice != 2 || !this.existeIndicePrimario())
                            {
                                this.atributos.Remove(atributo);
                                atributo = new Atributo(this.nombre, nuevoNombre, atributo.DirActual, tipo, indice, longitud, dirIndice, -1);
                                this.atributos.Add(atributo);
                                this.ajustaDireccionesAtributos();
                                band = true;
                            }
                            else
                            {
                                MessageBox.Show("Ya existe una llave primaria", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una clave de busqueda", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El atributo que desea modificar es una llave Foranea con la(s) entidad(es) : " + referencias + " por favor elimine la(s) referencia(s) primero", "Error");
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
            return band;
        }

        public void eliminaAtributo(string nombre)
        {
            if (this.dirRegistros == -1)
            {
                string referencias;
                Atributo atributo;
                referencias = "";
                atributo = this.buscaAtributo(nombre);
                if (atributo.Indice != 2 | !this.esLlaveForanea(this.dirActual, ref referencias))
                {
                    this.atributos.Remove(atributo);
                    this.ajustaDireccionesAtributos();
                }
                else
                {
                    MessageBox.Show("El atributo que desea eliminar es una llave Foranea con la(s) entidad(es): " + referencias + " por favor elimine la(s) referencia(s) primero", "Error");
                }
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
                this.atributos = this.atributos.OrderBy(atrib => atrib.Indice).ToList();
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
                    int indiceLlavePrimaria;
                    long dir;
                    string archivoDat;
                    string archivoIdx;
                    Registro registro;
                    FileStream abierto;
                    archivoDat = directorio + "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".dat";
                    archivoIdx = directorio + "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".idx";
                    indiceLlavePrimaria = this.buscaIndiceClavePrimaria();
                    abierto = new FileStream(archivoDat, FileMode.Append);//abre el archivo en un file stream
                    dir = (long)abierto.Seek(0, SeekOrigin.End);//Calcula la direccion final del archivo y lo mete en un long
                    abierto.Close();//Cierra el file Strea
                    registro = new Registro(dir, informacion);
                    this.registros.Add(informacion[indiceLlavePrimaria], registro);
                    int i;
                    i = -1;
                    foreach (Atributo atributo in this.atributos)
                    {
                        i++;
                        switch (atributo.Indice)
                        {
                            case 2://Indice Primario
                                atributo.altaIndicePrimario(informacion[indiceLlavePrimaria], dir, archivoIdx);
                            break;
                            case 4://Indice Secundario
                                atributo.altaIndiceSecundario(informacion[i], dir, archivoIdx);
                            break;
                            case 5:
                                atributo.altaHash(informacion[i], dir, archivoIdx);
                            break;
                        }
                    }
                    this.ajustaDireccionesRegistros();
                    foreach (Registro registroAux in this.registros.Values)
                    {
                        this.grabaRegistro(registroAux, archivoDat);
                    }
                }
                else
                {
                    MessageBox.Show("Falta un atributo llave primaria o clave de busqueda", "Error");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void modificaRegistro(string llavePrimaria, List<string> datos, string directorio, string[] infoOriginal)
        {
            try
            {
                if (!this.registros.ContainsKey(datos[this.buscaIndiceClavePrimaria()]) | llavePrimaria.Equals(datos[this.buscaIndiceClavePrimaria()]))
                {

                    int indiceLlavePrimaria;
                    string archivoDat;
                    string archivoIdx;
                    Registro registro1;
                    indiceLlavePrimaria = this.buscaIndiceClavePrimaria();
                    archivoDat = directorio + "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".dat";
                    archivoIdx = directorio + "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".idx";
                    if (this.atributos[indiceLlavePrimaria].Tipo.Equals('C'))
                    {
                        llavePrimaria = MetodosAuxiliares.ajustaCadena(llavePrimaria, this.atributos[indiceLlavePrimaria].Longitud);
                    }
                    registro1 = new Registro(this.registros[llavePrimaria].DirAct, datos);
                    this.registros.Remove(llavePrimaria);
                    this.registros.Add(datos[indiceLlavePrimaria], registro1);
                    int i;
                    i = 0;
                    string llaveOriginal;
                    string nuevallave;
                    foreach (Atributo atributo in this.atributos)
                    {
                        llaveOriginal = infoOriginal[i];
                        nuevallave = datos[i];
                        switch (atributo.Indice)
                        {
                            case 2:
                                atributo.modificaIndicePrimario(llavePrimaria, datos[indiceLlavePrimaria], archivoIdx);
                                this.modificaLLaveForanea(this.dirActual, llaveOriginal, nuevallave, directorio);
                            break;
                            case 4:
                                atributo.modificaIndiceSecundario(infoOriginal[i], datos[i], registro1.DirAct, archivoIdx);
                            break;
                            case 5:
                                if (atributo.Tipo.Equals('C'))
                                {
                                    llaveOriginal = MetodosAuxiliares.truncaCadena(llaveOriginal);
                                    nuevallave = MetodosAuxiliares.truncaCadena(nuevallave);
                                }
                                atributo.modificaHashEstatica(llaveOriginal, nuevallave, registro1.DirAct, archivoIdx);
                            break;
                        }
                        i++;
                    }
                    this.ajustaDireccionesRegistros();
                    foreach (Registro registro in this.registros.Values)
                    {
                        this.grabaRegistro(registro, archivoDat);
                    }
                }
                else
                {
                    MessageBox.Show("Se intento agregar un dato ya existente","Error");
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void eliminarRegistro(string directorio, string llavePrimaria)
        {
            try
            {
                if(this.atributos[this.buscaIndiceClavePrimaria()].Equals('C'))
                {
                    llavePrimaria = MetodosAuxiliares.ajustaCadena(llavePrimaria, this.atributos[this.buscaIndiceClavePrimaria()].Longitud);
                }
                if (this.registros.ContainsKey(llavePrimaria))
                {

                    string archivoDat;
                    string archivoIdx;
                    Registro reg;
                    archivoDat = directorio + "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".dat";
                    archivoIdx = directorio + "\\" + MetodosAuxiliares.truncaCadena(this.nombre) + ".idx";
                    if (this.atributos[this.buscaIndiceClavePrimaria()].Tipo.Equals('C'))
                    {
                        llavePrimaria = MetodosAuxiliares.ajustaCadena(llavePrimaria, this.atributos[this.buscaIndiceClavePrimaria()].Longitud);
                    }
                    else if (this.atributos[this.buscaIndiceClavePrimaria()].Tipo.Equals('E') | this.atributos[this.buscaIndiceClavePrimaria()].Tipo.Equals('D'))
                    {
                        llavePrimaria = MetodosAuxiliares.truncaCadena(llavePrimaria);
                    }
                    reg = this.registros[llavePrimaria];
                    if(!this.existeReferenciaForanea(this.dirActual,llavePrimaria))
                    {
                        this.registros.Remove(llavePrimaria);
                        int i;
                        i = -1;
                        foreach (Atributo atributo in this.atributos)
                        {
                            i++;
                            switch (atributo.Indice)
                            {
                                case 2:
                                    atributo.eliminaIndicePrimario(llavePrimaria, archivoIdx);
                                    break;
                                case 4:
                                    atributo.elimminaSecundario(reg.Datos[i], reg.DirAct, archivoIdx);
                                    break;
                                case 5:
                                    atributo.elimminaHash(reg.Datos[i], reg.DirAct, archivoIdx);
                                    break;
                            }
                            if(atributo.DirIndice == -1)
                            {
                                this.grabaAtributo(atributo);
                            }
                        }
                        this.ajustaDireccionesRegistros();
                        foreach (Registro registroAux in this.registros.Values)
                        {
                            this.grabaRegistro(registroAux, archivoDat);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Existen referencias foraneas a esta entidad por favor eliminelas antes", "Referencia Foranea detectada");
                    }
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
                this.registros = this.registros.OrderBy(registro => registro.Value.Datos[this.buscaIndiceClavePrimaria()]).ToDictionary(registro => registro.Key,registro => registro.Value);
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


        public void grabaRegistro(Registro registro, string directorio)
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
                        else if (this.atributos[i].Tipo.Equals('D'))
                        {
                            this.writer.Write(float.Parse(registro.Datos[i]));
                        }
                        else if (this.atributos[i].Tipo.Equals('C'))
                        {
                            this.writer.Write(registro.Datos[i].ToCharArray());
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
                            else if (atributo.Tipo.Equals('D'))
                            {
                                informacion.Add(this.reader.ReadSingle().ToString());
                            }
                            else if (atributo.Tipo.Equals('C'))
                            {
                                informacion.Add(new string(this.reader.ReadChars(atributo.Longitud)));
                            }
                            i++;
                        }
                        registro = new Registro(dirSig, informacion);
                        dirSig = registro.DirSig = this.reader.ReadInt64();
                        dirSig = registro.DirSig = this.reader.ReadInt64();
                        this.registros.Add(informacion[this.buscaIndiceClavePrimaria()],registro);
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
