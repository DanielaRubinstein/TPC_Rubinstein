using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos accesoDatos = new AccesoDatos();
            Producto producto;

            try
            {
                accesoDatos.SetearConsulta("Select P.IdProducto, P.Descripcion,C.Categoria,StockActual,Precio,Impuesto,Costo,Estado,Imagen from producto as P inner join CATEGORIAS_X_PRODUCTO as CxP on P.IdProducto = CxP.IDPRODUCTO inner join CATEGORIA as c on CxP.IDCATEGORIA = C.IDCATEGORIA where Estado=1");
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    producto = new Producto();
                    producto.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                    producto.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
                    producto.categoria = new Categoria();
                    producto.categoria.Descripcion = accesoDatos.Lector["Categoria"].ToString();
                    producto.StockActual = (int)accesoDatos.Lector["StockActual"];
                    producto.Precio = (decimal)accesoDatos.Lector["Precio"];
                    producto.Impuesto = (decimal)accesoDatos.Lector["Impuesto"];
                    producto.Costo = (decimal)accesoDatos.Lector["Costo"];
                    producto.Estado = (bool)accesoDatos.Lector["Estado"];
                    producto.Imagen = accesoDatos.Lector["Imagen"].ToString();
                    lista.Add(producto);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        //LISTAR POR CADA CATEGORIA?

    }
}
