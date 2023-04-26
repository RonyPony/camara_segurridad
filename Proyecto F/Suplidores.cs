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
    public partial class Suplidores : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = WINDOWS-Q2R254A\\RYUK;" +
  "persist security info=False;initial catalog=GossipCam");

        public Suplidores()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }


        public void enviar()
        {
            try
            {
                conexion.Open();
                string nombre = textBox1.Text;
                string apellidos = textBox2.Text;
                string producto = textBox4.Text;
                string modelo = textBox5.Text;
                string caracteristicas = textBox6.Text;
                string PPUAC = textBox7.Text;
                string PPUAV = textBox8.Text;
                string correo = textBox3.Text;
                string telefono = maskedTextBox1.Text;
                string contacto1 = maskedTextBox2.Text;
                string contacto2 = maskedTextBox3.Text;

                string consulta = "insert into suplidores (nombre,apellidos,producto,modelo,caracteristicas,ppuac,ppuav,correo,telefono,contacto1,contacto2)values('" + nombre + "','" + apellidos + "','" + producto + "','" + modelo + "','" + caracteristicas + "','" + PPUAC + "','" + PPUAV + "','" + correo + "','" + telefono + "','" + contacto1 + "','" + contacto2 + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + Convert.ToString(ex));
            }
            finally
            {
                conexion.Close();
                cargarParrilla();
                limpiar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            enviar();
            MessageBox.Show("Guardado Exitosamente", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox1.Focus();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Suplidores_Load(object sender, EventArgs e)
        {
            cargarParrilla();
        }
        public void cargarParrilla()
        {
            try
            {
                conexion.Open();
                string comando = "select * from suplidores";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
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

        private void button4_Click(object sender, EventArgs e)
        {
            cargarParrilla();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "delete from suplidores where nombre = '" + textBox9.Text + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            cargarParrilla();
        }
    }
}
