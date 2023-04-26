using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto_F
{
    public partial class Consulta_empleados : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = DESKTOP-T7DI1O2\\RONYCRUZ;" +
  "persist security info=False;initial catalog=GossipCam");

        public Consulta_empleados()
        {
                        InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") { MessageBox.Show("Primero seleccione un criterio de busqueda"); }
            else
            {
                foreach (DataGridViewRow Row in dtgconsulta.Rows)
                {

                    string strFila = Row.Index.ToString();
                    string Valor = Convert.ToString(Row.Cells[comboBox1.Text].Value);

                    if (Valor == this.text.Text)
                    {
                        dtgconsulta.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Estas segur@ de Salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Consulta_usuario_Load(object sender, EventArgs e)
        {
            cargar();
        }
        public void cargar()
        {
            try
            {
                conexion.Open();
                string comando = "select nombre,apellidos,direccion,telefono,cedula,sexo,celular,nombramiento,departamento,cargo,sueldo,correo from empleados";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dtgconsulta.DataSource = table;
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

        private void dtgconsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Consulta_clientes_Load(object sender, EventArgs e)
        {
           cargar();
        }

        private void dtgconsulta_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

 }
