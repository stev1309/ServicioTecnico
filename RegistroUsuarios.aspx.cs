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
    public partial class RegistroUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClientes();
                CargarTecnicos();
            }
        }

        private void CargarTecnicos()
        {
            var cargarTecnicos = LogicaTecnicos.listarTecnicos();
            ddlTecnico.Items.Insert(0, new ListItem("Seleccione...", "0"));

            foreach (var item in cargarTecnicos)
            {
                ListItem i = new ListItem(item.TEC_NOMBRE, item.TEC_ID.ToString());
                ddlTecnico.Items.Add(i);
            }
        }

        public void cargarClientes()
        {
            var clientes = LogicaClientes.listarClientes();

            GridView1.DataSource = clientes;
            GridView1.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtNombres.Text != "" && txtApellidos.Text != "" && txtRucCedula.Text != "" && txtTelefono.Text != "" && txtEmail.Text != "" && txtDireccion.Text != "" && ddlTecnico.SelectedIndex != 0 && hfIdCliente.Value == "")
            {
                string nombres = txtNombres.Text;
                string apellidos = txtApellidos.Text;
                string rucCedula = txtRucCedula.Text;
                string telefono = txtTelefono.Text;
                string email = txtEmail.Text;
                string direccion = txtDireccion.Text;
                try
                {
                    TBL_CLIENTE cliente = new TBL_CLIENTE();
                    cliente.TEC_ID = Int32.Parse(ddlTecnico.SelectedValue);
                    cliente.CLI_NOMBRES = nombres;
                    cliente.CLI_APELLIDOS = apellidos;
                    cliente.CLI_RUC_CEDULA = rucCedula;
                    cliente.CLI_TELEFONO = telefono;
                    cliente.CLI_EMAIL = email;
                    cliente.CLI_DIRECCION = direccion;

                    LogicaClientes.guardarCliente(cliente);
                    QuitarFondoModal();
                    MostrarToast("Registro Exitoso", "Se guardó exitosamente el nuevo cliente", "Success");
                    Limpiar();
                    cargarClientes();
                }
                catch (Exception ex)
                {
                    MostrarToast("Error Al guardar", "Error: " + ex.Message, "Error");
                }
            }
            else if (txtNombres.Text != "" && txtApellidos.Text != "" && txtRucCedula.Text != "" && txtTelefono.Text != "" && txtEmail.Text != "" && txtDireccion.Text != "" && ddlTecnico.SelectedIndex != 0 && hfIdCliente.Value != "")
            {
                int idCliente = Int32.Parse(hfIdCliente.Value);
                string nombres = txtNombres.Text;
                string apellidos = txtApellidos.Text;
                string rucCedula = txtRucCedula.Text;
                string telefono = txtTelefono.Text;
                string email = txtEmail.Text;
                string direccion = txtDireccion.Text;
                try
                {
                    TBL_CLIENTE cliente = LogicaClientes.ClienteXID(idCliente);

                    cliente.TEC_ID = Int32.Parse(ddlTecnico.SelectedValue);
                    cliente.CLI_NOMBRES = nombres;
                    cliente.CLI_APELLIDOS = apellidos;
                    cliente.CLI_RUC_CEDULA = rucCedula;
                    cliente.CLI_TELEFONO = telefono;
                    cliente.CLI_EMAIL = email;
                    cliente.CLI_DIRECCION = direccion;

                    LogicaClientes.ModificarCliente(cliente);
                    QuitarFondoModal();
                    MostrarToast("Modificado Exitoso", "Se modificó exitosamente el nuevo cliente", "Success");
                    Limpiar();
                    cargarClientes();
                }
                catch (Exception ex)
                {
                    MostrarToast("Error Al guardar", "Error: " + ex.Message, "Error");
                }
            }
            else
            {
                MostrarToast("Campos Vacíos", "No deje los campos vacíos", "Error");
            }
        }

        private void Limpiar()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtRucCedula.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            hfIdCliente.Value = "";
            btnSubmit.Text = "Añadir Cliente";
        }

        private void MostrarToast(string titulo, string mensaje, string tipo, int duracion = 3000) => ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mostrarToast", "mostrarToast('" + titulo + "', '" + mensaje + "', '" + tipo + "', " + duracion + ");", true);

        protected void lnkEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = Convert.ToInt32((sender as LinkButton).CommandArgument);

                TBL_CLIENTE cliente = LogicaClientes.ClienteXID(idCliente);
                string nombreCliente = cliente.CLI_NOMBRES + " " + cliente.CLI_APELLIDOS;

                LogicaClientes.EliminarCliente(cliente);

                MostrarToast("Eliminado exitoso", "Se elimino correctamente el cliente " + nombreCliente, "Success");
                cargarClientes();
            }
            catch (Exception ex)
            {
                MostrarToast("Error", ex.Message, "Error", 10000);
            }
        }

        protected void lnkModificarCliente_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32((sender as LinkButton).CommandArgument);

            TBL_CLIENTE cliente = LogicaClientes.ClienteXID(idCliente);

            txtNombres.Text = cliente.CLI_NOMBRES;
            txtApellidos.Text = cliente.CLI_APELLIDOS;
            txtTelefono.Text = cliente.CLI_TELEFONO;
            txtDireccion.Text = cliente.CLI_DIRECCION;
            txtRucCedula.Text = cliente.CLI_RUC_CEDULA;
            txtEmail.Text = cliente.CLI_EMAIL;

            ddlTecnico.SelectedValue = cliente.TEC_ID.ToString();

            hfIdCliente.Value = cliente.CLI_ID.ToString();
            btnSubmit.Text = "Modificar Cliente";
            MostrarModal();
        }

        protected void lnkCerrarModal_Click(object sender, EventArgs e)
        {
            Limpiar();
            QuitarFondoModal();
        }

        public void QuitarFondoModal()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "quitarModal", "quitarModal(); ", true);
        }
        public void MostrarModal()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "quitarModal", "mostrarModal(); ", true);
        }
    }
}