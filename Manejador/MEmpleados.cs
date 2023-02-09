using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Factura.Clases;
using Npgsql;

namespace Factura.Manejador
{
    class MEmpleados
    {
        Conexion cone = new Conexion();

        /// <summary>
        /// Siguiente Cod
        /// </summary>
        /// <returns></returns>
        public String getsgtCodigo()
        {
            string cod = "";
            string sql = "select max(cod_empleado) +1 as codigo from empleados";
            try
            {
                cone.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, cone.cone);
                NpgsqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        cod = reader["codigo"].ToString();
                    }
                   
                }
                comando.Dispose();
                cone.desconectar();
            }
            catch(NpgsqlException e)
            {
                MessageBox.Show("Error al traer siguiente Codigo "+e);
            }

            return cod;
        }

        /// <summary>
        /// Get Empleados
        /// </summary>
        /// <returns></returns>
        public DataTable getEmpleados()
        {
            DataTable tabla = new DataTable();
            string sql = "select e.cod_empleado as Codigo, (e.nombres || ' '|| e.apellidos) as Nombres, e.documento as Documento, " +
                "e.cargo as Cargo, e.sexo as Sexo, d.nombre as Departamento from empleados e inner join departamento d on d.cod_departamento = e.cod_departamento";
            try
            {
                cone.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, cone.cone);
                NpgsqlDataAdapter reader = new NpgsqlDataAdapter(comando);
                reader.Fill(tabla);
                comando.Dispose();
                cone.desconectar();

            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("eRROR AL EXTRAER LOS DATOS EN LA TABLA " + e);
            }

            return tabla;
        }

        /// <summary>
        /// AddEmpleados
        /// </summary>
        /// <param name="emple"></param>
        /// <returns></returns>
        public String addEmpleados(CEmpleados emple)
        {
            string mensaje = "";
            string sql = "insert into empleados(nombres, apellidos, documento, direccion, fecha_nacimiento, sexo, cargo, fecha_inicio, salario, cod_departamento) " +
                "values(@vnombres, @vapellidos, @vdocumento, @vdireccion, @vfecha_nacimiento, @vsexo, @vcargo, @vfecha_inicio, @vsalario, @vcod_departamento)";
            try
            {
                cone.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, cone.cone);
                comando.Parameters.Add(new NpgsqlParameter("@vnombres", emple.nombre));
                comando.Parameters.Add(new NpgsqlParameter("@vapellidos", emple.apellido));
                comando.Parameters.Add(new NpgsqlParameter("@vdocumento", emple.documento));
                comando.Parameters.Add(new NpgsqlParameter("@vdireccion", emple.direccion));
                comando.Parameters.Add(new NpgsqlParameter("@vfecha_nacimiento", emple.f_nacimiento));
                comando.Parameters.Add(new NpgsqlParameter("@vsexo", emple.sexo));
                comando.Parameters.Add(new NpgsqlParameter("@vcargo", emple.cargo));
                comando.Parameters.Add(new NpgsqlParameter("@vfecha_inicio", emple.f_inicio));
                comando.Parameters.Add(new NpgsqlParameter("@vsalario", emple.salario));
                comando.Parameters.Add(new NpgsqlParameter("@vcod_departamento", emple.cod_departamento));
                NpgsqlDataReader lector = comando.ExecuteReader();

                cone.desconectar();
                mensaje = "SE HA AGREGADO CORRECTAMENTE EMPLEADO";
            }
            catch(Exception e)
            {
                mensaje = "NO SE HA PODIDO AGREGAR EMPLEADO" + e;
            }
            return mensaje;
        }

        /// <summary>
        /// UpdateEmpleados
        /// </summary>
        /// <param name="emple"></param>
        /// <returns></returns>
        public String updateEmpleados(CEmpleados emple)
        {
            string mensaje = "";
            string sql = "update empleados set nombres=@vnombre, apellidos=@vapellido, documento=@vdocumento, direccion=@vdireccion, fecha_nacimiento=@vfecha_nacimiento, " +
                "sexo=@vsexo, cargo=@vcargo, fecha_inicio=@vfecha_inicio, salario=@vsalario,cod_departamento=@vcod_departamento where cod_empleado=@vcod_empleado";
            try
            {
                cone.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, cone.cone);
                comando.Parameters.Add(new NpgsqlParameter("@vnombre", emple.nombre));
                comando.Parameters.Add(new NpgsqlParameter("@vapellido", emple.apellido));
                comando.Parameters.Add(new NpgsqlParameter("@vdocumento", emple.documento));
                comando.Parameters.Add(new NpgsqlParameter("@vdireccion", emple.direccion));
                comando.Parameters.Add(new NpgsqlParameter("@vfecha_nacimiento", emple.f_nacimiento));
                comando.Parameters.Add(new NpgsqlParameter("@vsexo", emple.sexo));
                comando.Parameters.Add(new NpgsqlParameter("@vcargo", emple.cargo));
                comando.Parameters.Add(new NpgsqlParameter("@vfecha_inicio", emple.f_inicio));
                comando.Parameters.Add(new NpgsqlParameter("@vsalario", emple.salario));
                comando.Parameters.Add(new NpgsqlParameter("@vcod_departamento", emple.cod_departamento));
                comando.Parameters.Add(new NpgsqlParameter("@vcod_empleado", emple.cod_empleado));
                NpgsqlDataReader lector = comando.ExecuteReader();

                cone.desconectar();
                mensaje = "SE HA ACTUALIZADO CORRECTAMENTE EMPLEADO";
            }
            catch (Exception e)
            {
                mensaje = "NO SE HA PODIDO ACTUALIZAR EMPLEADO" + e;
            }
            return mensaje;
            
        }

        /// <summary>
        /// DeleteEmpleados
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public String deleteEmpleado(int valor)
        {
            string mensaje = "";
            string sql = "delete from empleados where cod_empleado="+valor;
            try
            {
                cone.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, cone.cone);
                NpgsqlDataReader lector = comando.ExecuteReader();

                cone.desconectar();
                mensaje = "SE HA ELIMINADO CORRECTAMENTE EMPLEADO";
            }
            catch(Exception e)
            {
                mensaje = "NO SE HA PODIDO ELIMINAR EMPLEADO "+e;
            }
            return mensaje;
        }

        public DataTable getEmpleadoCod(string valor)
        {
            DataTable tabla = new DataTable();
           
            return tabla;
        }


        public CEmpleados getEmpleados(string valor)
        {
            CEmpleados em= new CEmpleados();
            string sql = "select * from empleados where cod_empleado="+valor;
            try
            {
                cone.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, cone.cone);
                NpgsqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        em.cod_empleado =Int32.Parse(reader["cod_empleado"].ToString());
                        em.nombre = reader["nombres"].ToString();
                        em.apellido = reader["apellidos"].ToString();
                        em.documento = reader["documento"].ToString();
                        em.direccion = reader["direccion"].ToString();
                        em.f_nacimiento= DateTime.Parse(reader["fecha_nacimiento"].ToString());
                        em.sexo = reader["sexo"].ToString();
                        em.cargo = reader["cargo"].ToString();
                        em.f_inicio = DateTime.Parse(reader["fecha_inicio"].ToString());
                        em.salario =Int32.Parse(reader["salario"].ToString());
                        em.cod_departamento = Int32.Parse(reader["cod_departamento"].ToString());
                    }

                }
                comando.Dispose();
                cone.desconectar();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("ERROR AL EXTRAER DATOS " + e);
            }

            return em;
        }

        public DataTable getEmpleadosTable(int valor)
        {
            DataTable tabla = new DataTable();
            string sql = "select * from empleados where cod_empleados="+valor;
            try
            {
                cone.conectar();
                NpgsqlCommand comando = new NpgsqlCommand(sql, cone.cone);
                NpgsqlDataAdapter reader = new NpgsqlDataAdapter(comando);
                reader.Fill(tabla);
                comando.Dispose();
                cone.desconectar();

            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("ERROR AL EXTRAER LOS DATOS " + e);
            }

            return tabla;
        }

    }
}
