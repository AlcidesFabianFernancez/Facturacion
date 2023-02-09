using Factura.Clases;
using Factura.Manejador;
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
    public partial class Departamentos : Form
    {
        CDepartamentos cdepa;
        MDepartamentos mdepa= new MDepartamentos();
        string mensaje = "Vacio";
        public Departamentos()
        {
            InitializeComponent();
            cargarCodigo();
            CargarTabla();
        }


       
        
        private void btnagregar_Click(object sender, EventArgs e)
        {

            cdepa = new CDepartamentos(int.Parse(txtcodigo.Text), txtnombre.Text, txtdescripcion.Text);
            if (String.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Debe cargar el Nombre");
            }
            else
            {
                
               
                mensaje = mdepa.agregar(cdepa);
                MessageBox.Show(mensaje);
                limpiar();
                cargarCodigo();
                CargarTabla();
            }
            
        }


        private void btneliminar_Click(object sender, EventArgs e)
        {
            //cdepa = new CDepartamentos(int.Parse(txtcodigo.Text), txtnombre.Text, txtdescripcion.Text);
            MessageBox.Show(mdepa.eliminar(Convert.ToInt32(txtcodigo.Text)));
            limpiar();
            cargarCodigo();
            CargarTabla();
        }


        /// <summary>
        /// Traemos Datos de la DataTableView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgtabla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dgtabla.CurrentRow.Cells[0].Value.ToString();
            txtdescripcion.Text = dgtabla.CurrentRow.Cells[2].Value.ToString();
            txtnombre.Text= dgtabla.CurrentRow.Cells[1].Value.ToString();

        }


        /// <summary>
        /// Actualizar datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnactualizar_Click(object sender, EventArgs e)
        {

            cdepa = new CDepartamentos(int.Parse(txtcodigo.Text), txtnombre.Text, txtdescripcion.Text);
            if (String.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Debe cargar el Nombre");
            }
            else
            {


                mensaje = mdepa.modificar(cdepa);
                MessageBox.Show(mensaje);
                limpiar();
                cargarCodigo();
                CargarTabla();
            }
        }



        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        /// 
        ///
        /// 


        ///// 
        ///// limpiar
        /////
        private void limpiar()
        {
            txtdescripcion.Text = "";
            txtnombre.Text = "";
        }

        private void cargarCodigo()
        {
            txtcodigo.Text = mdepa.sigteCod();
        }

        private void CargarTabla()
        {
            dgtabla.DataSource = mdepa.getTable();
            //2dgtabla.AutoResizeColumns(DataGridViewAutoSizeColumnsMo‌​de.Fill);
        }

        
    }
}
