Imports System.IO
Public Class V_Key
    Private Sub V_Key_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CheckCredentials() = True Then
            If GetSession() = True Then
                Form1.Show()
                Me.Close()
            ElseIf CreateSession() = True Then
                Form1.Show()
                Me.Close()
            End If
        End If
        PingAPI()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DevKey = TextBox1.Text
        AuthKey = TextBox2.Text
        If CreateSession() = True Then
            File.WriteAllText(AppID & "\ID.crimson", DevKey & "*" & AuthKey)
            Form1.Show()
            Me.Close()
        Else
            MsgBox("Can't Login to API please try again!")
            PingAPI()
        End If
    End Sub

    Public Sub PingAPI()
        Dim IsOnline As Boolean = RequestPing()
        If IsOnline = True Then
            Label2.ForeColor = Color.DarkGreen
            Label2.Text = "Online"
        Else
            Label2.ForeColor = Color.DarkRed
            Label2.Text = "Offline"
        End If
    End Sub
End Class