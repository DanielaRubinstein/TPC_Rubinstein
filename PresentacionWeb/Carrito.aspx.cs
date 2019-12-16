using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public decimal total { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ConstantesSession.USUARIO_LOGUEADO] == null)
            {
                Response.Redirect("~/Ingresar");
               
            }

            listaComprada = (List<Producto>)Session[ConstantesSession.CARRITO];
            if (listaComprada == null)
            {
                listaComprada = new List<Producto>();
            }
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            string productoRequest = Request.QueryString["IdProducto"];

            if (String.IsNullOrEmpty(productoRequest) == false)
            {
                producto = productoNegocio.obtenerProducto(int.Parse(productoRequest));
                //LIMPIAR EL REQUEST (o guardar ID en sesion del querystring y al cargar comparar los ids)

                //producto.Imagen = Request.QueryString["Imagen"].ToString();
                //producto.Descripcion = Request.QueryString["Descripcion"].ToString();
                //producto.Precio = decimal.Parse(Request.QueryString["Precio"]);

                if (producto.IdProducto > 0)
                {
                    listaComprada.Add(producto);
                    Session[ConstantesSession.CARRITO] = listaComprada;
                    Response.Redirect("~/Carrito");
                }
            }
            //suma de todos los precios
            total = listaComprada.Sum(x => x.Precio);
            //cantidad.Text = carrito.Count.ToString();
        }

        public void btnAceptar_Click()
        {

        }
    }
}