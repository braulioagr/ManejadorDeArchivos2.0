namespace Manejador_De_Archivos_2._0
{
    partial class ConsultaRegistro
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDirSig = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Cerrar = new System.Windows.Forms.Button();
            this.Consulta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAtributos = new System.Windows.Forms.ListBox();
            this.comboBoxEntidades = new System.Windows.Forms.ComboBox();
            this.textBoxDirAct = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Direccion Siguiente";
            // 
            // textBoxDirSig
            // 
            this.textBoxDirSig.Enabled = false;
            this.textBoxDirSig.Location = new System.Drawing.Point(161, 205);
            this.textBoxDirSig.Name = "textBoxDirSig";
            this.textBoxDirSig.Size = new System.Drawing.Size(46, 20);
            this.textBoxDirSig.TabIndex = 40;
            this.textBoxDirSig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Dirección Actual";
            // 
            // Cerrar
            // 
            this.Cerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Cerrar.Location = new System.Drawing.Point(132, 241);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 37;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Consulta
            // 
            this.Consulta.Location = new System.Drawing.Point(252, 30);
            this.Consulta.Name = "Consulta";
            this.Consulta.Size = new System.Drawing.Size(75, 23);
            this.Consulta.TabIndex = 36;
            this.Consulta.Text = "Consulta";
            this.Consulta.UseVisualStyleBackColor = true;
            this.Consulta.Click += new System.EventHandler(this.Consulta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Llave Primaria";
            // 
            // listBoxAtributos
            // 
            this.listBoxAtributos.Enabled = false;
            this.listBoxAtributos.FormattingEnabled = true;
            this.listBoxAtributos.Location = new System.Drawing.Point(11, 78);
            this.listBoxAtributos.Name = "listBoxAtributos";
            this.listBoxAtributos.Size = new System.Drawing.Size(144, 147);
            this.listBoxAtributos.TabIndex = 34;
            // 
            // comboBoxEntidades
            // 
            this.comboBoxEntidades.FormattingEnabled = true;
            this.comboBoxEntidades.Location = new System.Drawing.Point(11, 30);
            this.comboBoxEntidades.Name = "comboBoxEntidades";
            this.comboBoxEntidades.Size = new System.Drawing.Size(235, 21);
            this.comboBoxEntidades.TabIndex = 33;
            // 
            // textBoxDirAct
            // 
            this.textBoxDirAct.Enabled = false;
            this.textBoxDirAct.Location = new System.Drawing.Point(161, 93);
            this.textBoxDirAct.Name = "textBoxDirAct";
            this.textBoxDirAct.Size = new System.Drawing.Size(46, 20);
            this.textBoxDirAct.TabIndex = 38;
            this.textBoxDirAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConsultaRegistro
            // 
            this.AcceptButton = this.Cerrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 276);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDirSig);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDirAct);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.Consulta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAtributos);
            this.Controls.Add(this.comboBoxEntidades);
            this.Name = "ConsultaRegistro";
            this.Text = "ConsultaRegistro";
            this.Load += new System.EventHandler(this.ConsultaRegistro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDirSig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button Consulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAtributos;
        private System.Windows.Forms.ComboBox comboBoxEntidades;
        private System.Windows.Forms.TextBox textBoxDirAct;
    }
}