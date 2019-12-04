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
    partial class ConsultaRegistroHash : Form
    {
        Entidad entidad;
        Atributo atributo;
        HashEstatica hash;
        int i;
        #region Constructores
        public ConsultaRegistroHash(Entidad entidad)
        {
            this.entidad = entidad;
            InitializeComponent();
        }

        private void ConsultaRegistroHash_Load(object sender, EventArgs e)
        {
            foreach(Atributo atributo in entidad.Atributos)
            {
                if(atributo.Indice == 5)
                {
                    this.comboBoxAtributos.Items.Add(MetodosAuxiliares.truncaCadena(atributo.Nombre));
                }
            }
            for(int i = 0; i < Constantes.valorHash; i++ )
            {
                this.comboBoxValores.Items.Add(i.ToString());
            }
            this.comboBoxAtributos.Text = this.comboBoxAtributos.Items[0].ToString();
        }
        #endregion

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Eventos

        private void ComboBoxValores_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxDirecciones.Items.Clear();
            this.comboBoxDirecciones.Text = "";
            i = Int32.Parse(this.comboBoxValores.Text);
            for(int j = 0 ; j < hash.Longitud ; j++)
            {
                if(hash.Apuntadores[i,j] != -1)
                {
                    this.comboBoxDirecciones.Items.Add(hash.Apuntadores[i, j]);
                }
            }
        }

        private void ComboBoxAtributos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxDirecciones.Items.Clear();
            this.atributo = this.entidad.buscaAtributo(MetodosAuxiliares.ajustaCadena(this.comboBoxAtributos.Text, Constantes.tam));
            this.hash = ((HashEstatica)atributo.Indices.First());
        }

        private void Consulta_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.comboBoxDirecciones.Text))
            {
                long direccion;
                Registro registro;
                direccion = Int64.Parse(this.comboBoxDirecciones.Text);
                registro = this.entidad.buscaRegistro(direccion);
                this.listBoxAtributos.Items.Clear();
                this.textBoxDirAct.Text = registro.DirAct.ToString();
                this.textBoxDirSig.Text = registro.DirSig.ToString();
                foreach(string dato in registro.Datos)
                {
                    this.listBoxAtributos.Items.Add(MetodosAuxiliares.truncaCadena(dato));
                }
            }
        }

        #endregion
    }
}
