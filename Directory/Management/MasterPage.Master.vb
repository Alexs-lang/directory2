Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Header.DataBind()
        If Not IsPostBack Then
            permisos()

        End If
    End Sub

    Private Sub BtnAgregarFuncionario_Click(sender As Object, e As EventArgs) Handles BtnAgregarFuncionario.Click
        Response.Redirect("~/Management/funcionario/Agregar.aspx")
    End Sub

    Private Sub BtnCerrarSesion_Click(sender As Object, e As EventArgs) Handles BtnCerrarSesion.Click
        HttpContext.Current.User = Nothing
        HttpContext.Current.Session.Clear()
        HttpContext.Current.Session.Abandon()
        HttpContext.Current.Response.Cookies.Clear()
        HttpContext.Current.Response.Clear()
        HttpContext.Current.Request.Cookies.Clear()
        FormsAuthentication.SignOut()
        HttpContext.Current.Response.Redirect("~/login.aspx")
    End Sub

    Private Sub btnConsultarFuncionarios_Click(sender As Object, e As EventArgs) Handles btnConsultarFuncionarios.Click
        Response.Redirect("~/Management/funcionario/Consultar.aspx")
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Response.Redirect("~/Management/funcionario/Agregar.aspx")
    End Sub

    Private Sub permisos()
        Dim usuario As CES.nspUsuarioAutenticado.UsuarioAutenticado = CType(Session("user"), CES.nspUsuarioAutenticado.UsuarioAutenticado)

        If usuario.rol = "admin" Then
            menuFuncionario.Visible = True
            menuAdministracion.Visible = True
            lblUsuarioAutenticado.Text = "Administrador"
            imgFoto.ImageUrl = "~/images/" + usuario.foto
        ElseIf usuario.rol = "user" Then
            menuFuncionario.Visible = True
            menuAdministracion.Visible = False
            lblUsuarioAutenticado.Text = "Usuario"
            imgFoto.ImageUrl = "~/images/" + usuario.foto
        End If
    End Sub
End Class