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
    public partial class Compra_suplidores : Form
    {
        int EnviarFecha = 0;
        SqlConnection conexion = new SqlConnection("integrated security = SSPI; data source = DESKTOP-T7DI1O2\\RONYCRUZ;" +
  "persist security info=False;initial catalog=GossipCam");
        public Compra_suplidores()
        {
            InitializeComponent();
        }

        private void Compra_suplidores_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();
        }

        private void CapturarFechaSistema()
        {
            maskedTextBox1.Text = DateTime.Now.ToShortDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void limpiar()
        {

            string idProducto = textBox1.Text = "";
            string descripcion = textBox2.Text = "";
            string tamaño = textBox3.Text = "";
            string referencia = textBox4.Text = "";
            string marca = textBox5.Text = "";
            string garantia = textBox6.Text = "";
            string gananciaxUnidad = textBox7.Text = "";
            string precioCompra = textBox8.Text = "";
            string precioVenta = textBox9.Text = "";
            //string RNC = textBox10.Text = "";
            //string nombreSuplidor = textBox11.Text = "";
            string cantidad = textBox12.Text = "";
            //string total = textBox13.Text = "";
            string efectivo = textBox14.Text = "";
            string tipoArticulo = comboBox1.Text = "";
            string tipocompra = comboBox2.Text = "";
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enviargrid();
        }
        protected void enviargrid()
        {
            conexion.Open();
            string query = @"insert into compraSuplidores (idProducto,descripcion,tamaño,referencia,marca,garantia,gananciaxUnidad,precioCompra,precioVenta,nombreSuplidor,cantidad,total,tipoArticulo,tipoCompra,nombreProducto,fecha)
					values (@idproducto, @descripcion,@tamaño,@referencia,@marca,@garantia,@gananciaxUnidad,@precioCompra,@precioVenta,@nombreSuplidor,@cantidad,@total,@tipoArticulo,@tipoCompra,@nombreProducto,@fecha)";
            SqlCommand query3 = new SqlCommand(query, conexion);

            foreach (DataGridViewRow GVRow in dataGridView1.Rows)
            {
                string idProducto = GVRow.Cells[0].Value.ToString();
                string descripcion = GVRow.Cells[1].Value.ToString();
                string tamaño = GVRow.Cells[4].Value.ToString();
                string referencia = GVRow.Cells[3].Value.ToString();
                string marca = GVRow.Cells[2].Value.ToString();
                string garantia = GVRow.Cells[5].Value.ToString();
                string gananciaxUnidad = GVRow.Cells[7].Value.ToString();
                string precioCompra = GVRow.Cells[8].Value.ToString();
                string precioVenta = GVRow.Cells[9].Value.ToString();
                string nombreSuplidor = GVRow.Cells[12].Value.ToString();
                string cantidad = GVRow.Cells[10].Value.ToString();
                string total = GVRow.Cells[11].Value.ToString();

                string tipoArticulo = GVRow.Cells[6].Value.ToString();
                string tipoCompra = GVRow.Cells[13].Value.ToString();
                string nombreProducto = GVRow.Cells[14].Value.ToString();
                string fecha = GVRow.Cells[15].Value.ToString();


                //MessageBox.Show(idcompra + "/" + cantidad + "/" + precio + "/" + suplidor + "/" + idcompra + "/"+  nombreproducto  + "/"+ comentario + "(" + fecha + ")");
                query3.Parameters.Clear();
                query3.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                query3.Parameters.AddWithValue("@cantidad", cantidad);
                query3.Parameters.AddWithValue("@total", total);
                query3.Parameters.AddWithValue("@nombreSuplidor", nombreSuplidor);
                query3.Parameters.AddWithValue("@idProducto", idProducto);
                query3.Parameters.AddWithValue("@descripcion", descripcion);
                query3.Parameters.AddWithValue("@tamaño", tamaño);
                query3.Parameters.AddWithValue("@referencia", referencia);
                query3.Parameters.AddWithValue("@marca", marca);
                query3.Parameters.AddWithValue("@garantia", garantia);
                query3.Parameters.AddWithValue("@gananciaxUnidad", gananciaxUnidad);
                query3.Parameters.AddWithValue("@precioCompra", precioCompra);
                query3.Parameters.AddWithValue("@precioVenta", precioVenta);
                query3.Parameters.AddWithValue("@tipoArticulo", tipoArticulo);
                query3.Parameters.AddWithValue("@tipoCompra", tipoCompra);
                query3.Parameters.AddWithValue("@fecha", fecha);


                query3.ExecuteNonQuery();
                MessageBox.Show(" Se ha facturado" + " * "+nombreProducto +" * ");
            }

            conexion.Close();
            limpiar();
            dataGridView1.Rows.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox10.Text == "")
            {
                MessageBox.Show("Rellenar Espacios en Blanco", "Gracias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int precioARTS = Convert.ToInt32(textBox8.Text) * Convert.ToInt32(textBox12.Text);
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox5.Text, textBox3.Text, textBox4.Text, textBox6.Text, comboBox1.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox12.Text, precioARTS, textBox11.Text, comboBox2.Text, textBox14.Text, maskedTextBox1.Text);

                if (textBox13.Text == "")
                {
                    int x = Convert.ToInt32(textBox8.Text) * Convert.ToInt32(textBox12.Text);
                    textBox13.Text = Convert.ToString(x);
                }
                else
                {
                    //MessageBox.Show("tiene");
                    int sumatoria = 0;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        sumatoria += Convert.ToInt32(row.Cells[11].Value);    //aqui recorre las celdas y las va sumando
                        textBox13.Text = sumatoria.ToString();
                    }
                }

                if (textBox17.Text == "") { textBox18.Text = textBox13.Text; }
                limpiar();                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            verificarSupli();
        }

        public void verificarSupli()
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("Select * From suplidores where codigoSuplidor = '"+textBox10.Text+"'", conexion);
                SqlDataReader dr;
                dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    string nombre = Convert.ToString(dr["nombre"]);
                    //MessageBox.Show(nombre);
                    textBox11.Text = nombre;
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

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            sacarPorciento();
        }

        public void sacarPorciento()
        {
            try {
                int porcentaje = Convert.ToInt32(textBox17.Text);
                int cantidad = Convert.ToInt32(textBox13.Text);
                int re = (cantidad * porcentaje / 100);
                float descuento = (re-cantidad);
                descuento = Math.Abs(descuento);
                textBox18.Text = Convert.ToString(descuento);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cap_suplidores menu = new Cap_suplidores();
            menu.Show();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void sacarPorcientoGanacias()
        {
            try
            {
                if (textBox7.Text != "" && textBox8.Text != "")
                {
                    string k = textBox7.Text;
                    string z = textBox8.Text;
                    int porcentaje = Convert.ToInt32(k);
                    int cantidad = Convert.ToInt32(z);
                    int resultado = (cantidad * porcentaje / 100);
                    int porno = resultado + cantidad;

                    textBox9.Text = Convert.ToString(porno);
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+Convert.ToString(ex));
            }
            finally
            {

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            sacarPorcientoGanacias();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (EnviarFecha)
            {
                case 0: CapturarFechaSistema(); break;
            }
        }
    }
}
