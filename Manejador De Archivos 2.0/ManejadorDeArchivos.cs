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
                    if (this.archivo == null)
                    {
                        NuevaBase nuevaBase;
                        string nombre;
                        FileStream file;
                        nuevaBase = new NuevaBase();
                        if(nuevaBase.ShowDialog().Equals(DialogResult.OK))
                        {
                            this.directorio += @"..\" + nuevaBase.Nombre;
                            if (!Directory.Exists(this.directorio))
                            {
                                Directory.CreateDirectory(this.directorio);
                                nombre = this.directorio + "\\" + nuevaBase.Nombre + ".diccionario";
                                this.archivo = new Archivo(nombre);
                                file = new FileStream(nombre, FileMode.Create);
                                file.Close();
                                archivo.grabaCabecera();
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
                    }
                break;
                default:
                    MessageBox.Show("Opción incorrecta o no implementada","Atención");
                break;
            }
        }
        
        private void entidades_Clicked(object sender, ToolStripItemClickedEventArgs e)
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
                foreach (Entidad busca in archivo.Entidades)
                {
                    /*dataGridEntidad.Rows.Add(MetodosAuxiliares.truncaCadena(busca.Nombre),
                                                busca.DirActual,
                                                busca.DirRegistros,
                                                busca.DirAtributos,
                                                busca.DirSig);*/
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
                    /*dataGridAtrib.Rows.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre),
                                           MetodosAuxiliares.truncaCadena(atributo.Nombre),
                                           atributo.DirActual,
                                           atributo.Tipo,
                                           MetodosAuxiliares.traduceIndice(atributo.Indice),
                                           atributo.Longitud,
                                           atributo.DirIndice,
                                           atributo.DirSig);*/
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
