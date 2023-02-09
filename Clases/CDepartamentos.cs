using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura.Clases
{
    class CDepartamentos
    {
        public int cod_derpartamento { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public CDepartamentos() { }

        public CDepartamentos(int cod, string nombre, string descripcion)
        {
            this.cod_derpartamento = cod;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}
