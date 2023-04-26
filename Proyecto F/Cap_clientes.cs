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
    public partial class Cap_clientes : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = DESKTOP-T7DI1O2\\RONYCRUZ;" +
  "persist security info=False;initial catalog=GossipCam");

        public Cap_clientes()
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
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("Rellenar Espacios en Blanco", "Gracias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                enviar();
            }

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
                string telefono = maskedTextBox2.Text;
                string sexo = comboBox1.Text;
                string celular = maskedTextBox3.Text;
                string cedula = maskedTextBox1.Text;
                string correo = textBox4.Text;
                string codigo = textBox6.Text;

                string consulta = "insert into clientes (cedula,nombre,apellidos,direccion,telefono,celular,correo,sexo,codigo)values('"+cedula+"','"+nombre+"','"+apellidos+"','"+direccion+"','"+telefono+"','"+celular+ "','" + correo + "','" + sexo + "','"+codigo+"')";
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
            generarID();
            cargarParrilla();
        }

        public void generarID()
        {
            Random numero = new Random();
            int idI = numero.Next(11111, 99999);
            string id = Convert.ToString(idI);
            textBox6.Text = id;
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

        private void button1_Click(object sender, EventArgs e)
        {
            generarID();
        }
    }
}
