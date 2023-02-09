using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace Factura.Clases
{
    class Login
    {
        Conexion conex = new Conexion();
        string query="";

        public bool ingresar(string usuario, string contrasena)
        {
            bool valor = false;
            try {
                conex.conectar();
                query = "select * from usuarios where nombre_usuario=@vusuario and pass=@vcontrasena and activo= 'true'";
                NpgsqlCommand conector = new NpgsqlCommand(query, conex.cone);
                conector.Parameters.Add(new NpgsqlParameter("@vusuario", usuario));
                conector.Parameters.Add(new NpgsqlParameter("@vcontrasena", contrasena));
                NpgsqlDataReader lector = conector.ExecuteReader();
                if (lector.Read())
                {
                    valor = true;
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos");
                }                

                conex.desconectar();
            }
            catch(NpgsqlException e)
            {
                MessageBox.Show("Error al Ingresar " + e);
            }
            return valor;
        }

    }
}
