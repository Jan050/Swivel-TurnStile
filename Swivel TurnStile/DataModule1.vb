Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Module DataModule1

    Public con As New SqlConnection
    Public cmd As New SqlCommand
    Public dr As SqlDataReader
    Public da As SqlDataAdapter
    Public comPort As String
    Public baudRate As String
    Public timeOut As String
    Public username As String
    Public password As String
    Public fullname As String
    Public useracctType As String
    Public client As New Net.Sockets.TcpClient
    Public rx As StreamReader
    Public tx As StreamWriter
    Public rawdata As String

    Function ImageToByte(image As Image) As Byte()
        If image Is Nothing Then
            Return Nothing
        End If
        Try
            Using ms As New MemoryStream()
                ' Use PNG format for better quality and compatibility
                image.Save(ms, Imaging.ImageFormat.Png)
                Return ms.ToArray()
            End Using
        Catch ex As Exception
            Debug.WriteLine($"ImageToByte error: {ex.Message}")
            Return Nothing
        End Try
    End Function

    Function ByteToImage(imageBytes As Byte()) As Image
        If imageBytes Is Nothing OrElse imageBytes.Length = 0 Then
            Return Nothing
        End If
        Try
            Using ms As New MemoryStream(imageBytes)
                ' Create a copy to avoid stream disposal issues
                Dim originalImage = Image.FromStream(ms)
                Dim copyImage As New Bitmap(originalImage)
                originalImage.Dispose()
                Return copyImage
            End Using
        Catch ex As Exception
            Debug.WriteLine($"ByteToImage error: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ' ✅ Use connection string from App.config
    Sub Connection()
        Dim connStr As String = ConfigurationManager.ConnectionStrings("Swivel_TurnStile.My.MySettings.MyDataBaseConnectionString").ConnectionString 'Swivel_TurnStile.My.MySettings.MyDataBaseConnectionString
        con = New SqlConnection(connStr)
    End Sub

    Sub GetUserName()
        Try
            Connection() ' Always initialize connection properly
            con.Open()
            cmd = New SqlCommand("SELECT * FROM tblUser WHERE username = @username AND password = @password", con)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)

            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                fullname = dr("fullname").ToString()
                useracctType = dr("accountType").ToString()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)

        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                dr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

End Module
