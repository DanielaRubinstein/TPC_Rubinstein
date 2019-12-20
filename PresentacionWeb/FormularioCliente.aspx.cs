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
    public partial class FormularioCliente : System.Web.UI.Page
    {
        private Cliente cliente = null;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                cliente = new Cliente();
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Localidad = txtLocalidad.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Mail = txtMail.Text;
                cliente.Pass = txtPassword.Text;
                cliente.Estado = true;

                clienteNegocio.agregarCliente(cliente);

                //if (cliente != null)
                //{
                //    lblCreado.Visible = true;
                //    lblError.Visible = false;
                //}
                //else

                //{
                //    lblCreado.Visible = false;
                //    lblError.Visible = true;
                //}

            }
            catch (Exception)
            {

                throw;
            } 
        }


    }
}