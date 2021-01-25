using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using CapaDatos;

namespace ServicioTecnico
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarTecnicos();
            }
        }

        public void ListarTecnicos()
        {
            var tecnicos = LogicaTecnicos.listarTecnicos();

            gvTecnicos.DataSource = tecnicos;
            gvTecnicos.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "" && txtTelefono.Text != "" && hfIdTecnico.Value == "")
            {
                TBL_TECNICO tecnico = new TBL_TECNICO();
                string nombre = txtNombres.Text;
                string telefono = txtTelefono.Text;
                try
                {
                    tecnico.TEC_NOMBRE = nombre;
                    tecnico.TEC_TELEFONO = telefono;
                    LogicaTecnicos.GuardarNuevoTecnico(tecnico);

                    QuitarFondoModal();
                    MostrarToast("Guardado exitoso", "Se guardo correctamente el nuevo tecnico", "Success");
                    Limpiar();
                    ListarTecnicos();
                }
                catch (Exception ex)
                {
                    MostrarToast("Error", ex.Message, "Error", 10000);
                }
            }
            else if (txtNombres.Text != "" && txtTelefono.Text != "" && hfIdTecnico.Value != "")
            {
                TBL_TECNICO tecnico = LogicaTecnicos.BuscarXId(Int32.Parse(hfIdTecnico.Value));
                string nombre = txtNombres.Text;
                string telefono = txtTelefono.Text;
                try
                {
                    tecnico.TEC_NOMBRE = nombre;
                    tecnico.TEC_TELEFONO = telefono;
                    LogicaTecnicos.ModificarTecnico(tecnico);

                    QuitarFondoModal();
                    MostrarToast("Actualizado exitoso", "Se actualizó correctamente el técnico " + txtNombres.Text, "Success");
                    Limpiar();
                    ListarTecnicos();
                }
                catch (Exception ex)
                {
                    MostrarToast("Error", ex.Message, "Error", 10000);
                }
            }
            else
            {
                MostrarToast("Advertencia", "No deje campos vacíos", "Warning", 10000);

            }
        }

        private void Limpiar()
        {
            txtNombres.Text = "";
            txtTelefono.Text = "";
            hfIdTecnico.Value = "";
            btnSubmit.Text = "Añadir Técnico";
        }

        public void QuitarFondoModal()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "quitarModal", "quitarModal(); ", true);
        }
        public void MostrarModal()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "quitarModal", "mostrarModal(); ", true);
        }

        private void MostrarToast(string titulo, string mensaje, string tipo, int duracion = 3000) => ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mostrarToast", "mostrarToast('" + titulo + "', '" + mensaje + "', '" + tipo + "', " + duracion + ");", true);

        protected void lnkEliminarTécnico_Click(object sender, EventArgs e)
        {
            try
            {
                int idTecnico = Convert.ToInt32((sender as LinkButton).CommandArgument);

                TBL_TECNICO tecnico = LogicaTecnicos.BuscarXId(idTecnico);
                string nombreTecnico = tecnico.TEC_NOMBRE;

                LogicaTecnicos.EliminarTecnico(tecnico);

                MostrarToast("Eliminado exitoso", "Se elimino correctamente el técnico " + nombreTecnico, "Success");
                ListarTecnicos();
            }
            catch (Exception ex)
            {
                MostrarToast("Error", ex.Message, "Error", 10000);
            }
        }

        protected void lnkModificarTecnico_Click(object sender, EventArgs e)
        {
            int idTecnico = Convert.ToInt32((sender as LinkButton).CommandArgument);

            TBL_TECNICO tecnico = LogicaTecnicos.BuscarXId(idTecnico);

            txtNombres.Text = tecnico.TEC_NOMBRE;
            txtTelefono.Text = tecnico.TEC_TELEFONO;
            hfIdTecnico.Value = tecnico.TEC_ID.ToString();
            btnSubmit.Text = "Modificar Técnico";
            MostrarModal();
        }

        protected void lnkCerrarModal_Click(object sender, EventArgs e)
        {
            Limpiar();
            QuitarFondoModal();
        }
    }
}