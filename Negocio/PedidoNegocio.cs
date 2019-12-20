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


        public void AgregarPedido(Pedido pedidoNuevo)
        {
            AccesoDatos accesoDatos = null;

            try
            {
                accesoDatos = new AccesoDatos();
                string consulta = @" declare @Id table (ID int)
                                        INSERT INTO PEDIDO 
                                        (IdCliente,
                                         Fecha,
                                         FechaEntrega,
                                         Estado)
                                         output Inserted.IdPedido into @Id
                                         VALUES(@IdCliente,
                                         getdate(),
                                         @FechaEntrega,
                                         1)";
                accesoDatos.InitComando();
                accesoDatos.Comando.Parameters.Clear();
                if (pedidoNuevo.detallePedido != null && pedidoNuevo.detallePedido.Count > 0)
                {
                    for (int i = 0; i < pedidoNuevo.detallePedido.Count; i++)
                    {

                        DetallePedido detallePedidoAux = pedidoNuevo.detallePedido[i];
                        consulta += string.Format(@" insert into DETALLE_PEDIDO
                                     (IDPEDIDO, IDPRODUCTO, CANTIDAD, PRECIO)
                                     values((select ID from @Id), @IdProducto{0}, @Cantidad{0}, @Precio{0})", i);
                        accesoDatos.Comando.Parameters.AddWithValue("@IdProducto"+ i, detallePedidoAux.producto.IdProducto);
                        accesoDatos.Comando.Parameters.AddWithValue("@Cantidad"+ i, detallePedidoAux.Cantidad);
                        accesoDatos.Comando.Parameters.AddWithValue("@Precio"+ i, detallePedidoAux.producto.Precio);
                    }
                }
                accesoDatos.ComandoQuery(consulta);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCliente", pedidoNuevo.cliente.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaEntrega", pedidoNuevo.FechaEntrega);

                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (accesoDatos != null)
                    accesoDatos.cerrarConexion();
            }




        }

       
    }
}
