using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class BProducto
    {
        private DProducto dProducto = null;

        public List<Producto> Listar(int id)
        {
            List<Producto> productos = null;
            try
            {
                dProducto = new DProducto();
                productos = dProducto.Listar(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return productos;
        }

        public bool Insertar(Producto producto)
        {
            bool result = true;
            try
            {
                dProducto = new DProducto();       
                dProducto.Insertar(producto);
           
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool Actualizar(Producto producto)
        {
            bool result = true;
            try
            {
                dProducto = new DProducto();
                dProducto.Actualizar(producto);
            }
            catch (Exception )
            {
                result = false;
            }
            return result;
        }

        public bool Eliminar(int IdProducto)
        {
            bool result = true;
            try
            {
                dProducto = new DProducto();
                dProducto.Eliminar(IdProducto);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
