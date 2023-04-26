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
    public partial class Cap_suplidores : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = DESKTOP-T7DI1O2\\RONYCRUZ;" +
  "persist security info=False;initial catalog=GossipCam");

        public Cap_suplidores()
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
                string codigoSuplidor = textBox11.Text;
                string nombre = textBox1.Text;
                string direccion = textBox2.Text;
                string correo = textBox3.Text;
                string telefono = maskedTextBox1.Text;
                

                string consulta = "insert into suplidores (codigoSuplidor,nombre,direccion,correo,telefono)values('" + codigoSuplidor + "','" + nombre + "','" + direccion + "','" + correo + "','" + telefono + "')";
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
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Rellenar Espacios en Blanco", "Gracias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                enviar();
                MessageBox.Show("Guardado Exitosamente", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
            textBox11.Text = "";
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
            cargar();
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

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        

        public void cargar()
        {
            try
            {
                if (comboBox1.Text == "") { MessageBox.Show("Primero seleccione un criterio de busqueda"); }
                else
                {
                    foreach (DataGridViewRow Row in dataGridView1.Rows)
                    {

                        string strFila = Row.Index.ToString();
                        string Valor = Convert.ToString(Row.Cells[comboBox1.Text].Value);

                        if (Valor == this.textBox4.Text)
                        {
                            dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
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
        private void text_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
