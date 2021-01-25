<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ServicioTecnico.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Login Form</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="content/toastr.min.css">

    <style>
        .container_cargando {
            position: absolute;
            background-color: #ffffffdb;
            z-index: 99999;
            left: 0;
            top: 0;
            height: 100vh;
            right: 0;
            width: 100%;
            max-width: 100vw;
            display: flex;
            align-items: center;
        }

            .container_cargando img {
                width: 25%;
                margin: 0 auto;
                box-shadow: none;
            }
    </style>
</head>
<body>

    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form class="login100-form validate-form" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div class="container container_cargando">
                                <asp:Image ID="imgLoading" ImageUrl="~/images/transparent-loading.gif" runat="server" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <span class="login100-form-title p-b-26">Welcome
                            </span>
                            <span class="login100-form-title p-b-48">
                                <i class="zmdi zmdi-font"></i>
                            </span>

                            <div class="wrap-input100 validate-input" data-validate="Valid email is: a@b.c">
                                <asp:TextBox ID="txtUsuario" CssClass="input100" runat="server"></asp:TextBox>
                                <%--<input class="input100" type="text" name="email">--%>
                                <span class="focus-input100" data-placeholder="Usuario"></span>
                            </div>

                            <div class="wrap-input100 validate-input" data-validate="Enter password">
                                <span class="btn-show-pass">
                                    <i class="zmdi zmdi-eye"></i>
                                </span>
                                <asp:TextBox ID="txtContrasenia" CssClass="input100" TextMode="Password" runat="server"></asp:TextBox>
                                <%--<input class="input100" type="password" name="pass">--%>
                                <span class="focus-input100" data-placeholder="Contraseña"></span>
                            </div>

                            <div class="container-login100-form-btn">
                                <div class="wrap-login100-form-btn">
                                    <div class="login100-form-bgbtn"></div>
                                    <%--<button class="login100-form-btn">Login</button>--%>
                                    <asp:Button ID="btnLogin" CssClass="login100-form-btn" runat="server" OnClick="btnLogin_Click" Text="Login" />
                                </div>
                            </div>

                            <div class="text-center p-t-115">
                                <span class="txt1">Don’t have an account?
                                </span>
                                <a class="txt2" href="#">Sign Up
                                </a>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </div>
        </div>
    </div>

    <div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>
    <!--===============================================================================================-->
    <script src="Scripts/toastr.min.js"></script>
    <script type="text/javascript">
        function mostrarToast(titulo, mensaje, tipo, duracion) {
            switch (tipo) {
                case 'Success':
                    toastr.success(mensaje, titulo, { closeButton: true, timeOut: duracion, progressBar: true });
                    break;
                case 'Info':
                    toastr.info(mensaje, titulo, { closeButton: true, timeOut: duracion, progressBar: true });
                    break;
                case 'Warning':
                    toastr.warning(mensaje, titulo, { closeButton: true, timeOut: duracion, progressBar: true });
                    break;
                case 'Error':
                    toastr.error(mensaje, titulo, { closeButton: true, timeOut: duracion, progressBar: true });
                    break;
                default:
                    toastr.warning('Sin nada', 'Nada', { closeButton: true, timeOut: duracion, progressBar: true });
                    break;
            }
        }
    </script>
</body>
</html>
