Imports System.ComponentModel.DataAnnotations
''' Class Persona
''' <summary>
''' It contains data from a person through Fields
''' </summary>
''' Fields:                 Accesible       editable
''' nombre as String        true            true
''' apellido as String      true            true
''' fechaNac as Date        true            true
''' direccion as String     true            true
''' telefono as String      true            true
''' <remarks></remarks>

Public Class Persona
#Region "Fields"
    Private _id As Integer
    Private _nombre As String
    Private _apellido As String
    Private _fechaNac As Date
    Private _direccion As String
    Private _telefono As String
#End Region
#Region "Constructor"

    'Por defecto
    Public Sub New()
        _nombre = "Nueva"
        _apellido = "Persona"
        _fechaNac = Nothing
        _direccion = Nothing
        _telefono = Nothing
    End Sub

    'Con parametros
    Public Sub New(ByVal nombre As String, ByVal apellidos As String, ByVal fechaNac As Date, ByVal direccion As String, ByVal telefono As String)
        _id = -1
        _nombre = nombre
        _apellido = apellidos
        _fechaNac = fechaNac
        _direccion = direccion
        _telefono = telefono
    End Sub
#End Region

#Region "Properties"
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
    <Required>
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    <Required>
    Public Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = value
        End Set
    End Property
    <Required>
    Public Property FechaNac As Date
        Get
            Return _fechaNac
        End Get
        Set(value As Date)
            _fechaNac = value
        End Set
    End Property
    <Required>
    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property
    <Required>
    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property

#End Region

End Class
