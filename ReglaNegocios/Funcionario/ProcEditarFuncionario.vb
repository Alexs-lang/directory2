﻿Imports Contexto.Entidades.Persistencia.Relacional.Daos
Imports Contexto.Accion.Accion
Imports Contexto.Notificaciones.controladorMensajes
Imports System.Data.SqlClient
Imports CES.NspFuncionario
Namespace NspFuncionario
    Public Class ProcEditarFuncionario : Inherits Accion(Of respuestaDelProceso)
        Public Property entidad As Funcionario
        Public Sub New()
            MyBase.New("ProcEditarFuncionario", "Actualiza un registro a la base de datos")
        End Sub
        Protected Overrides Function OnEjecutar() As respuestaDelProceso
            Dim respuesta As respuestaDelProceso = New respuestaDelProceso(tipoRespuestaDelProceso.Completado)
            Try
                Dim dao = New CAD.nspControladorDaos.ControladorDaosBase().ObtenerDao(Of CAD.NspFuncionario.DaoFuncionario)()
                dao.Actualizar(entidad)
                respuesta.comentario = "ok"
                respuesta.respuesta = tipoRespuestaDelProceso.Completado
            Catch ex As SqlException
                If ex.Number = 2601 Then
                    respuesta.comentario = "No puede duplicar la información en la base de datos."
                    respuesta.respuesta = tipoRespuestaDelProceso.NoCompletado
                Else
                    respuesta.comentario = ex.Message.ToString
                    respuesta.respuesta = tipoRespuestaDelProceso.NoCompletado
                End If
            Catch ex As Exception
                respuesta.comentario = "Ocurrió un error al agregar un registro en la base de datos"
                respuesta.respuesta = tipoRespuestaDelProceso.NoCompletado
            End Try
            Return respuesta
        End Function

    End Class
End Namespace

