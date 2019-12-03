using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Dominio;
using Negocio;

namespace PresentacionWeb
{
    public partial class Chocolate : System.Web.UI.Page
    {
        public List<Producto> listaProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Producto> productoFiltradoCat;
            try
            {
                
                ProductoNegocio productoNegocio = new ProductoNegocio();
                listaProducto = productoNegocio.listarCategorias("Chocolate");

                //listaProducto = productoNegocio.listar().FindAll(x =>
                //        x.categorias.Exists(y => y.Descripcion.Contains("Chocolate"));
                //productoFiltradoCat = listaProducto.FindAll(k => k.categoria.Descripcion.Contains("Chocolate"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //PARA AJAX
        //[WebMethod]
        //public static List<Producto> listaProducto()
        //{
        //    ProductoNegocio negocio = new ProductoNegocio();
        //    return negocio.listar();
        //}

    }
}