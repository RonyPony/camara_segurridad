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
    public partial class login : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = DESKTOP-T7DI1O2\\RONYCRUZ;" +
  "persist security info=False;initial catalog=GossipCam");
        DataTable dt = new DataTable();

        public login()
        {
            InitializeComponent();
        }

        int cont = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string usuario = textBox1.Text;
                string contraseña = textBox2.Text;
                string consulta = "select usuario,contraseña from usuariosLogin where usuario = '" + usuario + "' and contraseña = '" + contraseña + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean existenciaRegistro = lector.HasRows;

                if (existenciaRegistro)
                {
                    MessageBox.Show("Bienvenido al sistema " + usuario, "Usuario autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Frm_Menu frm = new Frm_Menu(textBox1.Text, textBox2.Text);
                    frm.Show();
                    this.Close();
                }
                else
                {
                    cont++;
                    MessageBox.Show("USUARIO INCORECTO", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Clear();
                    textBox1.Clear();
                    textBox1.Focus();
                    if (cont == 3)
                    {
                        MessageBox.Show("Agoto el limite de intento Datos Enviado al Correo");
                        Application.Exit();
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error, Por favor reinicie el sistema" + Convert.ToString(ex));
            }
            finally
            {
                conexion.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de SALIR", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
