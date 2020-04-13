namespace Manejador_De_Archivos_2._0
{
    partial class ConsultasSQL
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
            this.ConsultaSQL = new System.Windows.Forms.Button();
            this.textBoxSQL = new System.Windows.Forms.TextBox();
            this.dataGridSQL = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSQL)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsultaSQL
            // 
            this.ConsultaSQL.Location = new System.Drawing.Point(463, 13);
            this.ConsultaSQL.Name = "ConsultaSQL";
            this.ConsultaSQL.Size = new System.Drawing.Size(75, 23);
            this.ConsultaSQL.TabIndex = 8;
            this.ConsultaSQL.Text = "Consultas SQL";
            this.ConsultaSQL.UseVisualStyleBackColor = true;
            this.ConsultaSQL.Click += new System.EventHandler(this.ConsultaSQL_Click);
            // 
            // textBoxSQL
            // 
            this.textBoxSQL.Location = new System.Drawing.Point(12, 15);
            this.textBoxSQL.Name = "textBoxSQL";
            this.textBoxSQL.Size = new System.Drawing.Size(445, 20);
            this.textBoxSQL.TabIndex = 7;
            // 
            // dataGridSQL
            // 
            this.dataGridSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSQL.Location = new System.Drawing.Point(12, 41);
            this.dataGridSQL.Name = "dataGridSQL";
            this.dataGridSQL.RowHeadersVisible = false;
            this.dataGridSQL.Size = new System.Drawing.Size(526, 285);
            this.dataGridSQL.TabIndex = 6;
            // 
            // ConsultasSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 338);
            this.Controls.Add(this.ConsultaSQL);
            this.Controls.Add(this.textBoxSQL);
            this.Controls.Add(this.dataGridSQL);
            this.Name = "ConsultasSQL";
            this.Text = "ConultasSQL";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSQL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConsultaSQL;
        private System.Windows.Forms.TextBox textBoxSQL;
        private System.Windows.Forms.DataGridView dataGridSQL;
    }
}