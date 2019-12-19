﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DetallePedidoNegocio
    {
        public List<DetallePedido> listar()
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            AccesoDatos accesoDatos = new AccesoDatos();
            DetallePedido detallePedido;

            try
            {
                accesoDatos.SetearConsulta(@"select Prod.Descripcion, DP.Cantidad,DP.Precio
                                            from PEDIDO as P
                                            inner join DETALLE_PEDIDO as DP on P.IdPedido=DP.IdPedido
                                            inner join Producto as Prod on DP.IdProducto=Prod.IdProducto
                                            where p.Estado=1");
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    DetallePedido detallePedidoAux = lista.Find(x => x.IdDetalle == (int)accesoDatos.Lector["IdDetalle"]);

                    if (detallePedidoAux == null)
                    {
                        detallePedido = new DetallePedido();
                        detallePedido.IdDetalle = (int)accesoDatos.Lector["IdDetalle"];
                        detallePedido.producto = new Producto();
                        detallePedido.producto.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
                        detallePedido.Cantidad = (int)accesoDatos.Lector["Cantidad"];
                        detallePedido.Precio = (decimal)accesoDatos.Lector["Precio"];
                        //producto.StockActual = (int)accesoDatos.Lector["StockActual"];
                        //producto.Precio = Math.Round((decimal)accesoDatos.Lector["Precio"], 2);

                        lista.Add(detallePedido);
                    }
                    else
                    {
                        //detallePedidoAux.producto.Add(new Producto() { Descripcion = accesoDatos.Lector["Descripcion"].ToString()});
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

        public DetallePedido obtenerDetalle(int IdPedido)
        {
            DetallePedido detallePedido = null;
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.SetearConsulta(@"select Prod.Descripcion, DP.Cantidad,DP.Precio
                                            from PEDIDO as P
                                            inner join DETALLE_PEDIDO as DP on P.IdPedido = DP.IdPedido
                                            inner join Producto as Prod on DP.IdProducto = Prod.IdProducto where DP.IdPedido=" + IdPedido);
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    if (detallePedido == null)
                    {
                        detallePedido = new DetallePedido();
                        detallePedido.producto = new Producto();
                        detallePedido.producto.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
                        detallePedido.Cantidad = (int)accesoDatos.Lector["Cantidad"];
                        detallePedido.Precio = (decimal)accesoDatos.Lector["Precio"];
                    }
                    else
                    {
                        //producto.categorias.Add(new Categoria() { Descripcion = accesoDatos.Lector["Categoria"].ToString() });
                    }
                }
                return detallePedido;
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
