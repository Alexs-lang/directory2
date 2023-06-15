Namespace nspUsuario
    <Serializable>
    Public Class usuario
        Public Property id As Guid?
        Public Property idPlantel As Guid?
        Public Property usuario As String
        Public Property rol As String
        Public Property contraseña As String
        Public Property cambiarContraseña As Boolean
        Public Property esActivo As Boolean
        Public Property ultimaSesion As DateTime?
        Public Property idUsuarioMovimiento As Guid?
        Public Property idDireccionUsuario As Guid?
        Public Property idAlumno As Guid?
        Public Property idDocente As Guid?
        Public Property idTutor As Guid?
        Public Property _nombrePlantel As String
        Public Property _idDireccion As Guid
        Public Property _claveCentroTrabajo As String
        Public Property _directorEscuela As String
        Public Property _subDirectorEscula As String
        Public Property _logo As String
        Public Property _telefono As String
        Public Property _correoElectronico As String
        Public Property _rfc As String
        Public Property _turno As String
        Public Property _incorporadoA As String
        Public Property tipoEdicion As tipoEdicionUsuario?
    End Class
End Namespace

