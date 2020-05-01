using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador_De_Archivos_2._0
{
    partial class AltaRegistroSQL : Form
    {
        public delegate void AltaSQL(string sentencia, string directorio);
        public event AltaSQL altaSQL;
        public string directorio;
        public AltaRegistroSQL(string directorio)
        {
            this.directorio = directorio;
            InitializeComponent();
        }

        private void AltaRegistroSQL_Load(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.altaSQL(this.textBox1.Text,this.directorio);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(InvalidFormatException exception)
            {
                MessageBox.Show(exception.Message,"Error de Formato");
            }
        }
    }
}
