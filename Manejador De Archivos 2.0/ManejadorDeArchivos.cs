using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
            this.dataGridRegistros.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < dataGridRegistros.ColumnCount; i++)
            {
                /*Aliniamiento del texto de las celdas del data grid de los atributos*/
                this.dataGridRegistros.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            this.dataGridIdxPrimmario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < dataGridIdxPrimmario.ColumnCount; i++)
            {
                /*Aliniamiento del texto de las celdas del data grid de los atributos*/
                this.dataGridIdxPrimmario.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            this.dataGridSecundario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < dataGridSecundario.ColumnCount; i++)
            {
                /*Aliniamiento del texto de las celdas del data grid de los atributos*/
                this.dataGridSecundario.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            this.dataGridSecundarioAuxiliar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < dataGridSecundarioAuxiliar.ColumnCount; i++)
            {
                /*Aliniamiento del texto de las celdas del data grid de los atributos*/
                this.dataGridSecundarioAuxiliar.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            this.label7.Text = "N = " + Constantes.valorHash.ToString();
            this.label9.Text = "h(iS) = (iS mod " + Constantes.valorHash.ToString() + ")";
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
                                nuevo.Enabled = false;//Deshabilita la opcion de crear un nuevo archivo
                                abrir.Enabled = false;//Des habilita la opcion de abrir un nuevo archivo
                                cerrar.Enabled = true;//Habilita la opcion de cerrar el archivo
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
                        altaEntidad.Dispose();//Eliminamos el objeto
                        #endregion
                        break;
                    case "Modificar":
                        if (this.archivo.Entidades.Count > 0)
                        {
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
                        }
                    break;
                    case "Consulta":
                        if (this.archivo.Entidades.Count > 0)
                        {
                            #region Consulta
                            ConsultaEntidad consultaEntidad;
                            consultaEntidad = new ConsultaEntidad(this.archivo);
                            consultaEntidad.ShowDialog();
                            consultaEntidad.Dispose();
                            #endregion
                        }
                    break;
                    case "Eliminar":
                        if (this.archivo.Entidades.Count > 0)
                        {
                            #region Eliminar
                            SeleccionEntidad eliminaEntidad;
                            eliminaEntidad = new SeleccionEntidad(this.archivo);
                            if (eliminaEntidad.ShowDialog().Equals(DialogResult.OK))
                            {
                                string nombreAuxiliar;
                                nombreAuxiliar = this.directorio + "\\" + eliminaEntidad.Entidad;
                                archivo.eliminaEntidad(MetodosAuxiliares.ajustaCadena(eliminaEntidad.Entidad, Constantes.tam), nombreAuxiliar);
                                actualizaTodo();
                            }
                            eliminaEntidad.Dispose();
                            #endregion
                        }
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
                                                     altaAtributo.Tipo, altaAtributo.Longitud, altaAtributo.Indice,  dir,altaAtributo.DirIndice);
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
                                                         modificaAtributo.Tipo, modificaAtributo.Longitud, modificaAtributo.Indice,modificaAtributo.DirIndice);
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
                            altaRegistro.obtenLllaves += new AltaRegistro.ObtenLlaves(this.obtenLllavesEntidad);
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
                        seleccionEntidad = new SeleccionEntidad(this.archivo);
                        if(seleccionEntidad.ShowDialog().Equals(DialogResult.OK))
                        {
                            Entidad entidad;
                            entidad = this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(seleccionEntidad.Entidad, Constantes.tam));
                            seleccionRegistro = new SeleccionRegistro(entidad);
                            if (seleccionRegistro.ShowDialog().Equals(DialogResult.OK))
                            {
                                ModificaRegistro modificaRegistro;
                                modificaRegistro = new ModificaRegistro(entidad, seleccionRegistro.ClaveDeBusqueda);
                                modificaRegistro.obtenLllaves += new ModificaRegistro.ObtenLlaves(this.obtenLllavesEntidad);
                                if (modificaRegistro.ShowDialog().Equals(DialogResult.OK))
                                {
                                    this.archivo.modificaRegistro(seleccionEntidad.Entidad, seleccionRegistro.ClaveDeBusqueda, modificaRegistro.InfoOriginal, modificaRegistro.Datos,this.directorio);
                                    this.actualizaTodo();
                                }
                            }
                            seleccionRegistro.Dispose();
                        }
                        seleccionEntidad.Dispose();
                    break;
                    case "Consulta Primario":
                        seleccionEntidad = new SeleccionEntidad(this.archivo);
                        if(seleccionEntidad.ShowDialog().Equals(DialogResult.OK))
                        {
                            ConsultaRegistroPrimario consulta;
                            Entidad entidad;
                            entidad = this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(seleccionEntidad.Entidad,Constantes.tam));
                            if(entidad.Valores.Count > 0)
                            {
                                consulta = new ConsultaRegistroPrimario(entidad);
                                consulta.Show();
                            }
                            else
                            {
                                MessageBox.Show("La entidad seleccionada no contiene registros", "Error");
                            }
                        }
                    break;
                    case "Consulta Secundario":
                        seleccionEntidad = new SeleccionEntidad(this.archivo);
                        if(seleccionEntidad.ShowDialog().Equals(DialogResult.OK))
                        {
                            ConsultaRegistroSecundario consulta;
                            Entidad entidad;
                            entidad = this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(seleccionEntidad.Entidad, Constantes.tam));
                            if (entidad.Valores.Count > 0)
                            {
                                consulta = new ConsultaRegistroSecundario(entidad);
                                consulta.Show();
                            }
                            else
                            {
                                MessageBox.Show("La entidad seleccionada no contiene registros", "Error");
                            }
                        }
                    break;
                    case "Consulta Hash":
                        seleccionEntidad = new SeleccionEntidad(this.archivo);
                        if(seleccionEntidad.ShowDialog().Equals(DialogResult.OK))
                        {
                            ConsultaRegistroHash consulta;
                            Entidad entidad;
                            entidad = this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(seleccionEntidad.Entidad, Constantes.tam));
                            if (entidad.Valores.Count > 0)
                            {
                                consulta = new ConsultaRegistroHash(entidad);
                                consulta.Show();
                            }
                            else
                            {
                                MessageBox.Show("La entidad seleccionada no contiene registros", "Error");
                            }
                        }
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
            Point point;
            size = new Size(this.Size.Width - 40, this.Size.Height - 96);
            tabControl.Size = size;
            size = new Size(this.tabControl.Width - 20, this.tabControl.Height - 90);
            this.dataGridEntidad.Size = size;
            this.dataGridAtrib.Size = size;
            /*Reajusta el tabcontrol*/
            size = new Size(this.tabControl.Width / 2 -14, this.Size.Height -178);
            this.groupBoxRegistros.Size = size;
            this.groupBoxIndices.Size = size;
            /*ajustamos todo lo que pertenezca al group box de Registros */
            size = new Size(this.groupBoxRegistros.Size.Width - 12, this.groupBoxRegistros.Size.Height - 58);
            this.dataGridRegistros.Size = size;
            point = new Point(this.groupBoxRegistros.Size.Width + 6 - 133, this.comboBoxEntidad.Location.Y);
            this.comboBoxEntidad.Location = point;
            point = new Point(this.comboBoxEntidad.Location.X - 48, this.label2.Location.Y);
            this.label2.Location = point;
            /*ajustamos todo lo que pertenezca al group box de Indices */
            point = new Point(this.groupBoxRegistros.Size.Width + this.groupBoxRegistros.Location.X + 5, this.groupBoxIndices.Location.Y);
            this.groupBoxIndices.Location = point;
            size = new Size(this.groupBoxIndices.Width - 11, this.groupBoxIndices.Height - 25);
            this.tabControlIndices.Size = size;
            size = new Size(this.groupBoxIndices.Width - 30, this.groupBoxIndices.Height - 63);
            this.dataGridIdxPrimmario.Size = size;
            /*Reajusta todo lo que pertenezca a al indice Secundario*/
            size = new Size((this.tabControlIndices.Size.Width / 2) - 10, this.groupBoxIndices.Height - 108);
            this.dataGridSecundario.Size = size;
            size = new Size((this.tabControlIndices.Size.Width / 2) - 18, this.tabControlIndices.Size.Height - 57);
            this.dataGridSecundarioAuxiliar.Size = size;
            point = new Point(this.dataGridSecundario.Location.X + this.dataGridSecundario.Size.Width + 10,this.dataGridSecundarioAuxiliar.Location.Y);
            this.dataGridSecundarioAuxiliar.Location = point;
            point = new Point(this.dataGridSecundarioAuxiliar.Location.X - 3, this.label5.Location.Y);
            this.label5.Location = point;
        }

        #endregion

        #region ComboBox
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidad entidad;
            entidad = archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(comboBoxEntidad.Text, Constantes.tam));
            this.actualizaDataGridRegistros(entidad);
            this.actualizaDataGridIndicePrimario(entidad);
            this.actualizaComboIndiceSecundario(entidad);
            this.actualizaComboIndiceHash(entidad);
        }
        
        private void ComboBoxAtributosHash_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Entidad entidad;
            entidad = archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(this.comboBoxEntidad.Text, Constantes.tam));
            this.dataGridHash.Rows.Clear();
            foreach (Atributo atributo in entidad.Atributos)
            {
                if (MetodosAuxiliares.truncaCadena(atributo.Nombre).Equals(this.ComboBoxAtributosHash.Text))
                {
                    foreach(Indice indice in atributo.Indices)
                    {
                        for(int i = 0 ; i < ((HashEstatica)indice).Direcciones.Length ; i++)
                        {
                            this.dataGridHash.Rows.Add(i.ToString(), ((HashEstatica)indice).Direcciones[i].ToString());
                        }
                    }
                    break;
                }
            }
        }

        private void ComboBoxAtributosForaneos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidad entidad;
            entidad = archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(comboBoxEntidad.Text, Constantes.tam));
            this.dataGridSecundario.Rows.Clear();
            foreach (Atributo atributo in entidad.Atributos)
            {
                if (MetodosAuxiliares.truncaCadena(atributo.Nombre).Equals(this.comboBoxAtributosSecundarios.Text))
                {
                    foreach(Indice indice in atributo.Indices)
                    {
                        for (int i = 0; i < ((Secundario)indice).Llaves.Length; i++)
                        {
                            if(!MetodosAuxiliares.truncaCadena(((Secundario)indice).Llaves[i]).Equals("-1"))
                            {
                                this.dataGridSecundario.Rows.Add(MetodosAuxiliares.truncaCadena(((Secundario)indice).Llaves[i]), ((Secundario)indice).Direcciones[i]);
                            }
                        }
                    }
                    break;
                }
            }
        }
        #endregion

        #region DataGrid

        private void DataGridSecundario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            string valor;
            valor = "";
            Entidad entidad;
            Atributo atributo;
            Indice indice;
            DataGridViewCell cell;
            cell = dataGridSecundario.Rows[e.RowIndex].Cells[0];
            entidad = this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(this.comboBoxEntidad.Text, Constantes.tam));
            atributo = entidad.buscaAtributo(MetodosAuxiliares.ajustaCadena(this.comboBoxAtributosSecundarios.Text, Constantes.tam));
            this.dataGridSecundarioAuxiliar.Rows.Clear();
            if (atributo.Tipo.Equals('C'))
            {
                valor = MetodosAuxiliares.ajustaCadena(cell.Value.ToString(), atributo.Longitud);
            }
            else
            {
                valor = cell.Value.ToString();
            }
            indice = atributo.Indices.First();
            i = ((Secundario)indice).indiceLlave(valor);
            for (int j = 0; j < Constantes.tamNodoAux; j++)
            {
                if (((Secundario)indice).Apuntadores[i, j] != -1)
                {
                    this.dataGridSecundarioAuxiliar.Rows.Add(((Secundario)indice).Apuntadores[i, j]);
                }
            }
        }
        private void DataGridHash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            Entidad entidad;
            Atributo atributo;
            HashEstatica hash;
            DataGridViewCell cell;
            cell = dataGridHash.Rows[e.RowIndex].Cells[0];
            entidad = this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(this.comboBoxEntidad.Text, Constantes.tam));
            atributo = entidad.buscaAtributo(MetodosAuxiliares.ajustaCadena(this.ComboBoxAtributosHash.Text, Constantes.tam));
            this.dataGridHashAuxiliar.Rows.Clear();
            i = Int32.Parse(cell.Value.ToString());
            hash = ((HashEstatica)atributo.Indices.First());
            for (int j = 0; j < hash.Longitud; j++)
            {
                if(hash.Apuntadores[i,j] != -1)
                {
                    this.dataGridHashAuxiliar.Rows.Add(MetodosAuxiliares.truncaCadena(hash.Llaves[i, j]), hash.Apuntadores[i, j]);
                }
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

        private void actualizaDataGridRegistros(Entidad entidad)
        {
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
            foreach (Registro registro in entidad.Valores)
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

        private void actualizaDataGridIndicePrimario(Entidad entidad)
        {
            int i;
            i = entidad.buscaIndiceClavePrimaria();
            this.dataGridIdxPrimmario.Rows.Clear();
            foreach(Indice indice in entidad.Atributos[i].Indices)
            {
                foreach(NodoIndicePrimario nodo in ((Primario)indice).Idx)
                {
                    if(nodo.Direccion != -1)
                    {
                        this.dataGridIdxPrimmario.Rows.Add(nodo.ToString().Split(','));
                    }
                }
            }
        }
        private void actualizaDataGridSQLConSelect(Entidad entidad, List<Atributo> atributos, List<Registro> registros)
        {
            int i;
            int j;
            string[] tupla;
            i = 0;
            tupla = new string[atributos.Count];
            dataGridSQL.Columns.Clear();
            dataGridSQL.ColumnCount = 0;
            dataGridSQL.Rows.Clear();
            dataGridSQL.ColumnCount = atributos.Count;
            foreach (Atributo atributo in atributos)
            {
                dataGridSQL.Columns[i].Name = MetodosAuxiliares.truncaCadena(atributo.Nombre);
                i++;
            }

            foreach (Registro registro in registros)
            {
                for (int k = 0; k < tupla.Length; k++)
                {
                    j = entidad.buscaIndiceAtributo(atributos[k].Nombre);
                    tupla[k] = MetodosAuxiliares.truncaCadena(registro.Datos[j]);
                }
                dataGridSQL.Rows.Add(tupla);
            }
        }
        private void borraTodo()
        {
            this.dataGridAtrib.Rows.Clear();
            this.dataGridEntidad.Rows.Clear();
            this.label1.Text = "Cabecera = ?";
            this.dataGridRegistros.Rows.Clear();
            this.dataGridRegistros.ColumnCount = 0;
            this.dataGridSQL.Rows.Clear();
            this.dataGridSQL.ColumnCount = 0;
            this.comboBoxEntidad.Items.Clear();
            this.comboBoxEntidad.Text = "";
            this.comboBoxAtributosSecundarios.Items.Clear();
            this.comboBoxAtributosSecundarios.Text = "";
            this.dataGridIdxPrimmario.Rows.Clear();
            this.dataGridSecundario.Rows.Clear();
            this.dataGridSecundarioAuxiliar.Rows.Clear();
            this.ComboBoxAtributosHash.Items.Clear();
            this.dataGridHash.Rows.Clear();
            this.dataGridHashAuxiliar.Rows.Clear();
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
            this.comboBoxEntidad.Items.Clear();
            foreach (Entidad entidad in archivo.Entidades)
            {
                if (entidad.DirRegistros != -1)
                {
                    this.comboBoxEntidad.Items.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre));
                }
            }
        }

        private void actualizaComboIndiceHash(Entidad entidad)
        {
            this.ComboBoxAtributosHash.Items.Clear();
            foreach (Atributo atributo in entidad.Atributos)
            {
                if (atributo.Indice == 5)
                {
                    this.ComboBoxAtributosHash.Items.Add(MetodosAuxiliares.truncaCadena(atributo.Nombre));
                }
            }
            if (this.ComboBoxAtributosHash.Items.Count > 0)
            {
                this.ComboBoxAtributosHash.Text = this.ComboBoxAtributosHash.Items[0].ToString();
            }
        }
        private void actualizaComboIndiceSecundario(Entidad entidad)
        {
            this.comboBoxAtributosSecundarios.Items.Clear();
            foreach (Atributo atributo in entidad.Atributos)
            {
                if (atributo.Indice == 4)
                {
                    this.comboBoxAtributosSecundarios.Items.Add(MetodosAuxiliares.truncaCadena(atributo.Nombre));
                }
            }
            if (this.comboBoxAtributosSecundarios.Items.Count > 0)
            {
                this.comboBoxAtributosSecundarios.Text = this.comboBoxAtributosSecundarios.Items[0].ToString();
            }
        }
        #endregion

        #region delegados
        public List<string> obtenLllavesEntidad(long direccion)
        {
            Entidad referencia;
            referencia = this.archivo.buscaEntidad(direccion);
            return referencia.LlavePrimaria;
        }

        #endregion

        #endregion

        #region SQL

        private void ConsultaSQL_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxSQL.Text))
            {
                try
                {
                    if (this.textBoxSQL.Text.Contains("select"))
                    {
                        string[] sentencia;
                        sentencia = this.textBoxSQL.Text.Split((" ").ToCharArray());
                        if (sentencia.First().Equals("select"))
                        {
                            Entidad entidad;
                            List<Registro> registros;
                            List<Atributo> atributos;
                            entidad = null;
                            atributos = this.archivo.ConsultaAtributosSelect(sentencia, ref entidad);
                            if (entidad.Atributos.Count != 0)
                            {
                                if (entidad.Registros.Count != 0)
                                {
                                    if (!sentencia.Contains("where"))
                                    {
                                        registros = entidad.Valores;
                                        this.actualizaDataGridSQLConSelect(entidad, atributos, registros);
                                    }
                                    else
                                    {

                                        //registros = this.archivo.ConsultaRegistrosSelectWhere(atributos,entidad);
                                    }
                                }
                                else
                                {
                                    throw new InvalidConsultException("La entidad a consultar no tiene registros para consultar");
                                }
                            }
                            else
                            {
                                throw new InvalidConsultException("La entidad a consultar no tiene atributos para consultar");
                            }

                        }
                        else
                        {
                            throw new InvalidConsultException("El select debe ir al principio de la sentencia");
                        }
                    }
                    else if (this.textBoxSQL.Text.Contains("innner"))
                    {
                        throw new NotImplementedException("El comando inner aun no se implementa");
                    }
                    else
                    {
                        throw new InvalidConsultException("Formato de consulta no valido");
                    }
                }
                catch (InvalidConsultException e1)
                {
                    MessageBox.Show(e1.Message, "Consulta Invalida");
                }
                catch (NotImplementedException e2)
                {
                    MessageBox.Show(e2.Message, "Aun no implementado");
                }
            }
            else
            {
                MessageBox.Show("La cadena no puede estar vacia");
            }
        }
        #endregion
    }
}