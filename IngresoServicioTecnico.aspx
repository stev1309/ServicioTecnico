<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="IngresoServicioTecnico.aspx.cs" Inherits="ServicioTecnico.IngresoServicioTecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_message" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-12 m-t-20 m-b-20 text-center">
                        <h1>Pagina de Servicio Tecnico</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 ">
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-backdrop="static" data-keyboard="false" data-target="#formModal">
                            <i class="fa fa-plus"></i>&nbsp; Añadir Servicio
                        </button>
                    </div>
                </div>
                <div class="row m-t-20 m-b-20">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Listado de Servicios</h3>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table" Width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <%--<asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="CLI_ID" runat="server" Text='<% #Bind("CLI_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:BoundField DataField="EQU_ID" HeaderText="ID" />
                                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                        <asp:BoundField DataField="EQU_MARCA" HeaderText="Marca" />
                                        <asp:BoundField DataField="EQU_MODELO" HeaderText="Modelo" />
                                        <asp:BoundField DataField="EQU_SERIE" HeaderText="Serie" />
                                        <asp:BoundField DataField="ST_FECHA_INGRESO" HeaderText="Fecha ingreso" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label Text="Acciones" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEliminarServicio" CssClass="btn btn-danger" runat="server" CommandArgument='<%#Eval("EQU_ID").ToString() %>' OnClick="lnkEliminarServicio_Click" OnClientClick='confirm("Seguro que desea eliminar el servicio?");'><i class="fa fa fa-trash"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lnkModificarServicio" CssClass="btn btn-warning" runat="server" CommandArgument='<%#Eval("EQU_ID").ToString() %>' OnClick="lnkModificarServicio_Click"><i class="fa fa fa-pencil"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfIdEquipo" runat="server" />
            <div id="formModal" class="modal fade" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog" style="margin: 20vh auto; width: 100%; max-width: 850px;">
                    <div class="modal-content cont">
                        <div class="modal-header">
                            <asp:LinkButton ID="lnkCerrarModal" OnClick="lnkCerrarModal_Click" runat="server"><span aria-hidden="true"><i class="fa fa fa-times-circle fa-2x"></i></span></asp:LinkButton>
                            <h4 class="modal-title">Clientes</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-12 col-sm-12">
                                    <div class="mb-3">
                                        <label for="txtMarca" class="form-label">Marca</label>
                                        <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <label for="ddlClientes" class="form-label">Cliente</label>
                                        <%--<asp:TextBox ID="txtNombres" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlClientes" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6 col-12 col-sm-12">
                                    <div class="mb-3">
                                        <label for="txtModelo" class="form-label">Modelo</label>
                                        <asp:TextBox ID="txtModelo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <label for="txtSerie" class="form-label">Serie</label>
                                        <asp:TextBox ID="txtSerie" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="mb-3">
                                        <label for="txtObservaciones" class="form-label">Observaciones</label>
                                        <asp:TextBox ID="txtObservaciones" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-12">
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" runat="server" Text="Registrar Servicio" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_scripts" runat="server">
    <script type="text/javascript">
        function quitarModal() {
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
            $('#formModal').modal('hide')
        }

        function mostrarModal() {
            $('body').addClass('modal-open');
            $('#formModal').modal('show')
        }
    </script>
</asp:Content>
