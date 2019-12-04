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
    partial class ConsultaRegistroPrimario : Form
    {
        Entidad entidad;
        bool band;
        int tam;
        public ConsultaRegistroPrimario(Entidad entidad)
        {
            this.entidad = entidad;
            InitializeComponent();
        }

        private void ConsultaRegistro_Load(object sender, EventArgs e)
        {
            this.band = this.entidad.Atributos[this.entidad.buscaIndiceClavePrimaria()].Tipo.Equals('C');
            this.tam = this.entidad.Atributos[this.entidad.buscaIndiceClavePrimaria()].Longitud - 1;
            string llaveAux;
            foreach(string llave in this.entidad.LlavePrimaria)
            {
                llaveAux = llave;
                if (band)
                {
                    llaveAux = MetodosAuxiliares.truncaCadena(llaveAux);
                }
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Consulta_Click(object sender, EventArgs e)
        {
            this.listBoxAtributos.Items.Clear();
            if (!string.IsNullOrEmpty(this.comboBoxEntidades.Text))
            {
                Registro registro;
                string llave;
                llave = this.comboBoxEntidades.Text;
                if (this.band)
                {
                    llave = MetodosAuxiliares.ajustaCadena(llave, this.tam);
                }
                    registro = this.entidad.Registros[llave];
                if (registro != null)
                {

                    this.textBoxDirAct.Text = registro.DirAct.ToString();
                    this.textBoxDirSig.Text = registro.DirSig.ToString();
                    foreach (string dato in registro.Datos)
                    {
                        this.listBoxAtributos.Items.Add(MetodosAuxiliares.truncaCadena(dato));
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una entidad","Error");
            }
        }

        private void ComboBoxEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
