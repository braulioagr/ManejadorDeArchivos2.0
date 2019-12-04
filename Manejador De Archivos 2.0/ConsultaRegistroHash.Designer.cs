namespace Manejador_De_Archivos_2._0
{
    partial class ConsultaRegistroHash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDirecciones = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxValores = new System.Windows.Forms.ComboBox();
            this.Consulta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAtributos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDirSig = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDirAct = new System.Windows.Forms.TextBox();
            this.Cerrar = new System.Windows.Forms.Button();
            this.listBoxAtributos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Direcciones";
            // 
            // comboBoxDirecciones
            // 
            this.comboBoxDirecciones.FormattingEnabled = true;
            this.comboBoxDirecciones.Location = new System.Drawing.Point(132, 73);
            this.comboBoxDirecciones.Name = "comboBoxDirecciones";
            this.comboBoxDirecciones.Size = new System.Drawing.Size(115, 21);
            this.comboBoxDirecciones.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Valores";
            // 
            // comboBoxValores
            // 
            this.comboBoxValores.FormattingEnabled = true;
            this.comboBoxValores.Location = new System.Drawing.Point(11, 73);
            this.comboBoxValores.Name = "comboBoxValores";
            this.comboBoxValores.Size = new System.Drawing.Size(115, 21);
            this.comboBoxValores.TabIndex = 64;
            this.comboBoxValores.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValores_SelectedIndexChanged);
            // 
            // Consulta
            // 
            this.Consulta.Location = new System.Drawing.Point(252, 30);
            this.Consulta.Name = "Consulta";
            this.Consulta.Size = new System.Drawing.Size(75, 64);
            this.Consulta.TabIndex = 63;
            this.Consulta.Text = "Consulta";
            this.Consulta.UseVisualStyleBackColor = true;
            this.Consulta.Click += new System.EventHandler(this.Consulta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Atributo";
            // 
            // comboBoxAtributos
            // 
            this.comboBoxAtributos.FormattingEnabled = true;
            this.comboBoxAtributos.Location = new System.Drawing.Point(11, 30);
            this.comboBoxAtributos.Name = "comboBoxAtributos";
            this.comboBoxAtributos.Size = new System.Drawing.Size(235, 21);
            this.comboBoxAtributos.TabIndex = 61;
            this.comboBoxAtributos.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAtributos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Direccion Siguiente";
            // 
            // textBoxDirSig
            // 
            this.textBoxDirSig.Enabled = false;
            this.textBoxDirSig.Location = new System.Drawing.Point(161, 235);
            this.textBoxDirSig.Name = "textBoxDirSig";
            this.textBoxDirSig.Size = new System.Drawing.Size(46, 20);
            this.textBoxDirSig.TabIndex = 59;
            this.textBoxDirSig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Dirección Actual";
            // 
            // textBoxDirAct
            // 
            this.textBoxDirAct.Enabled = false;
            this.textBoxDirAct.Location = new System.Drawing.Point(161, 123);
            this.textBoxDirAct.Name = "textBoxDirAct";
            this.textBoxDirAct.Size = new System.Drawing.Size(46, 20);
            this.textBoxDirAct.TabIndex = 57;
            this.textBoxDirAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cerrar
            // 
            this.Cerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Cerrar.Location = new System.Drawing.Point(132, 271);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 56;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // listBoxAtributos
            // 
            this.listBoxAtributos.Enabled = false;
            this.listBoxAtributos.FormattingEnabled = true;
            this.listBoxAtributos.Location = new System.Drawing.Point(11, 108);
            this.listBoxAtributos.Name = "listBoxAtributos";
            this.listBoxAtributos.Size = new System.Drawing.Size(144, 147);
            this.listBoxAtributos.TabIndex = 55;
            // 
            // ConsultaRegistroHash
            // 
            this.AcceptButton = this.Cerrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 304);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxDirecciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxValores);
            this.Controls.Add(this.Consulta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAtributos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDirSig);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDirAct);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.listBoxAtributos);
            this.Name = "ConsultaRegistroHash";
            this.Text = "ConsultaRegistroHash";
            this.Load += new System.EventHandler(this.ConsultaRegistroHash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxDirecciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxValores;
        private System.Windows.Forms.Button Consulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAtributos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDirSig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDirAct;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.ListBox listBoxAtributos;
    }
}