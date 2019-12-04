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
    partial class ConsultaRegistroSecundario : Form
    {
        Entidad entidad;
        Atributo atributo;
        Secundario secundario;
        public ConsultaRegistroSecundario(Entidad entidad)
        {
            this.entidad = entidad;
            InitializeComponent();
        }

        private void ConsultaRegistroSecundario_Load(object sender, EventArgs e)
        {
            foreach (Atributo atributo in entidad.Atributos)
            {
                if (atributo.Indice == 4)
                {
                    this.comboBoxAtributos.Items.Add(MetodosAuxiliares.truncaCadena(atributo.Nombre));
                }
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxDirecciones.Items.Clear();
            this.comboBoxValores.Items.Clear();
            this.atributo = this.entidad.buscaAtributo(MetodosAuxiliares.ajustaCadena(this.comboBoxAtributos.Text, Constantes.tam));
            this.secundario = ((Secundario)this.atributo.Indices.First());
            foreach(string llave in this.secundario.Llaves)
            {
                if (!("-1").Equals(MetodosAuxiliares.truncaCadena(llave)))
                {
                    this.comboBoxValores.Items.Add(MetodosAuxiliares.truncaCadena(llave));
                }
            }
        }

        private void ComboBoxValores_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i = 0 ; i < this.secundario.Llaves.Length; i++)
            {
                if(this.comboBoxValores.Text.Equals(MetodosAuxiliares.truncaCadena(this.secundario.Llaves[i])))
                {
                    for(int j = 0; j < Constantes.tamNodoAux ; j++)
                    {
                        if (this.secundario.Apuntadores[i, j] != -1)
                        {
                            this.comboBoxDirecciones.Items.Add(this.secundario.Apuntadores[i,j].ToString());
                        }
                    }
                }
            }
        }

        private void Consulta_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.comboBoxDirecciones.Text))
            {
                long direccion;
                Registro registro;
                direccion = Int64.Parse(this.comboBoxDirecciones.Text);
                registro = this.entidad.buscaRegistro(direccion);
                this.listBoxAtributos.Items.Clear();
                this.textBoxDirAct.Text = registro.DirAct.ToString();
                this.textBoxDirSig.Text = registro.DirSig.ToString();
                foreach (string dato in registro.Datos)
                {
                    this.listBoxAtributos.Items.Add(MetodosAuxiliares.truncaCadena(dato));
                }
            }
        }
    }
}
