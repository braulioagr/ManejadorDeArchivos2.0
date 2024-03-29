﻿using System;
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
    partial class AltaRegistro : Form
    {

        #region Variables de Instancia

        private Stack<string> atributos;
        private Entidad entidad;
        private int indice;
        private ComboBox comboDato;

        public delegate List<string> ObtenLlaves(long direccion, ref string ent);
        public event ObtenLlaves obtenLllaves;
        #endregion

        #region Constructores

        public AltaRegistro(Entidad entidad)
        {
            this.entidad = entidad;
            this.atributos = new Stack<string>();
            this.indice = 0;
            InitializeComponent();
        }
        private void AltaRegistro_Load(object sender, EventArgs e)
        {
            actualizaLabel();
            Anterior.Enabled = false;
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
                else if (entidad.Atributos[indice].Tipo.Equals('D'))
                {
                    atributos.Push(float.Parse(textBoxDato.Text).ToString());
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
                    if (entidad.Atributos[indice].Tipo.Equals('D'))
                    {
                        float.Parse(textBoxDato.Text);
                        atributos.Push(textBoxDato.Text);
                    }
                    else if (entidad.Atributos[indice].Tipo.Equals('C'))
                    {
                        atributos.Push(MetodosAuxiliares.ajustaCadena(textBoxDato.Text, entidad.Atributos[indice].Longitud));
                    }
                    indice++;
                    actualizaLabel();
                    textBoxDato.Text = "";
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

        #region Metodos
        private void actualizaLabel()
        {
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
            this.textBoxLong.Text = entidad.Atributos[indice].Longitud.ToString();
            if (entidad.Atributos[indice].Indice == 3)
            {
                if (comboDato != null)
                {
                    comboDato.Dispose();
                    if (this.Controls.Contains(comboDato))
                    {
                        this.Controls.Remove(comboDato);
                    }
                    comboDato = null;                
                }
                List<string> llaves;
                comboDato = new ComboBox();
                string ent;
                ent = "";
                llaves = this.obtenLllaves(entidad.Atributos[indice].DirIndice, ref ent);
                if (llaves.Count > 0)
                {
                    this.textBoxDato.Visible = false;
                    comboDato.Location = textBoxDato.Location;
                    comboDato.Size = textBoxDato.Size;
                    //Aqui se manda llamar el metodo para llenar los datos del combo box
                    this.Controls.Add(this.comboDato);
                    this.comboDato.SelectedIndexChanged += new EventHandler(this.ComboBox1_SelectedIndexChanged);
                    foreach (string llave in llaves)
                    {
                        this.comboDato.Items.Add(llave);
                    }
                }
                else
                {
                    MessageBox.Show("No se encuentran valores para hacer referencia con la entidad: " + ent + " Por favor de de alta registros en esa tabla", "Error");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else if (entidad.Atributos[indice].Indice != 3 && !this.textBoxDato.Visible)
            {
                this.Controls.Remove(comboDato);
                comboDato.Dispose();
                this.textBoxDato.Visible = true;
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxDato.Text = comboDato.Text;
        }
        #endregion

        #region Gets & Sets

        public List<string> Informacion
        {
            get
            {
                List<string> registro = new List<string>();
                foreach (string reg in this.atributos)
                {
                    registro.Add(reg);
                }
                registro.Reverse();
                return registro;
            }
        }

        #endregion

    }
}
