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
    partial class ConsultaAtributo : Form
    {

        #region Variables de instancia
        Archivo archivo;
        Entidad entidad;
        Atributo atributo;
        #endregion

        #region Constructores
        public ConsultaAtributo(Archivo archivo)
        {
            this.archivo = archivo;
            InitializeComponent();
        }

        private void ConsultaAtributo_Load(object sender, EventArgs e)
        {
            this.comboEntidad.Items.Clear();
            foreach (Entidad busca in this.archivo.Entidades)
            {
                this.comboEntidad.Items.Add(MetodosAuxiliares.truncaCadena(busca.Nombre));
            }
            this.comboEntidad.Text = this.comboEntidad.Items[0].ToString();
            if (this.comboAtributo.Items.Count > 0)
            {
                this.comboAtributo.Text = this.comboAtributo.Items[0].ToString();
            }
            else
            {
                this.comboAtributo.Text = "";
                this.comboAtributo_SelectedIndexChanged(comboAtributo, null);
            }
        }
        #endregion

        #region ComboBox

        private void comboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboAtributo.Items.Clear();
            this.entidad = archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(this.comboEntidad.Text, Constantes.tam));
            foreach(Atributo buscando in entidad.Atributos)
            {
                comboAtributo.Items.Add(MetodosAuxiliares.truncaCadena(buscando.Nombre));
            }
            if (this.comboAtributo.Items.Count > 0)
            {
                this.comboAtributo.Text = this.comboAtributo.Items[0].ToString();
            }
            else
            {
                this.comboAtributo.Text = "";
                this.comboAtributo_SelectedIndexChanged(comboAtributo, null);
            }
        }

        private void comboAtributo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboAtributo.Text))
            {
                this.atributo = entidad.buscaAtributo(MetodosAuxiliares.ajustaCadena(comboAtributo.Text, Constantes.tam));
                this.textBoxTipo.Text = this.atributo.Tipo.ToString();
                this.textBoxLong.Text = atributo.Longitud.ToString();
                this.textBoxIndicie.Text = MetodosAuxiliares.traduceIndice(atributo.Indice);
                this.textBoxDir.Text = atributo.DirActual.ToString();
                this.textBox1.Text = atributo.DirIndice.ToString();
                this.textBox2.Text = atributo.DirSig.ToString();
            }
            else
            {
                this.textBoxTipo.Text = "";
                this.textBoxLong.Text = "";
                this.textBoxIndicie.Text = "";
                this.textBoxDir.Text = "";
            }
        }

        #endregion
        

    }
}
