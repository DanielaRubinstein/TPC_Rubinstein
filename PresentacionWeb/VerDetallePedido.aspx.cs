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
    public partial class VerDetallePedido : System.Web.UI.Page
    {
        public DetallePedido detallePedido = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DetallePedido detallePedido = new DetallePedido();
            DetallePedidoNegocio detallePedidoNegocio = new DetallePedidoNegocio();
            detallePedido = detallePedidoNegocio.obtenerDetalle(int.Parse(Request.QueryString["IdPedido"]));



        }
    }
}