Imports System.IO
'This Form handles the launch and verification of the API Dev & Auth Key
'
'For Future: This doesnt load previous session even if it is still valid
'
Public Class V_Key
    Private Sub V_Key_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check if credentials exist
        If CheckCredentials() = True Then
            'Try to connect
            If GetSession() = True Then
                'Can connect show form
                Form1.Show()
                Me.Close()
            ElseIf CreateSession() = True Then
                'Cant connect
                Form1.Show()
                Me.Close()
            End If
        End If
        'Get API Status maybe can't connect because API offline     
        PingAPI()
    End Sub

    'Connect Button Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Load DevKey & AuthKey to global variables
        DevKey = TextBox1.Text
        AuthKey = TextBox2.Text
        'Check if valid credentials
        If CreateSession() = True Then
            'Log correct credentials and show form1
            File.WriteAllText(AppID & "\ID.crimson", DevKey & "*" & AuthKey)
            Form1.Show()
            Me.Close()
        Else
            'Ooops can't connect
            MsgBox("Can't Login to API please try again!")
            PingAPI()
        End If
    End Sub

    'Update the API Status
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