namespace Manejador_De_Archivos_2._0
{
    partial class AltaAtributo
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
            this.Cancelar = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEntRef = new System.Windows.Forms.ComboBox();
            this.textBoxLong = new System.Windows.Forms.TextBox();
            this.comboEntidad = new System.Windows.Forms.ComboBox();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAtrib = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboIndice = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Location = new System.Drawing.Point(12, 207);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 13;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(211, 207);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 12;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxEntRef);
            this.groupBox1.Controls.Add(this.textBoxLong);
            this.groupBox1.Controls.Add(this.comboEntidad);
            this.groupBox1.Controls.Add(this.comboTipo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxAtrib);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ComboIndice);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 189);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ent Foranea";
            // 
            // comboBoxEntRef
            // 
            this.comboBoxEntRef.Enabled = false;
            this.comboBoxEntRef.FormattingEnabled = true;
            this.comboBoxEntRef.Location = new System.Drawing.Point(82, 152);
            this.comboBoxEntRef.Name = "comboBoxEntRef";
            this.comboBoxEntRef.Size = new System.Drawing.Size(168, 21);
            this.comboBoxEntRef.TabIndex = 13;
            this.comboBoxEntRef.TabStop = false;
            this.comboBoxEntRef.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // textBoxLong
            // 
            this.textBoxLong.Enabled = false;
            this.textBoxLong.Location = new System.Drawing.Point(82, 99);
            this.textBoxLong.Name = "textBoxLong";
            this.textBoxLong.Size = new System.Drawing.Size(168, 20);
            this.textBoxLong.TabIndex = 10;
            // 
            // comboEntidad
            // 
            this.comboEntidad.FormattingEnabled = true;
            this.comboEntidad.Location = new System.Drawing.Point(82, 19);
            this.comboEntidad.Name = "comboEntidad";
            this.comboEntidad.Size = new System.Drawing.Size(168, 21);
            this.comboEntidad.TabIndex = 5;
            this.comboEntidad.SelectedIndexChanged += new System.EventHandler(this.comboEntidad_SelectedIndexChanged);
            // 
            // comboTipo
            // 
            this.comboTipo.Enabled = false;
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {
            "E",
            "C"});
            this.comboTipo.Location = new System.Drawing.Point(82, 72);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(168, 21);
            this.comboTipo.TabIndex = 2;
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.ComboTipo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Longitud";
            // 
            // textBoxAtrib
            // 
            this.textBoxAtrib.Enabled = false;
            this.textBoxAtrib.Location = new System.Drawing.Point(82, 46);
            this.textBoxAtrib.Name = "textBoxAtrib";
            this.textBoxAtrib.Size = new System.Drawing.Size(168, 20);
            this.textBoxAtrib.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Indice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Entidad";
            // 
            // ComboIndice
            // 
            this.ComboIndice.Enabled = false;
            this.ComboIndice.FormattingEnabled = true;
            this.ComboIndice.Items.AddRange(new object[] {
            "0: Sin indice",
            "1: Clave de Busqueda",
            "2: Llave Primaria",
            "3: Llave Foranea",
            "4: Indice Secundario",
            "5: Hash Estatica"});
            this.ComboIndice.Location = new System.Drawing.Point(82, 125);
            this.ComboIndice.Name = "ComboIndice";
            this.ComboIndice.Size = new System.Drawing.Size(168, 21);
            this.ComboIndice.TabIndex = 7;
            this.ComboIndice.SelectedIndexChanged += new System.EventHandler(this.ComboIndice_SelectedIndexChanged_1);
            // 
            // AltaAtributo
            // 
            this.AcceptButton = this.Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(298, 242);
            this.ControlBox = false;
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaAtributo";
            this.Text = "AltaAtributo";
            this.Load += new System.EventHandler(this.AltaAtributo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxLong;
        private System.Windows.Forms.ComboBox comboEntidad;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAtrib;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboIndice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEntRef;
    }
}