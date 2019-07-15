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
    partial class ModificaEntidad : Form
    {

        #region Variables de Instancia
        List<string>entinades;
        #endregion

        #region Constructores
        public ModificaEntidad(Archivo archivo)
        {
            entinades = new List<string>();
            foreach (Entidad entidad in archivo.Entidades)
            {
                this.entinades.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre));
            }
            InitializeComponent();
        }

        private void ModificaEntidad_Load(object sender, EventArgs e)
        {
            foreach (string entidad in this.entinades)
            {
                this.comboEntidades.Items.Add(entidad);
            }
        }
        #endregion

        #region Gets&Sets

        public string Entidad
        {
            get { return this.comboEntidades.Text; }
        }

        public string Cambio
        {
            get { return this.textEntidades.Text; }
        }

        #endregion

        #region Eventos

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textEntidades.Text) || !string.IsNullOrEmpty(this.comboEntidades.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Un campo esta vacio","Error");
            }
        }

        #endregion

    }
}
