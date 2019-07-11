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

        public bool existeEntidad(string nombre)
        {
            bool band;
            band = false;
            foreach(Entidad entidad in this.entidades)
            {
                if (entidad.Nombre.Equals(nombre))
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        #endregion

        #region Entidades

        public void altaEntidad(string nombre, long dirActual, long dirAtributos, long dirRegistros, long dirSig)
        {
            Entidad entidad;
            entidad = new Entidad(nombre, dirActual, dirAtributos, dirRegistros, dirSig);
            this.entidades.Add(entidad);
            this.ajustaDirecciones();
        }

        public void modificaEntidad()
        {
            throw new NotImplementedException();
        }
        
        public void eliminaEntidad()
        {
            throw new NotImplementedException();
        }


        /**
         * Este metodo se dedica a ordenar la lista tanto en memoria como en archivo siendo en memoria ordenada mediante el metodo
         * OrderBy usando como directriz el nombre de las entidades, y despues organizar las direcciones siguiente y volviendo a
         * grabar todas las entidades en el archivo.
         */
        public void ajustaDirecciones()
        {
            this.entidades = this.entidades.OrderBy(entidad => entidad.Nombre).ToList();//Manda ordenar la lista en base al nombre
            for (int i = 0; i < this.entidades.Count - 1; i++)
            {
                this.entidades[i].DirSig = this.entidades[i + 1].DirActual;//Iguala la direccion siguiente a la direccion actual de la siguiente entidad en la lista
            }
            this.entidades.Last().DirSig = -1;//Iguala a -1 la direccion siguiente del ultimo elemento de la lista
            this.cabecera = entidades.First().DirActual;//A la cabecera le asigna el valor de la primera entidad
            this.grabaCabecera();//Manda grabar la cabecera
            foreach (Entidad entidad in entidades)
            {
                this.grabaEntidad(entidad);//Manda grabar las entidades con su direccion actual
            }
        }
        
        #endregion

        #region Atributos
        public void altaAtributo()
        {
            throw new NotImplementedException();
        }
        public void modificaAtributo()
        {
            throw new NotImplementedException();
        }
        public void eliminaAtributo()
        {
            throw new NotImplementedException();
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
                    this.writer.Write(entidad.Nombre);//Graba el nombre
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
                    writer.Write(atributo.Nombre);//Graba el Nombre
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

        #endregion

    }
}
