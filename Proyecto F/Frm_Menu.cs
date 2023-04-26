using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_F
{
    public partial class Frm_Menu : Form
    {
        int EnviarFecha = 0;
        public Frm_Menu(string usuario,string pass)
        {
            InitializeComponent();
        }
       

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_usuario menu = new Consulta_usuario();
            menu.Show();
        }

        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Factura_clientes menu = new Factura_clientes();
            menu.Show();
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void suplidoresToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Cap_suplidores menu = new Cap_suplidores();
            menu.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cap_clientes menu = new Cap_clientes();
            menu.Show();
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cap_empleados menu = new Cap_empleados();
            menu.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void cotizacionEInstalacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cap_usuario menu = new Cap_usuario();
            menu.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_clientes menu = new Consulta_clientes();
            menu.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_empleados menu = new Consulta_empleados();
            menu.Show();
        }

        private void suplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_suplidores menu = new Consulta_suplidores();
            menu.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (EnviarFecha)
            {
                case 0: CapturarFechaSistema(); break;
            }
        }

        private void CapturarFechaSistema()
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Inventario menu = new Inventario();
            menu.Show();
        }

        private void compraSuplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra_suplidores menu = new Compra_suplidores();
            menu.Show();
        }

        private void compromisoInstalacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compromiso_instalacion menu = new Compromiso_instalacion();
            menu.Show();
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }
    }
    }
