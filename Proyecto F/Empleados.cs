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
    public partial class Empleados : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = WINDOWS-Q2R254A\\RYUK;" +
  "persist security info=False;initial catalog=GossipCam");

        public Empleados()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
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
            textBox6.Text = "";
            maskedTextBox4.Text = "";
            textBox7.Text = "";
            textBox1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            enviar();
            limpiar();
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
                string nacimineto = maskedTextBox4.Text;
                string dep = textBox5.Text;
                string cargo = textBox6.Text;
                string sueldo = textBox7.Text;
                string correo = textBox4.Text;

                string consulta = "insert into empleados (nombre,apellidos,direccion,telefono,sexo,celular,nacimiento,departamento,cargo,sueldo,correo)values('" + nombre + "','" + apellidos + "','" + direccion + "','" + telefono + "','" + sexo + "','" + celular + "','" + nacimineto + "','" + dep + "','" + cargo + "','" + sueldo + "','" + correo + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();

                MessageBox.Show("Guardado Exitosamente", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            catch (Exception ex)
            {
              //  MessageBox.Show("ERROR" + Convert.ToString(ex));
            }
            finally
            {
                conexion.Close();
                cargarParrilla();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            cargarParrilla();
        }
        public void cargarParrilla()
        {
            try
            {
                conexion.Open();
                string comando = "select * from empleados";
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
            string consulta = "delete from empleados where nombre = '" + textBox8.Text + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            limpiar();
            cargarParrilla();
        }
    }
}

