namespace Manejador_De_Archivos_2._0
{
    partial class ManejadorDeArchivos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManejadorDeArchivos));
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.nuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.renombrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.abrir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrar = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabEntidades = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridEntidad = new System.Windows.Forms.DataGridView();
            this.nombreEntidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionEntidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccioDeDatos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirAtrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dirSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuEntidades = new System.Windows.Forms.MenuStrip();
            this.altaEntidad = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarEntidad = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaEntidad = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarEntidad = new System.Windows.Forms.ToolStripMenuItem();
            this.tabAtributos = new System.Windows.Forms.TabPage();
            this.dataGridAtrib = new System.Windows.Forms.DataGridView();
            this.Entidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDeIndice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirIndice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirSig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuAtributos = new System.Windows.Forms.MenuStrip();
            this.altaAtributo = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarAtributo = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaAtributo = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarAtributo = new System.Windows.Forms.ToolStripMenuItem();
            this.tabRegistros = new System.Windows.Forms.TabPage();
            this.groupBoxRegistros = new System.Windows.Forms.GroupBox();
            this.dataGridRegistros = new System.Windows.Forms.DataGridView();
            this.comboBoxEntidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxIndices = new System.Windows.Forms.GroupBox();
            this.tabControlIndices = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridIdxPrimmario = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridSecundario = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSecundarioAuxiliar = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAtributosSecundarios = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridHash = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridHashAuxiliar = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboBoxAtributosHash = new System.Windows.Forms.ComboBox();
            this.menuRegistros = new System.Windows.Forms.MenuStrip();
            this.altaRegistros = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarRegistros = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarRegistros = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolBar.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabEntidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidad)).BeginInit();
            this.menuEntidades.SuspendLayout();
            this.tabAtributos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtrib)).BeginInit();
            this.menuAtributos.SuspendLayout();
            this.tabRegistros.SuspendLayout();
            this.groupBoxRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRegistros)).BeginInit();
            this.groupBoxIndices.SuspendLayout();
            this.tabControlIndices.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIdxPrimmario)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSecundario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSecundarioAuxiliar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHashAuxiliar)).BeginInit();
            this.menuRegistros.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.CanOverflow = false;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevo,
            this.toolStripSeparator1,
            this.renombrar,
            this.toolStripSeparator2,
            this.abrir,
            this.toolStripSeparator3,
            this.cerrar});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(889, 37);
            this.toolBar.TabIndex = 0;
            this.toolBar.Text = "Menu";
            this.toolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tool_Clicked);
            // 
            // nuevo
            // 
            this.nuevo.AccessibleName = "Nuevo";
            this.nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevo.Image = ((System.Drawing.Image)(resources.GetObject("nuevo.Image")));
            this.nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(34, 34);
            this.nuevo.Text = "Nuevo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // renombrar
            // 
            this.renombrar.AccessibleName = "Renombrar";
            this.renombrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renombrar.Enabled = false;
            this.renombrar.Image = ((System.Drawing.Image)(resources.GetObject("renombrar.Image")));
            this.renombrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.renombrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renombrar.Name = "renombrar";
            this.renombrar.Size = new System.Drawing.Size(34, 34);
            this.renombrar.Text = "Renombrar Bases de Datos";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // abrir
            // 
            this.abrir.AccessibleName = "Abrir";
            this.abrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrir.Image = ((System.Drawing.Image)(resources.GetObject("abrir.Image")));
            this.abrir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.abrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(34, 34);
            this.abrir.Text = "Abrir";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // cerrar
            // 
            this.cerrar.AccessibleName = "Cerrar";
            this.cerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cerrar.Enabled = false;
            this.cerrar.Image = ((System.Drawing.Image)(resources.GetObject("cerrar.Image")));
            this.cerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(34, 34);
            this.cerrar.Text = "Cerrar";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabEntidades);
            this.tabControl.Controls.Add(this.tabAtributos);
            this.tabControl.Controls.Add(this.tabRegistros);
            this.tabControl.Location = new System.Drawing.Point(12, 44);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(865, 386);
            this.tabControl.TabIndex = 1;
            // 
            // tabEntidades
            // 
            this.tabEntidades.BackColor = System.Drawing.SystemColors.Control;
            this.tabEntidades.Controls.Add(this.label1);
            this.tabEntidades.Controls.Add(this.dataGridEntidad);
            this.tabEntidades.Controls.Add(this.menuEntidades);
            this.tabEntidades.Location = new System.Drawing.Point(4, 22);
            this.tabEntidades.Name = "tabEntidades";
            this.tabEntidades.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntidades.Size = new System.Drawing.Size(857, 360);
            this.tabEntidades.TabIndex = 0;
            this.tabEntidades.Text = "Entidades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cabecera ";
            // 
            // dataGridEntidad
            // 
            this.dataGridEntidad.AllowUserToAddRows = false;
            this.dataGridEntidad.AllowUserToDeleteRows = false;
            this.dataGridEntidad.AllowUserToResizeColumns = false;
            this.dataGridEntidad.AllowUserToResizeRows = false;
            this.dataGridEntidad.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridEntidad.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridEntidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEntidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreEntidad,
            this.direccionEntidad,
            this.direccioDeDatos,
            this.DirAtrib,
            this.dirSiguiente});
            this.dataGridEntidad.Location = new System.Drawing.Point(6, 58);
            this.dataGridEntidad.MultiSelect = false;
            this.dataGridEntidad.Name = "dataGridEntidad";
            this.dataGridEntidad.RowHeadersVisible = false;
            this.dataGridEntidad.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridEntidad.ShowCellErrors = false;
            this.dataGridEntidad.ShowCellToolTips = false;
            this.dataGridEntidad.ShowEditingIcon = false;
            this.dataGridEntidad.ShowRowErrors = false;
            this.dataGridEntidad.Size = new System.Drawing.Size(845, 296);
            this.dataGridEntidad.TabIndex = 2;
            this.dataGridEntidad.TabStop = false;
            // 
            // nombreEntidad
            // 
            this.nombreEntidad.HeaderText = "Nombre";
            this.nombreEntidad.Name = "nombreEntidad";
            this.nombreEntidad.Width = 160;
            // 
            // direccionEntidad
            // 
            this.direccionEntidad.HeaderText = "Direccion Entidad";
            this.direccionEntidad.Name = "direccionEntidad";
            this.direccionEntidad.Width = 160;
            // 
            // direccioDeDatos
            // 
            this.direccioDeDatos.HeaderText = "Direccion de Datos";
            this.direccioDeDatos.Name = "direccioDeDatos";
            this.direccioDeDatos.Width = 160;
            // 
            // DirAtrib
            // 
            this.DirAtrib.HeaderText = "Direccion Atributos";
            this.DirAtrib.Name = "DirAtrib";
            this.DirAtrib.Width = 160;
            // 
            // dirSiguiente
            // 
            this.dirSiguiente.HeaderText = "DireccionSiguiente";
            this.dirSiguiente.Name = "dirSiguiente";
            this.dirSiguiente.Width = 160;
            // 
            // menuEntidades
            // 
            this.menuEntidades.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaEntidad,
            this.modificarEntidad,
            this.consultaEntidad,
            this.eliminarEntidad});
            this.menuEntidades.Location = new System.Drawing.Point(3, 3);
            this.menuEntidades.Name = "menuEntidades";
            this.menuEntidades.Size = new System.Drawing.Size(851, 24);
            this.menuEntidades.TabIndex = 0;
            this.menuEntidades.Text = "menuStrip1";
            this.menuEntidades.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.entidades_Clicked);
            // 
            // altaEntidad
            // 
            this.altaEntidad.AccessibleName = "Alta";
            this.altaEntidad.Name = "altaEntidad";
            this.altaEntidad.Size = new System.Drawing.Size(40, 20);
            this.altaEntidad.Text = "Alta";
            // 
            // modificarEntidad
            // 
            this.modificarEntidad.AccessibleName = "Modificar";
            this.modificarEntidad.Name = "modificarEntidad";
            this.modificarEntidad.Size = new System.Drawing.Size(70, 20);
            this.modificarEntidad.Text = "Modificar";
            // 
            // consultaEntidad
            // 
            this.consultaEntidad.AccessibleName = "Consulta";
            this.consultaEntidad.Name = "consultaEntidad";
            this.consultaEntidad.Size = new System.Drawing.Size(66, 20);
            this.consultaEntidad.Text = "Consulta";
            // 
            // eliminarEntidad
            // 
            this.eliminarEntidad.AccessibleName = "Eliminar";
            this.eliminarEntidad.Name = "eliminarEntidad";
            this.eliminarEntidad.Size = new System.Drawing.Size(62, 20);
            this.eliminarEntidad.Text = "Eliminar";
            // 
            // tabAtributos
            // 
            this.tabAtributos.BackColor = System.Drawing.SystemColors.Control;
            this.tabAtributos.Controls.Add(this.dataGridAtrib);
            this.tabAtributos.Controls.Add(this.menuAtributos);
            this.tabAtributos.Location = new System.Drawing.Point(4, 22);
            this.tabAtributos.Name = "tabAtributos";
            this.tabAtributos.Padding = new System.Windows.Forms.Padding(3);
            this.tabAtributos.Size = new System.Drawing.Size(857, 360);
            this.tabAtributos.TabIndex = 1;
            this.tabAtributos.Text = "Atributos";
            // 
            // dataGridAtrib
            // 
            this.dataGridAtrib.AllowUserToAddRows = false;
            this.dataGridAtrib.AllowUserToDeleteRows = false;
            this.dataGridAtrib.AllowUserToResizeColumns = false;
            this.dataGridAtrib.AllowUserToResizeRows = false;
            this.dataGridAtrib.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridAtrib.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAtrib.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entidad,
            this.Nombre,
            this.DirActual,
            this.Tipo,
            this.TipoDeIndice,
            this.Longitud,
            this.DirIndice,
            this.DirSig});
            this.dataGridAtrib.Location = new System.Drawing.Point(6, 58);
            this.dataGridAtrib.MultiSelect = false;
            this.dataGridAtrib.Name = "dataGridAtrib";
            this.dataGridAtrib.RowHeadersVisible = false;
            this.dataGridAtrib.ShowCellErrors = false;
            this.dataGridAtrib.ShowCellToolTips = false;
            this.dataGridAtrib.ShowEditingIcon = false;
            this.dataGridAtrib.ShowRowErrors = false;
            this.dataGridAtrib.Size = new System.Drawing.Size(845, 296);
            this.dataGridAtrib.TabIndex = 11;
            this.dataGridAtrib.TabStop = false;
            // 
            // Entidad
            // 
            this.Entidad.HeaderText = "Entidad";
            this.Entidad.Name = "Entidad";
            this.Entidad.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // DirActual
            // 
            this.DirActual.HeaderText = "DirActual";
            this.DirActual.Name = "DirActual";
            this.DirActual.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // TipoDeIndice
            // 
            this.TipoDeIndice.HeaderText = "Tipo de Indice";
            this.TipoDeIndice.Name = "TipoDeIndice";
            this.TipoDeIndice.ReadOnly = true;
            // 
            // Longitud
            // 
            this.Longitud.HeaderText = "Longitud";
            this.Longitud.Name = "Longitud";
            this.Longitud.ReadOnly = true;
            // 
            // DirIndice
            // 
            this.DirIndice.HeaderText = "DirIndice";
            this.DirIndice.Name = "DirIndice";
            this.DirIndice.ReadOnly = true;
            // 
            // DirSig
            // 
            this.DirSig.HeaderText = "DirSig";
            this.DirSig.Name = "DirSig";
            this.DirSig.ReadOnly = true;
            // 
            // menuAtributos
            // 
            this.menuAtributos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaAtributo,
            this.modificarAtributo,
            this.consultaAtributo,
            this.eliminarAtributo});
            this.menuAtributos.Location = new System.Drawing.Point(3, 3);
            this.menuAtributos.Name = "menuAtributos";
            this.menuAtributos.Size = new System.Drawing.Size(851, 24);
            this.menuAtributos.TabIndex = 1;
            this.menuAtributos.Text = "menuStrip1";
            this.menuAtributos.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.atributos_Clicked);
            // 
            // altaAtributo
            // 
            this.altaAtributo.AccessibleName = "Alta";
            this.altaAtributo.Name = "altaAtributo";
            this.altaAtributo.Size = new System.Drawing.Size(40, 20);
            this.altaAtributo.Text = "Alta";
            // 
            // modificarAtributo
            // 
            this.modificarAtributo.AccessibleName = "Modificar";
            this.modificarAtributo.Name = "modificarAtributo";
            this.modificarAtributo.Size = new System.Drawing.Size(70, 20);
            this.modificarAtributo.Text = "Modificar";
            // 
            // consultaAtributo
            // 
            this.consultaAtributo.AccessibleName = "Consulta";
            this.consultaAtributo.Name = "consultaAtributo";
            this.consultaAtributo.Size = new System.Drawing.Size(66, 20);
            this.consultaAtributo.Text = "Consulta";
            // 
            // eliminarAtributo
            // 
            this.eliminarAtributo.AccessibleName = "Eliminar";
            this.eliminarAtributo.Name = "eliminarAtributo";
            this.eliminarAtributo.Size = new System.Drawing.Size(62, 20);
            this.eliminarAtributo.Text = "Eliminar";
            // 
            // tabRegistros
            // 
            this.tabRegistros.Controls.Add(this.groupBoxRegistros);
            this.tabRegistros.Controls.Add(this.groupBoxIndices);
            this.tabRegistros.Controls.Add(this.menuRegistros);
            this.tabRegistros.Location = new System.Drawing.Point(4, 22);
            this.tabRegistros.Name = "tabRegistros";
            this.tabRegistros.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegistros.Size = new System.Drawing.Size(857, 360);
            this.tabRegistros.TabIndex = 2;
            this.tabRegistros.Text = "Registros";
            this.tabRegistros.UseVisualStyleBackColor = true;
            // 
            // groupBoxRegistros
            // 
            this.groupBoxRegistros.Controls.Add(this.dataGridRegistros);
            this.groupBoxRegistros.Controls.Add(this.comboBoxEntidad);
            this.groupBoxRegistros.Controls.Add(this.label2);
            this.groupBoxRegistros.Location = new System.Drawing.Point(6, 51);
            this.groupBoxRegistros.Name = "groupBoxRegistros";
            this.groupBoxRegistros.Size = new System.Drawing.Size(420, 303);
            this.groupBoxRegistros.TabIndex = 5;
            this.groupBoxRegistros.TabStop = false;
            this.groupBoxRegistros.Text = "Registros";
            // 
            // dataGridRegistros
            // 
            this.dataGridRegistros.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRegistros.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridRegistros.Location = new System.Drawing.Point(6, 52);
            this.dataGridRegistros.Name = "dataGridRegistros";
            this.dataGridRegistros.RowHeadersVisible = false;
            this.dataGridRegistros.Size = new System.Drawing.Size(408, 245);
            this.dataGridRegistros.TabIndex = 1;
            // 
            // comboBoxEntidad
            // 
            this.comboBoxEntidad.FormattingEnabled = true;
            this.comboBoxEntidad.Location = new System.Drawing.Point(293, 25);
            this.comboBoxEntidad.Name = "comboBoxEntidad";
            this.comboBoxEntidad.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEntidad.TabIndex = 2;
            this.comboBoxEntidad.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entidad";
            // 
            // groupBoxIndices
            // 
            this.groupBoxIndices.Controls.Add(this.tabControlIndices);
            this.groupBoxIndices.Location = new System.Drawing.Point(431, 51);
            this.groupBoxIndices.Name = "groupBoxIndices";
            this.groupBoxIndices.Size = new System.Drawing.Size(420, 303);
            this.groupBoxIndices.TabIndex = 4;
            this.groupBoxIndices.TabStop = false;
            this.groupBoxIndices.Text = "Indices";
            // 
            // tabControlIndices
            // 
            this.tabControlIndices.Controls.Add(this.tabPage3);
            this.tabControlIndices.Controls.Add(this.tabPage1);
            this.tabControlIndices.Controls.Add(this.tabPage2);
            this.tabControlIndices.Location = new System.Drawing.Point(6, 19);
            this.tabControlIndices.Name = "tabControlIndices";
            this.tabControlIndices.SelectedIndex = 0;
            this.tabControlIndices.Size = new System.Drawing.Size(408, 278);
            this.tabControlIndices.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridIdxPrimmario);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(400, 252);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Primario";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridIdxPrimmario
            // 
            this.dataGridIdxPrimmario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIdxPrimmario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridIdxPrimmario.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridIdxPrimmario.Location = new System.Drawing.Point(6, 6);
            this.dataGridIdxPrimmario.Name = "dataGridIdxPrimmario";
            this.dataGridIdxPrimmario.RowHeadersVisible = false;
            this.dataGridIdxPrimmario.Size = new System.Drawing.Size(388, 240);
            this.dataGridIdxPrimmario.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Llave";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 190;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Direccíon";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 190;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dataGridSecundario);
            this.tabPage1.Controls.Add(this.dataGridSecundarioAuxiliar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.comboBoxAtributosSecundarios);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(400, 252);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Secundario";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Direccion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Entidad";
            // 
            // dataGridSecundario
            // 
            this.dataGridSecundario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSecundario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.dataGridSecundario.Location = new System.Drawing.Point(6, 51);
            this.dataGridSecundario.Name = "dataGridSecundario";
            this.dataGridSecundario.ReadOnly = true;
            this.dataGridSecundario.RowHeadersVisible = false;
            this.dataGridSecundario.Size = new System.Drawing.Size(190, 195);
            this.dataGridSecundario.TabIndex = 4;
            this.dataGridSecundario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSecundario_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Llave";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 93;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Direccion";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 93;
            // 
            // dataGridSecundarioAuxiliar
            // 
            this.dataGridSecundarioAuxiliar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSecundarioAuxiliar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5});
            this.dataGridSecundarioAuxiliar.Location = new System.Drawing.Point(204, 27);
            this.dataGridSecundarioAuxiliar.Name = "dataGridSecundarioAuxiliar";
            this.dataGridSecundarioAuxiliar.ReadOnly = true;
            this.dataGridSecundarioAuxiliar.RowHeadersVisible = false;
            this.dataGridSecundarioAuxiliar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridSecundarioAuxiliar.Size = new System.Drawing.Size(190, 219);
            this.dataGridSecundarioAuxiliar.TabIndex = 2;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Direccion";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 186;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Atributos";
            // 
            // comboBoxAtributosSecundarios
            // 
            this.comboBoxAtributosSecundarios.FormattingEnabled = true;
            this.comboBoxAtributosSecundarios.Location = new System.Drawing.Point(57, 6);
            this.comboBoxAtributosSecundarios.Name = "comboBoxAtributosSecundarios";
            this.comboBoxAtributosSecundarios.Size = new System.Drawing.Size(118, 21);
            this.comboBoxAtributosSecundarios.TabIndex = 0;
            this.comboBoxAtributosSecundarios.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAtributosForaneos_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.dataGridHash);
            this.tabPage2.Controls.Add(this.dataGridHashAuxiliar);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.ComboBoxAtributosHash);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(400, 252);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Hash Estatica";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(110, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Formula";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Direccion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Entidad";
            // 
            // dataGridHash
            // 
            this.dataGridHash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHash.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridHash.Location = new System.Drawing.Point(8, 51);
            this.dataGridHash.Name = "dataGridHash";
            this.dataGridHash.ReadOnly = true;
            this.dataGridHash.RowHeadersVisible = false;
            this.dataGridHash.Size = new System.Drawing.Size(190, 195);
            this.dataGridHash.TabIndex = 10;
            this.dataGridHash.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridHash_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Indice";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 93;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Direccion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 93;
            // 
            // dataGridHashAuxiliar
            // 
            this.dataGridHashAuxiliar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHashAuxiliar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.dataGridViewTextBoxColumn3});
            this.dataGridHashAuxiliar.Location = new System.Drawing.Point(206, 27);
            this.dataGridHashAuxiliar.Name = "dataGridHashAuxiliar";
            this.dataGridHashAuxiliar.ReadOnly = true;
            this.dataGridHashAuxiliar.RowHeadersVisible = false;
            this.dataGridHashAuxiliar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridHashAuxiliar.Size = new System.Drawing.Size(190, 219);
            this.dataGridHashAuxiliar.TabIndex = 9;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Llave";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Direccion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 186;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Atributos";
            // 
            // ComboBoxAtributosHash
            // 
            this.ComboBoxAtributosHash.FormattingEnabled = true;
            this.ComboBoxAtributosHash.Location = new System.Drawing.Point(59, 6);
            this.ComboBoxAtributosHash.Name = "ComboBoxAtributosHash";
            this.ComboBoxAtributosHash.Size = new System.Drawing.Size(118, 21);
            this.ComboBoxAtributosHash.TabIndex = 7;
            this.ComboBoxAtributosHash.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAtributosHash_SelectedIndexChanged_1);
            // 
            // menuRegistros
            // 
            this.menuRegistros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaRegistros,
            this.modificarRegistros,
            this.consultaToolStripMenuItem,
            this.consultasSQLToolStripMenuItem,
            this.eliminarRegistros});
            this.menuRegistros.Location = new System.Drawing.Point(3, 3);
            this.menuRegistros.Name = "menuRegistros";
            this.menuRegistros.Size = new System.Drawing.Size(851, 24);
            this.menuRegistros.TabIndex = 0;
            this.menuRegistros.Text = "menuStrip1";
            this.menuRegistros.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.registros_ItemClicked);
            // 
            // altaRegistros
            // 
            this.altaRegistros.AccessibleName = "Alta";
            this.altaRegistros.Name = "altaRegistros";
            this.altaRegistros.Size = new System.Drawing.Size(40, 20);
            this.altaRegistros.Text = "Alta";
            // 
            // modificarRegistros
            // 
            this.modificarRegistros.AccessibleName = "Modificar";
            this.modificarRegistros.Name = "modificarRegistros";
            this.modificarRegistros.Size = new System.Drawing.Size(70, 20);
            this.modificarRegistros.Text = "Modificar";
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.AccessibleName = "Consulta Primario";
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.consultaToolStripMenuItem.Text = "Consulta Primario";
            // 
            // consultasSQLToolStripMenuItem
            // 
            this.consultasSQLToolStripMenuItem.AccessibleName = "Consultas SQL";
            this.consultasSQLToolStripMenuItem.Name = "consultasSQLToolStripMenuItem";
            this.consultasSQLToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.consultasSQLToolStripMenuItem.Text = "Consultas SQL";
            // 
            // eliminarRegistros
            // 
            this.eliminarRegistros.AccessibleName = "Eliminar";
            this.eliminarRegistros.Name = "eliminarRegistros";
            this.eliminarRegistros.Size = new System.Drawing.Size(62, 20);
            this.eliminarRegistros.Text = "Eliminar";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ManejadorDeArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 442);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolBar);
            this.MainMenuStrip = this.menuEntidades;
            this.Name = "ManejadorDeArchivos";
            this.Text = "Manejador de Archivos";
            this.Load += new System.EventHandler(this.ManejadorDeArchivos_Load);
            this.Resize += new System.EventHandler(this.ManejadorDeArchivos_Resize);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabEntidades.ResumeLayout(false);
            this.tabEntidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidad)).EndInit();
            this.menuEntidades.ResumeLayout(false);
            this.menuEntidades.PerformLayout();
            this.tabAtributos.ResumeLayout(false);
            this.tabAtributos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtrib)).EndInit();
            this.menuAtributos.ResumeLayout(false);
            this.menuAtributos.PerformLayout();
            this.tabRegistros.ResumeLayout(false);
            this.tabRegistros.PerformLayout();
            this.groupBoxRegistros.ResumeLayout(false);
            this.groupBoxRegistros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRegistros)).EndInit();
            this.groupBoxIndices.ResumeLayout(false);
            this.tabControlIndices.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIdxPrimmario)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSecundario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSecundarioAuxiliar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHashAuxiliar)).EndInit();
            this.menuRegistros.ResumeLayout(false);
            this.menuRegistros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabEntidades;
        private System.Windows.Forms.MenuStrip menuEntidades;
        private System.Windows.Forms.TabPage tabAtributos;
        private System.Windows.Forms.MenuStrip menuAtributos;
        private System.Windows.Forms.ToolStripButton nuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton abrir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cerrar;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.DataGridView dataGridEntidad;
        private System.Windows.Forms.DataGridView dataGridAtrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDeIndice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirIndice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirSig;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccioDeDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirAtrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn dirSiguiente;
        private System.Windows.Forms.ToolStripMenuItem altaEntidad;
        private System.Windows.Forms.ToolStripMenuItem modificarEntidad;
        private System.Windows.Forms.ToolStripMenuItem consultaEntidad;
        private System.Windows.Forms.ToolStripMenuItem eliminarEntidad;
        private System.Windows.Forms.ToolStripMenuItem altaAtributo;
        private System.Windows.Forms.ToolStripMenuItem modificarAtributo;
        private System.Windows.Forms.ToolStripMenuItem consultaAtributo;
        private System.Windows.Forms.ToolStripMenuItem eliminarAtributo;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabRegistros;
        private System.Windows.Forms.MenuStrip menuRegistros;
        private System.Windows.Forms.DataGridView dataGridRegistros;
        private System.Windows.Forms.ToolStripMenuItem altaRegistros;
        private System.Windows.Forms.ToolStripMenuItem modificarRegistros;
        private System.Windows.Forms.ToolStripMenuItem eliminarRegistros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEntidad;
        private System.Windows.Forms.GroupBox groupBoxIndices;
        private System.Windows.Forms.TabControl tabControlIndices;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridIdxPrimmario;
        private System.Windows.Forms.GroupBox groupBoxRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridSecundario;
        private System.Windows.Forms.DataGridView dataGridSecundarioAuxiliar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxAtributosSecundarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridHash;
        private System.Windows.Forms.DataGridView dataGridHashAuxiliar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboBoxAtributosHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripMenuItem consultasSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton renombrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

