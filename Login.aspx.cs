using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaLogica;

namespace ServicioTecnico
{
    public partial class Login : System.Web.UI.Page
    {
        string intentos = "";
        int contador = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["count"] = Session["countOld"];
            if (!IsPostBack)
            {
                Session["nombre_Usuario"] = null;
                Session["estado_Usuario"] = null;
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e) => ingresar();

        private void ingresar()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                mostrarToast("Advertencia", "No deje vácio el nombre de usuario", "Warning");
                return;
            }
            if (string.IsNullOrEmpty(txtContrasenia.Text))
            {
                mostrarToast("Advertencia", "No deje vácio el campo de contraseña", "Warning");
                return;
            }

            bool existeNombre = LogicaUsuarios.autenticarNombreUsuario(txtUsuario.Text);
            bool existeUsuario = LogicaUsuarios.autenticar(txtUsuario.Text, txtContrasenia.Text);

            if (existeNombre)
            {
                if (existeUsuario)
                {
                    TBL_USUARIO usuarioExistente = LogicaUsuarios.autenticarXLogin(txtUsuario.Text, txtContrasenia.Text);
                    Session["nombre_Usuario"] = usuarioExistente.USU_NOMBRE + " " + usuarioExistente.USU_APELLIDO;
                    Session["estado_Usuario"] = usuarioExistente.USU_ESTADO;

                    mostrarToast("Correcto", "Nombre: " + Session["nombre_Usuario"], "Success");
                    Response.Redirect("Principal.aspx");
                }
                else
                {
                    intentos = (contador + (Convert.ToInt32(Session["count"]))).ToString();
                    Session["countOld"] = intentos.ToString();

                    if (Convert.ToInt32(intentos) >= 3)
                    {
                        try
                        {
                            //LogicaUsuarios.bloquearUsu(usuarioExistente);
                            mostrarToast("Máximo de intentos", "Su usuario ha sido bloqueado por máximo de intentos permitidos (3). Consulte con el administrador.", "Error", 4000);
                            Session.Clear();
                            btnLogin.Visible = false;
                            Limpiar();
                        }
                        catch (Exception ex)
                        {
                            mostrarToast("Error", "Error al bloquear usuario: " + ex.Message, "Error", 6000);
                        }
                    }
                    else
                    {
                        mostrarToast("Usuario o contraseña incorrectos", "Intentos restantes: " + intentos, "Warning", 2000);
                    }
                }
            }
            else
            {
                mostrarToast("Datos incorrectos", "Su usuario y contraseña no son correctos", "Warning", 2000);
                Limpiar();
            }
        }

        private void Limpiar()
        {
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
        }

        private void mostrarToast(string titulo, string mensaje, string tipo, int duracion = 3000) => ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mostrarToast", "mostrarToast('" + titulo + "', '" + mensaje + "', '" + tipo + "', " + duracion + ");", true);
    }
}