<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="Directory.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href='<%#Page.ResolveUrl("~/Management/plugins/fontawesome-free/css/all.min.css") %>' rel="stylesheet" />
    <link href='<%#Page.ResolveUrl("~/Management/dist/css/ionicons.min.css") %>' rel="stylesheet" />
    <link href='<%#Page.ResolveUrl("~/Management/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css") %>' rel="stylesheet" />
    <link href='<%#Page.ResolveUrl("~/Management/plugins/icheck-bootstrap/icheck-bootstrap.min.css")%>' rel="stylesheet" />
    <link href='<%#Page.ResolveUrl("~/Management/dist/css/adminlte.min.css")%>' rel="stylesheet"  />
  
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
<div class="login-box">
  <div class="login-logo">
    <a href="../../index2.html">Directorio</a>
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg">Iniciar Sesisón</p>

      
        <div class="input-group mb-3">
            <asp:TextBox runat="server" ID="TxbUsuario" class="form-control" placeholder="Usuario" />
          
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
            <asp:TextBox runat="server" id="TxbContraseña" class="form-control" type="" placeholder="Password"/>
          
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            
          </div>
          <!-- /.col -->
          <div class="col-4">
              <asp:LinkButton Text="Aceptar" runat="server" ID="btnEntrar" class="btn btn-primary btn-block"/>
            
          </div>
          <!-- /.col -->
        </div>


      <div class="social-auth-links text-center mb-3">
          <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="MensajeError" >
                        <strong>Alerta!  </strong>
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </div>
      </div>
      <!-- /.social-auth-links -->


    </div>
    <!-- /.login-card-body -->
  </div>
</div>
<!-- /.login-box -->

<!-- jQuery -->
        <script src="<%=Page.ResolveUrl("~/Management/plugins/jquery/jquery.min.js")%>" type="text/javascript"></script>
        <script src="<%=Page.ResolveUrl("~/Management/plugins/bootstrap/js/bootstrap.bundle.min.js")%>" type="text/javascript"></script>
        <script src="<%=Page.ResolveUrl("~/Management/dist/js/adminlte.js")%>" type="text/javascript"></script>

    </form>
</body>
</html>
