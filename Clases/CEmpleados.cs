using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura.Clases
{
    class CEmpleados
    {
        public int cod_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public int salario { get; set; }
        public string documento { get; set; }
        public string sexo { get; set; }
        public string cargo { get; set; }
        public int cod_departamento { get; set; }
        public DateTime f_inicio { get; set; }
        public DateTime f_nacimiento { get; set; }

        public CEmpleados(int cod_empleado, string nombre, string apellido, string direccion, int salario, 
            string documento, string sexo, string cargo, int cod_departamento, DateTime f_inicio, DateTime f_nacimiento)
        {
            this.cod_empleado = cod_empleado;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.salario = salario;
            this.documento = documento;
            this.sexo = sexo;
            this.cargo = cargo;
            this.cod_departamento = cod_departamento;
            this.f_inicio = f_inicio;
            this.f_nacimiento = f_nacimiento;
        }

        public CEmpleados()
        {

        }

       
    }
}
