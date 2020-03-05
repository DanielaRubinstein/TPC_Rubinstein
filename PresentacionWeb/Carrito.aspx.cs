using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web.UI.WebControls;

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
                    EnvioMail(pedido.cliente.Mail);

                    Session[ConstantesSession.CARRITO] = null;
                    Response.Redirect("~/PedidoConfirmado");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void SendMail(string mail)
        {
            try
            {
                MailMessage Mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                Mail.From = new MailAddress("tortaslasframbuesas@gmail.com");
                //Mail.To.Add("nanurubinstein@gmail.com");
                Mail.To.Add(mail);
                Mail.Subject = "Pedido Las Frambuesas";
                Mail.Body = "Recibimos tu pedido, nos estaremos comunicando para la entrega";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tortaslasframbuesas@gmail.com", "UTNFRGP2020");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(Mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void EnvioMail(string Mail)
        {

            //ClienteNegocio clienteNegocio = new ClienteNegocio();
            //Cliente cliente = new Cliente();
            //cliente = clienteNegocio.buscarCliente();
            SendMail(Mail);
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