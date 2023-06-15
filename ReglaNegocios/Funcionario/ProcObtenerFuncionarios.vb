Imports Contexto.Entidades.Persistencia.Relacional.Daos
Imports Contexto.Accion.Accion
Imports Contexto.Notificaciones.controladorMensajes
Imports CES.NspFuncionario
Namespace NspFuncionario
    Public Class ProcObtenerFuncionarios : Inherits Accion(Of List(Of Funcionario))
        Public Property tipoConsulta As TipoConsultaFuncionario
        Public Property id As Guid?
        Public Property APaterno As String
        Public Property AMaterno As String
        Public Property IdTipoFuncionario As Guid?
        Public Property EsActivo As Boolean?


        Public Sub New()
            MyBase.New("ProcObtenerFuncionarios", "Obtiene el listado de registros")
        End Sub

        Protected Overrides Function OnEjecutar() As List(Of Funcionario)
            Dim parametros As New List(Of ParametroPredicado)
            parametros.Add(New ParametroPredicado("tipoConsulta", tipoConsulta))
            Select Case tipoConsulta
                Case TipoConsultaFuncionario.Id
                    parametros.Add(New ParametroPredicado("id", id))
                Case TipoConsultaFuncionario.Nombre
                    parametros.Add(New ParametroPredicado("nombre", Nombre))
                    parametros.Add(New ParametroPredicado("APaterno", APaterno))
                    parametros.Add(New ParametroPredicado("AMaterno", AMaterno))
                Case TipoConsultaFuncionario.IdTipoFuncionario
                    parametros.Add(New ParametroPredicado("IdTipoFuncionario", IdTipoFuncionario))
                Case TipoConsultaFuncionario.EsActivo
                    parametros.Add(New ParametroPredicado("EsActivo", EsActivo))
            End Select
            Return New CAD.nspControladorDaos.ControladorDaosBase().ObtenerDao(Of CAD.NspFuncionario.DaoFuncionario)().ObtenerConjunto(New Predicado("", parametros.ToArray()))
        End Function
    End Class

End Namespace
