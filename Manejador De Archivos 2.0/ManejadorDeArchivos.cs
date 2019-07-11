using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador_De_Archivos_2._0
{
    public partial class ManejadorDeArchivos : Form
    {
        #region Variables de Instancia
        private Archivo archivo;
        string directorio;
        #endregion

        #region Constructores

        public ManejadorDeArchivos()
        {
            InitializeComponent();
        }

        private void ManejadorDeArchivos_Load(object sender, EventArgs e)
        {
            /*Cargador de la ventana principal*/
            this.dataGridEntidad.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < dataGridEntidad.ColumnCount; i++)
            {
                /*Aliniamiento del texto de las celdas del data grid de las entidades*/
                this.dataGridEntidad.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            this.dataGridAtrib.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < dataGridAtrib.ColumnCount; i++)
            {
                /*Aliniamiento del texto de las celdas del data grid de los atributos*/
                this.dataGridAtrib.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            this.directorio = Environment.CurrentDirectory + @"..\BasesDeDatos";
        }

        #endregion

        #region Eventos

        #region Menu
        private void tool_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.AccessibleName)
            {
                case "Nuevo":
                    if (this.archivo == null)//Verifica que no exista una base abierta
                    {
                        NuevaBase nuevaBase;
                        string nombre;
                        FileStream file;
                        nuevaBase = new NuevaBase();
                        if(nuevaBase.ShowDialog().Equals(DialogResult.OK))
                        {
                            this.directorio += @"..\" + nuevaBase.Nombre;//Crea la dirección del archivo
                            if (!Directory.Exists(this.directorio))//Verifica si la carpeta existe
                            {
                                Directory.CreateDirectory(this.directorio);//Si no existe La crea
                                nombre = this.directorio + "\\" + nuevaBase.Nombre + ".diccionario";//Crea el nombre del archivo
                                this.archivo = new Archivo(nombre);//Construye el objeto archivo
                                file = new FileStream(nombre, FileMode.Create);//Crea el archivo en disco
                                file.Close();
                                archivo.grabaCabecera();//Graba la cabecera del archivo
                            }
                            else
                            {
                                MessageBox.Show("Ya existe esa base de datos", "Error");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor cierre primero la base de datos", "Error");
                    }
                break;
                case "Cerrar":
                    if(this.archivo != null)
                    {
                        this.directorio = Environment.CurrentDirectory + @"..\BasesDeDatos";
                        this.archivo = null;
                        this.borraDataGreed();
                    }
                break;
                default:
                    MessageBox.Show("Opción incorrecta o no implementada","Atención");
                break;
            }
        }
        
        private void entidades_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Entidades
            if (this.archivo != null)
            {
                switch (e.ClickedItem.AccessibleName)
                {
                    case "Alta":
                        #region Alta
                        AltaEntidad altaEntidad = new AltaEntidad(archivo.Nombre);
                        if (altaEntidad.ShowDialog() == DialogResult.OK)
                        {
                            string nombre;
                            long dir;
                            nombre = MetodosAuxiliares.ajustaCadena(altaEntidad.Nombre, Constantes.tam);
                            if (!archivo.existeEntidad(nombre))//Verifica que la entidad no exista en el archivo
                            {
                                FileStream abierto;
                                abierto = new FileStream(archivo.Nombre, FileMode.Append);//abre el archivo en un file stream
                                dir = (long)abierto.Seek(0, SeekOrigin.End);//Calcula la direccion final del archivo y lo mete en un long
                                abierto.Close();//Cierra el file Stream
                                archivo.altaEntidad(nombre, dir, -1, -1, -1);//Da de alta la entidad
                                this.actualizaTodo();//Actualiza todos los Data Grid
                            }
                            else
                            {
                                MessageBox.Show("Esa entidad esta dada de alta", "Invalido");//Arroja un mensaje de error si la entidad existe
                            }
                        }
                        altaEntidad.Dispose();//Eliminamos el objeto
                        #endregion
                    break;
                    case "Modificar":
                    break;
                    case "Consulta":
                        #region Consulta
                        ConsultaEntidad consultaEntidad;
                        consultaEntidad = new ConsultaEntidad(this.archivo);
                        consultaEntidad.ShowDialog();
                        consultaEntidad.Dispose();
                        #endregion
                    break;
                    case "Eliminar":
                    break;
                    default:
                        MessageBox.Show("Opción incorrecta o no implementada", "Atención");
                    break;
                }
            }
            else
            {
                MessageBox.Show("Por favor abra una base de datos", "Error");
            }
            #endregion
        }

        private void atributos_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.AccessibleName)
            {
                case "Alta":
                    break;
                case "Modificar":
                    break;
                case "Consulta":
                    break;
                case "Eliminar":
                    break;
                default:
                    MessageBox.Show("Opción incorrecta o no implementada", "Atención");
                    break;
            }
        }

        #endregion
        
        #endregion

        #region Metodos

        #region DataGrid

        private void actualizaDataGreedEntidad()
        {
            dataGridEntidad.Rows.Clear();
            if (dataGridEntidad.Columns.Count > 0)
            {
                foreach (Entidad entidad in archivo.Entidades)
                {
                    dataGridEntidad.Rows.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre),
                                                entidad.DirActual,
                                                entidad.DirRegistros,
                                                entidad.DirAtributos,
                                                entidad.DirSig);
                }
            }
        }

        private void actualizaDataGreedAtrib()
        {
            dataGridAtrib.Rows.Clear();
            foreach (Entidad entidad in archivo.Entidades)
            {
                foreach(Atributo atributo in entidad.Atributos)
                {
                    dataGridAtrib.Rows.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre),
                                           MetodosAuxiliares.truncaCadena(atributo.Nombre),
                                           atributo.DirActual,
                                           atributo.Tipo,
                                           MetodosAuxiliares.traduceIndice(atributo.Indice),
                                           atributo.Longitud,
                                           atributo.DirIndice,
                                           atributo.DirSig);
                }
                if (entidad.Atributos.Count != 0)
                {
                    dataGridAtrib.Rows.Add("-", "-", "-", "-", "-", "-", "-", "-");
                }
            }
        }

        private void borraDataGreed()
        {
            this.dataGridAtrib.Rows.Clear();
            this.dataGridEntidad.Rows.Clear();
            /*this.dataGridRegistros.Rows.Clear();
            this.comboEntidadRegistros.Items.Clear();*/
        }

        private void actualizaTodo()
        {
            this.borraDataGreed();
            this.actualizaDataGreedEntidad();
            this.actualizaDataGreedAtrib();
            //this.actualizaComboEntidadRegistros();
        }

        #endregion


        #endregion
    }
}
