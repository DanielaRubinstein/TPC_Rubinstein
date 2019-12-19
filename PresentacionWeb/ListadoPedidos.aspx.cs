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
    public partial class ListadoPedidos : System.Web.UI.Page
    {
        public List<Pedido> listaPedidos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                listaPedidos = pedidoNegocio.listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}