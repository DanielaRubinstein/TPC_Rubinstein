using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace PresentacionWeb
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Producto> listaProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                ProductoNegocio productoNegocio = new ProductoNegocio();
                listaProducto = productoNegocio.listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}