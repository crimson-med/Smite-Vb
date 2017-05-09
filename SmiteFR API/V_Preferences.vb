Public Class V_Preferences
    Private Sub V_Preferences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = CurrentPlatform.ToString
        If IsDebug = True Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Store Old Platform
        Dim OldPlatform As Platform = CurrentPlatform
        'Update New Platform
        If ComboBox1.Text = "PS4" Then
            CurrentPlatform = Platform.PS4
        ElseIf ComboBox1.Text = "Xbox" Then
            CurrentPlatform = Platform.Xbox
        ElseIf ComboBox1.Text = "PC" Then
            CurrentPlatform = Platform.PC
        Else
            CurrentPlatform = Platform.PS4
        End If
        'Check if the platform changed
        If OldPlatform <> CurrentPlatform Then
            'Recreate Session from correct EndPoint
            CreateSession()
        End If
        'Update Platform Image
        Form1.UpdateImage()
        'Handle Debug Mode
        If CheckBox1.Checked = True Then
            IsDebug = True
        Else
            IsDebug = False
        End If
        Form1.UpdateDebug()
        Me.Close()
    End Sub
End Class