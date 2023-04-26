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
    public partial class Cap_usuario : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = DESKTOP-T7DI1O2\\RONYCRUZ;" +
  "persist security info=False;initial catalog=GossipCam");
        public Cap_usuario()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Rellenar Espacios en Blanco", "Gracias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                enviarDatos();
                MessageBox.Show("Guardado Exitosamente", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Cap_usuario_Load(object sender, EventArgs e)
        {
            generarID();
        }

        public void enviarDatos()
        {
            try
            {
                conexion.Open();
                string usuario = textBox1.Text;
                string contraseña = textBox2.Text;
                string id = textBox3.Text;
                string consulta = "insert into usuariosLogin (usuario,contraseña,idusuario)values('"+usuario+"','"+contraseña+"','"+id+"')";
                SqlCommand comando = new SqlCommand(consulta,conexion);
                comando.ExecuteNonQuery();
            } catch (Exception ex)
            {
                MessageBox.Show("ERROR" + Convert.ToString(ex));
            }
            finally
            {
                conexion.Close();
                limpiar();
            }
        }

        public void generarID()
        {
            Random numero = new Random();
            int idI = numero.Next(11111,99999);
            string id = Convert.ToString(idI);
            textBox3.Text = id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generarID();
        }
    }
}
