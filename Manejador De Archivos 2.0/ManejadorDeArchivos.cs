using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Manejador_De_Archivos_2._0
{
    public partial class ManejadorDeArchivos : Form
    {

        #region Variables de Instancia
        private Archivo archivo;
        private string directorio;
        #endregion

        #region Constructores

        public ManejadorDeArchivos()
        {
            InitializeComponent();
        }

        private void ManejadorDeArchivos_Load(object sender, EventArgs e)
        {
            this.directorio = Environment.CurrentDirectory + @"..\BasesDeDatos";
            if (!Directory.Exists(this.directorio))//Verifica si la carpeta existe
            {
                Directory.CreateDirectory(this.directorio);
            }
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
        }

        #endregion 

        #region Eventos

        #region Menu

        private void tool_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.AccessibleName)
            {
                case "Nuevo":
                    #region Nuevo
                    if (this.archivo == null)//Verifica que no exista una base abierta
                    {
                        NuevaBase nuevaBase;
                        string nombre;
                        FileStream file;
                        nuevaBase = new NuevaBase();
                        if (nuevaBase.ShowDialog().Equals(DialogResult.OK))
                        {
                            this.directorio += @"..\" + nuevaBase.Nombre;//Crea la dirección del archivo
                            if (!Directory.Exists(this.directorio))//Verifica si la carpeta existe
                            {
                                Directory.CreateDirectory(this.directorio);//Si no existe La crea
                                nombre = this.directorio + "\\" + nuevaBase.Nombre + ".dd";//Crea el nombre del archivo
                                this.archivo = new Archivo(nombre);//Construye el objeto archivo
                                file = new FileStream(nombre, FileMode.Create);//Crea el archivo en disco
                                file.Close();
                                archivo.grabaCabecera();//Graba la cabecera del archivo
                                this.actualizaTodo();
                            }
                            else
                            {
                                MessageBox.Show("Ya existe esa base de datos", "Error");
                            }
                        }
                        nuevaBase.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Por favor cierre primero la base de datos", "Error");
                    }
                    #endregion
                    break;
                case "Abrir":
                    #region Abrir
                    try
                    {
                        openFileDialog.Title = "Abrir Base de Datos";//Titulo del dialogo
                        openFileDialog.DefaultExt = ".dd";//Extencion predeterminada
                        openFileDialog.Filter = "(*.dd) | *.dd";//Filtro de Extenciones
                        openFileDialog.AddExtension = true;//Habilita la opcion para añadir la extension 
                        openFileDialog.RestoreDirectory = true;
                        openFileDialog.InitialDirectory = directorio;//Redirecciona la carpeta del directorio inicial al directorio donde se encuentra el ejecutable
                        if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
                        {
                            nuevo.Enabled = false;//Deshabilita la opcion de crear un nuevo archivo
                            abrir.Enabled = false;//Des habilita la opcion de abrir un nuevo archivo
                            cerrar.Enabled = true;//Habilita la opcion de cerrar el archivo
                            archivo = new Archivo(openFileDialog.FileName);//Crea el objeto archivo
                            this.directorio += "\\" + openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.Length - 3);
                            this.archivo.leeArchivo(this.directorio);//Lee el archivo y construye la lista de listas
                            this.actualizaTodo();//Manda actualizar los combo box y los data grid
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("Archivo No Entcontrado");
                    }
                    #endregion
                    break;
                case "Cerrar":
                    if (this.archivo != null)
                    {
                        this.directorio = Environment.CurrentDirectory + @"..\BasesDeDatos";
                        this.archivo = null;
                        nuevo.Enabled = true;//Habilita la opcion de crear un nuevo archivo
                        abrir.Enabled = true;//Habilita la opcion de abrir un nuevo archivo
                        cerrar.Enabled = false;//Deshabilita la opcion de cerrar el archivo
                        this.borraTodo();
                    }
                    break;
                default:
                    MessageBox.Show("Opción incorrecta o no implementada", "Atención");
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
                            nombre = MetodosAuxiliares.ajustaCadena(altaEntidad.Nombre, Constantes.tam);
                            if (!archivo.existeEntidad(nombre))//Verifica que la entidad no exista en el archivo
                            {
                                long dir;
                                FileStream abierto;
                                abierto = new FileStream(archivo.Nombre, FileMode.Append);//abre el archivo en un file stream
                                dir = (long)abierto.Seek(0, SeekOrigin.End);//Calcula la direccion final del archivo y lo mete en un long
                                abierto.Close();//Cierra el file Stream
                                archivo.altaEntidad(nombre, dir, -1, -1, -1);//Da de alta la entidad
                                abierto = new FileStream(this.directorio + "\\" + altaEntidad.Nombre + ".dat", FileMode.Create);//Crea el archivo .dat de la entidad
                                abierto.Close();
                                abierto = new FileStream(this.directorio + "\\" + altaEntidad.Nombre + ".idx", FileMode.Create);//Crea el archivo .idx de la entidad
                                abierto.Close();
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
                        #region Modificar
                        ModificaEntidad modificaEntidad;
                        modificaEntidad = new ModificaEntidad(this.archivo);
                        if (modificaEntidad.ShowDialog().Equals(DialogResult.OK))
                        {
                            string original;
                            string nuevo;
                            archivo.modificaEntidad(MetodosAuxiliares.ajustaCadena(modificaEntidad.Entidad, Constantes.tam),
                                                    MetodosAuxiliares.ajustaCadena(modificaEntidad.Cambio, Constantes.tam));
                            original = this.directorio + "\\" + modificaEntidad.Entidad + ".dat";
                            nuevo = this.directorio + "\\" + modificaEntidad.Cambio + ".dat";
                            File.Move(original, nuevo);
                            original = this.directorio + "\\" + modificaEntidad.Entidad + ".idx";
                            nuevo = this.directorio + "\\" + modificaEntidad.Cambio + ".idx";
                            File.Move(original, nuevo);
                            this.actualizaTodo();
                        }
                        modificaEntidad.Dispose();
                        #endregion
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
                        #region Eliminar
                        SeleccionEntidad eliminaEntidad;
                        eliminaEntidad = new SeleccionEntidad(this.archivo);
                        if (eliminaEntidad.ShowDialog().Equals(DialogResult.OK))
                        {
                            string nombreAuxiliar;
                            archivo.eliminaEntidad(MetodosAuxiliares.ajustaCadena(eliminaEntidad.Entidad, Constantes.tam));
                            nombreAuxiliar = this.directorio + "\\" + eliminaEntidad.Entidad;
                            File.Delete(nombreAuxiliar + ".dat");
                            File.Delete(nombreAuxiliar + ".idx");
                            actualizaTodo();
                        }
                        eliminaEntidad.Dispose();
                        #endregion
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
            #region Atributos
            if (this.archivo != null)
            {
                if (this.archivo.Entidades.Count != 0)
                {
                    #region Existen Entidades
                    switch (e.ClickedItem.AccessibleName)
                    {
                        case "Alta":
                            #region Alta
                            AltaAtributo altaAtributo;
                            altaAtributo = new AltaAtributo(this.archivo);
                            if (altaAtributo.ShowDialog().Equals(DialogResult.OK))
                            {
                                long dir;
                                FileStream abierto;
                                abierto = new FileStream(archivo.Nombre, FileMode.Append);//abre el archivo en un file stream
                                dir = (long)abierto.Seek(0, SeekOrigin.End);//Calcula la direccion final del archivo y lo mete en un long
                                abierto.Close();//Cierra el file Stream
                                archivo.altaAtributo(MetodosAuxiliares.ajustaCadena(altaAtributo.Entidad, Constantes.tam),
                                                     MetodosAuxiliares.ajustaCadena(altaAtributo.Nombre, Constantes.tam),
                                                     altaAtributo.Tipo, altaAtributo.Longitud, altaAtributo.Indice, dir);
                                this.actualizaTodo();
                            }
                            altaAtributo.Dispose();
                            #endregion
                            break;
                        case "Modificar":
                            #region Modificar
                            ModificaAtributo modificaAtributo;
                            modificaAtributo = new ModificaAtributo(archivo);
                            if (modificaAtributo.ShowDialog().Equals(DialogResult.OK))
                            {
                                archivo.modificaAtributo(MetodosAuxiliares.ajustaCadena(modificaAtributo.Entidad, Constantes.tam),
                                                         MetodosAuxiliares.ajustaCadena(modificaAtributo.Atributo, Constantes.tam),
                                                         MetodosAuxiliares.ajustaCadena(modificaAtributo.Nombre, Constantes.tam),
                                                         modificaAtributo.Tipo, modificaAtributo.Longitud, modificaAtributo.Indice);
                                this.actualizaTodo();
                            }
                            modificaAtributo.Dispose();
                            #endregion
                            break;
                        case "Consulta":
                            #region Consulta
                            ConsultaAtributo consultaAtributo;
                            consultaAtributo = new ConsultaAtributo(this.archivo);
                            consultaAtributo.ShowDialog();
                            consultaAtributo.Dispose();
                            #endregion
                            break;
                        case "Eliminar":
                            #region Eliminar
                            EliminarAtributo eliminarAtributo;
                            eliminarAtributo = new EliminarAtributo(this.archivo);
                            if (eliminarAtributo.ShowDialog().Equals(DialogResult.OK))
                            {
                                this.archivo.eliminaAtributo(MetodosAuxiliares.ajustaCadena(eliminarAtributo.Entidad, Constantes.tam),
                                                             MetodosAuxiliares.ajustaCadena(eliminarAtributo.Atributo, Constantes.tam));
                                this.actualizaTodo();
                            }
                            eliminarAtributo.Dispose();
                            #endregion
                            break;
                        default:
                            MessageBox.Show("Opción incorrecta o no implementada", "Atención");
                            break;
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("Por favor Agregue Entidades primero", "Imposible");
                }
            }
            else
            {
                MessageBox.Show("Por favor cree una base de d   atos primero", "Error");
            }
            #endregion
        }

        private void registros_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Registros
            if (this.archivo != null)
            {
                SeleccionEntidad seleccionEntidad;
                SeleccionRegistro seleccionRegistro;
                switch (e.ClickedItem.AccessibleName)
                {
                    case "Alta":
                        seleccionEntidad = new SeleccionEntidad(this.archivo);
                        if (seleccionEntidad.ShowDialog().Equals(DialogResult.OK))
                        {
                            AltaRegistro altaRegistro;
                            altaRegistro = new AltaRegistro(this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(seleccionEntidad.Entidad, Constantes.tam)));
                            if (altaRegistro.ShowDialog().Equals(DialogResult.OK))
                            {
                                this.archivo.altaRegistro(MetodosAuxiliares.ajustaCadena(seleccionEntidad.Entidad, Constantes.tam),
                                                         this.directorio, altaRegistro.Informacion);
                                this.actualizaTodo();
                            }
                            altaRegistro.Dispose();
                        }
                        seleccionEntidad.Dispose();
                        break;
                    case "Modificar":
                    break;
                    case "Eliminar":
                        seleccionEntidad = new SeleccionEntidad(this.archivo);
                        if (seleccionEntidad.ShowDialog().Equals(DialogResult.OK))
                        {
                            seleccionRegistro = new SeleccionRegistro(this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(seleccionEntidad.Entidad, Constantes.tam)));
                            if (seleccionRegistro.ShowDialog().Equals(DialogResult.OK))
                            {
                                this.archivo.eliminaRegistro(MetodosAuxiliares.ajustaCadena(seleccionEntidad.Entidad,Constantes.tam),
                                                             seleccionRegistro.ClaveDeBusqueda, this.directorio);
                                this.actualizaTodo();
                            }
                        }
                        seleccionEntidad.Dispose();
                    break;
                    default:
                        MessageBox.Show("Opción incorrecta o no implementada", "Atención");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Por favor abra una base de datos o cree", "Error");
            }

        }
        
        #endregion

        #endregion

        #region Area Cliente

        private void ManejadorDeArchivos_Resize(object sender, EventArgs e)
        {
            Size size;
            size = new Size(this.Size.Width - 16, this.Size.Height - 85);
            tabRegistros.Size = size;
            size = new Size(this.tabRegistros.Width - 11, this.tabRegistros.Height - 98);
            this.dataGridEntidad.Size = size;
            this.dataGridAtrib.Size = size;
        }

        #endregion

        #region ComboBox
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidad entidad;
            entidad = archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(comboBox1.Text, Constantes.tam));
            dataGridRegistros.Columns.Clear();
            dataGridRegistros.ColumnCount = 0;
            dataGridRegistros.Rows.Clear();
            dataGridRegistros.ColumnCount = entidad.Atributos.Count + 2;
            dataGridRegistros.Columns[0].Name = "Dirección Actual";
            dataGridRegistros.Columns[dataGridRegistros.ColumnCount - 1].Name = "Dirección Siguiente";
            int i;
            i = 1;
            foreach (Atributo atributo in entidad.Atributos)
            {
                dataGridRegistros.Columns[i].Name = MetodosAuxiliares.truncaCadena(atributo.Nombre);
                i++;
            }
            i = 0;
            foreach (Registro registro in entidad.Registros)
            {
                int j = 1;
                int k = 0;
                dataGridRegistros.Rows.Add();
                dataGridRegistros.Rows[i].Cells[0].Value = registro.DirAct;
                dataGridRegistros.Rows[i].Cells[dataGridRegistros.ColumnCount - 1].Value = registro.DirSig;
                foreach (Atributo atributo in entidad.Atributos)
                {
                    dataGridRegistros.Rows[i].Cells[j].Value = MetodosAuxiliares.truncaCadena(registro.Datos[k++]);
                    j++;
                }
                i++;
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
                foreach (Atributo atributo in entidad.Atributos)
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

        private void borraTodo()
        {
            this.dataGridAtrib.Rows.Clear();
            this.dataGridEntidad.Rows.Clear();
            this.label1.Text = "Cabecera = ?";
            this.dataGridRegistros.Rows.Clear();
            this.dataGridRegistros.ColumnCount = 0;
            this.comboBox1.Items.Clear();
            this.comboBox1.Text = "";
        }

        private void actualizaTodo()
        {
            this.borraTodo();
            this.actualizaDataGreedEntidad();
            this.actualizaDataGreedAtrib();
            this.actualizaComboEntidadRegistros();
            this.label1.Text = "Cabecera = " + this.archivo.Cabecera.ToString();
        }

        #endregion

        #region ComboBox
        private void actualizaComboEntidadRegistros()
        {
            this.comboBox1.Items.Clear();
            foreach (Entidad entidad in archivo.Entidades)
            {
                if (entidad.DirRegistros != -1)
                {
                    this.comboBox1.Items.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre));
                }
            }
        }
        #endregion

        #endregion


    }
}
