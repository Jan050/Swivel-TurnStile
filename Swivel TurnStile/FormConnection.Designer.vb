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
        Me.lblPort10001 = New System.Windows.Forms.Label()
        Me.lbConnectedClients10001 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnStopServer = New System.Windows.Forms.Button()
        Me.btnStartServer = New System.Windows.Forms.Button()
        Me.lblPort10002 = New System.Windows.Forms.Label()
        Me.lbConnectedClients10002 = New System.Windows.Forms.Label()
        Me.lstClients10001 = New System.Windows.Forms.ListBox()
        Me.lstClients10002 = New System.Windows.Forms.ListBox()
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
        'lblPort10001
        '
        Me.lblPort10001.AutoSize = True
        Me.lblPort10001.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPort10001.Location = New System.Drawing.Point(12, 34)
        Me.lblPort10001.Name = "lblPort10001"
        Me.lblPort10001.Size = New System.Drawing.Size(72, 16)
        Me.lblPort10001.TabIndex = 5
        Me.lblPort10001.Text = "Port: 10001"
        '
        'lbConnectedClients10001
        '
        Me.lbConnectedClients10001.AutoSize = True
        Me.lbConnectedClients10001.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbConnectedClients10001.Location = New System.Drawing.Point(12, 53)
        Me.lbConnectedClients10001.Name = "lbConnectedClients10001"
        Me.lbConnectedClients10001.Size = New System.Drawing.Size(174, 16)
        Me.lbConnectedClients10001.TabIndex = 6
        Me.lbConnectedClients10001.Text = "Connected Clients (10001): 0"
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
        Me.GroupBox1.Text = "Gate 1 (Port 10001)"
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
        Me.GroupBox2.Text = "Gate 2 (Port 10002)"
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
        'lblPort10002
        '
        Me.lblPort10002.AutoSize = True
        Me.lblPort10002.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPort10002.Location = New System.Drawing.Point(83, 34)
        Me.lblPort10002.Name = "lblPort10002"
        Me.lblPort10002.Size = New System.Drawing.Size(72, 16)
        Me.lblPort10002.TabIndex = 11
        Me.lblPort10002.Text = "Port: 10002"
        '
        'lbConnectedClients10002
        '
        Me.lbConnectedClients10002.AutoSize = True
        Me.lbConnectedClients10002.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbConnectedClients10002.Location = New System.Drawing.Point(12, 69)
        Me.lbConnectedClients10002.Name = "lbConnectedClients10002"
        Me.lbConnectedClients10002.Size = New System.Drawing.Size(174, 16)
        Me.lbConnectedClients10002.TabIndex = 12
        Me.lbConnectedClients10002.Text = "Connected Clients (10002): 0"
        '
        'lstClients10001
        '
        Me.lstClients10001.FormattingEnabled = True
        Me.lstClients10001.Location = New System.Drawing.Point(15, 280)
        Me.lstClients10001.Name = "lstClients10001"
        Me.lstClients10001.Size = New System.Drawing.Size(294, 82)
        Me.lstClients10001.TabIndex = 13
        '
        'lstClients10002
        '
        Me.lstClients10002.FormattingEnabled = True
        Me.lstClients10002.Location = New System.Drawing.Point(15, 390)
        Me.lstClients10002.Name = "lstClients10002"
        Me.lstClients10002.Size = New System.Drawing.Size(294, 82)
        Me.lstClients10002.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Clients (Port 10001):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 374)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Clients (Port 10002):"
        '
        'FormConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 485)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lstClients10002)
        Me.Controls.Add(Me.lstClients10001)
        Me.Controls.Add(Me.lbConnectedClients10002)
        Me.Controls.Add(Me.lblPort10002)
        Me.Controls.Add(Me.btnStartServer)
        Me.Controls.Add(Me.btnStopServer)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbConnectedClients10001)
        Me.Controls.Add(Me.lblPort10001)
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
    Friend WithEvents lblPort10001 As Label
    Friend WithEvents lbConnectedClients10001 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnStopServer As Button
    Friend WithEvents btnStartServer As Button
    Friend WithEvents lblPort10002 As Label
    Friend WithEvents lbConnectedClients10002 As Label
    Friend WithEvents lstClients10001 As ListBox
    Friend WithEvents lstClients10002 As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class