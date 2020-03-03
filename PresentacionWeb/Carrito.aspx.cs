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
using System.Globalization;

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

            if (!IsPostBack)
            { 
                repetidor.DataSource = listaComprada;
                repetidor.DataBind();
            }
        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            Pedido pedido = new Pedido();
            List<Producto> listaProducto = (List<Producto>)Session[ConstantesSession.CARRITO];


            if (listaProducto != null && listaProducto.Count > 0 && !String.IsNullOrEmpty(txtFecha.Text) && !String.IsNullOrEmpty(txtHora.Text))
            {
                try
                {
                    pedido.cliente = (Cliente)Session[ConstantesSession.USUARIO_LOGUEADO];
                    pedido.Fecha = DateTime.Now;
                    TimeSpan horaEntrega = DateTime.ParseExact(txtHora.Text, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay;
                    pedido.FechaEntrega = DateTime.Parse(txtFecha.Text).Add(horaEntrega);
                    pedido.detallePedido = new List<DetallePedido>();

                    foreach (var item in listaProducto)
                    {
                        DetallePedido detallePedido = new DetallePedido();
                        detallePedido.producto = item;
                        detallePedido.Cantidad = 1;
                        pedido.detallePedido.Add(detallePedido);
                    }

                    pedido.Estado = true;
                    pedidoNegocio.AgregarPedido(pedido);

                    Session[ConstantesSession.CARRITO] = null;

                    Response.Redirect("~/PedidoConfirmado");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //Mensaje de pedido enviado
        }

        public void eliminarProducto(object sender, EventArgs e)
        {
            Producto producto = new Producto();


        }

        protected void btnArgumento_Click(object sender, EventArgs e)
        {
            int argument = Int32.Parse(((LinkButton)sender).CommandArgument);
            Pedido pedido = new Pedido();
            List<Producto> listaProducto = (List<Producto>)Session[ConstantesSession.CARRITO];
            try
            {
                Session[ConstantesSession.CARRITO] = listaProducto.Where(x => x.IdProducto != argument).ToList();
                Response.Redirect("~/Carrito");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}