Imports System.Data.SqlClient
Imports CAD.nspControladorDaos
Imports Contexto.Persistencia.Relacional.Sql
Imports CES.NspFuncionario
Namespace NspFuncionario
    Public Class DaoFuncionario : Inherits DaoSql(Of Funcionario)
        Public Sub New(controladorDaos As ControladorDaosBase)
            MyBase.New(controladorDaos)
        End Sub

        Protected Overrides Sub OnConfigurarComandoSeleccion(comando As SqlCommand, Optional predicado As Contexto.Entidades.Persistencia.Relacional.Daos.Predicado = Nothing)
            If (Not predicado.ContieneParametro("tipoConsulta")) Then
                Throw New NotSupportedException("Imposible continuar: no contiene parametro correcto.")
            End If
            Dim tipoConsulta As TipoConsultaFuncionario = CType(predicado.Parametros("tipoConsulta").Valor, TipoConsultaFuncionario)
            Select Case tipoConsulta
                Case TipoConsultaFuncionario.Id
                    comando.Parameters.AddWithValue("@Accion", 1)
                    comando.Parameters.AddWithValue("@id", predicado.Parametros("id").Valor)
                Case TipoConsultaFuncionario.Nombre
                    comando.Parameters.AddWithValue("@Accion", 2)
                    comando.Parameters.AddWithValue("@esActivo", predicado.Parametros("esActivo").Valor)
                Case TipoConsultaFuncionario.IdTipoFuncionario
                    comando.Parameters.AddWithValue("@Accion", 3)
                    comando.Parameters.AddWithValue("@esActivo", predicado.Parametros("esActivo").Valor)
                Case TipoConsultaFuncionario.EsActivo
                    comando.Parameters.AddWithValue("@Accion", 4)
                    comando.Parameters.AddWithValue("@esActivo", predicado.Parametros("esActivo").Valor)

                Case TipoConsultaFuncionario.Todos
                    comando.Parameters.AddWithValue("@Accion", 99)
            End Select

            comando.CommandText = "ProcObtenerFuncionario"
            comando.CommandType = CommandType.StoredProcedure
        End Sub

        Protected Overrides Function OnConfigurarEntidadSeleccionada(lectorRenglonActual As SqlDataReader) As Funcionario
            Dim entidad As New Funcionario
            entidad.Id = Guid.Parse(lectorRenglonActual("Id").ToString)
            entidad.IdTipoFuncionario = Guid.Parse(lectorRenglonActual("IdTipoFuncionario").ToString)
            entidad.Nombre = lectorRenglonActual("Nombre").ToString
            entidad.APaterno = lectorRenglonActual("APaterno").ToString
            entidad.AMaterno = lectorRenglonActual("AMaterno").ToString
            entidad.Cargo = lectorRenglonActual("Cargo").ToString
            If lectorRenglonActual("MapaOficina").ToString <> "" Then
                entidad.MapaOficina = lectorRenglonActual("MapaOficina").ToString
            End If
            If lectorRenglonActual("Telefono").ToString <> "" Then
                entidad.Telefono = lectorRenglonActual("Telefono").ToString
            End If
            If lectorRenglonActual("Correo").ToString <> "" Then
                entidad.Correo = lectorRenglonActual("Correo").ToString
            End If
            entidad.FechaNacimiento = lectorRenglonActual("FechaNacimiento").ToString
            If lectorRenglonActual("Foto").ToString <> "" Then
                entidad.Foto = lectorRenglonActual("Foto").ToString
            End If
            entidad.EsActivo = lectorRenglonActual("EsActivo").ToString
            entidad.FechaCaptura = lectorRenglonActual("FechaCaptura").ToString
            entidad._TipoFuncionario = lectorRenglonActual("_TipoFuncionario").ToString
            Return entidad
        End Function

        Protected Overrides Sub OnConfigurarComandoInsertar(comando As SqlCommand, entidad As Funcionario)
            If (Not IsNothing(entidad)) Then
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "ProcAgregarFuncionario"
                comando.Parameters.AddWithValue("@IdTipoFuncionario", entidad.IdTipoFuncionario)
                comando.Parameters.AddWithValue("@Nombre", entidad.Nombre)
                comando.Parameters.AddWithValue("@APaterno", entidad.APaterno)
                comando.Parameters.AddWithValue("@AMaterno", entidad.AMaterno)
                comando.Parameters.AddWithValue("@Cargo", entidad.Cargo)
                If Not entidad.MapaOficina Is Nothing Then
                    comando.Parameters.AddWithValue("@MapaOficina", entidad.MapaOficina)
                End If
                If Not entidad.Telefono Is Nothing Then
                    comando.Parameters.AddWithValue("@Telefono", entidad.Telefono)
                End If
                If Not entidad.Correo Is Nothing Then
                    comando.Parameters.AddWithValue("@Correo", entidad.Correo)
                End If
                comando.Parameters.AddWithValue("@FechaNacimiento", entidad.FechaNacimiento)
                If Not entidad.Foto Is Nothing Then
                    comando.Parameters.AddWithValue("@Foto", entidad.Foto)
                End If
            Else
                Throw New NotSupportedException("Imposible continuar: Entidad no contiene datos.")
            End If
        End Sub

        Protected Overrides Sub OnConfigurarComandoActualizar(comando As SqlCommand, entidad As Funcionario)
            If (Not IsNothing(entidad)) Then
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "ProcEditarFuncionario"
                comando.Parameters.AddWithValue("@id", entidad.Id)
                comando.Parameters.AddWithValue("@IdTipoFuncionario", entidad.IdTipoFuncionario)
                comando.Parameters.AddWithValue("@Nombre", entidad.Nombre)
                comando.Parameters.AddWithValue("@APaterno", entidad.APaterno)
                comando.Parameters.AddWithValue("@AMaterno", entidad.AMaterno)
                comando.Parameters.AddWithValue("@Cargo", entidad.Cargo)
                If Not entidad.MapaOficina Is Nothing Then
                    comando.Parameters.AddWithValue("@MapaOficina", entidad.MapaOficina)
                End If
                If Not entidad.Telefono Is Nothing Then
                    comando.Parameters.AddWithValue("@Telefono", entidad.Telefono)
                End If
                If Not entidad.Correo Is Nothing Then
                    comando.Parameters.AddWithValue("@Correo", entidad.Correo)
                End If
                comando.Parameters.AddWithValue("@FechaNacimiento", entidad.FechaNacimiento)
                If Not entidad.Foto Is Nothing Then
                    comando.Parameters.AddWithValue("@Foto", entidad.Foto)
                End If
                comando.Parameters.AddWithValue("@EsActivo", entidad.EsActivo)
            Else
                Throw New NotSupportedException("Imposible continuar: Entidad no contiene datos.")
            End If
        End Sub

        Protected Overrides Sub OnConfigurarComandoEliminar(comando As SqlCommand, entidad As Funcionario)
            If (Not IsNothing(entidad)) Then
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandText = "ProcEliminarFuncionario"
                comando.Parameters.AddWithValue("@id", entidad.Id)

            Else
                Throw New NotSupportedException("Imposible continuar: Entidad no contiene datos.")
            End If
        End Sub
    End Class
End Namespace






