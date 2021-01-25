<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Reparaciones.aspx.cs" Inherits="ServicioTecnico.Reparaciones" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style>
        .caja_simbolo {
            align-items: center;
            display: flex;
            padding: 0px 10px;
            background: #f0f0f0;
            border-radius: 5px 0 0 5px;
            border: 1px solid #e3e3e3;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_message" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_content" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-12 m-t-20 m-b-20 text-center">
                        <h1>Pagina de Reparaciones</h1>
                    </div>
                </div>
                <div class="row m-t-20 m-b-20">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Listado de Reparaciones</h3>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6 col-lg-4 col-sm-12 col-12">
                                        <div class="mb-3">
                                            <label for="ddlClientes" class="form-label">Buscar Por</label>
                                            <%--<asp:TextBox ID="txtNombres" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlBuscarPor" CssClass="form-control" runat="server">
                                                <asp:ListItem Text="Seleccione..." Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Cliente" Value="Cliente"></asp:ListItem>
                                                <asp:ListItem Text="Marca Equipo" Value="EQU_MARCA"></asp:ListItem>
                                                <asp:ListItem Text="Modelo Equipo" Value="EQU_MODELO"></asp:ListItem>
                                                <asp:ListItem Text="Serie Equipo" Value="EQU_SERIE"></asp:ListItem>
                                                <asp:ListItem Text="Técnico" Value="TEC_NOMBRE"></asp:ListItem>
                                                <asp:ListItem Text="Estado" Value="EQU_ESTADO"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-lg-8 col-sm-12 col-12">

                                        <div class="input-group mb-3">
                                            <asp:TextBox ID="txtBuscar" CssClass="form-control" placeholder="Buscar por..." aria-describedby="btnBuscar" runat="server"></asp:TextBox>
                                            <asp:LinkButton ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-outline-secondary" runat="server"><i class="fa fa-search"></i></asp:LinkButton>
                                            <asp:LinkButton ID="btnLimpiarBuscar" ToolTip="Limpiar" CssClass="btn btn-dark text-light" OnClick="btnLimpiarBuscar_Click" runat="server"><i class="fa fa-refresh"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <asp:GridView ID="gvEquipos" runat="server" CssClass="table" Width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="ST_ID" HeaderText="ID S.T." />
                                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                        <asp:BoundField DataField="EQU_MARCA" HeaderText="Marca" />
                                        <asp:BoundField DataField="EQU_MODELO" HeaderText="Modelo" />
                                        <asp:BoundField DataField="EQU_SERIE" HeaderText="Serie" />
                                        <asp:BoundField DataField="TEC_NOMBRE" HeaderText="Técnico" />
                                        <asp:BoundField DataField="EQU_ESTADO" HeaderText="Estado" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label runat="server" Text="Acciones"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%--<asp:LinkButton ID="btnRepararEquipo" CommandArgument='<%#Eval("EQU_ID").ToString() %>' CssClass="ps-morelink btn btn-info" runat="server" OnClick="btnRepararEquipo_Click">Seleccionar <i class="fa fa-long-arrow-right" onclick="$('#exampleModal').modal()"></i></asp:LinkButton>--%>
                                                <asp:LinkButton ID="btnRepararEquipo" CommandArgument='<%#Eval("EQU_ID").ToString() %>' CssClass="btn btn-info" runat="server" OnClick="btnRepararEquipo_Click" ToolTip="Reparaciones"><i class="fa fa-cogs"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnGenerarReporte" CssClass="btn btn-success" CommandArgument='<%#Eval("EQU_ID").ToString() %>' Visible='<%# (Eval("EQU_ESTADO").ToString() == "Reparado")%>' OnClick="btnGenerarReporte_Click" ToolTip="Reporte" runat="server" Text="Reporte"><i class="fa fa-file-archive-o"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Panel ID="pnNoHayDatos" runat="server" CssClass="text-center" Visible="false">
                                    <b>
                                        <asp:Label ID="Label1" runat="server" Text="No hay datos a mostrar"></asp:Label>
                                    </b>
                                </asp:Panel>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <%--<div class="col-md-7 col-sm-12 col-lg-7 col-xs-12 col-12">
                        <div class="row">
                            <asp:ListView ID="lvEquipos" runat="server" GroupItemCount="2">
                                <LayoutTemplate>
                                    <div class="col-12">
                                        <asp:DataPager ID="dpTop" runat="server" PageSize="5">
                                            <Fields>
                                                <asp:NextPreviousPagerField ButtonCssClass="ps-morelink" ButtonType="Link" />
                                            </Fields>
                                        </asp:DataPager>
                                    </div>
                                    <table border="1">
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />
                                    </table>
                                    <div>
                                        <asp:DataPager ID="dtBottom" runat="server" PageSize="5">
                                            <Fields>
                                                <asp:NextPreviousPagerField ButtonCssClass="ps-morelink" ButtonType="Link" />
                                            </Fields>
                                        </asp:DataPager>
                                    </div>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <div class="col-md-6 col-sm-12 col-lg-6 col-xs-12 col-12">
                                        <div class="card">
                                            <div class="card-header">
                                                <h4 class="card-title">
                                                    <asp:Label ID="lblCliente" runat="server" Text='<%#Eval("Cliente") %>'></asp:Label></h4>
                                            </div>
                                            <div class="card-body">
                                                <h5>Equipo</h5>
                                                <p>
                                                    <b>Marca: </b>
                                                    <asp:Label ID="lblMarca" runat="server" Text='<%#Eval("EQU_MARCA") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    <b>Modelo: </b>
                                                    <asp:Label ID="lblModelo" runat="server" Text='<%#Eval("EQU_MODELO") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    <b>Serie: </b>
                                                    <asp:Label ID="lblSerie" runat="server" Text='<%#Eval("EQU_SERIE") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    <b>Tecnico: </b>
                                                    <asp:Label ID="lblTecnico" runat="server" Text='<%#Eval("TEC_NOMBRE") %>'></asp:Label>
                                                </p>
                                                <p>
                                                    <b>Estado: </b>
                                                    <asp:Label ID="lblEstado" runat="server" Text='<%#Eval("EQU_ESTADO") %>'></asp:Label>
                                                </p>
                                                <asp:LinkButton ID="btnRepararEquipo" CommandArgument='<%#Eval("EQU_ID").ToString() %>' CssClass="ps-morelink" runat="server" OnClick="btnRepararEquipo_Click">Seleccionar <i class="fa fa-long-arrow-right"></i></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <GroupTemplate>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </GroupTemplate>
                                <LayoutTemplate>
                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />
                                </LayoutTemplate>
                                <LayoutTemplate>
                                    <div class="col-12">
                                        <div>
                                            <asp:DataPager ID="dpTop" runat="server" PageSize="5">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonCssClass="ps-morelink" ButtonType="Link" />
                                                </Fields>
                                            </asp:DataPager>
                                        </div>
                                        <table border="1">
                                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />
                                        </table>
                                        <div>
                                            <asp:DataPager ID="dtBottom" runat="server" PageSize="5">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonCssClass="ps-morelink" ButtonType="Link" />
                                                </Fields>
                                            </asp:DataPager>
                                        </div>
                                    </div>
                                </LayoutTemplate>
                            </asp:ListView>
                        </div>
                    </div>--%>
                    <%--                    <div class="col-md-5 col-sm-12 col-lg-5 col-xs-12 col-12 cont_datos">
                    </div>--%>
                </div>
            </div>
            <asp:HiddenField ID="hfidReparacion" runat="server" />
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Reparación Equipo</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="cont_limpiar mb-20">
                                <asp:LinkButton ID="btnLimpiar" CssClass="ps-morelink" OnClick="btnLimpiar_Click" runat="server">Limpiar <i class="fa fa-eraser"></i></asp:LinkButton>
                            </div>
                            <div class="mb-10 cont_datos_usuario">
                                <h6 class="d-inline-block"><i class="fa fa-user mr-10"></i>&nbsp; Cliente: </h6>
                                <p class="d-inline-block">
                                    <asp:Label ID="lblRepCliente" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                            <div class="mb-10 cont_datos_usuario">
                                <h6 class="d-inline-block"><i class="fa fa-laptop mr-10"></i>&nbsp; Equipo: </h6>
                                <p class="d-inline-block">
                                    <asp:Label ID="lblRepEquipo" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                            <div class="col-12">
                                <div class="mb-3">
                                    <label for="txtReparacion" class="form-label">Reparacion</label>
                                    <asp:TextBox ID="txtReparacion" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                                <label for="txtPrecio" class="form-label">Precio</label>
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend caja_simbolo">
                                        <span class="input-group-text" id="validationTooltipUsernamePrepend">$</span>
                                    </div>
                                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <label for="txtReparacion" class="form-label">Fecha de egreso</label>
                                    <asp:TextBox ID="txtFecha" CssClass="form-control controlDatePicker" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                                </div>
                            </div>
                            <asp:HiddenField ID="hfServicioTecnico" runat="server" />
                            <asp:HiddenField ID="hfIdEquipo" runat="server" />
                            <asp:Panel ID="pnlTextBoxes" runat="server">
                            </asp:Panel>
                            <hr />
                            <%--<asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnGet" runat="server" Text="Get Values" OnClick="btnGet_Click" />--%>
                            <%--<div class="mb-10 cont_datos_usuario">
                                    <h5><i class="fa fa-check mr-10"></i>Estado: </h5>
                                    <p>
                                        <%if (Session["estadoUsuarioConf"] != null)
                                            {
                                                char usuClass = (char)Session["estadoUsuarioConf"];
                                                switch (usuClass)
                                                {
                                                    case 'A':
                                        %>
                                        <p><span class="badge bg-primary">Activo</span></p>
                                        <%
                                                break;
                                            case 'I':
                                        %>
                                        <p><span class="badge bg-danger">Inactivo</span></p>
                                        <%
                                                break;
                                            case 'B':
                                        %>
                                        <p><span class="badge bg-danger">Bloqueado</span></p>
                                        <%
                                                break;
                                            case 'C':
                                        %>
                                        <p><span class="badge bg-warning text-dark">Confirmar Registro</span></p>
                                        <%
                                                break;
                                            case 'R':
                                        %>
                                        <p><span class="badge bg-info text-dark">Recuperando Contraseña</span></p>
                                        <%
                                                break;
                                            default:
                                        %>
                                        <p><span class="badge bg-dark">Sin Estado</span></p>
                                        <%
                                                    break;
                                                }
                                            } %>
                                        <%--<asp:Label ID="lblEstadoConf" runat="server" Text=""></asp:Label>
                                    </p>--%>
                        </div>
                        <div class="modal-footer">
                            <%--<asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-secondary" Text="Cancelar" data-dismiss="modal" />--%>
                            <asp:LinkButton ID="btnConfirmarRegistro" CssClass="btn btn-primary" OnClick="btnConfirmarRegistro_Click" runat="server">Confirmar Reparaciones <i class="fa fa-angle-right"></i></asp:LinkButton>
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
            $('#exampleModal').modal('hide')
        }

        function mostrarModal() {
            $('body').addClass('modal-open');
            $('#exampleModal').modal('show')
        }
    </script>
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                $('.controlDatePicker').datepicker(
                    {
                        dateFormat: "yy-mm-dd",
                        timeFormat: "hh:mm:ss",
                        format: 'dd/mm/yyyy 08:00:00'
                    }
                );
            }

        });
    </script>--%>
</asp:Content>
