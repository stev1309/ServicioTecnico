using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace ServicioTecnico.Reporte
{
    public partial class ReporteForm : System.Web.UI.Page
    {

        //ReportDocument reporte = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            int idServicios = Int32.Parse(Session["idServicioTecnico"].ToString());
            int idCliente = Int32.Parse(Session["idCliente"].ToString());

            Reporte reporte = new Reporte();
            reporte.SetDatabaseLogon("sa", "itsco12345", "STEVENLUNA", "evaluacion");
            //reporte.Load(Server.MapPath("Reporte.rpt"));

            reporte.SetParameterValue("@ID_SERVICIO_TECNICO", idServicios);
            reporte.SetParameterValue("@PROC_CI_CLIENTE", idCliente);

            ////reporte.Refresh();

            CrystalReportViewer1.ReportSource = reporte;
            ////CrystalReportViewer1.RefreshReport();

        }
    }
}