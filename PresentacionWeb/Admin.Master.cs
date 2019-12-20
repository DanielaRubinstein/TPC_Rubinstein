using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace PresentacionWeb
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ConstantesSession.USUARIO_LOGUEADO] == null)
            {
                linkIngresar.Visible = true;
                linkDesloguear.Visible = false;
            }
            else
            {
                linkDesloguear.Visible = true;
                linkIngresar.Visible = false;
            }

            if (Session[ConstantesSession.USUARIO_LOGUEADO] == null || Session[ConstantesSession.USUARIO_LOGUEADO] is Cliente)
            {
                Response.Redirect("~/Chocolate");
            }

        }
    }
}