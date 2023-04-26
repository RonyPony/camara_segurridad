using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto_F
{
    public partial class Compromiso_instalacion : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = DESKTOP-T7DI1O2\\RONYCRUZ;" +
"persist security info=False;initial catalog=GossipCam");
        public Compromiso_instalacion()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cap_clientes menu = new Cap_clientes();
            menu.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void cargarParrilla()
        {
            try
            {
                conexion.Open();
                string comando = "select * from clientes";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataGridView2.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + Convert.ToString(ex));
            }
            finally
            {
                conexion.Close();
            }
        }

        private void Compromiso_instalacion_Load(object sender, EventArgs e)
        {
            cargarParrilla();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cargarParrilla();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "") { MessageBox.Show("Primero escriba para la busqueda"); }
            else
            {
                foreach (DataGridViewRow Row in dataGridView2.Rows)
                {
                    string strFila = Row.Index.ToString();
                    string Valor = Convert.ToString(Row.Cells["nombre"].Value);

                    if (Valor == this.textBox18.Text)
                    {
                        dataGridView2.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;

                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("Select * From clientes where codigo = '" + textBox1.Text + "'", conexion);
                    SqlDataReader dr;
                    dr = comando.ExecuteReader();
                    if (dr.Read())
                    {
                        string nombre = Convert.ToString(dr["nombre"]);
                        string celular = Convert.ToString(dr["celular"]);
                        string apellidos = Convert.ToString(dr["apellidos"]);
                    string email = Convert.ToString(dr["correo"]);
                    string cedula = Convert.ToString(dr["cedula"]);
                    string direccion = Convert.ToString(dr["direccion"]);
                    //MessageBox.Show(nombre);
                    textBox2.Text = nombre;
                    textBox16.Text = celular;
                    textBox3.Text = apellidos;
                    textBox4.Text = email;
                    textBox17.Text = cedula;
                    textBox5.Text = direccion;
                }
                    else { MessageBox.Show("no se encontro suplidor con ese codigo"); }
                }
                catch (Exception error)
                {
                    MessageBox.Show("ERROR  " + Convert.ToString(error));
                }
                finally
                {
                    conexion.Close();
                }

            }
    }
}
