Imports System.Data.SqlClient
Imports CAD.nspControladorDaos
Imports Contexto.Persistencia.Relacional.Sql
Imports CES.NspTipoFuncionario
Namespace NspTipoFuncionario
    Public Class DaoTipoFuncionario : Inherits DaoSql(Of TipoFuncionario)
        Public Sub New(controladorDaos As ControladorDaosBase)
            MyBase.New(controladorDaos)
        End Sub

        Protected Overrides Sub OnConfigurarComandoSeleccion(comando As SqlCommand, Optional predicado As Contexto.Entidades.Persistencia.Relacional.Daos.Predicado = Nothing)
            If (Not predicado.ContieneParametro("tipoConsulta")) Then
                Throw New NotSupportedException("Imposible continuar: no contiene parametro correcto.")
            End If
            Dim tipoConsulta As TipoConsultaTipoFuncionario = CType(predicado.Parametros("tipoConsulta").Valor, TipoConsultaTipoFuncionario)
            Select Case tipoConsulta
                Case TipoConsultaTipoFuncionario.id
                    comando.Parameters.AddWithValue("@Accion", 1)
                    comando.Parameters.AddWithValue("@Id", predicado.Parametros("Id").Valor)
                Case TipoConsultaTipoFuncionario.EsActivo
                    comando.Parameters.AddWithValue("@Accion", 2)
                    comando.Parameters.AddWithValue("@EsActivo", predicado.Parametros("EsActivo").Valor)

                Case TipoConsultaTipoFuncionario.todos
                    comando.Parameters.AddWithValue("@Accion", 99)
            End Select

            comando.CommandText = "ProcObtenerTipoFuncionario"
            comando.CommandType = CommandType.StoredProcedure
        End Sub

        Protected Overrides Function OnConfigurarEntidadSeleccionada(lectorRenglonActual As SqlDataReader) As TipoFuncionario
            Return New TipoFuncionario() With {.Id = Guid.Parse(lectorRenglonActual("id").ToString),
                                                .Tipo = lectorRenglonActual("Tipo").ToString,
                                                .EsActivo = Boolean.Parse(lectorRenglonActual("esActivo").ToString)}
        End Function

        Protected Overrides Sub OnConfigurarComandoInsertar(comando As SqlCommand, entidad As TipoFuncionario)
            If (Not IsNothing(entidad)) Then
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "ProcAgregarTipoFuncionario"
                comando.Parameters.AddWithValue("@id", entidad.Id)
                ' Si hay mas campos escribelos aquí
            Else
                Throw New NotSupportedException("Imposible continuar: Entidad no contiene datos.")
            End If
        End Sub

        Protected Overrides Sub OnConfigurarComandoActualizar(comando As SqlCommand, entidad As TipoFuncionario)
            If (Not IsNothing(entidad)) Then
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "ProcEditarTipoFuncionario"
                comando.Parameters.AddWithValue("@id", entidad.Id)
                ' Si hay mas campos escribelos aquí
            Else
                Throw New NotSupportedException("Imposible continuar: Entidad no contiene datos.")
            End If
        End Sub

        Protected Overrides Sub OnConfigurarComandoEliminar(comando As SqlCommand, entidad As TipoFuncionario)
            If (Not IsNothing(entidad)) Then
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "ProcEliminarTipoFuncionario"
                comando.Parameters.AddWithValue("@id", entidad.Id)
            Else
                Throw New NotSupportedException("Imposible continuar: Entidad no contiene datos.")
            End If
        End Sub
    End Class
End Namespace


