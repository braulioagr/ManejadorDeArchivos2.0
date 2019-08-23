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
    partial class EliminarAtributo : Form
    {

        #region Variables de Instancia
        Archivo archivo;
        #endregion

        #region Constructores
        public EliminarAtributo(Archivo archivo)
        {
            this.archivo = archivo;
            InitializeComponent();
        }
        private void EliminarAtributo_Load(object sender, EventArgs e)
        {
            this.comboEntidad.Items.Clear();
            foreach(Entidad busca in archivo.Entidades)
            {
                this.comboEntidad.Items.Add(MetodosAuxiliares.truncaCadena(busca.Nombre));
            }
        }
        #endregion

        #region Eventos

        #region Eventos ComboBox


        private void comboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboAtributo.Items.Clear();
            Entidad entidad;
            entidad = archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(comboEntidad.Text,Constantes.tam));
            foreach (Atributo atributo in entidad.Atributos)
            {
                comboAtributo.Items.Add(MetodosAuxiliares.truncaCadena(atributo.Nombre));
            }
        }

        #endregion

        #region Eventos Botones
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboEntidad.Text) && !string.IsNullOrEmpty(comboAtributo.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor complete la informacion", "Incompleto");
            }
        }

        #endregion
        
        #endregion

        #region Gets & Sets
        public string Entidad
        {
            get { return this.comboEntidad.Text; }
        }
        public string Atributo
        {
            get { return this.comboAtributo.Text; }
        }
        #endregion

    }
}
