using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //
            //Apertura de Formulario Login
            //

            Form1 login = new Form1();
            login.ShowDialog();

            //
            // Si el login es correcto
            //
            if (login.DialogResult == DialogResult.OK)
            {
                Application.Run(new Principal());
            }
        }
    }
}
