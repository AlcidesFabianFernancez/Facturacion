using Factura.Clases;
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
    public partial class Form1 : Form
    {
        Conexion conexion = new Conexion();
        Login lo = new Login();
        Principal pri = new Principal();
        public Form1()
        {
            InitializeComponent();
            txtusuario.Focus();
        }

        private void btconectar_Click(object sender, EventArgs e)
        {
            ingresar();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void txtcontrasena_TextChanged(object sender, EventArgs e)
        {
            //ingresar();
        }

       
        private void txtcontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ingresar();
            }
        }

        private void ingresar()
        {
            verificarDatos();
           
            if (lo.ingresar(txtusuario.Text, txtcontrasena.Text))
            {                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
           
        }

        private void limpiar()
        {
            txtcontrasena.Text = "";
            txtusuario.Text = "";
            txtusuario.Focus();

        }

        private void verificarDatos()
        {
            if (string.IsNullOrEmpty(txtusuario.Text))
            {
                MessageBox.Show("LLENAR CAMPO USUARIO");
            }
            if (string.IsNullOrEmpty(txtcontrasena.Text))
            {
                MessageBox.Show("LLENAR CAMPO CONTRASEÑA");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
