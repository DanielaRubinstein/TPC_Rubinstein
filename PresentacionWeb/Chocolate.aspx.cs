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

            List<Producto> filtroCategoria;
            try
            {
                
                ProductoNegocio producto = new ProductoNegocio();
                listaProducto = producto.listar();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;
            try
            {
                if (txtBusqueda.Text == "")
                {
                    listaFiltrada = lista;
                }
                else
                {
                    listaFiltrada = lista.FindAll(k => k.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower()) || k.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) || (k.Evolucion != null ? k.Evolucion.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) : k.Nombre.Contains("")));
                }
                dgvListadoPokemones.DataSource = listaFiltrada;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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