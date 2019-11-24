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
    partial class ModificaAtributo : Form
    {

        #region Variables de Instancia
        Archivo archivo;
        Entidad entidad;
        #endregion

        #region Constructores
        public ModificaAtributo(Archivo archivo)
        {
            this.archivo = archivo;
            InitializeComponent();
        }

        private void ModificaAtributo_Load(object sender, EventArgs e)
        {
            foreach (Entidad entidad in this.archivo.Entidades)
            {
                this.comboBox1.Items.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre));
                comboEntidad.Items.Add(MetodosAuxiliares.truncaCadena(entidad.Nombre));
            }
        }
        #endregion

        #region Gets & Sets
        public long DirIndice
        {

            get
            {
                long direccion;
                direccion = -1;
                if (this.comboInidice.Text.Equals("3: Llave Foranea"))
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

        public string Atributo
        {
            get { return this.comboAtributo.Text; }
        }
        
        public string Nombre
        {
            get { return this.textBoxNombre.Text; }
        }

        public int Longitud
        {
            get { return Int32.Parse(this.textBoxLong.Text); }
        }

        public char Tipo
        {
            get { return this.comboBoxTipo.Text.ToCharArray().First(); }
        }

        public int Indice
        {
            get { return Int32.Parse(this.comboInidice.Text[0].ToString()); }
        }

        #endregion

        #region Eventos

        #region Botones
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (!this.vacios())
            {
                try
                {
                    int i = Int32.Parse(textBoxLong.Text);
                    if (string.IsNullOrEmpty(textBoxNombre.Text))
                    {
                        textBoxNombre.Text = comboAtributo.Text;
                    }
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

        #region Combos

        private void comboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            entidad = archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(this.comboEntidad.Text,Constantes.tam));
            comboAtributo.Items.Clear();
            comboAtributo.Text = "";
            foreach(Atributo atributo in entidad.Atributos)
            {
                comboAtributo.Items.Add(MetodosAuxiliares.truncaCadena(atributo.Nombre));
            }
        }

        private void comboAtributo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Atributo atributo;
            atributo = entidad.buscaAtributo(MetodosAuxiliares.ajustaCadena(comboAtributo.Text,Constantes.tam));
            this.textBoxNombre.Text = MetodosAuxiliares.truncaCadena(atributo.Nombre);
            this.comboBoxTipo.Text = atributo.Tipo.ToString();
            this.textBoxLong.Text = atributo.Longitud.ToString();
            this.comboInidice.Text = comboInidice.Items[atributo.Indice].ToString();
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.Text.Equals("E"))
            {
                textBoxLong.Text = "4";
                textBoxLong.Enabled = false;
            }
            else if (comboBoxTipo.Text.Equals("C"))
            {
                textBoxLong.Enabled = true;
            }
        }

        #endregion

        #endregion

        #region Metodos
        public bool vacios()
        {
            return string.IsNullOrEmpty(comboEntidad.Text) || string.IsNullOrEmpty(comboAtributo.Text) ||
                   string.IsNullOrEmpty(comboBoxTipo.Text) || string.IsNullOrEmpty(textBoxLong.Text) ||
                   string.IsNullOrEmpty(comboInidice.Text);
        }
        #endregion

        private void ComboInidice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboInidice.Text.Equals("3: Indice Secundario"))
            {
                comboBox1.Enabled = true;
                this.comboBoxTipo.Enabled = false;
                this.textBoxLong.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
                this.comboBoxTipo.Enabled = true;
                this.textBoxLong.Enabled = true;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidad entidad;
            Atributo atributo;
            entidad = this.archivo.buscaEntidad(MetodosAuxiliares.ajustaCadena(comboBox1.Text, Constantes.tam));
            if (entidad.existeIndicePrimario())
            {
                atributo = entidad.buscaAtributoForaneo();
                this.comboBoxTipo.Text = atributo.Tipo.ToString();
                this.textBoxLong.Text = atributo.Longitud.ToString();
            }
            else
            {
                this.comboInidice.Text = "0: Sin indice";
                MessageBox.Show("No existe Indice Primario", "Error");
            }
        }
    }
}
