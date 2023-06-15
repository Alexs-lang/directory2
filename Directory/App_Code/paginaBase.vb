Imports CES.nspPopup
Public Class paginaBase : Inherits System.Web.UI.Page

    Public ReadOnly Property rolUsuario As String
        Get
            Return OnObtenerRol()
        End Get
    End Property
    Public ReadOnly Property imagenUsuario As String
        Get
            Return OnObtenerImagen()
        End Get
    End Property
    Public ReadOnly Property myUsuario As String
        Get
            Return OnObtenerUsuario()
        End Get
    End Property


    Public ReadOnly Property idUsuario As Guid?
        Get
            Return OnObtenerIdUsuario()
        End Get
    End Property
    Public ReadOnly Property UsuarioEsAutenticado As Boolean
        Get
            Return OnObtenerusuarioAutenticado()
        End Get
    End Property

    Private Function OnObtenerRol() As String
        Dim Rol As String = String.Empty
        If (Not HttpContext.Current.User Is Nothing) Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Dim usuario = OnObtenerEntidad()
                If (Not usuario Is Nothing) Then
                    Rol = usuario.rol
                End If
            End If
        End If
        Return Rol
    End Function
    Private Function OnObtenerImagen() As String
        Dim nombre As String = String.Empty
        If (Not HttpContext.Current.User Is Nothing) Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Dim usuario = OnObtenerEntidad()
                If (Not usuario Is Nothing) Then
                    nombre = "user.jpg"
                End If
            End If
        End If
        Return nombre
    End Function
    Private Function OnObtenerUsuario() As String
        Dim usuarioText As String = String.Empty
        If (Not HttpContext.Current.User Is Nothing) Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Dim usuario = OnObtenerEntidad()
                If (Not usuario Is Nothing) Then
                    usuarioText = usuario.usuario
                End If
            End If
        End If
        Return usuarioText
    End Function


    Private Function OnObtenerIdUsuario() As Guid?
        Dim id As Guid?
        If (Not HttpContext.Current.User Is Nothing) Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Dim usuario = OnObtenerEntidad()
                If (Not usuario Is Nothing) Then
                    id = usuario.id
                Else
                    id = Nothing
                End If
            End If
        End If
        Return id
    End Function
    Private Function OnObtenerusuarioAutenticado() As String
        Dim continuar As Boolean = False
        If (Not HttpContext.Current.User Is Nothing) Then
            If (HttpContext.Current.User.Identity.IsAuthenticated) Then
                Dim usuario = OnObtenerEntidad()
                If (Not usuario Is Nothing) Then
                    continuar = True
                Else
                    continuar = False
                End If
            End If
        End If
        Return continuar
    End Function


    Public Sub NotificacionToastSwal(Mensaje As String, Tipo As tipoNotificacion)
        Dim sb As StringBuilder = New StringBuilder

        Select Case Tipo
            Case tipoNotificacion.Exitoso
                sb.Append("<script>Toast.fire({type: 'success', title: '").Append(Mensaje).Append("'});</script>")
            Case tipoNotificacion.Alerta
                sb.Append("<script>Toast.fire({type: 'warning', title: '").Append(Mensaje).Append("'});</script>")
            Case tipoNotificacion.Informacion
                sb.Append("<script>Toast.fire({type: 'info', title: '").Append(Mensaje).Append("'});</script>")
            Case tipoNotificacion.Error_
                sb.Append("<script>Toast.fire({type: 'error', title: '").Append(Mensaje).Append("'})</script>")
        End Select
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "scriptmodalNotification", sb.ToString, False)
    End Sub
    Public Sub NotificacionToast(Mensaje As String, Tipo As tipoNotificacion)
        Dim sb As StringBuilder = New StringBuilder

        Select Case Tipo
            Case tipoNotificacion.Exitoso
                sb.Append("<script>toastr.success('").Append(Mensaje).Append("')</script>")
            Case tipoNotificacion.Alerta
                sb.Append("<script>toastr.warning('").Append(Mensaje).Append("')</script>")
            Case tipoNotificacion.Informacion
                sb.Append("<script>toastr.info('").Append(Mensaje).Append("')</script>")
            Case tipoNotificacion.Error_
                sb.Append("<script>toastr.error('").Append(Mensaje).Append("')</script>")
        End Select
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "scriptmodalNotification", sb.ToString, False)
    End Sub
    Public Sub CerrarSesion()
        HttpContext.Current.User = Nothing
        HttpContext.Current.Session.Clear()
        HttpContext.Current.Session.Abandon()
        HttpContext.Current.Response.Cookies.Clear()
        HttpContext.Current.Response.Clear()
        HttpContext.Current.Request.Cookies.Clear()
        FormsAuthentication.SignOut()
        HttpContext.Current.Response.Redirect("~/login.aspx")
    End Sub
    Public Sub mandaDefault()
        HttpContext.Current.Response.Redirect("~/default.aspx")
    End Sub

    Private Function OnObtenerEntidad() As CES.nspUsuarioAutenticado.UsuarioAutenticado
        Dim user As New CES.nspUsuarioAutenticado.UsuarioAutenticado
        If Not Session("user") Is Nothing Then
            user = CType(Session("user"), CES.nspUsuarioAutenticado.UsuarioAutenticado)

        Else
            CerrarSesion()
        End If
        Return user
    End Function


End Class
