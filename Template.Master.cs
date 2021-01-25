using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioTecnico
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkServicioTecnico_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoServicioTecnico.aspx");
        }

        protected void lnkClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroUsuarios.aspx");
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx");
        }

        protected void lnkReparaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reparaciones.aspx");
        }

        protected void lnkTecnicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tecnicos.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}