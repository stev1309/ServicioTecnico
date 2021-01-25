<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="ServicioTecnico.Tecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_message" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-12 m-t-20 m-b-20 text-center">
                        <h1>Pagina de Técnicos</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-backdrop="static" data-keyboard="false" data-target="#formModal">
                            <i class="fa fa-plus"></i>&nbsp; Añadir Técnico
                        </button>
                        <%--<div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Registro de Técnico</h3>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6 col-lg-6 col-12 col-sm-12">
                                        <div class="mb-3">
                                            <label for="exampleInputEmail1" class="form-label">Nombres</label>
                                            <asp:TextBox ID="txtNombres" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-lg-6 col-12 col-sm-12">
                                        <div class="mb-3">
                                            <label for="exampleInputPassword1" class="form-label">Teléfono</label>
                                            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" runat="server" Text="Añadir Técnico" />
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="row m-t-20 m-b-20">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Listado de Clientes</h3>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="gvTecnicos" runat="server" CssClass="table" Width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <%--<asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="CLI_ID" runat="server" Text='<% #Bind("CLI_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:BoundField DataField="TEC_ID" HeaderText="ID" />
                                        <asp:BoundField DataField="TEC_NOMBRE" HeaderText="Nombre" />
                                        <asp:BoundField DataField="TEC_TELEFONO" HeaderText="Teléfono" />
                                        <asp:BoundField DataField="TEC_FECHA_CREACION" HeaderText="Fecha de Creación" />
                                        <asp:BoundField DataField="TEC_ESTADO" HeaderText="Estado" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label Text="Acciones" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEliminarTécnico" CssClass="btn btn-danger" runat="server" CommandArgument='<%#Eval("TEC_ID").ToString() %>' OnClick="lnkEliminarTécnico_Click" OnClientClick='confirm("Seguro que desea eliminar el Técnico");'><i class="fa fa fa-trash"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lnkModificarTecnico" CssClass="btn btn-warning" runat="server" CommandArgument='<%#Eval("TEC_ID").ToString() %>' OnClick="lnkModificarTecnico_Click"><i class="fa fa fa-pencil"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfIdTecnico" runat="server" />
            <div id="formModal" class="modal fade" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog" style="margin: 20vh auto; width: 360px">
                    <div class="modal-content cont">
                        <div class="modal-header">
                            <asp:LinkButton ID="lnkCerrarModal" OnClick="lnkCerrarModal_Click" runat="server"><span aria-hidden="true"><i class="fa fa fa-times-circle fa-2x"></i></span></asp:LinkButton>
                            <h4 class="modal-title">Técnico</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-12">
                                    <div class="mb-3">
                                        <label for="exampleInputEmail1" class="form-label">Nombres</label>
                                        <asp:TextBox ID="txtNombres" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="mb-3">
                                        <label for="exampleInputPassword1" class="form-label">Teléfono</label>
                                        <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" runat="server" Text="Añadir Técnico" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkModificarTecnico" EventName="Click" />
        </Triggers>--%>
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
