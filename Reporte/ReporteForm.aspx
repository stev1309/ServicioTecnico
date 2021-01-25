<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteForm.aspx.cs" Inherits="ServicioTecnico.Reporte.ReporteForm" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="../crystalreportviewers13/js/crviewer/crv.js"></script>
    <title>Reporte</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" />
        </div>
    </form>
</body>
</html>
