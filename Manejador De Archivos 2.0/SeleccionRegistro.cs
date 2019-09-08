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
    partial class SeleccionRegistro : Form
    {
        private Entidad entidad;
        public SeleccionRegistro(Entidad entidad)
        {
            this.entidad = entidad;
            InitializeComponent();
        }

        private void SeleccionRegistro_Load(object sender, EventArgs e)
        {
            this.comboEntidades.Items.Clear();
            foreach(string key in this.entidad.ClavesDeBusqueda)
            {
                this.comboEntidades.Items.Add(key);
            }
            this.comboEntidades.Text = this.entidad.ClavesDeBusqueda.First();
        }
        public string ClaveDeBusqueda
        {
            get { return this.comboEntidades.Text; }
        }

    }
}
