
Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Header.DataBind()
        If Not IsPostBack Then
            Session.RemoveAll()
            Session.Clear()
            MensajeError.Visible = False
        End If
    End Sub

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Try
            If Trim(TxbUsuario.Text.ToString) = "admin" And Trim(TxbContraseña.Text.ToString) = "123" Or Trim(TxbUsuario.Text.ToString) = "user" And Trim(TxbContraseña.Text.ToString) = "123" Then
                Dim usarioAtenticado As New CES.nspUsuarioAutenticado.UsuarioAutenticado
                usarioAtenticado.id = Guid.NewGuid()
                usarioAtenticado.rol = Trim(TxbUsuario.Text.ToString)
                usarioAtenticado.usuario = Trim(TxbUsuario.Text.ToString)
                usarioAtenticado.foto = Trim(TxbUsuario.Text.ToString) + ".png"
                Session("user") = usarioAtenticado
                FormsAuthentication.RedirectFromLoginPage(TxbUsuario.Text, True)
                Response.Redirect("~/Management/funcionario/Consultar.aspx")
            Else
                MensajeError.Visible = True
                lblMensaje.Text = "Usuario o contraseña no valido"
            End If
        Catch ex As Exception
            MensajeError.Visible = True
            lblMensaje.Text = "Usuario o contraseña no valido"
        End Try
    End Sub
End Class