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
    public partial class ListadoProductos : System.Web.UI.Page
    {
        public List<Producto> listaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                listaProductos = productoNegocio.listar(false);

                //if (!IsPostBack)
                //{
                //    //esto es lo que necesitamos para el repeater.
                //    repetidor.DataSource = listaProductos;
                //    repetidor.DataBind();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //var argument = ((Button)sender).CommandArgument;

        }

        protected void DespublicarProducto(object sender, EventArgs e)
        {


        }
    }
}