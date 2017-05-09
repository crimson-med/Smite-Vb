<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class V_PlayerStats
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.leaves = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.looses = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.wins = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.clanname = New System.Windows.Forms.Label()
        Me.playername = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.leveler = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.leaves)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.looses)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.wins)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 147)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 116)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Statistics: "
        '
        'leaves
        '
        Me.leaves.AutoSize = True
        Me.leaves.Location = New System.Drawing.Point(70, 82)
        Me.leaves.Name = "leaves"
        Me.leaves.Size = New System.Drawing.Size(31, 16)
        Me.leaves.TabIndex = 5
        Me.leaves.Text = "N/A"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Leaves: "
        '
        'looses
        '
        Me.looses.AutoSize = True
        Me.looses.Location = New System.Drawing.Point(70, 56)
        Me.looses.Name = "looses"
        Me.looses.Size = New System.Drawing.Size(31, 16)
        Me.looses.TabIndex = 3
        Me.looses.Text = "N/A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Looses: "
        '
        'wins
        '
        Me.wins.AutoSize = True
        Me.wins.Location = New System.Drawing.Point(70, 31)
        Me.wins.Name = "wins"
        Me.wins.Size = New System.Drawing.Size(31, 16)
        Me.wins.TabIndex = 1
        Me.wins.Text = "N/A"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Wins: "
        '
        'clanname
        '
        Me.clanname.AutoSize = True
        Me.clanname.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clanname.Location = New System.Drawing.Point(147, 53)
        Me.clanname.Name = "clanname"
        Me.clanname.Size = New System.Drawing.Size(135, 25)
        Me.clanname.TabIndex = 7
        Me.clanname.Text = "Player Name"
        '
        'playername
        '
        Me.playername.AutoSize = True
        Me.playername.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.playername.Location = New System.Drawing.Point(147, 12)
        Me.playername.Name = "playername"
        Me.playername.Size = New System.Drawing.Size(181, 31)
        Me.playername.TabIndex = 6
        Me.playername.Text = "Player Name"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'leveler
        '
        Me.leveler.AutoSize = True
        Me.leveler.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.leveler.Location = New System.Drawing.Point(146, 88)
        Me.leveler.Name = "leveler"
        Me.leveler.Size = New System.Drawing.Size(135, 25)
        Me.leveler.TabIndex = 9
        Me.leveler.Text = "Player Name"
        '
        'V_PlayerStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(512, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.clanname)
        Me.Controls.Add(Me.playername)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.leveler)
        Me.Name = "V_PlayerStats"
        Me.Text = "V_PlayerStats"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents leaves As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents looses As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents wins As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents clanname As Label
    Friend WithEvents playername As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents leveler As Label
End Class
