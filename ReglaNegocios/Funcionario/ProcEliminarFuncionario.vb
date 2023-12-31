﻿Imports Contexto.Entidades.Persistencia.Relacional.Daos
Imports Contexto.Accion.Accion
Imports Contexto.Notificaciones.controladorMensajes
Imports System.Data.SqlClient
Imports CES.NspFuncionario
Namespace NspFuncionario
    Public Class ProcEliminarFuncionario : Inherits Accion(Of respuestaDelProceso)
        Public Property id As Guid
        Public Sub New()
            MyBase.New("ProcEliminarFuncionario", "Elimina un registro en la base de datos")
        End Sub
        Protected Overrides Function OnEjecutar() As respuestaDelProceso
            Dim respuesta As respuestaDelProceso = New respuestaDelProceso(tipoRespuestaDelProceso.Completado)
            Dim entidad = New ProcObtenerFuncionario() With {.id = id}.Ejecutar()
            Try
                Dim dao = New CAD.nspControladorDaos.ControladorDaosBase().ObtenerDao(Of CAD.NspFuncionario.DaoFuncionario)()
                dao.Eliminar(entidad)
                respuesta.comentario = "La acción se realizó con éxito.."
                respuesta.respuesta = tipoRespuestaDelProceso.Completado
            Catch exSQL As SqlException
                If exSQL.Number = 547 Then ' Cuando un registro ya fue ocupado, las siguientes lineas desactivan la entidad, solo cuando aplique.
                    Try
                        Dim dao = New CAD.nspControladorDaos.ControladorDaosBase().ObtenerDao(Of CAD.NspFuncionario.DaoFuncionario)()
                        entidad.esActivo = False
                        dao.Actualizar(entidad)
                    Catch ex2 As Exception
                        respuesta.comentario = "Ocurrió un error al eliminar el registro seleccionado."
                        respuesta.respuesta = tipoRespuestaDelProceso.NoCompletado
                    End Try
                Else
                End If
            Catch ex As Exception
                respuesta.comentario = "Ocurrió un error al eliminar el registro seleccionado."
                respuesta.respuesta = tipoRespuestaDelProceso.NoCompletado
            End Try
            Return respuesta
        End Function
    End Class

End Namespace

