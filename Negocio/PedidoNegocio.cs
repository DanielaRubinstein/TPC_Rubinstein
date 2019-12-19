using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PedidoNegocio
    {
        public List<Pedido> listar()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos accesoDatos = new AccesoDatos();
            Pedido pedido;

            try
            {
                accesoDatos.SetearConsulta(@"select P.IdPedido,P.Fecha,P.FechaEntrega,P.Estado,
                                            C.IdCliente,C.Nombre,C.Apellido,C.Direccion,C.Localidad,C.Telefono,C.Mail,
                                            DP.IdDetalle, DP.Cantidad, DP.Precio,
                                            Prod.Descripcion
                                            from PEDIDO as P
                                            inner join Cliente as C on P.IdCliente=C.IdCliente
                                            inner join DETALLE_PEDIDO as DP on P.IdPedido=DP.IdPedido
                                            inner join Producto as Prod on DP.IdProducto=Prod.IdProducto
                                            where p.Estado=1");
                //Chequear si agregar el group by
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    Pedido pedidoAux = lista.Find(x => x.IdPedido == (int)accesoDatos.Lector["IdPedido"]);

                    if (pedidoAux == null)
                    {
                        pedido = new Pedido();
                        pedido.IdPedido = (int)accesoDatos.Lector["IdPedido"];
                        pedido.Fecha = (DateTime)accesoDatos.Lector["Fecha"];
                        pedido.FechaEntrega = (DateTime)accesoDatos.Lector["FechaEntrega"];
                        pedido.Estado = (bool)accesoDatos.Lector["Estado"];
                        pedido.cliente = new Cliente();
                        pedido.cliente.Nombre = accesoDatos.Lector["Nombre"].ToString();
                        pedido.cliente.Direccion = accesoDatos.Lector["Direccion"].ToString();

                        pedido.detallePedido = new List<DetallePedido>();
                        pedido.detallePedido.Add(new DetallePedido() { IdDetalle = (int)accesoDatos.Lector["IdDetalle"] });
                        
                        //producto.StockActual = (int)accesoDatos.Lector["StockActual"];
                        //producto.Precio = Math.Round((decimal)accesoDatos.Lector["Precio"], 2);

                        lista.Add(pedido);
                    }
                    else
                    {
                        pedidoAux.detallePedido.Add(new DetallePedido() { IdDetalle = (int)accesoDatos.Lector["IdDetalle"] });
                    }
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



       
    }
}
