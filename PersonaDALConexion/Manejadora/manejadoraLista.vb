Imports Entities

Public Class manejadoraLista

#Region "Atributos"
    Private listaPersona As List(Of Persona)
    Private conexionDB As clsListadoPersona
#End Region

#Region "Constructor"
    Public Sub New()
        Try
            conexionDB = New clsListadoPersona()
            listaPersona = conexionDB.listadosPersonasDal()
        Catch ex As Exception
            Throw New Exception("No se puede conectar con la base de datos, vuelva a intentarlo más tarde" & ex.Message)
        End Try
    End Sub
#End Region

#Region "Metodos"

    Public Function listadosPersonasDal() As List(Of Persona)
        Return listaPersona
    End Function

    Public Function getPersona(ByVal id As Integer) As Persona
        Dim persona As Persona
        persona = Nothing

        For Each elementoPersona As Persona In listaPersona
            If id = elementoPersona.id Then
                persona = elementoPersona
            End If
        Next

        If persona.Equals(Nothing) Then
            Throw New Exception("Persona no encontrada")
        End If

        Return (persona)
    End Function

    Public Sub savePersona(ByVal personaMod As Persona)

        If (personaMod.id.Equals(-1)) Then
            conexionDB.insertPersona(personaMod)
        Else
            conexionDB.modifiedPersona(personaMod)
        End If
    End Sub

    Public Sub deletePersona(ByVal id As Integer)
        Dim persona As Persona

        Try
            persona = getPersona(id)
        Catch ex As Exception
            Throw New Exception("La persona no se pudo borrar")
        End Try

        conexionDB.deletePersona(persona.id)
    End Sub
#End Region
End Class
