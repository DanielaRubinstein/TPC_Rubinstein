using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace PresentacionWeb
{
    public partial class SiteMaster : MasterPage
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

        }

        public void Desloguear(object sender, EventArgs e)
        {
            Session[ConstantesSession.USUARIO_LOGUEADO] = null;
            

        }
    }
}