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
            bool band;
            string primeraLlave;
            band = entidad.Atributos[entidad.buscaIndiceClavePrimaria()].Tipo.Equals('C');
            foreach(string key in this.entidad.LlavePrimaria)
            {
                if (band)
                {
                    this.comboEntidades.Items.Add(MetodosAuxiliares.truncaCadena(key));
                }
                else
                {
                    this.comboEntidades.Items.Add(key);
                }
            }
            primeraLlave = this.entidad.LlavePrimaria.First();
            if (band)
            {
                primeraLlave = MetodosAuxiliares.truncaCadena(primeraLlave);
            }
            this.comboEntidades.Text = primeraLlave;
        }
        public string ClaveDeBusqueda
        {
            get { return this.comboEntidades.Text; }
        }

    }
}
