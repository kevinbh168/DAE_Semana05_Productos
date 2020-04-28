using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DProducto
    {
        public List<Producto> Listar(int id)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Producto> productos = null;

            try
            {
                comandText = "USP_GetProductos";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = id;
                productos = new List<Producto>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, comandText,
                    CommandType.StoredProcedure,parameters))
                {

                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            NombreProducto = reader["NombreProducto"] != null ? Convert.ToString(reader["NombreProducto"]) : string.Empty,
                            PrecioUnidad = reader["PrecioUnidad"] != null ? Convert.ToInt32(reader["PrecioUnidad"]) : 0,
                            UnidadesEnExistencia = reader["UnidadesEnExistencia"] != null ? Convert.ToInt32(reader["UnidadesEnExistencia"]) : 0
                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return productos;
        }


        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            try
            {
                commandText = "USP_InsProducto";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@nombreproducto", SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;
                parameters[1] = new SqlParameter("@precio", SqlDbType.Int);
                parameters[1].Value =producto.PrecioUnidad;
                parameters[2] = new SqlParameter("@unidades", SqlDbType.Int);
                parameters[2].Value = producto.UnidadesEnExistencia;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Actualizar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            try
            {
                commandText = "USP_UpdProducto";
                parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                parameters[1] = new SqlParameter("@nombreproducto", SqlDbType.VarChar);
                parameters[1].Value = producto.NombreProducto;
                parameters[2] = new SqlParameter("@precio", SqlDbType.Int);
                parameters[2].Value = producto.PrecioUnidad;
                parameters[3] = new SqlParameter("@unidades", SqlDbType.Int);
                parameters[3].Value = producto.UnidadesEnExistencia;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = null;
            string commandtext = string.Empty;
            try
            {
                commandtext = "USP_DelProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, commandtext, CommandType.StoredProcedure, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
