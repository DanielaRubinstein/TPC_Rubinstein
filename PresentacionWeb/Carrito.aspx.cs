using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<int> carrito = (List<int>)Session["carrito"];
            if (carrito == null)
            {
                carrito = new List<int>();
            }

            int idProducto = int.Parse(Request.QueryString["IdProducto"]);
            if (idProducto > 0)
            {
                carrito.Add(idProducto);
                Session["carrito"] = carrito;
            }
            //cantidad.Text = carrito.Count.ToString();


        }
    }
}