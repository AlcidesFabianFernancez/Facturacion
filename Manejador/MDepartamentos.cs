using Factura.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Data;

namespace Factura.Manejador
{
    class MDepartamentos
    {
        Conexion conex = new Conexion();

        /// 
        /// 
        /// Agregar 
        /// 
        /// 
        public string agregar(CDepartamentos depa)
        {
            string mensaje = "";
            string sql = "insert into departamento(nombre, descripcion) values(@vnombre, @vdescripcion)";
            try
            {
                conex.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, conex.cone);
                comando.Parameters.Add(new NpgsqlParameter("@vnombre", depa.nombre));
                comando.Parameters.Add(new NpgsqlParameter("@vdescripcion", depa.descripcion));
                NpgsqlDataReader lector = comando.ExecuteReader();

                conex.desconectar();
                mensaje = "Se ha agregado Correctamente";
            }
            catch(NpgsqlException e)
            {
                mensaje = "No se ha podido agregar Correctamente " + e;
            }

            return mensaje;
        }



        /// 
        /// 
        /// modificar
        /// 
        /// 
        public String modificar(CDepartamentos depa)
        {
            string mensaje = "";
            string sql = "update departamento set nombre=@vnombre, descripcion=@vdescripcion where cod_departamento=@vcodigo";
            try
            {
                conex.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, conex.cone);
                comando.Parameters.Add(new NpgsqlParameter("@vnombre", depa.nombre));
                comando.Parameters.Add(new NpgsqlParameter("@vdescripcion", depa.descripcion));
                comando.Parameters.Add(new NpgsqlParameter("@vcodigo", depa.cod_derpartamento));
                NpgsqlDataReader lector = comando.ExecuteReader();

                conex.desconectar();
                mensaje = "Se ha actualizado Correctamente";
            }
            catch(NpgsqlException e)
            {
                mensaje = "No se ha podido actualizar " + e;
            }
            return mensaje;
        }


        /// 
        /// 
        /// Eliminar
        /// 
        /// 
        public String eliminar(int valor)
        {
            string mensaje = "";
            string sql = "delete from departamento where cod_departamento=@vcodigo";
            try
            {
                conex.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, conex.cone);
                comando.Parameters.Add(new NpgsqlParameter("@vcodigo", valor));
                NpgsqlDataReader lector = comando.ExecuteReader();
                conex.desconectar();

                mensaje = "Se ha eliminado Correctamente";
            }
            catch(NpgsqlException e)
            {
                mensaje = "No se ha eliminado los Datos " + e;
            }
            return mensaje;
        }
        

        /// 
        /// Siguiente Codigo
        /// 
        /// 
        public String sigteCod()
        {
            string valor = "";
            string sql = "select MAX(cod_departamento)+1 as codigo from departamento";

            try
            {
                conex.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, conex.cone);
                NpgsqlDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        valor = lector["codigo"].ToString();
                    }
                }
               
                conex.desconectar();
            }
            catch(NpgsqlException e)
            {
               MessageBox.Show(""+e);
            }
            return valor;
        }


        /// 
        /// GetTable
        /// 
        /// 
        public DataTable getTable()
        {
            string sql = "select cod_departamento as Codigo, nombre as Nombre, descripcion as Descripcion from departamento";
            DataTable tabla = new DataTable();
            try
            {
                conex.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, conex.cone);
                comando.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(comando);
                da.Fill(tabla);
                comando.Dispose();
                conex.desconectar();
            }
            catch(NpgsqlException e)
            {
                MessageBox.Show("Error en la Tabla " + e);
            }
            return tabla;
        }

        public DataTable getTableCod(int valor)
        {
            string sql = "select cod_departamento as Codigo, nombre as Nombre, descripcion as Descripcion from departamento where cod_departamento= "+valor;
            DataTable tabla = new DataTable();
            try
            {
                conex.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, conex.cone);
                comando.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(comando);
                da.Fill(tabla);
                comando.Dispose();
                conex.desconectar();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error en la Tabla " + e);
            }
            return tabla;
        }
    }
}
