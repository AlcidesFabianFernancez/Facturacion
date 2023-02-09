using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura
{
    public partial class Principal : Form
    {
        Departamentos depar = new Departamentos();
        Empleados emple = new Empleados();
        public Principal()
        {
            //maximizar formuario
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();            
        }

        private void ventasPorEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void formularioDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            depar.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formularioEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emple.ShowDialog();
        }
    }
}
