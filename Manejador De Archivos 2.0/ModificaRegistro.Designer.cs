namespace Manejador_De_Archivos_2._0
{
    partial class ModificaRegistro
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
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIndice = new System.Windows.Forms.TextBox();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            this.textBoxAtributo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Anterior = new System.Windows.Forms.Button();
            this.Siguiente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.textBoxDato = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Dato";
            // 
            // textBoxIndice
            // 
            this.textBoxIndice.Enabled = false;
            this.textBoxIndice.Location = new System.Drawing.Point(60, 41);
            this.textBoxIndice.Name = "textBoxIndice";
            this.textBoxIndice.Size = new System.Drawing.Size(276, 20);
            this.textBoxIndice.TabIndex = 34;
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Enabled = false;
            this.textBoxTipo.Location = new System.Drawing.Point(214, 15);
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.Size = new System.Drawing.Size(122, 20);
            this.textBoxTipo.TabIndex = 33;
            // 
            // textBoxAtributo
            // 
            this.textBoxAtributo.Enabled = false;
            this.textBoxAtributo.Location = new System.Drawing.Point(60, 15);
            this.textBoxAtributo.Name = "textBoxAtributo";
            this.textBoxAtributo.Size = new System.Drawing.Size(114, 20);
            this.textBoxAtributo.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Indice";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Tipo";
            // 
            // Anterior
            // 
            this.Anterior.Location = new System.Drawing.Point(99, 92);
            this.Anterior.Name = "Anterior";
            this.Anterior.Size = new System.Drawing.Size(75, 23);
            this.Anterior.TabIndex = 29;
            this.Anterior.Text = "Anterior";
            this.Anterior.UseVisualStyleBackColor = true;
            this.Anterior.Click += new System.EventHandler(this.Anterior_Click);
            // 
            // Siguiente
            // 
            this.Siguiente.Location = new System.Drawing.Point(180, 92);
            this.Siguiente.Name = "Siguiente";
            this.Siguiente.Size = new System.Drawing.Size(75, 23);
            this.Siguiente.TabIndex = 28;
            this.Siguiente.Text = "Siguiente";
            this.Siguiente.UseVisualStyleBackColor = true;
            this.Siguiente.Click += new System.EventHandler(this.Siguiente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Atributo";
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Location = new System.Drawing.Point(15, 92);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 26;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(261, 92);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 25;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Visible = false;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // textBoxDato
            // 
            this.textBoxDato.Location = new System.Drawing.Point(60, 66);
            this.textBoxDato.Name = "textBoxDato";
            this.textBoxDato.Size = new System.Drawing.Size(276, 20);
            this.textBoxDato.TabIndex = 24;
            // 
            // ModificaRegistro
            // 
            this.AcceptButton = this.Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(347, 131);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxIndice);
            this.Controls.Add(this.textBoxTipo);
            this.Controls.Add(this.textBoxAtributo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Anterior);
            this.Controls.Add(this.Siguiente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.textBoxDato);
            this.Name = "ModificaRegistro";
            this.Text = "ModificaRegistro";
            this.Load += new System.EventHandler(this.ModificaRegistro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIndice;
        private System.Windows.Forms.TextBox textBoxTipo;
        private System.Windows.Forms.TextBox textBoxAtributo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Anterior;
        private System.Windows.Forms.Button Siguiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.TextBox textBoxDato;
    }
}