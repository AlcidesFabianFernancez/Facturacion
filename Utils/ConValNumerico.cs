using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Factura.Utils
{
    public static class  ConValNumerico
    {
        public static int validarNumeros(string valor)
        {
            int numero = 0;
            int i = 0;
            bool result = int.TryParse(valor, out i); //i now = 108  
            if (result)
            {
                numero = int.Parse(valor);
            }
            else
            {
                numero = 0; 
            }

            return numero;
        }
    }
}
