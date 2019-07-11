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
    public partial class AltaEntidad : Form
    {        
        #region Vairables de instancia
        private string nombreArchivo;
        #endregion

        #region Constructores
        
        public AltaEntidad(string nombreArchivo)
        {
            InitializeComponent();
            this.nombreArchivo = nombreArchivo;
        }

        private void AltaEntidad_Load(object sender, EventArgs e)
        {

        }

        #endregion
        
        #region Eventos
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEntidades.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("El Campo del texto no debe estar vacio");
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion
        
        #region Gets & Sets
        public string Nombre
        {
            get { return this.textBoxEntidades.Text; }
        }
        #endregion

    }
}
