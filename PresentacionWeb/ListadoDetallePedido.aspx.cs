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
    public partial class ListadoDetallePedido : System.Web.UI.Page
    {
        public List<DetallePedido> listaDetallePedido { get; set; }
        private DetallePedido detallePedido = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //List<DetallePedido> listaDetallePedido = new List<DetallePedido>();
                DetallePedidoNegocio detallePedidoNegocio = new DetallePedidoNegocio();
                listaDetallePedido = detallePedidoNegocio.obtenerDetalle(int.Parse(Request.QueryString["IdPedido"]));

                
                //listaDetallePedido = detallePedidoNegocio.listar();
            }


            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}