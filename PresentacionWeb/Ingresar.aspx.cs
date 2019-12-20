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
    public partial class Ingresar : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnIngresar_Click(object sender, EventArgs e)
        {
            IUser usuario = new Cliente();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            try
            {
                usuario.Mail = txtMail.Text.Trim();
                usuario.Pass = txtPass.Text.Trim();
                usuario = clienteNegocio.validarUsuario(usuario);

                if (usuario != null)
                {
                    lblError.Visible = false;
                    Session[ConstantesSession.USUARIO_LOGUEADO]=usuario;

                    if (usuario is Administrador)
                    { Response.Redirect("~/ListadoProductos");}
                    else { Response.Redirect("~/Chocolate"); }
                    
                }
                else
                {
                    Session[ConstantesSession.USUARIO_LOGUEADO] = null;
                    lblError.Visible = true;
                    //TO DO: bloqueo de usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}