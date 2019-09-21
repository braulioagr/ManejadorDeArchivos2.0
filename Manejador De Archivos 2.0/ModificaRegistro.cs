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
    partial class ModificaRegistro : Form
    {
        #region variables de Instancia
        private Entidad entidad;
        private Registro registro;
        private int indice;
        private Stack<string> atributos;
        #endregion

        #region Constructores
        public ModificaRegistro(Entidad entidad, string claveDeBusqueda)
        {
            this.entidad = entidad;
            this.registro = entidad.buscaRegistro(claveDeBusqueda);
            this.atributos = new Stack<string>();
            this.indice = 0;
            InitializeComponent();
        }
        
        private void ModificaRegistro_Load(object sender, EventArgs e)
        {
            actualizaLabel();
            Anterior.Enabled = false;
        }
        #endregion

        #region Metodos
        private void actualizaLabel()
        {
            this.textBoxDato.Enabled = true;
            if (indice == 1)
            {
                Anterior.Enabled = true;
            }
            if (!Siguiente.Enabled)
            {
                Siguiente.Enabled = true;
            }
            if (Aceptar.Visible)
            {
                Aceptar.Visible = false;
            }
            if (indice == 0)
            {
                Anterior.Enabled = false;
            }
            if (indice == entidad.Atributos.Count - 1)
            {
                Siguiente.Enabled = false;
                Aceptar.Visible = true;
            }
            textBoxAtributo.Text = MetodosAuxiliares.truncaCadena(entidad.Atributos[indice].Nombre);
            textBoxTipo.Text = entidad.Atributos[indice].Tipo.ToString();
            textBoxIndice.Text = MetodosAuxiliares.traduceIndice(entidad.Atributos[indice].Indice);
            this.textBoxDato.Text = MetodosAuxiliares.truncaCadena(this.registro.Datos[indice]);
            if (entidad.Atributos[indice].Indice == 1)
            {
                this.textBoxDato.Enabled = false;
            }
        }
        #endregion

        #region Gets & Sets
        public List<string> Datos
        {
            get
            {
                List<string> datos = this.atributos.ToList();
                datos.Reverse();
                return datos;
            }
        }
        #endregion

        #region Eventos

        #region Botones

        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                if (entidad.Atributos[indice].Tipo.Equals('E'))
                {
                    atributos.Push(Int32.Parse(textBoxDato.Text).ToString());
                }
                else if (entidad.Atributos[indice].Tipo.Equals('C'))
                {
                    atributos.Push(MetodosAuxiliares.ajustaCadena(textBoxDato.Text, entidad.Atributos[indice].Longitud));
                }
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Este atributo es de tipo entero ponga un entero", "Error");
                textBoxDato.Text = "";
            }
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxDato.Text))
                {
                    if (entidad.Atributos[indice].Tipo.Equals('E'))
                    {
                        Int32.Parse(textBoxDato.Text);
                        atributos.Push(textBoxDato.Text);
                    }
                    else if (entidad.Atributos[indice].Tipo.Equals('C'))
                    {
                        atributos.Push(MetodosAuxiliares.ajustaCadena(textBoxDato.Text, entidad.Atributos[indice].Longitud));
                    }
                    indice++;
                    actualizaLabel();
                    //textBoxDato.Text = "";
                }
                else
                {
                    MessageBox.Show("No puede hacer campos vacios", "Error");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Este atributo es de tipo entero ponga un entero", "Error");
                textBoxDato.Text = "";
            }
        }


        private void Anterior_Click(object sender, EventArgs e)
        {
            indice--;
            actualizaLabel();
            textBoxDato.Text = MetodosAuxiliares.truncaCadena(atributos.Pop());
        }

        #endregion

        #endregion

    }
}
