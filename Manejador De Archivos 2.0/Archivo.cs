using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador_De_Archivos_2._0
{
    class Archivo
    {
        #region Variables de Instancia
        private long cabecera;
        private string nombre;
        private List<Entidad> entidades;
        private BinaryReader reader;
        private BinaryWriter writer;
        #endregion

        #region Constructores
        public Archivo(string nombre)
        {
            this.cabecera = -1;
            this.nombre = nombre;
            this.entidades = new List<Entidad>();
        }
        #endregion

        #region Gets & Sets
        public string Nombre
        {
            get { return this.nombre; }
        }
        public long Cabecera
        {
            get { return this.cabecera; }
        }
        public List<Entidad> Entidades
        {
            get { return this.entidades; }
        }
        #endregion

        #region Metodos

        #region Busqueda

        public Entidad buscaEntidad(long direccion)
        {
            Entidad entidad;
            entidad = null;
            foreach (Entidad entidad1 in this.entidades)
            {
                if (entidad1.DirActual == direccion)
                {
                    entidad = entidad1;
                    break;
                }
            }
            return entidad;
        }

        public Entidad buscaEntidad(string nombre)
        {
            Entidad destino;
            destino = null;
            foreach (Entidad entidad in this.entidades)
            {
                if(entidad.Nombre.Equals(nombre))
                {
                    destino = entidad;
                    break;
                }
            }
            return destino;
        }

        public bool existeEntidad(string nombre)
       {
            bool band;
            band = false;
            foreach(Entidad entidad in this.entidades)

            {
                if (entidad.Nombre==nombre)
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        public bool existeEntidad(string nombre, ref Entidad entidad)
        {
            bool band;
            band = false;
            foreach (Entidad entidad2 in this.entidades)
            {
                if (entidad2.Nombre.Equals(nombre))
                {
                    band = true;
                    entidad = entidad2;
                    break;
                }
            }
            return band;
        }

        #endregion

        #region Entidades

        public void altaEntidad(string nombre, long dirActual, long dirAtributos, long dirRegistros, long dirSig)
        {
            if (!this.existeEntidad(nombre))
            {
                Entidad entidad;
                entidad = new Entidad(nombre, dirActual, dirAtributos, dirRegistros, dirSig);
                this.entidades.Add(entidad);
                this.ajustaDirecciones();
            }
            else
            {
                MessageBox.Show("Esa entidad ya existe", "Error");
            }
        }

        public void modificaEntidad(string nombre, string cambio)
        {
            if (this.existeEntidad(nombre))
            {
                if (!this.existeEntidad(cambio))
                {
                    Entidad destino;
                    destino = this.buscaEntidad(nombre);
                    if (destino.DirRegistros == -1)
                    {
                        destino.Nombre = cambio;
                        this.ajustaDirecciones();
                    }
                    else
                    {
                        MessageBox.Show("La entidad seleccionada no se puede modificar", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("La entidad ya existe", "Error");
                }
            }
            else
            {
                MessageBox.Show("La entidad seleccionada no existe","Error");
            }
        }
        
        public void eliminaEntidad(string nombre, string directorio)
        {
            if (this.existeEntidad(nombre))
            {
                Entidad entidad;
                entidad = this.buscaEntidad(nombre);
                if (entidad.DirRegistros == -1)
                {
                    this.entidades.Remove(entidad);
                    this.ajustaDirecciones();
                    File.Delete(directorio + ".dat");
                    File.Delete(directorio + ".idx");
                }
                else
                {
                    MessageBox.Show("La entidad seleccionada contiene datos dados de alta por favor eliminelos", "Error");
                }
            }
            else
            {
                MessageBox.Show("La entidad seleccionada no existe", "Error");
            }
        }


        /**
         * Este metodo se dedica a ordenar la lista tanto en memoria como en archivo siendo en memoria ordenada mediante el metodo
         * OrderBy usando como directriz el nombre de las entidades, y despues organizar las direcciones siguiente y volviendo a
         * grabar todas las entidades en el archivo.
         */
        public void ajustaDirecciones()
        {
            if (this.entidades.Count > 0)
            {
                this.entidades = this.entidades.OrderBy(entidad => entidad.Nombre).ToList();//Manda ordenar la lista en base al nombre
                for (int i = 0; i < this.entidades.Count - 1; i++)
                {
                    this.entidades[i].DirSig = this.entidades[i + 1].DirActual;//Iguala la direccion siguiente a la direccion actual de la siguiente entidad en la lista
                }
                this.entidades.Last().DirSig = -1;//Iguala a -1 la direccion siguiente del ultimo elemento de la lista
                this.cabecera = entidades.First().DirActual;//A la cabecera le asigna el valor de la primera entidad
                foreach (Entidad entidad in entidades)
                {
                    this.grabaEntidad(entidad);//Manda grabar las entidades con su direccion actual
                }
            }
            else
            {
                this.cabecera = -1;
            }
            this.grabaCabecera();//Manda grabar la cabecera
        }
        
        #endregion

        #region Atributos

        public void altaAtributo(string entidad, string nombre, char tipo, int longitud, int indice, long dir,long dirIndice)
        {            
            Entidad ent;
            ent = null;
            if (this.existeEntidad(entidad, ref ent))
            {
                if (ent.DirRegistros == -1)
                {
                    ent.altaAtributo(nombre, tipo, longitud, indice, dirIndice, dir);
                    this.grabaEntidad(ent);
                    foreach (Atributo atributo in ent.Atributos)
                    {
                        this.grabaAtributo(atributo);
                    }
                }
                else
                {
                    MessageBox.Show("A la entidad seleccionada ya no se pueden dar de alta Atributos","Error");
                }
            }
            else
            {
                MessageBox.Show("La entidad que selecciono no existe", "Error");
            }
        }

        public void modificaAtributo(string entidad, string nombre, string nuevoNombre, char tipo, int longitud, int indice,long dirIndice)
        {
            Entidad ent;
            ent = buscaEntidad(entidad);
            if (ent.DirRegistros == -1)
            {
                ent.modificaAtributo(nombre, nuevoNombre, tipo, longitud, indice,dirIndice);
                Atributo atributo;
                atributo = ent.buscaAtributo(MetodosAuxiliares.ajustaCadena(nuevoNombre, Constantes.tam));
                this.grabaAtributo(atributo);
            }
            else
            {
                MessageBox.Show("El atributo pertenece a una entidad no se puede modificar", "Error");
            }
        }
        
        public void eliminaAtributo(string entidad, string nombre)
        {
            Entidad ent;
            ent = buscaEntidad(entidad);
            if (ent.DirRegistros == -1)
            {
                ent.eliminaAtributo(nombre);
                this.grabaEntidad(ent);
            }
            else
            {
                MessageBox.Show("El atributo pertenece a una entidad no se puede modificar", "Error");
            }
        }
        #endregion

        #region Registros

        public void altaRegistro(string nombre, string directorio, List<string> informacion)
        {
            Entidad entidad;
            entidad = buscaEntidad(nombre);
            entidad.altaRegistro(directorio,informacion);
            this.grabaEntidad(entidad);
            foreach(Atributo atributo in entidad.Atributos)
            {
                if(atributo.DirIndice != -1)
                {
                    this.grabaAtributo(atributo);
                }
            }
        }


        public void modificaRegistro(string entidad, string llavePrimaria, string[] infoOriginal, List<string> datos, string directorio)
        {
            Entidad entidad1;
            entidad1 = this.buscaEntidad(MetodosAuxiliares.ajustaCadena(entidad,Constantes.tam));
            entidad1.modificaRegistro(llavePrimaria,datos,directorio,infoOriginal);
            this.grabaEntidad(entidad1);
        }

        public void eliminaRegistro(string nombreEntidad, string llavePrimaria, string directorio)
        {
            Entidad entidad;
            entidad = this.buscaEntidad(nombreEntidad);
            entidad.eliminarRegistro(directorio, llavePrimaria);
            this.grabaEntidad(entidad);
        }
        
        #endregion

        #region Grabado de datos

        /**
         * Este metodo es el encargado de grabar la Entidad utilizando el objeto BinaryWriter 
         * el cual solo graba el long en la poscicion original del archivo
         */
        public void grabaCabecera()
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(nombre, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    writer.Seek(0, SeekOrigin.Begin);//Psciciona el BinaryWriter en el origen
                    writer.Write(this.cabecera);//Graba la cabecera
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /**
         * Este metodo es el encargado de grabar la Entidad utilizando el objeto BinaryWriter 
         * el cual va grabando dato por dato de manera secuencial
         * @param Entidad entidad que se va a grabar
         */
        public void grabaEntidad(Entidad entidad)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(this.Nombre, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    this.writer.Seek((int)entidad.DirActual, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    this.writer.Write(entidad.DirActual);//Graba la dirección Actual
                    this.writer.Write(entidad.Nombre.ToCharArray());//Graba el nombre
                    this.writer.Write(entidad.DirAtributos);//Graba la direccion de atributos
                    this.writer.Write(entidad.DirRegistros);//Graba la Dirección de Registros
                    this.writer.Write(entidad.DirSig);//Graba la dirección de la siguiente entidad
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /**
         * Este metodo es el encargado de grabar el atributo utilizando el objeto BinaryWriter 
         * el cual va grabando dato por dato de manera secuencial
         * @param Atributo atributo que se va a grabar
         */
        public void grabaAtributo(Atributo atributo)
        {
            try
            {
                using (writer = new BinaryWriter(new FileStream(this.Nombre, FileMode.Open)))//Abre el archivo con el BinaryWriter
                {
                    writer.Seek((int)atributo.DirActual, SeekOrigin.Current);//Posiciona el grabado del archivo en la dirección actual
                    writer.Write(atributo.Nombre.ToCharArray());//Graba el Nombre
                    writer.Write(atributo.Tipo);//Graba el Tipo
                    writer.Write(atributo.Longitud);//Graba la Longitud
                    writer.Write(atributo.DirActual);//Graba la Direccion Actual
                    writer.Write(atributo.Indice);//Graba el Indice
                    writer.Write(atributo.DirIndice);//Graba la dirección del indice
                    writer.Write(atributo.DirSig);//Graba la Direccion siguiente
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region Lectura de datos

        /**
         * Metodo que se encarga de leer el archivo primero leyendo
         *        las entidades despues los atributos
         */
        public void leeArchivo(string directorio)
        {
            try
            {
                string archivoIdx;
                this.leeEntidades();
                this.leeAtributos();
                foreach (Entidad entidad in this.entidades)
                {
                    entidad.leeRegistros(directorio);
                    archivoIdx = directorio + "\\" + MetodosAuxiliares.truncaCadena(entidad.Nombre) + ".idx";
                    foreach (Atributo atributo in entidad.Atributos)
                    {
                        atributo.leeIndices(archivoIdx);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        /**
         * Metodo que se encarga de leer las entidades guardadas
         * en el diccionario de datos utilizando un BinaryReader
         * y una secuencia con un while para que se detenga cuando
         * el valor de la dirección siguiente sea igual a -1
         */
        private void leeEntidades()
        {
            long dirSigEntidad;//Crea un long que servira como iterador
            long actual;
            string nombre;
            long dirAtributo;
            long dirRegistros;
            Entidad entidad;
            dirSigEntidad = 0;
            while (dirSigEntidad != -1)//Se cicla mientras
            {
                using (reader = new BinaryReader(new FileStream(this.Nombre, FileMode.Open)))//Abre el archivo con el BinaryReader
                {
                    if ((int)dirSigEntidad == 0)//Si es 0 o lo que es lo mismo entrar por primera vez
                    {
                        this.cabecera = dirSigEntidad = reader.ReadInt64();//La cabecera y el iterador  son iguales al resultado de leer un long
                        continue;
                    }
                    reader.BaseStream.Seek(dirSigEntidad, SeekOrigin.Current);//Se posciona en la posición del iterador
                    actual = reader.ReadInt64();//Lee un long que de la dirección actual
                    nombre = new string(reader.ReadChars(Constantes.tam));//Lee el string del nombre
                    dirAtributo = reader.ReadInt64();//Lee un long que de la dirección de los atributos
                    dirRegistros = reader.ReadInt64();//Lee un long que de la dirección de los registros
                    dirSigEntidad = reader.ReadInt64();////Lee un long que de la dirección de la siguiente entidad
                    entidad = new Entidad(nombre, actual, dirAtributo, dirRegistros, dirSigEntidad);//Crea una nueva entidad con los datos leidos
                    entidades.Add(entidad);//Añade la entidad a la lista de entidades
                }
            }
        }

        /**
         * Metodo que se encarga de leer las entidades guardadas
         * en el diccionario de datos utilizando un BinaryReader
         * y una secuencia con un foreach que contiene dentro un
         * ciclo while que se cicla si y solo si la direccion del
         * siguiente atributo es diferente de -1
         */
        private void leeAtributos()
        {
            long dirSiguienteAtributo;//Crea un long que servira como iterador
            string nombre;
            char tipo;
            int longitud;
            long dirActual;
            int tipoIndice;
            long dirIndice;
            Atributo atributo;
            dirSiguienteAtributo = 0;
            foreach (Entidad entidad in this.entidades)
            {
                dirSiguienteAtributo = (int)entidad.DirAtributos;
                while (dirSiguienteAtributo != -1)
                {
                    using (reader = new BinaryReader(new FileStream(this.Nombre, FileMode.Open)))//Abre el archivo con un BinaryReader
                    {
                        reader.BaseStream.Seek(dirSiguienteAtributo, SeekOrigin.Current);//Se posciona en la posición del iterador
                        nombre = new string(reader.ReadChars(Constantes.tam));//Se lee el string del nombre
                        tipo = reader.ReadChar();//Se lee el string del tipo de dato
                        longitud = reader.ReadInt32();//Se lee el int de la longitud del tipo de dato
                        dirActual = reader.ReadInt64();//Se lee el long de la dirección actual
                        tipoIndice = reader.ReadInt32();//Se lee el int del tipo de indice
                        dirIndice = reader.ReadInt64();//Se lee el long de la dirección del indice
                        dirSiguienteAtributo = reader.ReadInt64();//Se lee el long de la dirección del siguiente atributo
                        atributo = new Atributo(entidad.Nombre, nombre, dirActual, tipo, tipoIndice, longitud, dirIndice, dirSiguienteAtributo);//Crea un nuevo atributo con los datos leidos
                        entidad.Atributos.Add(atributo);//Se añade el atributo a la lista de la entidad
                    }
                }
            }
        }

        public List<Atributo> ConsultaAtributosSelect(string[] sentencia, ref Entidad entidad)
        {
            if (sentencia.Contains("from"))
            {
                int i;
                List<Atributo> atributos;
                atributos = new List<Atributo>();
                i = Array.IndexOf(sentencia, "from");
                if(!sentencia.Last().Equals("from"))
                {
                    if (this.existeEntidad(MetodosAuxiliares.ajustaCadena(sentencia[i + 1], Constantes.tam)))
                    {
                        entidad = this.buscaEntidad(MetodosAuxiliares.ajustaCadena(sentencia[i + 1], Constantes.tam));
                        if (sentencia.Contains("*"))
                        {
                            if (Array.IndexOf(sentencia, "select") == 0 && i == 2 && Array.IndexOf(sentencia, "*") == 1)
                            {
                                atributos = entidad.Atributos;
                            }
                            else
                            {
                                throw new InvalidConsultException("El * debe ir solo");
                            }
                        }
                        else
                        {
                            for (int j = 1; j < i; j++)
                            {
                                if (entidad.existeAtributo(MetodosAuxiliares.ajustaCadena(sentencia[j], Constantes.tam)))
                                {
                                    atributos.Add(entidad.buscaAtributo(MetodosAuxiliares.ajustaCadena(sentencia[j], Constantes.tam)));
                                }
                                else
                                {
                                    throw new InvalidConsultException("El Atributo a buscar no existe");
                                }
                            }
                        }
                        return atributos;
                    }
                    else
                    {
                        throw new InvalidConsultException("La Entidad a buscar no existe o no se especifico");
                    }
                }
                else
                {
                    throw new InvalidConsultException("Por favor especifique una entidad a buscar");
                }
            }
            else
            {
                throw new InvalidConsultException("Falta el from perro");
            }
        }

        public List<Registro> ConsultaRegistrosSelectWhere(List<Atributo> atributos, Entidad entidad, string[] where)
        {
            throw new NotImplementedException("Aun no se finaliza este pedo");
        }

        #endregion

        #endregion
    }
}  
