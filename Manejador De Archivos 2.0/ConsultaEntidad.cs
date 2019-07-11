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
    partial class ConsultaEntidad : Form
    {
        #region Variables de Instancia
        Archivo archivo;
        #endregion
        public ConsultaEntidad(Archivo archivo)
        {
            this.archivo = archivo;
            InitializeComponent();
        }

        private void ConsultaEntidad_Load(object sender, EventArgs e)
        {
            foreach (Entidad busca in this.archivo.Entidades)
            {
                comboBoxEntidades.Items.Add(MetodosAuxiliares.truncaCadena(busca.Nombre));
            }
        }

        private void Consulta_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(comboBoxEntidades.Text))
            {
                string aux = MetodosAuxiliares.ajustaCadena(comboBoxEntidades.Text, Constantes.tam);
                foreach (Entidad entidad in this.archivo.Entidades)
                {
                    if (aux.Equals(entidad.Nombre))
                    {
                        textBoxDirAct.Text = entidad.DirActual.ToString();
                        textBoxDirAtrib.Text = entidad.DirAtributos.ToString();
                        textBoxDirReg.Text = entidad.DirRegistros.ToString();
                        textBoxDirSig.Text = entidad.DirSig.ToString();
                        listBoxAtributos.Items.Clear();
                        foreach (Atributo atributo in entidad.Atributos)
                        {
                            listBoxAtributos.Items.Add(MetodosAuxiliares.truncaCadena(atributo.Nombre));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una entidad");
            }
        }
    
    }
}
