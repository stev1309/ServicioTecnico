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
    public partial class IngresoServicioTecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                CargarEquipos();
            }
        }

        private void CargarClientes()
        {
            var cargarClientes = LogicaClientes.listarClientes();
            ddlClientes.Items.Insert(0, new ListItem("Seleccione...", "0"));

            foreach (var item in cargarClientes)
            {
                ListItem i = new ListItem(item.CLI_NOMBRES + " " + item.CLI_APELLIDOS, item.CLI_ID.ToString());
                ddlClientes.Items.Add(i);
            }
        }

        private void CargarEquipos()
        {
            var cargarEquipos = LogicaServicio.ListadoServicioTecnico();
            GridView1.DataSource = cargarEquipos;
            GridView1.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text != "" && txtModelo.Text != "" && txtSerie.Text != "" && txtObservaciones.Text != "" && ddlClientes.SelectedIndex != 0 && hfIdEquipo.Value == "")
            {
                try
                {
                    LogicaServicio.GuardarNuevoServicio();
                }
                catch (Exception ex)
                {
                    MostrarToast("Error", "Error al guardar el servicio: " + ex.Message, "Error", 6000);
                    throw new ArgumentException("Los datos no fueron guardados: </br> " + ex.Message);
                }

                TBL_SERVICIO_TECNICO servicio = LogicaServicio.UltimoServicio();

                int idServicio = servicio.ST_ID;
                int idCliente = Int32.Parse(ddlClientes.SelectedValue);
                string marca = txtMarca.Text;
                string modelo = txtModelo.Text;
                string serie = txtSerie.Text;
                string observaciones = txtObservaciones.Text;

                try
                {
                    TBL_EQUIPO equipo = new TBL_EQUIPO();
                    equipo.ST_ID = idServicio;
                    equipo.CLI_ID = idCliente;
                    equipo.EQU_MARCA = marca;
                    equipo.EQU_MODELO = modelo;
                    equipo.EQU_SERIE = serie;
                    equipo.EQU_OBSERVACIONES = observaciones;

                    LogicaEquipos.guardarNuevoEquipo(equipo);
                    MostrarToast("Guardado exitoso", "El nuevo servicio se guardo exitosamente", "Success");
                    Limpiar();
                    CargarEquipos();
                    QuitarFondoModal();
                }
                catch (Exception ex)
                {
                    MostrarToast("Error", "Error al guardar el equipo: " + ex.Message, "Error", 6000);
                    return;
                }
            }
            else if (txtMarca.Text != "" && txtModelo.Text != "" && txtSerie.Text != "" && txtObservaciones.Text != "" && ddlClientes.SelectedIndex != 0 && hfIdEquipo.Value != "")
            {
                TBL_EQUIPO equipo = LogicaEquipos.EquipoXID(Int32.Parse(hfIdEquipo.Value));

                int idServicio = equipo.TBL_SERVICIO_TECNICO.ST_ID;
                int idCliente = Int32.Parse(ddlClientes.SelectedValue);
                string marca = txtMarca.Text;
                string modelo = txtModelo.Text;
                string serie = txtSerie.Text;
                string observaciones = txtObservaciones.Text;

                try
                {
                    //TBL_EQUIPO equipo = new TBL_EQUIPO();
                    equipo.ST_ID = idServicio;
                    equipo.CLI_ID = idCliente;
                    equipo.EQU_MARCA = marca;
                    equipo.EQU_MODELO = modelo;
                    equipo.EQU_SERIE = serie;
                    equipo.EQU_OBSERVACIONES = observaciones;

                    LogicaEquipos.ModificarEquipo(equipo);
                    MostrarToast("Modificado exitoso", "El servicio se modifico exitosamente", "Success");
                    Limpiar();
                    CargarEquipos();
                    QuitarFondoModal();
                }
                catch (Exception ex)
                {
                    MostrarToast("Error", "Error al guardar el equipo: " + ex.Message, "Error", 6000);
                    return;
                }
            }
            else
            {
                MostrarToast("Advertencia", "No deje los campos vacios", "Warning");
            }
        }

        private void Limpiar()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtSerie.Text = "";
            txtObservaciones.Text = "";
            hfIdEquipo.Value = "";
            ddlClientes.ClearSelection();
        }

        private void MostrarToast(string titulo, string mensaje, string tipo, int duracion = 3000) => ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mostrarToast", "mostrarToast('" + titulo + "', '" + mensaje + "', '" + tipo + "', " + duracion + ");", true);

        public void QuitarFondoModal()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "quitarModal", "quitarModal(); ", true);
        }
        public void MostrarModal()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "quitarModal", "mostrarModal(); ", true);
        }

        protected void lnkEliminarServicio_Click(object sender, EventArgs e)
        {
            int codEquipo = Convert.ToInt32((sender as LinkButton).CommandArgument);

            TBL_EQUIPO equipo = LogicaEquipos.EquipoXID(codEquipo);

            LogicaEquipos.EliminarEquipo(equipo);

            MostrarToast("Eliminado exitoso", "Se elimino correctamente el equipo", "Success");
            Limpiar();
            CargarEquipos();
        }

        protected void lnkModificarServicio_Click(object sender, EventArgs e)
        {
            int codEquipo = Convert.ToInt32((sender as LinkButton).CommandArgument);

            TBL_EQUIPO equipo = LogicaEquipos.EquipoXID(codEquipo);

            txtMarca.Text = equipo.EQU_MARCA;
            txtModelo.Text = equipo.EQU_MODELO;
            txtObservaciones.Text = equipo.EQU_OBSERVACIONES;
            txtSerie.Text = equipo.EQU_SERIE;

            hfIdEquipo.Value = equipo.EQU_ID.ToString();

            ddlClientes.SelectedValue = equipo.TBL_CLIENTE.CLI_ID.ToString();

            MostrarModal();
        }

        protected void lnkCerrarModal_Click(object sender, EventArgs e)
        {
            QuitarFondoModal();
            Limpiar();
        }
    }
}