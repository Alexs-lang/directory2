Imports CES.NspFuncionario
Imports CRN.NspFuncionario
Imports CES.NspTelefono
Imports CES.nspPopup
Imports CES.NspTipoFuncionario, CRN.NspTipoFuncionario
Imports Contexto.Notificaciones.controladorMensajes
Imports System.IO
Imports System.Xml.Serialization
Public Class Editar
    Inherits paginaBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        img.Attributes("onchange") = "UploadFile(this)"
        If Not IsPostBack Then
            Session("listaTelefono") = Nothing
            lvsTelefonos.DataSource = New List(Of Telefono)
            lvsTelefonos.DataBind()
            ObtenerTipoFuncionarios()
            ObtenerFuncionario()
        End If
    End Sub
    Private Sub ObtenerFuncionario()
        If Not Request.QueryString("id") Is Nothing Then
            Dim funcionario = New ProcObtenerFuncionario() With {.id = Guid.Parse(Request.QueryString("id"))}.Ejecutar
            If Not funcionario Is Nothing Then
                ddlTipoFuncionario.SelectedValue = funcionario.IdTipoFuncionario.ToString
                txbNombre.Text = funcionario.Nombre
                txbAPaterno.Text = funcionario.APaterno
                txbAMaterno.Text = funcionario.AMaterno
                txbCargo.Text = funcionario.Cargo
                txbFechaNacimiento.Text = CDate(funcionario.FechaNacimiento).ToString("yyyy-MM-dd")
                txbCorreo.Text = funcionario.Correo
                txbMapaOficina.Text = funcionario.MapaOficina
                imgFoto.ImageUrl = "~/images/Funcionarios/" + funcionario.Foto.ToString
                lblFoto.Text = funcionario.Foto.ToString
                ObtenerTelefono(funcionario.Telefono)
            End If
        End If
    End Sub
    Private Sub ObtenerTelefono(cadenaXML As String)
        If cadenaXML <> "" Then
            Dim XML As New XmlSerializer(GetType(List(Of Telefono)))
            Dim lista As List(Of Telefono) = CType(XML.Deserialize(New StringReader(cadenaXML.ToString)), List(Of Telefono))
            lvsTelefonos.DataSource = lista
            lvsTelefonos.DataBind()
            Session("listaTelefono") = lista
        End If

    End Sub
    Private Sub ObtenerTipoFuncionarios()
        Dim lista = New ProcObtenerTipoFuncionarios() With {.tipoConsulta = TipoConsultaTipoFuncionario.EsActivo, .EsActivo = True}.Ejecutar
        ddlTipoFuncionario.Items.Clear()
        ddlTipoFuncionario.Items.Add("Seleccione un elemento de la lista")
        ddlTipoFuncionario.DataTextField = "Tipo"
        ddlTipoFuncionario.DataValueField = "Id"
        ddlTipoFuncionario.DataSource = lista
        ddlTipoFuncionario.DataBind()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        Try
            validar()
            Dim lista As List(Of Telefono) = CType(Session("listaTelefono"), List(Of Telefono))
            Dim funcionario = New ProcObtenerFuncionario() With {.id = Guid.Parse(Request.QueryString("id").ToString)}.Ejecutar
            funcionario.IdTipoFuncionario = Guid.Parse(ddlTipoFuncionario.SelectedValue)
            funcionario.Nombre = txbNombre.Text.ToString
            funcionario.APaterno = txbAPaterno.Text.ToString
            funcionario.AMaterno = txbAMaterno.Text.ToString
            funcionario.Cargo = txbCargo.Text.ToString
            funcionario.FechaNacimiento = txbFechaNacimiento.Text
            If lblFoto.Text <> "user.png" Then
                funcionario.Foto = lblFoto.Text
            End If

            funcionario.MapaOficina = txbMapaOficina.Text
            If Not lista Is Nothing Then
                funcionario.Telefono = lista_A_xml(lista).ToString
            Else
                funcionario.Telefono = Nothing
            End If
            funcionario.Correo = txbCorreo.Text

            Dim respuesta = New ProcEditarFuncionario() With {.entidad = funcionario}.Ejecutar()
            Select Case respuesta.respuesta
                Case tipoRespuestaDelProceso.Completado
                    NotificacionToast("Los datos se actualizaron correctamente", tipoNotificacion.Exitoso)
                Case tipoRespuestaDelProceso.Advertencia
                    Throw New Exception(respuesta.comentario)
                Case tipoRespuestaDelProceso.NoCompletado
                    Throw New Exception(respuesta.comentario)
            End Select

        Catch ex As Exception
            Dim fail As String = ex.Message.Replace(vbCrLf, " ").Replace("""", "").Replace("'", "").ToString
            NotificacionToast(fail, tipoNotificacion.Alerta)
        End Try
    End Sub
    Private Sub validar()
        If ddlTipoFuncionario.SelectedValue = "Seleccione un elemento de la lista" Then
            Throw New Exception("El campo Tipo funcionario es obligatorio.")
        End If
        If Trim(txbCargo.Text.ToString) = "" Then
            Throw New Exception("El campo Cargo es obligatorio.")
        End If
        If Trim(txbNombre.Text.ToString) = "" Then
            Throw New Exception("El campo Nombre es obligatorio.")
        End If
        If Trim(txbAPaterno.Text.ToString) = "" Then
            Throw New Exception("El campo Apellido paterno es obligatorio.")
        End If
        If Trim(txbAMaterno.Text.ToString) = "" Then
            Throw New Exception("El campo Apellido materno es obligatorio.")
        End If
        If Trim(txbFechaNacimiento.Text.ToString) = "" Then
            Throw New Exception("El campo Nombre es obligatorio.")
        End If
        If Trim(txbCorreo.Text.ToString) <> "" Then
            If Regex.IsMatch(txbCorreo.Text, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") = False Then

                Throw New Exception("Ingresa un correo valido.")
            End If
        End If
    End Sub

    Private Sub btnAgregarTelefono_Click(sender As Object, e As EventArgs) Handles btnAgregarTelefono.Click
        Try
            If cmbTipoTelefono.SelectedItem.ToString = "Tipo" Then
                Throw New Exception("Seleccione el tipo de teléfono")
            End If
            If txbTelefono.Text = "" Then
                Throw New Exception("Escribe el número telefónico")
            End If
            Dim nuevoTelefono As New Telefono
            nuevoTelefono.numero = txbTelefono.Text
            nuevoTelefono.tipo = cmbTipoTelefono.SelectedItem.ToString
            Dim lista As New List(Of Telefono)
            If Session("listaTelefono") Is Nothing Then
                lista.Add(nuevoTelefono)
                Session("listaTelefono") = lista
            Else
                lista = Session("listaTelefono")
                If lista.Count = 0 Then
                    lista.Add(nuevoTelefono)
                    Session("listaTelefono") = lista
                Else
                    Dim bandera As Boolean = False
                    For i = 0 To lista.Count - 1
                        If lista(i).numero = nuevoTelefono.numero Then
                            bandera = True
                        End If
                    Next
                    If bandera = False Then
                        lista.Add(nuevoTelefono)
                        Session("listaTelefono") = lista
                    Else
                        Throw New Exception("El teléfono estaría duplicado.")
                    End If
                End If
            End If
            lvsTelefonos.DataSource = lista.ToList
            lvsTelefonos.DataBind()
            txbTelefono.Text = ""
            cmbTipoTelefono.SelectedValue = "Tipo"
        Catch ex As Exception
            NotificacionToast(ex.Message.ToString, tipoNotificacion.Alerta)
        End Try

    End Sub
    Protected Sub btnEliminarTelefono_Click(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        Dim lista As List(Of Telefono) = CType(Session("listaTelefono"), List(Of Telefono))
        lista.Remove(lista(CInt(btn.CommandArgument)))
        lvsTelefonos.DataSource = lista
        lvsTelefonos.DataBind()
        Session("listaTelefono") = lista
    End Sub
    Private Function lista_A_xml(ByVal lista As List(Of Telefono)) As String
        Dim cadenaXML As StringWriter = New StringWriter()
        Dim ordenarXML As New XmlSerializer(lista.GetType())
        ordenarXML.Serialize(cadenaXML, lista)
        Return cadenaXML.ToString
    End Function
    Protected Sub Upload(sender As Object, e As EventArgs)
        Try

            If Request.Files.Count > 0 Then
                Dim extensionArchivo As String = Path.GetExtension(img.FileName).ToLower()
                If (extensionArchivo = ".png" Or extensionArchivo = ".jpg" Or extensionArchivo = ".jpeg" Or extensionArchivo = ".gif") Then
                    Dim nombre As String = "foto_" + New Random().Next(1, 999999).ToString + Date.Now.Hour.ToString + Date.Now.Millisecond.ToString + extensionArchivo
                    Dim directorio As String = System.Web.HttpContext.Current.Server.MapPath("~/images/Funcionarios/" + nombre.ToString)
                    If File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/images/Funcionarios/" + lblFoto.Text.ToString)) Then
                        File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/images/Funcionarios/" + lblFoto.Text.ToString))
                    End If
                    img.SaveAs(directorio)
                    lblFoto.ToolTip = nombre
                    imgFoto.ImageUrl = "~/images/Funcionarios/" + nombre
                    lblFoto.Text = nombre
                Else
                    Throw New Exception("Formato de imágen no válida. Se esperaba (*.jpg | *.png | *.gif)")
                End If
            End If
        Catch ex As Exception
            NotificacionToast(ex.Message.ToString, tipoNotificacion.Alerta)
        End Try
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Response.Redirect("~/Management/Funcionario/Consultar.aspx")
    End Sub

End Class