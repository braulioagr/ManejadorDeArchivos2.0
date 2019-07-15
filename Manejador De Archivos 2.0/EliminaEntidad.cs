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
    partial class EliminaEntidad : Form
    {
        #region Variables de Instancia
        List<string> entidades;
        #endregion
        #region Constructores
        public EliminaEntidad(Archivo archivo)
        {
            entidades = new List<string>();
            foreach(Entidad entidad in archivo.Entidades)
            {
                this.entidades.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre));
            }
            InitializeComponent();
        }

        private void EliminaEntidad_Load(object sender, EventArgs e)
        {
            foreach (string entidad in this.entidades)
            {
                this.comboEntidades.Items.Add(entidad);
            }
            comboEntidades.Text = entidades.First();
        }
        #endregion

        #region Gets & Sets
        public string Entidad
        {
            get { return this.comboEntidades.Text; }
        }
        #endregion
    }
}
