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
            this.abrir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolBar.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabEntidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidad)).BeginInit();
            this.menuEntidades.SuspendLayout();
            this.tabAtributos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtrib)).BeginInit();
            this.menuAtributos.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.CanOverflow = false;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevo,
            this.toolStripSeparator1,
            this.abrir,
            this.toolStripSeparator2,
            this.cerrar});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(818, 37);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // cerrar
            // 
            this.cerrar.AccessibleName = "Cerrar";
            this.cerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.tabControl.Location = new System.Drawing.Point(0, 44);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(818, 363);
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
            this.tabEntidades.Size = new System.Drawing.Size(810, 337);
            this.tabEntidades.TabIndex = 0;
            this.tabEntidades.Text = "Entidades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 56);
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
            this.dataGridEntidad.Location = new System.Drawing.Point(0, 72);
            this.dataGridEntidad.MultiSelect = false;
            this.dataGridEntidad.Name = "dataGridEntidad";
            this.dataGridEntidad.RowHeadersVisible = false;
            this.dataGridEntidad.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridEntidad.ShowCellErrors = false;
            this.dataGridEntidad.ShowCellToolTips = false;
            this.dataGridEntidad.ShowEditingIcon = false;
            this.dataGridEntidad.ShowRowErrors = false;
            this.dataGridEntidad.Size = new System.Drawing.Size(807, 265);
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
            this.menuEntidades.Size = new System.Drawing.Size(804, 24);
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
            this.tabAtributos.Size = new System.Drawing.Size(810, 337);
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
            this.dataGridAtrib.Location = new System.Drawing.Point(0, 75);
            this.dataGridAtrib.MultiSelect = false;
            this.dataGridAtrib.Name = "dataGridAtrib";
            this.dataGridAtrib.RowHeadersVisible = false;
            this.dataGridAtrib.ShowCellErrors = false;
            this.dataGridAtrib.ShowCellToolTips = false;
            this.dataGridAtrib.ShowEditingIcon = false;
            this.dataGridAtrib.ShowRowErrors = false;
            this.dataGridAtrib.Size = new System.Drawing.Size(810, 262);
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
            this.menuAtributos.Size = new System.Drawing.Size(804, 24);
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
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ManejadorDeArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 409);
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
    }
}

