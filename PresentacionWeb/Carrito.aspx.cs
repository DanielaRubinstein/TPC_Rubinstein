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
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Producto> listaComprada { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
             listaComprada = (List<Producto>)Session["carrito"];
            if (listaComprada == null)
            {
                listaComprada = new List<Producto>();
            }

            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            producto = productoNegocio.obtenerProducto(int.Parse(Request.QueryString["IdProducto"]));

            //producto.Imagen = Request.QueryString["Imagen"].ToString();
            //producto.Descripcion = Request.QueryString["Descripcion"].ToString();
            //producto.Precio = decimal.Parse(Request.QueryString["Precio"]);

            if (producto.IdProducto > 0)
            {
                listaComprada.Add(producto);
                Session["carrito"] = listaComprada;
            }
            //cantidad.Text = carrito.Count.ToString();
        }
    }
}