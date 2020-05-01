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
    partial class ConsultasSQL : Form
    {
        public delegate List<Atributo> ConsultaAtributosSelect(string[] sentencia, ref Entidad entidad);
        public event ConsultaAtributosSelect consultaAtributosSelect;
        public delegate List<Registro> ConsultaRegistrosSelectWhere(List<Atributo> atributos, Entidad entidad, string[] where);
        public event ConsultaRegistrosSelectWhere consultaRegistrosSelectWhere;
        public delegate List<Registro> ConsultaRegistrosSelectAnd(List<Atributo> atributos, Entidad entidad, string[] where);
        public event ConsultaRegistrosSelectAnd consultaRegistrosSelectAnd;
        public delegate Entidad InnerJoin(string[] sentencia);
        public event InnerJoin innerJoin;
        public delegate List<Atributo> ConsultaAtributosSelectInnerJoin(string[] sentencia, Entidad entidad);
        public event ConsultaAtributosSelectInnerJoin consultaAtributosSelectInnerJoin;
        public ConsultasSQL()
        {
            InitializeComponent();
        }

        private void ConsultaSQL_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxSQL.Text))
            {
                try
                {
                    string[] sentencia;
                    sentencia = this.textBoxSQL.Text.Split((" ").ToCharArray());
                    sentencia = MetodosAuxiliares.LimpiaSentencia(sentencia);
                    if (sentencia.Contains("select"))
                    {
                        int i;
                        if (sentencia.First().Equals("select"))
                        {
                            Entidad entidad;
                            List<Registro> registros;
                            List<Atributo> atributos;
                            entidad = null;
                            if (!sentencia.Contains("inner"))
                            {
                                atributos = this.consultaAtributosSelect(sentencia, ref entidad);
                                if (entidad.Atributos.Count != 0)
                                {
                                    if (entidad.Registros.Count != 0)
                                    {
                                        if (!sentencia.Contains("where"))
                                        {
                                            registros = entidad.Valores;
                                            this.actualizaDataGridSQLConSelect(entidad, atributos, registros, false);
                                        }
                                        else
                                        {
                                            string[] where;
                                            i = Array.IndexOf(sentencia, "where");
                                            i++;
                                            if (i != sentencia.Length)
                                            {
                                                where = MetodosAuxiliares.SubArray(sentencia, i, sentencia.Length - i);
                                                registros = this.consultaRegistrosSelectWhere(atributos, entidad, where);
                                                this.actualizaDataGridSQLConSelect(entidad, atributos, registros, false);
                                            }
                                            else
                                            {
                                                throw new InvalidConsultException("Por favor ponga el enunciado de la sentencia where");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new InvalidConsultException("La entidad a consultar no tiene registros para consultar");
                                    }
                                }
                                else
                                {
                                    throw new InvalidConsultException("La entidad a consultar no tiene atributos para consultar");
                                }
                            }
                            else if(sentencia.Contains("inner") && sentencia.Contains("join") && sentencia.Contains("on") && !sentencia.Contains("where"))
                            {
                                entidad = this.innerJoin(sentencia);
                                atributos = this.consultaAtributosSelectInnerJoin(sentencia, entidad);
                                if (entidad.Registros.Count > 0)
                                {
                                    if (!sentencia.Contains("and"))
                                    {
                                        registros = entidad.Valores;
                                        this.actualizaDataGridSQLConSelect(entidad, atributos, registros, true);
                                    }
                                    else
                                    {
                                        string[] and;
                                        i = Array.IndexOf(sentencia, "and");
                                        i++;
                                        if (i != sentencia.Length)
                                        {
                                            and = MetodosAuxiliares.SubArray(sentencia, i, sentencia.Length - i);
                                            registros = this.consultaRegistrosSelectAnd(atributos, entidad, and);
                                            this.actualizaDataGridSQLConSelect(entidad, atributos, registros, false);
                                        }
                                        else
                                        {
                                            throw new InvalidConsultException("Por favor ponga el enunciado de la sentencia where");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                throw new InvalidConsultException("El formato de la consulta no es valido por favor revise la sentencia");
                            }
                        }
                        else
                        {
                            throw new InvalidConsultException("El select debe ir al principio de la sentencia");
                        }
                    }
                    else
                    {
                        throw new InvalidConsultException("Formato de consulta no valido");
                    }
                }
                catch (InvalidConsultException e1)
                {
                    MessageBox.Show(e1.Message, "Consulta Invalida");
                }
                catch (NotImplementedException e2)
                {
                    MessageBox.Show(e2.Message, "Aun no implementado");
                }
            }
            else
            {
                MessageBox.Show("La cadena no puede estar vacia");
            }
        }

        private void actualizaDataGridSQLConSelect(Entidad entidad, List<Atributo> atributos, List<Registro> registros, bool band)
        {
            int i;
            int j;
            string[] tupla;
            i = 0;
            tupla = new string[atributos.Count];
            dataGridSQL.Columns.Clear();
            dataGridSQL.ColumnCount = 0;
            dataGridSQL.Rows.Clear();
            dataGridSQL.ColumnCount = atributos.Count;
            foreach (Atributo atributo in atributos)
            {
                if (band)
                {
                    dataGridSQL.Columns[i].Name = MetodosAuxiliares.truncaCadena(atributo.Nombre) + " - " + MetodosAuxiliares.truncaCadena(atributo.Entidad);
                }
                else
                {
                    dataGridSQL.Columns[i].Name = MetodosAuxiliares.truncaCadena(atributo.Nombre);
                }
                i++;
            }

            foreach (Registro registro in registros)
            {
                for (int k = 0; k < tupla.Length; k++)
                {
                    j = entidad.buscaIndiceAtributo(atributos[k].Nombre, atributos[k].Entidad);
                    tupla[k] = MetodosAuxiliares.truncaCadena(registro.Datos[j]);
                }
                dataGridSQL.Rows.Add(tupla);
            }
        }


        private void ConsultasSQL_Resize(object sender, EventArgs e)
        {
            Size size = new Size();
            Point point = new Point();
            point.Y = this.ConsultaSQL.Location.Y;
            size.Width = this.Size.Width - 40;
            size.Height = this.Size.Height - 92;
            this.dataGridSQL.Size = size;
            point.X = this.Size.Width - 103;
            this.ConsultaSQL.Location = point;
            size.Height = this.textBoxSQL.Height;
            size.Width = this.Size.Width - 121;
            this.textBoxSQL.Size = size;
        }

        private void ConsultasSQL_Load(object sender, EventArgs e)
        {

        }
    }
}
