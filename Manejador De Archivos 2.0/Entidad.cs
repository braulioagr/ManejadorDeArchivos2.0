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
        //private BinaryReader reader;//Objeto para leer el archivo
        //private BinaryWriter writer;//Objeto para guardar el archivo
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

        public bool existeAtributo(string nombre)
        {
            bool band;
            band = false;
            return band;

        }

        private bool ExisteClaveDeBusqueda()
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

        #endregion

        #region Atributos
        public void altaAtributo(string nombre, char tipo, int longitud, int indice, long dir)
        {
            if (this.dirRegistros == -1)
            {
                if (!this.existeAtributo(nombre))
                {
                    if (indice != 1 || !this.ExisteClaveDeBusqueda())
                    {
                        Atributo atributo;
                        atributo = new Atributo(this.nombre, nombre, dir, tipo, indice, longitud, -1, -1);
                        this.atributos.Add(atributo);
                        this.ajustaDirecciones();
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

        public void modificaAtributo(string nombre,string nuevoNombre, char tipo, int longitud, int indice)
        {
            if (this.dirRegistros == -1)
            {
                if (!this.existeAtributo(nuevoNombre))
                {
                    Atributo atributo;
                    atributo = buscaAtributo(nombre);
                    if (indice != 1|| !this.ExisteClaveDeBusqueda() || indice == atributo.Indice)
                    {
                        if (this.dirRegistros == -1)
                        {
                            this.atributos.Remove(atributo);
                            atributo = new Atributo(this.nombre, nuevoNombre, atributo.DirActual, tipo, indice, longitud, -1, -1);
                            this.atributos.Add(atributo);
                            this.ajustaDirecciones();
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
                this.ajustaDirecciones();
            }
            else
            {
                MessageBox.Show("Esta entidad ya tiene registros", "Error");
            }
        }

        private void ajustaDirecciones()
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

        #endregion


    }
}
