using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_F
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new Compra_suplidores());
            //Application.Run(new Cap_usuario());
            //Application.Run(new Cap_suplidores());
            //Application.Run(new Compromiso_instalacion());
            //Application.Run(new Inventario());
        }
    }
}
