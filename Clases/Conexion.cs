using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Factura
{
    class Conexion
    {
        public NpgsqlConnection cone; 
        static string servidor= "localhost";
        static string bd= "FacturacionyStock";
        static string usuario= "postgres";
        static string pass= "1234";
        static string puerto="5433";

        string cadenaConexion = "Server=" + servidor + ";Port=" + puerto + ";User Id=" + usuario + ";Password=" + pass + "; Database=" + bd;
    
        public NpgsqlConnection conectar()
        {
            try
            {
                cone= new NpgsqlConnection(cadenaConexion);
                cone.Open();
                //MessageBox.Show("Conexion con exito");
            }
            catch(NpgsqlException e)
            {
                MessageBox.Show("No se ha podido realizar la conexion " + e);
            }
            return cone;
        }    

        public NpgsqlConnection desconectar()
        {
            try
            {
                cone.Close();
                //MessageBox.Show("Nos desconectamos correctamente");
            }
            catch(NpgsqlException e)
            {
                MessageBox.Show("Error al desconectar " + e);
            }
            return cone;
        }
    }
}
