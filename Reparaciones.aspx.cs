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
    public partial class Reparaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cont = 2;
                Session["prob"] = 2;
                CargarDatos();
                //MantenerTextBoxes();

                Session["idCliente"] = null;
                Session["idServicioTecnico"] = null;

                btnLimpiarBuscar.Enabled = false;
                pnNoHayDatos.Visible = false;
            }

            //if (Int32.Parse(Session["prob"].ToString()) == 1)
            //{
            //    try
            //    {
            //        List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
            //        int i = 1;
            //        foreach (string key in keys)
            //        {
            //            this.CreateTextBox("txtDynamic" + i);
            //            i++;
            //        }

            //        List<string> keys2 = Request.Form.AllKeys.Where(key => key.Contains("txtPrecio")).ToList();
            //        int j = 1;
            //        foreach (string key in keys2)
            //        {
            //            this.CreateTextBoxPrecio("txtPrecio" + j);
            //            j++;
            //        }
            //        Session["prob"] = 2;
            //    }
            //    catch (Exception ex)
            //    {
            //        MostrarToast("Error", ex.Message, "Error");
            //    }
            //    Session["prob"] = 2;
            //}

        }

        private void CargarDatos()
        {
            Session["prob"] = 2;
            var equipos = LogicaEquipos.ListadoEquiposReparaciones();

            if (equipos != null)
            {
                pnNoHayDatos.Visible = true;
            }
            else
            {
                pnNoHayDatos.Visible = false;
            }
            //Label1.Text = equipos.Count().ToString();

            //lvEquipos.DataSource = equipos;
            //lvEquipos.DataBind();

            gvEquipos.DataSource = equipos;
            gvEquipos.DataBind();

        }

        private void CargarDatosPorBuscador(string cliNombre = "", string cliApellido = "", string marca = "", string modelo = "", string serie = "", string tecnico = "", string estado = "")
        {
            IEnumerable<dynamic> equipos = null;
            Session["prob"] = 2;
            if (ddlBuscarPor.SelectedValue == "Todo")
            {
                equipos = LogicaEquipos.ListadoEquiposReparacionesBuscarPorTodo(cliNombre, cliApellido, marca, modelo, serie, tecnico, estado);
            }
            else
            {
                equipos = LogicaEquipos.ListadoEquiposReparacionesBuscarPor(cliNombre, cliApellido, marca, modelo, serie, tecnico, estado);
            }

            if (equipos != null)
            {
                pnNoHayDatos.Visible = true;
            }
            else
            {
                pnNoHayDatos.Visible = false;
            }

            //lvEquipos.DataSource = equipos;
            //lvEquipos.DataBind();
            gvEquipos.DataSource = equipos;
            gvEquipos.DataBind();

        }

        protected void btnRepararEquipo_Click(object sender, EventArgs e)
        {
            Session["prob"] = 2;
            //int codEquipo = Convert.ToInt32((sender as LinkButton).CommandArgument);
            int codEquipo = Convert.ToInt32((sender as LinkButton).CommandArgument);

            TBL_EQUIPO equipo = LogicaEquipos.EquipoXID(codEquipo);

            TBL_CLIENTE cliente = LogicaClientes.ClienteXID(equipo.CLI_ID);

            lblRepCliente.Text = cliente.CLI_NOMBRES + " " + cliente.CLI_APELLIDOS;
            lblRepEquipo.Text = equipo.EQU_MARCA + " " + equipo.EQU_MODELO + " " + equipo.EQU_SERIE;

            hfIdEquipo.Value = codEquipo.ToString();
            hfServicioTecnico.Value = equipo.ST_ID.ToString();

            if (equipo.EQU_ESTADO == "Reparado")
            {
                TBL_REPARACIONES reparacion = LogicaReparaciones.ObtenerReparacion(equipo.ST_ID);
                txtReparacion.Text = reparacion.REP_DESCRIPCION;
                txtPrecio.Text = reparacion.REP_PRECIO.ToString();
                hfidReparacion.Value = reparacion.REP_ID.ToString();
                txtFecha.Text = equipo.TBL_SERVICIO_TECNICO.ST_FECHA_EGRESO.ToString();
            }

            MostrarModal();

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            DateTime datet = DateTime.Now;
            MostrarToast("tiempo", datet.ToString(), "Success");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["prob"] = 1;
            int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBox("txtDynamic" + index);
            this.CreateTextBoxPrecio("txtPrecio" + index);
        }

        private void CreateTextBox(string id)
        {
            Session["prob"] = 2;
            Literal lbl = new Literal();
            lbl.Text = "<small>Reparacion</small>";
            pnlTextBoxes.Controls.Add(lbl);

            TextBox txt = new TextBox();
            txt.ID = id;
            txt.CssClass = "txtBoxDinamicos form-control";
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Rows = 2;
            pnlTextBoxes.Controls.Add(txt);

            Literal lt = new Literal();
            lt.Text = "<br />";
            pnlTextBoxes.Controls.Add(lt);
        }
        private void CreateTextBoxPrecio(string id)
        {
            Session["prob"] = 2;
            Literal lbl = new Literal();
            lbl.Text = "<small>Precio</small>";
            pnlTextBoxes.Controls.Add(lbl);
            TextBox txt = new TextBox();
            txt.ID = id;
            txt.CssClass = "txtPrecios form-control";
            pnlTextBoxes.Controls.Add(txt);

            Literal lt = new Literal();
            lt.Text = "<br />";
            pnlTextBoxes.Controls.Add(lt);

            Literal hr = new Literal();
            hr.Text = "<hr />";
            pnlTextBoxes.Controls.Add(hr);
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            Session["prob"] = 1;
            string message = "";
            foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
            {
                message += textBox.ID + ": " + textBox.Text + "\\n";
            }
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);

            MostrarToast("Textos", message, "Success", 10000);
        }

        private void MostrarToast(string titulo, string mensaje, string tipo, int duracion = 3000) => ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mostrarToast", "mostrarToast('" + titulo + "', '" + mensaje + "', '" + tipo + "', " + duracion + ");", true);


        protected void btnConfirmarRegistro_Click(object sender, EventArgs e)
        {
            if (txtReparacion.Text != "" && txtPrecio.Text != "" && hfServicioTecnico.Value != "" && hfIdEquipo.Value != "")
            {
                try
                {
                    TBL_REPARACIONES reparacion = new TBL_REPARACIONES();
                    string descripcion = txtReparacion.Text;
                    string precio = txtPrecio.Text;
                    //foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
                    //{
                    //    if (textBox.ID.Contains("txtDynamic"))
                    //    {
                    //        descripcion = textBox.Text;
                    //    }
                    //    else if (textBox.ID.Contains("txtPrecio"))
                    //    {
                    //        precio = textBox.Text;
                    //    }
                    //    else
                    //    {
                    //        descripcion = "Sin descripcion";
                    //        precio = "Sin precio";
                    //    }
                    //}

                    reparacion.REP_DESCRIPCION = descripcion;
                    reparacion.REP_PRECIO = float.Parse(precio);
                    reparacion.ST_ID = Int32.Parse(hfServicioTecnico.Value);
                    DateTime fecha = DateTime.Parse(txtFecha.Text);

                    if (hfidReparacion.Value == "")
                    {
                        LogicaReparaciones.GuardarReparaciones(reparacion);
                    }
                    else
                    {
                        LogicaReparaciones.ModificarReparaciones(reparacion);

                    }

                    TBL_EQUIPO equipo = LogicaEquipos.EquipoXID(Int32.Parse(hfIdEquipo.Value));

                    LogicaEquipos.CambiarEstadoEquipo(equipo, "Reparado");

                    TBL_SERVICIO_TECNICO servicio = LogicaServicio.ServicioXId(Int32.Parse(hfServicioTecnico.Value));

                    LogicaServicio.CambiarFechaDeEgreso(servicio, fecha);

                    MostrarToast("Reparacion Guardada", "Las reparaciones han sido guardadas", "Success");
                    CargarDatos();
                    Limpiar();
                    QuitarFondoModal();

                }
                catch (Exception ex)
                {
                    MostrarToast("Error", ex.Message, "Error", 10000);
                }

            }
            else
            {
                MostrarToast("Advertencia", "No deje la descripcion y el precio vacíos", "Warning");
            }
        }

        private void Limpiar()
        {
            pnlTextBoxes.Controls.Clear();
            lblRepCliente.Text = "";
            lblRepEquipo.Text = "";
            txtReparacion.Text = "";
            txtPrecio.Text = "";
            hfIdEquipo.Value = "";
            hfServicioTecnico.Value = "";
            hfidReparacion.Value = "";
            Session["prob"] = 2;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            int codEquipo = Convert.ToInt32((sender as LinkButton).CommandArgument);

            TBL_EQUIPO equipo = LogicaEquipos.EquipoXID(codEquipo);

            TBL_CLIENTE cliente = LogicaClientes.ClienteXID(equipo.CLI_ID);

            Session["idCliente"] = cliente.CLI_ID;
            Session["idServicioTecnico"] = equipo.ST_ID;

            Response.Redirect("~/Reporte/ReporteForm.aspx");
        }

        public void QuitarFondoModal()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "quitarModal", "quitarModal(); ", true);
        }
        public void MostrarModal()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "quitarModal", "mostrarModal(); ", true);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscando();
        }

        private void Buscando()
        {
            if (ddlBuscarPor.SelectedIndex != 0)
            {
                btnLimpiarBuscar.Enabled = true;
                if (txtBuscar.Text != "")
                {
                    string criterio = ddlBuscarPor.SelectedValue;
                    string valor = txtBuscar.Text;

                    switch (criterio)
                    {
                        case "Cliente":
                            CargarDatosPorBuscador(cliNombre: valor, cliApellido: valor);
                            break;
                        case "Todo":
                            CargarDatosPorBuscador(marca: valor, modelo: valor, serie: valor, tecnico: valor, estado: valor, cliNombre: valor, cliApellido: valor);
                            break;
                        case "EQU_MARCA":
                            CargarDatosPorBuscador(marca: valor);
                            break;
                        case "EQU_MODELO":
                            CargarDatosPorBuscador(modelo: valor);
                            break;
                        case "EQU_SERIE":
                            CargarDatosPorBuscador(serie: valor);
                            break;
                        case "TEC_NOMBRE":
                            CargarDatosPorBuscador(tecnico: valor);
                            break;
                        case "EQU_ESTADO":
                            CargarDatosPorBuscador(estado: valor);
                            break;
                        default:
                            CargarDatos();
                            LimpiarBuscarPor();
                            break;
                    }
                }
                else
                {

                    MostrarToast("Advertencia", "No olvide de ingresar el valor a buscar", "Warning");
                    txtBuscar.Focus();
                }
            }
            else
            {
                MostrarToast("Advertencia", "No olvide de seleccionar un criterio a buscar", "Warning");
                ddlBuscarPor.Focus();
            }
        }

        private void LimpiarBuscarPor()
        {
            ddlBuscarPor.ClearSelection();
            txtBuscar.Text = "";
            btnLimpiarBuscar.Enabled = false;
            Label1.Text = "";
            CargarDatos();
        }

        protected void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            LimpiarBuscarPor();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscando();
        }
    }
}