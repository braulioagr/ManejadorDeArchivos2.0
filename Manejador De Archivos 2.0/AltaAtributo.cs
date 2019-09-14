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
    partial class AltaAtributo : Form
    {

        #region Variables de Instancia
        List<string> entidades;
        Archivo archivo;
        #endregion

        #region Constructores
        public AltaAtributo(Archivo archivo)
        {
            this.entidades = new List<string>();
            this.archivo = archivo;
            foreach (Entidad entidad in archivo.Entidades)
            {
                this.entidades.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre));
            }
            InitializeComponent();
        }

        private void AltaAtributo_Load(object sender, EventArgs e)
        {
            foreach (string entidad in this.entidades)
            {
                this.comboEntidad.Items.Add(entidad);
                this.comboBox1.Items.Add(entidad);
            }
            this.comboEntidad.Text = this.entidades.First();
        }
        #endregion

        #region  Gets & Sets
        public long DirIndice
        {
            get
            {
                long direccion;
                direccion = -1;
                if (ComboIndice.Text.Equals("3: Indice Secundario"))
                {
                    Entidad entidad;
                    entidad = this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(comboBox1.Text, Constantes.tam));
                    direccion = entidad.DirActual;
                }
                return direccion;
            }
        }
        public string Entidad
        {
            get { return this.comboEntidad.Text; }
        }
        public string Nombre
        {
            get { return this.textBoxAtrib.Text; }
        }
        public char Tipo
        {
            get { return comboTipo.Text.ToCharArray().First(); }
        }
        public int Longitud
        {
            get { return Int32.Parse(textBoxLong.Text); }
        }
        public int Indice
        {
            get { return Int32.Parse(ComboIndice.Text[0].ToString()); }
        }
        #endregion        

        #region Eventos

        #region Combos

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipo.Text.Equals("E"))
            {
                textBoxLong.Text = "4";
                textBoxLong.Enabled = false;
            }
            else if (comboTipo.Text.Equals("C"))
            {
                textBoxLong.Enabled = true;
            }
        }

        private void comboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboEntidad.Text))
            {
                this.comboEntidad.Enabled = true;
                this.textBoxAtrib.Enabled = true;
                this.comboTipo.Enabled = true;
                this.textBoxLong.Enabled = true;
                this.ComboIndice.Enabled = true;
            }
        }

        #endregion

        #region Botones
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (!this.vacios())
            {
                
                try
                {
                    int i = Int32.Parse(textBoxLong.Text);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor ponga un formato valido para la longitud del indice", "Error de Formato");
                }
            }
            else
            {
                MessageBox.Show("Por favor complete la informacion", "Campos Incompletos");
            }
        }
        #endregion
        
        #endregion

        #region Metodos
        private bool vacios()
        {
            return string.IsNullOrEmpty(this.comboEntidad.Text) || string.IsNullOrEmpty(this.textBoxAtrib.Text) ||
                   string.IsNullOrEmpty(this.comboTipo.Text) || string.IsNullOrEmpty(this.textBoxLong.Text) ||
                   string.IsNullOrEmpty(this.ComboIndice.Text);
        }
        #endregion

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidad entidad;
            Atributo atributo;
            entidad = this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(comboBox1.Text, Constantes.tam));
            if (entidad.existeIndicePrimario())
            {
                atributo = entidad.buscaAtributoForaneo();
                this.comboTipo.Text = atributo.Tipo.ToString();
                this.textBoxLong.Text = atributo.Longitud.ToString();
            }
            else
            {
                this.ComboIndice.Text = "0: Sin indice";
                MessageBox.Show("No existe Indice Primario","Error");
            }
        }

        private void ComboIndice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboIndice.Text.Equals("3: Indice Secundario"))
            {
                comboBox1.Enabled = true;
                this.comboTipo.Enabled = false;
                this.textBoxLong.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
                this.comboTipo.Enabled = true;
                this.textBoxLong.Enabled = true;
            }
        }
    }
}
