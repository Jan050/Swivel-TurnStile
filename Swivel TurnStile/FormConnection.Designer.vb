<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConnection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tbUDIGate1IN = New System.Windows.Forms.TextBox()
        Me.tbUDIGate1OUT = New System.Windows.Forms.TextBox()
        Me.tbUDIGate2IN = New System.Windows.Forms.TextBox()
        Me.tbUDIGate2OUT = New System.Windows.Forms.TextBox()
        Me.lbServerStatus = New System.Windows.Forms.Label()
        Me.lblPort7070 = New System.Windows.Forms.Label()
        Me.lbConnectedClients7070 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnStopServer = New System.Windows.Forms.Button()
        Me.btnStartServer = New System.Windows.Forms.Button()
        Me.lblPort8080 = New System.Windows.Forms.Label()
        Me.lbConnectedClients8080 = New System.Windows.Forms.Label()
        Me.lstClients7070 = New System.Windows.Forms.ListBox()
        Me.lstClients8080 = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbUDIGate1IN
        '
        Me.tbUDIGate1IN.BackColor = System.Drawing.SystemColors.Info
        Me.tbUDIGate1IN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUDIGate1IN.Location = New System.Drawing.Point(65, 19)
        Me.tbUDIGate1IN.Name = "tbUDIGate1IN"
        Me.tbUDIGate1IN.ReadOnly = True
        Me.tbUDIGate1IN.Size = New System.Drawing.Size(223, 22)
        Me.tbUDIGate1IN.TabIndex = 0
        '
        'tbUDIGate1OUT
        '
        Me.tbUDIGate1OUT.BackColor = System.Drawing.SystemColors.Info
        Me.tbUDIGate1OUT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUDIGate1OUT.Location = New System.Drawing.Point(65, 47)
        Me.tbUDIGate1OUT.Name = "tbUDIGate1OUT"
        Me.tbUDIGate1OUT.ReadOnly = True
        Me.tbUDIGate1OUT.Size = New System.Drawing.Size(223, 22)
        Me.tbUDIGate1OUT.TabIndex = 1
        '
        'tbUDIGate2IN
        '
        Me.tbUDIGate2IN.BackColor = System.Drawing.SystemColors.Info
        Me.tbUDIGate2IN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUDIGate2IN.Location = New System.Drawing.Point(65, 19)
        Me.tbUDIGate2IN.Name = "tbUDIGate2IN"
        Me.tbUDIGate2IN.ReadOnly = True
        Me.tbUDIGate2IN.Size = New System.Drawing.Size(223, 22)
        Me.tbUDIGate2IN.TabIndex = 2
        '
        'tbUDIGate2OUT
        '
        Me.tbUDIGate2OUT.BackColor = System.Drawing.SystemColors.Info
        Me.tbUDIGate2OUT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUDIGate2OUT.Location = New System.Drawing.Point(65, 47)
        Me.tbUDIGate2OUT.Name = "tbUDIGate2OUT"
        Me.tbUDIGate2OUT.ReadOnly = True
        Me.tbUDIGate2OUT.Size = New System.Drawing.Size(223, 22)
        Me.tbUDIGate2OUT.TabIndex = 3
        '
        'lbServerStatus
        '
        Me.lbServerStatus.AutoSize = True
        Me.lbServerStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbServerStatus.Location = New System.Drawing.Point(12, 9)
        Me.lbServerStatus.Name = "lbServerStatus"
        Me.lbServerStatus.Size = New System.Drawing.Size(104, 16)
        Me.lbServerStatus.TabIndex = 4
        Me.lbServerStatus.Text = "Server Status:"
        '
        'lblPort7070
        '
        Me.lblPort7070.AutoSize = True
        Me.lblPort7070.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPort7070.Location = New System.Drawing.Point(12, 34)
        Me.lblPort7070.Name = "lblPort7070"
        Me.lblPort7070.Size = New System.Drawing.Size(65, 16)
        Me.lblPort7070.TabIndex = 5
        Me.lblPort7070.Text = "Port: 7070"
        '
        'lbConnectedClients7070
        '
        Me.lbConnectedClients7070.AutoSize = True
        Me.lbConnectedClients7070.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbConnectedClients7070.Location = New System.Drawing.Point(12, 53)
        Me.lbConnectedClients7070.Name = "lbConnectedClients7070"
        Me.lbConnectedClients7070.Size = New System.Drawing.Size(161, 16)
        Me.lbConnectedClients7070.TabIndex = 6
        Me.lbConnectedClients7070.Text = "Connected Clients (7070): 0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbUDIGate1IN)
        Me.GroupBox1.Controls.Add(Me.tbUDIGate1OUT)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 80)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gate 1 (Port 7070)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Reader 1:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Reader 2:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.tbUDIGate2IN)
        Me.GroupBox2.Controls.Add(Me.tbUDIGate2OUT)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(294, 80)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gate 2 (Port 8080)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Reader 3:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Reader 4:"
        '
        'btnStopServer
        '
        Me.btnStopServer.Location = New System.Drawing.Point(234, 27)
        Me.btnStopServer.Name = "btnStopServer"
        Me.btnStopServer.Size = New System.Drawing.Size(75, 23)
        Me.btnStopServer.TabIndex = 9
        Me.btnStopServer.Text = "Stop Server"
        Me.btnStopServer.UseVisualStyleBackColor = True
        '
        'btnStartServer
        '
        Me.btnStartServer.Location = New System.Drawing.Point(153, 27)
        Me.btnStartServer.Name = "btnStartServer"
        Me.btnStartServer.Size = New System.Drawing.Size(75, 23)
        Me.btnStartServer.TabIndex = 10
        Me.btnStartServer.Text = "Start Server"
        Me.btnStartServer.UseVisualStyleBackColor = True
        '
        'lblPort8080
        '
        Me.lblPort8080.AutoSize = True
        Me.lblPort8080.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPort8080.Location = New System.Drawing.Point(83, 34)
        Me.lblPort8080.Name = "lblPort8080"
        Me.lblPort8080.Size = New System.Drawing.Size(65, 16)
        Me.lblPort8080.TabIndex = 11
        Me.lblPort8080.Text = "Port: 8080"
        '
        'lbConnectedClients8080
        '
        Me.lbConnectedClients8080.AutoSize = True
        Me.lbConnectedClients8080.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbConnectedClients8080.Location = New System.Drawing.Point(12, 69)
        Me.lbConnectedClients8080.Name = "lbConnectedClients8080"
        Me.lbConnectedClients8080.Size = New System.Drawing.Size(161, 16)
        Me.lbConnectedClients8080.TabIndex = 12
        Me.lbConnectedClients8080.Text = "Connected Clients (8080): 0"
        '
        'lstClients7070
        '
        Me.lstClients7070.FormattingEnabled = True
        Me.lstClients7070.Location = New System.Drawing.Point(15, 280)
        Me.lstClients7070.Name = "lstClients7070"
        Me.lstClients7070.Size = New System.Drawing.Size(294, 82)
        Me.lstClients7070.TabIndex = 13
        '
        'lstClients8080
        '
        Me.lstClients8080.FormattingEnabled = True
        Me.lstClients8080.Location = New System.Drawing.Point(15, 390)
        Me.lstClients8080.Name = "lstClients8080"
        Me.lstClients8080.Size = New System.Drawing.Size(294, 82)
        Me.lstClients8080.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Clients (Port 7070):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 374)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Clients (Port 8080):"
        '
        'FormConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 485)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lstClients8080)
        Me.Controls.Add(Me.lstClients7070)
        Me.Controls.Add(Me.lbConnectedClients8080)
        Me.Controls.Add(Me.lblPort8080)
        Me.Controls.Add(Me.btnStartServer)
        Me.Controls.Add(Me.btnStopServer)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbConnectedClients7070)
        Me.Controls.Add(Me.lblPort7070)
        Me.Controls.Add(Me.lbServerStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormConnection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TCP Server - Turnstile Control"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbUDIGate1IN As TextBox
    Friend WithEvents tbUDIGate1OUT As TextBox
    Friend WithEvents tbUDIGate2IN As TextBox
    Friend WithEvents tbUDIGate2OUT As TextBox
    Friend WithEvents lbServerStatus As Label
    Friend WithEvents lblPort7070 As Label
    Friend WithEvents lbConnectedClients7070 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnStopServer As Button
    Friend WithEvents btnStartServer As Button
    Friend WithEvents lblPort8080 As Label
    Friend WithEvents lbConnectedClients8080 As Label
    Friend WithEvents lstClients7070 As ListBox
    Friend WithEvents lstClients8080 As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class