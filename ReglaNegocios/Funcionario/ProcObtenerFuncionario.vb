Imports Contexto.Entidades.Persistencia.Relacional.Daos
Imports Contexto.Accion.Accion
Imports Contexto.Notificaciones.controladorMensajes
Imports CES.NspFuncionario
Namespace NspFuncionario
    Public Class ProcObtenerFuncionario : Inherits Accion(Of Funcionario)
        Public Property id As Guid
        Public Sub New()
            MyBase.New("ProcObtenerFuncionario", "Obtiene un registro")
        End Sub
        Protected Overrides Function OnEjecutar() As Funcionario
            Return New ProcObtenerFuncionarios() With {.tipoConsulta = TipoConsultaFuncionario.Id, .id = id}.Ejecutar().FirstOrDefault()
        End Function
    End Class

End Namespace

