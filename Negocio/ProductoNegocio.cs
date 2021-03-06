﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar(bool filtroEstado=true)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos accesoDatos = new AccesoDatos();
            Producto producto;

            try
            {
                string consulta = "Select P.IdProducto, P.Descripcion,C.Categoria,StockActual,Precio,Impuesto,Costo,Estado,Imagen from producto as P left join CATEGORIAS_X_PRODUCTO as CxP on P.IdProducto = CxP.IDPRODUCTO left join CATEGORIA as c on CxP.IDCATEGORIA = C.IDCATEGORIA ";
                if (filtroEstado == true)
                {
                    consulta += "where Estado = 1";
                }
                accesoDatos.SetearConsulta(consulta);
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    Producto productoAux = lista.Find(x => x.IdProducto == (int)accesoDatos.Lector["IdProducto"]);

                    if (productoAux==null) {
                        producto = new Producto();
                        producto.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                        producto.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
                        producto.categorias = new List<Categoria>();
                        producto.categorias.Add(new Categoria() { Descripcion = accesoDatos.Lector["Categoria"].ToString() });
                        producto.StockActual = (int)accesoDatos.Lector["StockActual"];
                        producto.Precio = Math.Round((decimal)accesoDatos.Lector["Precio"],2);
                        producto.Impuesto = (decimal)accesoDatos.Lector["Impuesto"];
                        producto.Costo = (decimal)accesoDatos.Lector["Costo"];
                        producto.Estado = (bool)accesoDatos.Lector["Estado"];
                        producto.Imagen = accesoDatos.Lector["Imagen"].ToString();
                        lista.Add(producto);
                    }
                    else
                    {
                        productoAux.categorias.Add(new Categoria() { Descripcion = accesoDatos.Lector["Categoria"].ToString() });
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

        public List<Producto> listarCategorias(string cat)
        {
            return this.listar().FindAll(x => x.categorias.Exists(y => y.Descripcion.Contains(cat)));
            
        }

        public void modificarProducto(Producto productoModificado)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.InitComando();
                accesoDatos.Comando.Parameters.Clear();

                string consulta =@"
                                update PRODUCTO set 
                                Descripcion=@Descripcion,
                                StockActual=@StockActual,
                                Precio=@Precio,
                                Impuesto=@Impuesto,
                                Costo=@Costo,
                                Estado=@Estado,
                                Imagen=@Imagen 
                                where IdProducto=" + productoModificado.IdProducto;

                   consulta +=@" Delete from CATEGORIAS_X_PRODUCTO
                           where Idproducto="+ productoModificado.IdProducto;

                accesoDatos.InitComando();
                accesoDatos.Comando.Parameters.Clear();

                if (productoModificado.categorias != null && productoModificado.categorias.Count > 0)
                {

                    for (int i = 0; i < productoModificado.categorias.Count; i++)
                    {
                        consulta += @" insert into CATEGORIAS_X_PRODUCTO
                                (IDPRODUCTO, IDCATEGORIA)
                                values(" + productoModificado.IdProducto + ", @IdCategoria" + i + ")";
                        accesoDatos.Comando.Parameters.AddWithValue("@IdCategoria" + i, productoModificado.categorias[i].IdCategoria);    
                    }
                    
                }
                 accesoDatos.ComandoQuery(consulta);
                //accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", productoModificado.Descripcion);
                //accesoDatos.Comando.Parameters.AddWithValue("@Categoria", productoModificado.categorias);
                accesoDatos.Comando.Parameters.AddWithValue("@StockActual", productoModificado.StockActual);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", productoModificado.Precio);
                accesoDatos.Comando.Parameters.AddWithValue("@Impuesto", productoModificado.Impuesto);
                accesoDatos.Comando.Parameters.AddWithValue("@Costo", productoModificado.Costo);
                //accesoDatos.Comando.Parameters.AddWithValue("@IdProveedor", productoModificado.Proveedor.IdEmpresa); //combobox
                accesoDatos.Comando.Parameters.AddWithValue("@Estado", productoModificado.Estado);
                accesoDatos.Comando.Parameters.AddWithValue("@Imagen", productoModificado.Imagen);
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

        public void eliminarProducto(Producto productoModificado)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.SetearConsulta("update PRODUCTO set Estado=@Estado where IdProducto=" + productoModificado.IdProducto);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Estado", productoModificado.Estado);
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarAccion();
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

        public void agregarProducto(Producto productoNuevo)
        {
            AccesoDatos accesoDatos = null;

            try
            {
                accesoDatos = new AccesoDatos();
                string consulta = @" declare @Id table (ID int)
                                        INSERT INTO producto 
                                        (descripcion,
                                         stockactual,
                                         precio,
                                         impuesto,
                                         costo,
                                         estado,
                                         imagen)
                                         output Inserted.IdProducto into @Id
                                         VALUES(@Descripcion,
                                         @StockActual,
                                         @Precio,
                                         @Impuesto,
                                         @Costo,
                                         @Estado,
                                         @Imagen)
                                        ";
                accesoDatos.InitComando();
                accesoDatos.Comando.Parameters.Clear();
                if (productoNuevo.categorias!=null && productoNuevo.categorias.Count > 0)
                {
                    for (int i = 0; i < productoNuevo.categorias.Count; i++)
                    {
                        consulta += @" insert into CATEGORIAS_X_PRODUCTO
                                     (IDPRODUCTO, IDCATEGORIA)
                                     values((select ID from @Id), @IdCategoria" + i + ")";
                        accesoDatos.Comando.Parameters.AddWithValue("@IdCategoria" + i, productoNuevo.categorias[i].IdCategoria);
                    }    
                }
                accesoDatos.ComandoQuery(consulta);
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", productoNuevo.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@StockActual", productoNuevo.StockActual);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", productoNuevo.Precio);
                accesoDatos.Comando.Parameters.AddWithValue("@Impuesto", productoNuevo.Impuesto);
                accesoDatos.Comando.Parameters.AddWithValue("@Costo", productoNuevo.Costo);
                accesoDatos.Comando.Parameters.AddWithValue("@Estado", productoNuevo.Estado);
                accesoDatos.Comando.Parameters.AddWithValue("@Imagen", productoNuevo.Imagen);

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

        public Producto obtenerProducto(int IdProducto)
        {
            Producto producto = null;
            AccesoDatos accesoDatos = new AccesoDatos();
            //Producto producto;

            try
            {
                accesoDatos.SetearConsulta("Select P.IdProducto, P.Descripcion,C.Categoria,StockActual,Precio,Impuesto,Costo,Estado,Imagen from producto as P left join CATEGORIAS_X_PRODUCTO as CxP on P.IdProducto = CxP.IDPRODUCTO left join CATEGORIA as c on CxP.IDCATEGORIA = C.IDCATEGORIA where P.IdProducto=" + IdProducto);
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    //Producto productoAux = productoSeleccionado.Find(x => x.IdProducto == (int)accesoDatos.Lector["IdProducto"]);

                    if (producto == null)
                    {
                        producto = new Producto();
                        producto.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                        producto.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
                        producto.categorias = new List<Categoria>();
                        producto.categorias.Add(new Categoria() { Descripcion = accesoDatos.Lector["Categoria"].ToString() });
                        producto.StockActual = (int)accesoDatos.Lector["StockActual"];
                        producto.Precio = Math.Round((decimal)accesoDatos.Lector["Precio"],2);
                        producto.Impuesto = (decimal)accesoDatos.Lector["Impuesto"];
                        producto.Costo = (decimal)accesoDatos.Lector["Costo"];
                        producto.Estado = (bool)accesoDatos.Lector["Estado"];
                        producto.Imagen = accesoDatos.Lector["Imagen"].ToString();
                        //productoSeleccionado.Add(producto);
                    }
                    else
                    {
                        producto.categorias.Add(new Categoria() { Descripcion = accesoDatos.Lector["Categoria"].ToString() });
                    }
                }
                return producto;
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
