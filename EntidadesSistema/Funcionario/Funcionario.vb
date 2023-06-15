Namespace NspFuncionario
    <Serializable>
    Public Class Funcionario
        Public Property Id As Guid
        Public Property IdTipoFuncionario As Guid
        Public Property Nombre As String
        Public Property APaterno As String
        Public Property AMaterno As String
        Public Property Cargo As String
        Public Property MapaOficina As String
        Public Property Telefono As String
        Public Property Correo As String
        Public Property FechaNacimiento As Date?
        Public Property Foto As String
        Public Property EsActivo As Boolean
        Public Property FechaCaptura As DateTime
        Public Property _TipoFuncionario As String

    End Class
End Namespace

