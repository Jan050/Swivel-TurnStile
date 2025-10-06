<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPorts = New System.Windows.Forms.ComboBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvAttendance = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnLoadData = New System.Windows.Forms.Button()
        Me.btnCheckNewRecords = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtOutTemplate = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtInTemplate = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSaveTemplates = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvSentMessages = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpConfiguration = New System.Windows.Forms.GroupBox()
        Me.numCheckInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkAutoCheckEnabled = New System.Windows.Forms.CheckBox()
        Me.btnSaveConfig = New System.Windows.Forms.Button()
        Me.btnViewLog = New System.Windows.Forms.Button()
        Me.btnReprocess = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvSentMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.grpConfiguration.SuspendLayout()
        CType(Me.numCheckInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(664, 361)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblStatus)
        Me.TabPage1.Controls.Add(Me.btnConnect)
        Me.TabPage1.Controls.Add(Me.btnRefresh)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbPorts)
        Me.TabPage1.Controls.Add(Me.btnSend)
        Me.TabPage1.Controls.Add(Me.txtMessage)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtPhoneNumber)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(656, 335)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Manual SMS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(174, 307)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(73, 13)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Disconnected"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(93, 302)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 8
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(12, 302)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 7
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(441, 307)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Port:"
        '
        'cmbPorts
        '
        Me.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPorts.FormattingEnabled = True
        Me.cmbPorts.Location = New System.Drawing.Point(476, 304)
        Me.cmbPorts.Name = "cmbPorts"
        Me.cmbPorts.Size = New System.Drawing.Size(92, 21)
        Me.cmbPorts.TabIndex = 5
        '
        'btnSend
        '
        Me.btnSend.Enabled = False
        Me.btnSend.Location = New System.Drawing.Point(253, 302)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 4
        Me.btnSend.Text = "Send SMS"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(71, 38)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(497, 229)
        Me.txtMessage.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Message:"
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(99, 12)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(173, 20)
        Me.txtPhoneNumber.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Phone Number:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnReprocess)
        Me.TabPage2.Controls.Add(Me.dgvAttendance)
        Me.TabPage2.Controls.Add(Me.btnLoadData)
        Me.TabPage2.Controls.Add(Me.btnCheckNewRecords)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(656, 335)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Attendance Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvAttendance
        '
        Me.dgvAttendance.AllowUserToAddRows = False
        Me.dgvAttendance.AllowUserToDeleteRows = False
        Me.dgvAttendance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAttendance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dgvAttendance.Location = New System.Drawing.Point(6, 35)
        Me.dgvAttendance.Name = "dgvAttendance"
        Me.dgvAttendance.ReadOnly = True
        Me.dgvAttendance.Size = New System.Drawing.Size(644, 294)
        Me.dgvAttendance.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = "Student ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Student Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Data / Time"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "IN / OUT"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Remarks"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Processed"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'btnLoadData
        '
        Me.btnLoadData.Location = New System.Drawing.Point(6, 6)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadData.TabIndex = 1
        Me.btnLoadData.Text = "Load Data"
        Me.btnLoadData.UseVisualStyleBackColor = True
        '
        'btnCheckNewRecords
        '
        Me.btnCheckNewRecords.Location = New System.Drawing.Point(87, 6)
        Me.btnCheckNewRecords.Name = "btnCheckNewRecords"
        Me.btnCheckNewRecords.Size = New System.Drawing.Size(120, 23)
        Me.btnCheckNewRecords.TabIndex = 0
        Me.btnCheckNewRecords.Text = "Check New Records"
        Me.btnCheckNewRecords.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtOutTemplate)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.txtInTemplate)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.btnSaveTemplates)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(656, 335)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Message Templates"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtOutTemplate
        '
        Me.txtOutTemplate.Location = New System.Drawing.Point(0, 168)
        Me.txtOutTemplate.Multiline = True
        Me.txtOutTemplate.Name = "txtOutTemplate"
        Me.txtOutTemplate.Size = New System.Drawing.Size(645, 130)
        Me.txtOutTemplate.TabIndex = 4
        Me.txtOutTemplate.Text = "Dear Parent/Guardian," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Your child {studname} has checked OUT at {datetime}." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Even" &
    "t: {remarks}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Thank you."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "OUT Message Template"
        '
        'txtInTemplate
        '
        Me.txtInTemplate.Location = New System.Drawing.Point(3, 19)
        Me.txtInTemplate.Multiline = True
        Me.txtInTemplate.Name = "txtInTemplate"
        Me.txtInTemplate.Size = New System.Drawing.Size(645, 130)
        Me.txtInTemplate.TabIndex = 2
        Me.txtInTemplate.Text = "Dear Parent/Guardian," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Your child {studname} has checked IN at {datetime}." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Event" &
    ": {remarks}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Thank you."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "IN Message Template"
        '
        'btnSaveTemplates
        '
        Me.btnSaveTemplates.Location = New System.Drawing.Point(3, 304)
        Me.btnSaveTemplates.Name = "btnSaveTemplates"
        Me.btnSaveTemplates.Size = New System.Drawing.Size(120, 23)
        Me.btnSaveTemplates.TabIndex = 0
        Me.btnSaveTemplates.Text = "Save Templates"
        Me.btnSaveTemplates.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvSentMessages)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(656, 335)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Sent Messages"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvSentMessages
        '
        Me.dgvSentMessages.AllowUserToAddRows = False
        Me.dgvSentMessages.AllowUserToDeleteRows = False
        Me.dgvSentMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSentMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSentMessages.Location = New System.Drawing.Point(3, 3)
        Me.dgvSentMessages.Name = "dgvSentMessages"
        Me.dgvSentMessages.ReadOnly = True
        Me.dgvSentMessages.Size = New System.Drawing.Size(650, 329)
        Me.dgvSentMessages.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 385)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(664, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLabel
        '
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(39, 17)
        Me.statusLabel.Text = "Ready"
        '
        'grpConfiguration
        '
        Me.grpConfiguration.Controls.Add(Me.numCheckInterval)
        Me.grpConfiguration.Controls.Add(Me.Label4)
        Me.grpConfiguration.Controls.Add(Me.chkAutoCheckEnabled)
        Me.grpConfiguration.Controls.Add(Me.btnSaveConfig)
        Me.grpConfiguration.Controls.Add(Me.btnViewLog)
        Me.grpConfiguration.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpConfiguration.Location = New System.Drawing.Point(0, 361)
        Me.grpConfiguration.Name = "grpConfiguration"
        Me.grpConfiguration.Size = New System.Drawing.Size(664, 24)
        Me.grpConfiguration.TabIndex = 2
        Me.grpConfiguration.TabStop = False
        Me.grpConfiguration.Text = "Configuration"
        '
        'numCheckInterval
        '
        Me.numCheckInterval.Location = New System.Drawing.Point(319, 1)
        Me.numCheckInterval.Maximum = New Decimal(New Integer() {60000, 0, 0, 0})
        Me.numCheckInterval.Minimum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numCheckInterval.Name = "numCheckInterval"
        Me.numCheckInterval.Size = New System.Drawing.Size(80, 20)
        Me.numCheckInterval.TabIndex = 4
        Me.numCheckInterval.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(219, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Check Interval (ms):"
        '
        'chkAutoCheckEnabled
        '
        Me.chkAutoCheckEnabled.AutoSize = True
        Me.chkAutoCheckEnabled.Checked = True
        Me.chkAutoCheckEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoCheckEnabled.Location = New System.Drawing.Point(79, 4)
        Me.chkAutoCheckEnabled.Name = "chkAutoCheckEnabled"
        Me.chkAutoCheckEnabled.Size = New System.Drawing.Size(132, 17)
        Me.chkAutoCheckEnabled.TabIndex = 2
        Me.chkAutoCheckEnabled.Text = "Enable Auto-Checking"
        Me.chkAutoCheckEnabled.UseVisualStyleBackColor = True
        '
        'btnSaveConfig
        '
        Me.btnSaveConfig.Location = New System.Drawing.Point(419, 1)
        Me.btnSaveConfig.Name = "btnSaveConfig"
        Me.btnSaveConfig.Size = New System.Drawing.Size(100, 23)
        Me.btnSaveConfig.TabIndex = 1
        Me.btnSaveConfig.Text = "Save Configuration"
        Me.btnSaveConfig.UseVisualStyleBackColor = True
        '
        'btnViewLog
        '
        Me.btnViewLog.Location = New System.Drawing.Point(529, 1)
        Me.btnViewLog.Name = "btnViewLog"
        Me.btnViewLog.Size = New System.Drawing.Size(100, 23)
        Me.btnViewLog.TabIndex = 0
        Me.btnViewLog.Text = "View Log"
        Me.btnViewLog.UseVisualStyleBackColor = True
        '
        'btnReprocess
        '
        Me.btnReprocess.Location = New System.Drawing.Point(573, 6)
        Me.btnReprocess.Name = "btnReprocess"
        Me.btnReprocess.Size = New System.Drawing.Size(75, 23)
        Me.btnReprocess.TabIndex = 3
        Me.btnReprocess.Text = "Reprocess"
        Me.btnReprocess.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 407)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.grpConfiguration)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Form1"
        Me.Text = "Attendance SMS Notification System"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvSentMessages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpConfiguration.ResumeLayout(False)
        Me.grpConfiguration.PerformLayout()
        CType(Me.numCheckInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbPorts As ComboBox
    Friend WithEvents btnSend As Button
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvAttendance As DataGridView
    Friend WithEvents btnLoadData As Button
    Friend WithEvents btnCheckNewRecords As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents txtOutTemplate As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtInTemplate As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSaveTemplates As Button
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents dgvSentMessages As DataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents statusLabel As ToolStripStatusLabel
    Friend WithEvents grpConfiguration As GroupBox
    Friend WithEvents numCheckInterval As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents chkAutoCheckEnabled As CheckBox
    Friend WithEvents btnSaveConfig As Button
    Friend WithEvents btnViewLog As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents btnReprocess As Button
End Class
