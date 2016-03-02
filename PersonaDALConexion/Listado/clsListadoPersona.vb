Imports Entities
Imports System.Data.SqlClient

Public Class clsListadoPersona
#Region "Atributos"
    Private myConnection As clsMyConnection
#End Region

#Region "Constructores"
    Public Sub New()
        myConnection = New clsMyConnection()
    End Sub
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Return a List of Persona
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listadosPersonasDal() As List(Of Persona)

        Dim listPersona As New List(Of Persona)
        Dim miCommand As New SqlCommand
        'Igualamos a Nothing para evitar warnings
        Dim miConexion As SqlConnection = Nothing
        Dim readerPersona As SqlDataReader = Nothing
        Dim oPersona As Persona

        Try
            miConexion = myConnection.getConnection
            'ten en cuenta como hallas llamado a la tabla en la base de datos
            miCommand.CommandText = "Select * FROM Personas"
            miCommand.Connection = miConexion

            readerPersona = miCommand.ExecuteReader()

            'Rellenamos la lista
            If readerPersona.HasRows Then
                While readerPersona.Read
                    oPersona = New Persona
                    With oPersona
                        'Aqui el problema no seran los atributos de persona, los que tienes que vigilar son las 
                        .id = readerPersona.Item("IdPersona")
                        .Nombre = readerPersona.Item("nombre")
                        .Apellido = readerPersona.Item("apellidos")
                        .FechaNac = readerPersona.Item("fechaNac")
                        .Direccion = readerPersona.Item("direccion")
                        .Telefono = readerPersona.Item("telefono")
                    End With
                    listPersona.Add(oPersona)
                End While
            End If

            Return listPersona

        Catch ex As Exception
            Throw New Exception("Error al listar" & ex.Message)

        Finally
            readerPersona.Close()
            miConexion.Close()
        End Try


    End Function


    Public Sub insertPersona(personaMod As Persona)
        Dim añadirPersona As String
        Dim miCommand As New SqlCommand
        Dim resultado As Integer
        'Igualamos a Nothing para evitar warnings
        Dim miConexion As SqlConnection = Nothing

        añadirPersona = "INSERT INTO Personas VALUES ( @nombre , @apellido , @fechaNac , @direccion , @telefono)"
        Try
            miConexion = myConnection.getConnection
            miCommand.CommandText = añadirPersona
            miCommand.Connection = miConexion
            miCommand.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar))
            miCommand.Parameters("@nombre").Value = personaMod.Nombre
            miCommand.Parameters.Add(New SqlParameter("@apellido", SqlDbType.NVarChar))
            miCommand.Parameters("@apellido").Value = personaMod.Apellido
            miCommand.Parameters.Add(New SqlParameter("@fechaNac", SqlDbType.Date))
            miCommand.Parameters("@fechaNac").Value = personaMod.FechaNac
            miCommand.Parameters.Add(New SqlParameter("@direccion", personaMod.Direccion))
            miCommand.Parameters.Add(New SqlParameter("@telefono", SqlDbType.NVarChar))
            miCommand.Parameters("@telefono").Value = personaMod.Telefono
            resultado = miCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Error al insertar" & ex.Message)
        Finally
            miConexion.Close()
        End Try
    End Sub

    Public Sub modifiedPersona(personaMod As Persona)
        Dim borrarPersona As String
        Dim miCommand As New SqlCommand
        Dim resultado As Integer
        'Igualamos a Nothing para evitar warnings
        Dim miConexion As SqlConnection = Nothing

        borrarPersona = "UPDATE [dbo].[Personas] SET [nombre] = @nombre, [apellidos] = @apellidos , [fechaNac] = @fechaNac, [direccion] = @direccion ,[telefono] = @telefono WHERE [IdPersona] = @id"

        Try
            miConexion = myConnection.getConnection
            miCommand.CommandText = borrarPersona
            miCommand.Connection = miConexion
            miCommand.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar))
            miCommand.Parameters("@nombre").Value = personaMod.Nombre
            miCommand.Parameters.Add(New SqlParameter("@apellidos", SqlDbType.NVarChar))
            miCommand.Parameters("@apellidos").Value = personaMod.Apellido
            miCommand.Parameters.Add(New SqlParameter("@fechanac", SqlDbType.Date))
            miCommand.Parameters("@fechanac").Value = personaMod.FechaNac
            miCommand.Parameters.Add(New SqlParameter("@direccion", SqlDbType.NVarChar))
            miCommand.Parameters("@direccion").Value = personaMod.Direccion
            miCommand.Parameters.Add(New SqlParameter("@telefono", SqlDbType.NVarChar))
            miCommand.Parameters("@telefono").Value = personaMod.Telefono

            miCommand.Parameters.Add(New SqlParameter("@id", SqlDbType.Int))
            miCommand.Parameters("@id").Value = personaMod.id
            resultado = miCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error al modificar" & ex.Message)
        Finally
            miConexion.Close()
        End Try
    End Sub

    Public Sub deletePersona(id As Integer)
        Dim borrarPersona As String
        Dim miCommand As New SqlCommand
        Dim resultado As Integer
        'Igualamos a Nothing para evitar warnings
        Dim miConexion As SqlConnection = Nothing

        borrarPersona = "DELETE FROM Personas WHERE IDPersona = @id"
        Try
            miConexion = myConnection.getConnection
            miCommand.CommandText = borrarPersona
            miCommand.Connection = miConexion
            miCommand.Parameters.Add(New SqlParameter("@id", SqlDbType.Int))
            miCommand.Parameters("@id").Value = id
            resultado = miCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error al borrar" & ex.Message)
        Finally
            miConexion.Close()
        End Try
    End Sub

#End Region

End Class
