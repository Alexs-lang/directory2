Imports Contexto.Entidades.Persistencia.Relacional.Daos
Imports Contexto.Accion.Accion
Imports Contexto.Notificaciones.controladorMensajes
Imports CES.NspTipoFuncionario
Namespace NspTipoFuncionario
    Public Class ProcObtenerTipoFuncionarios : Inherits Accion(Of List(Of TipoFuncionario))
        Public Property tipoConsulta As TipoConsultaTipoFuncionario
        Public Property Id As Guid
        Public Property EsActivo As Boolean?

        Public Sub New()
            MyBase.New("ProcObtenerTipoFuncionarios", "Obtiene el listado de registros")
        End Sub

        Protected Overrides Function OnEjecutar() As List(Of TipoFuncionario)
            Dim parametros As New List(Of ParametroPredicado)
            parametros.Add(New ParametroPredicado("tipoConsulta", tipoConsulta))
            Select Case tipoConsulta
                Case TipoConsultaTipoFuncionario.id
                    parametros.Add(New ParametroPredicado("Id", Id))
                Case TipoConsultaTipoFuncionario.EsActivo
                    parametros.Add(New ParametroPredicado("EsActivo", EsActivo))
            End Select
            Return New CAD.nspControladorDaos.ControladorDaosBase().ObtenerDao(Of CAD.NspTipoFuncionario.DaoTipoFuncionario)().ObtenerConjunto(New Predicado("", parametros.ToArray()))
        End Function
    End Class

End Namespace

