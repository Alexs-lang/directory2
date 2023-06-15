Imports CES.NspFuncionario
Imports CRN.NspFuncionario
Imports CES.NspTelefono
Imports CES.nspPopup
Imports System.IO
Imports System.Xml.Serialization
Imports Contexto.Notificaciones.controladorMensajes
Public Class Consultar
    Inherits paginaBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ObtenerFuncionarios()
        End If
    End Sub
    Private Sub ObtenerFuncionarios()
        Dim lista = New ProcObtenerFuncionarios() With {.tipoConsulta = TipoConsultaFuncionario.Todos}.Ejecutar()
        lvsFuncionarios.DataSource = lista
        lvsFuncionarios.DataBind()
    End Sub

    Private Sub BtnAgregarFuncionario_Click(sender As Object, e As EventArgs) Handles BtnAgregarFuncionario.Click
        Response.Redirect("~/Management/Funcionario/Agregar.aspx")
    End Sub
    Protected Sub btnVerInformacion_Click(sender As Object, e As EventArgs)
        Dim btn As Button = sender

        Dim funcionario = New ProcObtenerFuncionario() With {.id = Guid.Parse(btn.CommandArgument.ToString)}.Ejecutar
        If Not funcionario Is Nothing Then
            lblCargo.Text = funcionario.Cargo
            lblTipoFuncionario.Text = funcionario._TipoFuncionario
            lblNombre.Text = funcionario.Nombre + " " + funcionario.APaterno + " " + funcionario.AMaterno
            imgFoto.ImageUrl = "~/images/Funcionarios/" + funcionario.Foto
            ObtenerTelefono(funcionario.Telefono)
            lblCorreo.Text = funcionario.Correo
            iframeUbicacion.Attributes.Add("Src", funcionario.MapaOficina)
            lblFechaNacimiento.Text = funcionario.FechaNacimiento
        End If
        Dim sb As StringBuilder = New StringBuilder
        sb.Append("<script> $('#modalInformacion').modal('show');</script>")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "scriptmodal", sb.ToString, False)
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



    Protected Sub btnDesactivarActivar_Click(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        Dim mensaje As String = ""
        Dim funcionario = New ProcObtenerFuncionario() With {.id = Guid.Parse(btn.CommandArgument.ToString)}.Ejecutar
        If Not funcionario Is Nothing Then
            If funcionario.EsActivo = True Then
                mensaje = "El funcionario se desactivo correctamente"
                funcionario.EsActivo = False
            Else
                mensaje = "El funcionario se activo correctamente"
                funcionario.EsActivo = True
            End If
        End If
        Dim respuesta = New ProcEditarFuncionario() With {.entidad = funcionario}.Ejecutar()
        Select Case respuesta.respuesta
            Case tipoRespuestaDelProceso.Completado
                ObtenerFuncionarios()
                updLista.Update()
                NotificacionToast(mensaje, tipoNotificacion.Exitoso)
            Case tipoRespuestaDelProceso.Advertencia
                Throw New Exception(respuesta.comentario)
            Case tipoRespuestaDelProceso.NoCompletado
                Throw New Exception(respuesta.comentario)
        End Select
    End Sub

    Protected Sub BtnEditar_Click(sender As Object, e As EventArgs)
        Try
            Dim btn As LinkButton = sender
            Response.Redirect("~/Management/Funcionario/Editar.aspx?id=" + btn.CommandArgument.ToString)
        Catch ex As Exception

        End Try

    End Sub


End Class