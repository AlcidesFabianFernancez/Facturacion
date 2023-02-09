using Factura.Clases;
using Factura.Manejador;
using Factura.Utils;
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
    public partial class Empleados : Form
    {
        MEmpleados manejador = new MEmpleados();
        MDepartamentos departamentos = new MDepartamentos();
        CEmpleados empleados;
        bool nuevo = false;
        int num = 0;
        public Empleados()
        {
            InitializeComponent();
            getCodigo();
            cargarTabla();
            desactivar();
            comboBoxDepartamento();
            comboBoxSexo();
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            nuevo = true;
            limpiar();
            getCodigo();
            activar();
            comboBoxDepartamento();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string departamento = cbdepartamento.SelectedValue.ToString();           

            if (validarCampos())
            {
                empleados = new CEmpleados(Int32.Parse(txtcodigo.Text), txtnombre.Text, txtapellido.Text, txtdireccion.Text,
                int.Parse(txtsalario.Text), txtDocumento.Text, cbsexo.Text, txtcargo.Text, Int32.Parse(departamento), dtpInicio.Value, dtpNacimiento.Value);
                if (nuevo)
                {
                   MessageBox.Show(manejador.addEmpleados(empleados));
                }
                else
                {
                    MessageBox.Show(manejador.updateEmpleados(empleados));
                }


            }
            desactivar();
            limpiar();
            cargarTabla();

        }

        private void dgvTabla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor = dgvTabla.CurrentRow.Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("FILA SELECCIONADA VACIA");
            }
            else
            {
                nuevo = false;
                empleados = manejador.getEmpleados(valor);
                txtcodigo.Text = empleados.cod_empleado.ToString();
                txtnombre.Text = empleados.nombre.ToString();
                txtapellido.Text = empleados.apellido.ToString();
                txtcargo.Text = empleados.cargo.ToString();
                txtdireccion.Text = empleados.direccion.ToString();
                txtDocumento.Text = empleados.documento.ToString();
                txtsalario.Text = empleados.salario.ToString();
                dtpInicio.Value = empleados.f_inicio;
                dtpNacimiento.Value = empleados.f_nacimiento;
                cbsexo.SelectedItem = empleados.sexo.ToString();

                comboBoxDepartamento();
                comboBoxSexo();
                activar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = manejador.deleteEmpleado(int.Parse(txtcodigo.Text));
            MessageBox.Show(mensaje);
            limpiar();
            cargarTabla();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desactivar();
            limpiar();
            cargarTabla();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Metodo privado getCodigo
        /// </summary>
        private void getCodigo()
        {
            txtcodigo.Text = manejador.getsgtCodigo();
        }

        /// <summary>
        /// Metodo privado cargarTabla
        /// </summary>
        private void cargarTabla()
        {
            dgvTabla.DataSource = manejador.getEmpleados();
        }


        /// <summary>
        /// Activar Componentes
        /// </summary>
        private void activar()
        {
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = true;
            txtapellido.Enabled = true;
            txtcargo.Enabled = true;
            txtDocumento.Enabled = true;
            txtdireccion.Enabled = true;
            txtnombre.Enabled = true;
            txtsalario.Enabled = true;
            cbdepartamento.Enabled = true;
            cbsexo.Enabled = true;
            dtpInicio.Enabled = false;
            dtpNacimiento.Enabled = true;

            txtnombre.Focus();
        }


        /// <summary>
        /// Desactivar Componentes
        /// </summary>
        private void desactivar()
        {
            {
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnCancelar.Enabled = false;
                txtapellido.Enabled = false;
                txtcargo.Enabled = false;
                txtDocumento.Enabled = false;
                txtdireccion.Enabled = false;
                txtnombre.Enabled = false;
                txtsalario.Enabled = false;
                cbdepartamento.Enabled = false;
                cbsexo.Enabled = false;
                dtpInicio.Enabled = false;
                dtpNacimiento.Enabled = false;
            }
        }

        /// <summary>
        /// Cargar ComboBox Departamento
        /// </summary>
        private void comboBoxDepartamento()
        {
            cbdepartamento.DataSource = departamentos.getTable();
            cbdepartamento.DisplayMember = "Nombre";
            cbdepartamento.ValueMember = "Codigo";
        }


        /// <summary>
        /// Cargar ComboBox Sexo
        /// </summary>
        private void comboBoxSexo()
        {
            cbsexo.Items.Add("Masculino");
            cbsexo.Items.Add("Femenino");

        }


        /// <summary>
        /// Validar datos introducidos
        /// </summary>
        private Boolean validarCampos()
        {
            bool ver = true;
            DateTime fechaactual = DateTime.Today;
            int edad = fechaactual.Year - dtpNacimiento.Value.Year;
            if (fechaactual < dtpNacimiento.Value.AddYears(edad))
            {
                edad--;
                if (edad < 18)
                {
                    MessageBox.Show("LA EDAD ES MENOR A 18 AÑOS");
                    ver = false;
                }
                
            }
            else if (String.IsNullOrEmpty(txtnombre.Text) || String.IsNullOrEmpty(txtDocumento.Text) || String.IsNullOrEmpty(txtapellido.Text) ||
                string.IsNullOrEmpty(txtsalario.Text) || string.IsNullOrEmpty(txtdireccion.Text) || string.IsNullOrEmpty(txtcargo.Text))
            {
                MessageBox.Show("LOS CAMPOS NO PUEDEN QUEDAR VACIOS");
                ver = false;
            }

            else if (txtDocumento.TextLength < 6)
            {
                MessageBox.Show("NUMERO DE DOCUMENTO NO PUEDE SER MENOR A 6 CARACTERES");
                ver = false;
            }
            else if (!int.TryParse(txtDocumento.Text, out num))
            {
                MessageBox.Show("EL VALOR INGRESADO EN DOCUMENTO NO ES VALIDO");
                ver = false;
            }

            else if (!int.TryParse(txtsalario.Text, out num))
            {
                MessageBox.Show("EL VALOR INGRESADO EN SALARIO NO ES VALIDO");
                ver = false;
            }
            

            return ver;
        }

        private void limpiar()
        {
            txtapellido.Text = "";
            txtcargo.Text = "";
            txtcodigo.Text = "";
            txtdireccion.Text = "";
            txtDocumento.Text = "";
            txtnombre.Text = "";
            txtsalario.Text = "";
            cbdepartamento.SelectedIndex = -1;
            cbsexo.SelectedIndex = -1;
            dtpInicio.Value = DateTime.Now;
            dtpNacimiento.Value = DateTime.Now;
        }

        
    }
}
