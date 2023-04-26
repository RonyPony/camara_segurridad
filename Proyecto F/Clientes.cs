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
    public partial class Clientes : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = WINDOWS-Q2R254A\\RYUK;" +
  "persist security info=False;initial catalog=GossipCam");

        public Clientes()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            enviar();


        }

        private void button6_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargarParrilla();
        }

        public void enviar()
        {
            try
            {
                conexion.Open();
                string nombre = textBox1.Text;
                string apellidos = textBox2.Text;
                string direccion = textBox3.Text;
                string telefono = maskedTextBox1.Text;
                string sexo = comboBox1.Text;
                string celular = textBox3.Text;
                string cedula = maskedTextBox2.Text;
                string correo = textBox4.Text;

                string consulta = "insert into clientes (cedula,nombre,apellidos,direccion,telefono,celular,correo,sexo)values('"+cedula+"','"+nombre+"','"+apellidos+"','"+direccion+"','"+telefono+"','"+celular+ "','" + correo + "','" + sexo + "')";
                SqlCommand comando = new SqlCommand(consulta,conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Guardado Exitosamente", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            } catch (Exception ex)
            {
                MessageBox.Show("ERROR"+Convert.ToString(ex));
            }
            finally
            {
                conexion.Close();

                cargarParrilla();
                limpiar();
            }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            cargarParrilla();
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

        private void button5_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "delete from clientes where nombre = '" + textBox5.Text + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            limpiar();
            cargarParrilla();
        }
    }
}
