<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAttendance
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAttendance))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClearFilters = New System.Windows.Forms.Button()
        Me.lblAdvancedFilter = New System.Windows.Forms.Label()
        Me.BLoad = New System.Windows.Forms.Button()
        Me.BStart = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbOutIn = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbInOut = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSearch = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbProgramFilter = New System.Windows.Forms.ComboBox()
        Me.cbforinandout = New System.Windows.Forms.ComboBox()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.deleteMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grpSmsSettings = New System.Windows.Forms.GroupBox()
        Me.btnViewLog2 = New System.Windows.Forms.Button()
        Me.lblSmsStatus = New System.Windows.Forms.Label()
        Me.btnSmsConnect = New System.Windows.Forms.Button()
        Me.btnRefreshPorts = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSmsPorts = New System.Windows.Forms.ComboBox()
        Me.btnSendSms = New System.Windows.Forms.Button()
        Me.txtSmsMessage = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSmsPhone = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpTemplates = New System.Windows.Forms.GroupBox()
        Me.txtOutTemplate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtInTemplate = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnSaveTemplates = New System.Windows.Forms.Button()
        Me.grpAutoSend = New System.Windows.Forms.GroupBox()
        Me.numCheckInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkAutoCheckEnabled = New System.Windows.Forms.CheckBox()
        Me.btnSaveConfig = New System.Windows.Forms.Button()
        Me.btnCheckNewRecords = New System.Windows.Forms.Button()
        Me.btnViewLog = New System.Windows.Forms.Button()
        Me.grpSentMessages = New System.Windows.Forms.GroupBox()
        Me.dgvSentMessages = New System.Windows.Forms.DataGridView()
        Me.colTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSentBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMessage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TimerSMS = New System.Windows.Forms.Timer(Me.components)
        Me.attendanceUpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contextMenu.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpSmsSettings.SuspendLayout()
        Me.grpTemplates.SuspendLayout()
        Me.grpAutoSend.SuspendLayout()
        CType(Me.numCheckInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSentMessages.SuspendLayout()
        CType(Me.dgvSentMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnClearFilters)
        Me.Panel1.Controls.Add(Me.lblAdvancedFilter)
        Me.Panel1.Controls.Add(Me.BLoad)
        Me.Panel1.Controls.Add(Me.BStart)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cbOutIn)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cbInOut)
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbSearch)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cbProgramFilter)
        Me.Panel1.Controls.Add(Me.cbforinandout)
        Me.Panel1.Controls.Add(Me.tbSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1285, 123)
        Me.Panel1.TabIndex = 0
        '
        'btnClearFilters
        '
        Me.btnClearFilters.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnClearFilters.FlatAppearance.BorderSize = 0
        Me.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClearFilters.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFilters.Location = New System.Drawing.Point(10, 59)
        Me.btnClearFilters.Name = "btnClearFilters"
        Me.btnClearFilters.Size = New System.Drawing.Size(128, 23)
        Me.btnClearFilters.TabIndex = 18
        Me.btnClearFilters.Text = "Clear Filters"
        Me.btnClearFilters.UseVisualStyleBackColor = True
        Me.btnClearFilters.Visible = False
        '
        'lblAdvancedFilter
        '
        Me.lblAdvancedFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAdvancedFilter.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdvancedFilter.ForeColor = System.Drawing.Color.Yellow
        Me.lblAdvancedFilter.Location = New System.Drawing.Point(144, 63)
        Me.lblAdvancedFilter.Name = "lblAdvancedFilter"
        Me.lblAdvancedFilter.Size = New System.Drawing.Size(300, 17)
        Me.lblAdvancedFilter.TabIndex = 19
        Me.lblAdvancedFilter.Text = "Active filters will appear here"
        Me.lblAdvancedFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAdvancedFilter.Visible = False
        '
        'BLoad
        '
        Me.BLoad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BLoad.FlatAppearance.BorderSize = 0
        Me.BLoad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BLoad.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BLoad.Location = New System.Drawing.Point(518, 97)
        Me.BLoad.Name = "BLoad"
        Me.BLoad.Size = New System.Drawing.Size(64, 23)
        Me.BLoad.TabIndex = 15
        Me.BLoad.Text = "Load"
        Me.BLoad.UseVisualStyleBackColor = True
        '
        'BStart
        '
        Me.BStart.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BStart.FlatAppearance.BorderSize = 0
        Me.BStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BStart.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BStart.Location = New System.Drawing.Point(1216, 74)
        Me.BStart.Name = "BStart"
        Me.BStart.Size = New System.Drawing.Size(64, 23)
        Me.BStart.TabIndex = 13
        Me.BStart.Text = "Start"
        Me.BStart.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1152, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Gate 2"
        '
        'cbOutIn
        '
        Me.cbOutIn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cbOutIn.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOutIn.FormattingEnabled = True
        Me.cbOutIn.Items.AddRange(New Object() {"OUT", "IN", "IN/OUT"})
        Me.cbOutIn.Location = New System.Drawing.Point(1142, 75)
        Me.cbOutIn.Name = "cbOutIn"
        Me.cbOutIn.Size = New System.Drawing.Size(68, 23)
        Me.cbOutIn.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1081, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Gate 1"
        '
        'cbInOut
        '
        Me.cbInOut.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cbInOut.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbInOut.FormattingEnabled = True
        Me.cbInOut.Items.AddRange(New Object() {"IN", "OUT", "IN/OUT"})
        Me.cbInOut.Location = New System.Drawing.Point(1068, 75)
        Me.cbInOut.Name = "cbInOut"
        Me.cbInOut.Size = New System.Drawing.Size(68, 23)
        Me.cbInOut.TabIndex = 9
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DateTimePicker2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(325, 97)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(187, 22)
        Me.DateTimePicker2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(267, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "End Date"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DateTimePicker1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(74, 97)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(187, 22)
        Me.DateTimePicker1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Start Date"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "&Search"
        '
        'cbSearch
        '
        Me.cbSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbSearch.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearch.FormattingEnabled = True
        Me.cbSearch.Location = New System.Drawing.Point(10, 27)
        Me.cbSearch.Name = "cbSearch"
        Me.cbSearch.Size = New System.Drawing.Size(104, 23)
        Me.cbSearch.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(575, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Attendance"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbProgramFilter
        '
        Me.cbProgramFilter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbProgramFilter.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProgramFilter.FormattingEnabled = True
        Me.cbProgramFilter.Items.AddRange(New Object() {"CEIT", "CITTE", "CTSM", "CBA", "DLHS"})
        Me.cbProgramFilter.Location = New System.Drawing.Point(120, 27)
        Me.cbProgramFilter.Name = "cbProgramFilter"
        Me.cbProgramFilter.Size = New System.Drawing.Size(199, 23)
        Me.cbProgramFilter.TabIndex = 17
        Me.cbProgramFilter.Visible = False
        '
        'cbforinandout
        '
        Me.cbforinandout.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbforinandout.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbforinandout.FormattingEnabled = True
        Me.cbforinandout.Items.AddRange(New Object() {"IN", "OUT"})
        Me.cbforinandout.Location = New System.Drawing.Point(120, 27)
        Me.cbforinandout.Name = "cbforinandout"
        Me.cbforinandout.Size = New System.Drawing.Size(47, 23)
        Me.cbforinandout.TabIndex = 16
        Me.cbforinandout.Visible = False
        '
        'tbSearch
        '
        Me.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbSearch.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearch.Location = New System.Drawing.Point(119, 27)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(86, 22)
        Me.tbSearch.TabIndex = 14
        Me.tbSearch.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 123)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1285, 574)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1277, 548)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Attendance Viewing"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column6, Me.Column7, Me.Column9, Me.Column10, Me.Column5})
        Me.DataGridView1.ContextMenuStrip = Me.contextMenu
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1271, 542)
        Me.DataGridView1.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "Student ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.FillWeight = 120.0!
        Me.Column2.HeaderText = "Student Name"
        Me.Column2.MinimumWidth = 10
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Data / Time"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "IN / OUT"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 77
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.HeaderText = "Remarks"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Type"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Contact Number"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'Column10
        '
        Me.Column10.HeaderText = "Processed"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 70
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "Program"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'contextMenu
        '
        Me.contextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.deleteMenuItem})
        Me.contextMenu.Name = "contextMenu"
        Me.contextMenu.Size = New System.Drawing.Size(186, 26)
        '
        'deleteMenuItem
        '
        Me.deleteMenuItem.Name = "deleteMenuItem"
        Me.deleteMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.deleteMenuItem.Text = "Delete Selected Rows"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1277, 548)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SMS Configuration & Log"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpSmsSettings)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpTemplates)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpAutoSend)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpSentMessages)
        Me.SplitContainer1.Size = New System.Drawing.Size(1271, 542)
        Me.SplitContainer1.SplitterDistance = 565
        Me.SplitContainer1.TabIndex = 0
        '
        'grpSmsSettings
        '
        Me.grpSmsSettings.Controls.Add(Me.btnViewLog2)
        Me.grpSmsSettings.Controls.Add(Me.lblSmsStatus)
        Me.grpSmsSettings.Controls.Add(Me.btnSmsConnect)
        Me.grpSmsSettings.Controls.Add(Me.btnRefreshPorts)
        Me.grpSmsSettings.Controls.Add(Me.Label7)
        Me.grpSmsSettings.Controls.Add(Me.cmbSmsPorts)
        Me.grpSmsSettings.Controls.Add(Me.btnSendSms)
        Me.grpSmsSettings.Controls.Add(Me.txtSmsMessage)
        Me.grpSmsSettings.Controls.Add(Me.Label8)
        Me.grpSmsSettings.Controls.Add(Me.txtSmsPhone)
        Me.grpSmsSettings.Controls.Add(Me.Label9)
        Me.grpSmsSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpSmsSettings.Location = New System.Drawing.Point(0, 292)
        Me.grpSmsSettings.Name = "grpSmsSettings"
        Me.grpSmsSettings.Size = New System.Drawing.Size(565, 293)
        Me.grpSmsSettings.TabIndex = 0
        Me.grpSmsSettings.TabStop = False
        Me.grpSmsSettings.Text = "SMS Settings & Manual Testing"
        '
        'btnViewLog2
        '
        Me.btnViewLog2.Location = New System.Drawing.Point(383, 215)
        Me.btnViewLog2.Name = "btnViewLog2"
        Me.btnViewLog2.Size = New System.Drawing.Size(100, 23)
        Me.btnViewLog2.TabIndex = 10
        Me.btnViewLog2.Text = "View Log"
        Me.btnViewLog2.UseVisualStyleBackColor = True
        '
        'lblSmsStatus
        '
        Me.lblSmsStatus.AutoSize = True
        Me.lblSmsStatus.Location = New System.Drawing.Point(10, 241)
        Me.lblSmsStatus.Name = "lblSmsStatus"
        Me.lblSmsStatus.Size = New System.Drawing.Size(73, 13)
        Me.lblSmsStatus.TabIndex = 9
        Me.lblSmsStatus.Text = "Disconnected"
        '
        'btnSmsConnect
        '
        Me.btnSmsConnect.Location = New System.Drawing.Point(89, 215)
        Me.btnSmsConnect.Name = "btnSmsConnect"
        Me.btnSmsConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnSmsConnect.TabIndex = 8
        Me.btnSmsConnect.Text = "Connect"
        Me.btnSmsConnect.UseVisualStyleBackColor = True
        '
        'btnRefreshPorts
        '
        Me.btnRefreshPorts.Location = New System.Drawing.Point(8, 215)
        Me.btnRefreshPorts.Name = "btnRefreshPorts"
        Me.btnRefreshPorts.Size = New System.Drawing.Size(75, 23)
        Me.btnRefreshPorts.TabIndex = 7
        Me.btnRefreshPorts.Text = "Refresh"
        Me.btnRefreshPorts.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(173, 220)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Port:"
        '
        'cmbSmsPorts
        '
        Me.cmbSmsPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSmsPorts.FormattingEnabled = True
        Me.cmbSmsPorts.Location = New System.Drawing.Point(208, 217)
        Me.cmbSmsPorts.Name = "cmbSmsPorts"
        Me.cmbSmsPorts.Size = New System.Drawing.Size(92, 21)
        Me.cmbSmsPorts.TabIndex = 5
        '
        'btnSendSms
        '
        Me.btnSendSms.Enabled = False
        Me.btnSendSms.Location = New System.Drawing.Point(306, 215)
        Me.btnSendSms.Name = "btnSendSms"
        Me.btnSendSms.Size = New System.Drawing.Size(75, 23)
        Me.btnSendSms.TabIndex = 4
        Me.btnSendSms.Text = "Send SMS"
        Me.btnSendSms.UseVisualStyleBackColor = True
        '
        'txtSmsMessage
        '
        Me.txtSmsMessage.Location = New System.Drawing.Point(12, 109)
        Me.txtSmsMessage.Multiline = True
        Me.txtSmsMessage.Name = "txtSmsMessage"
        Me.txtSmsMessage.Size = New System.Drawing.Size(836, 100)
        Me.txtSmsMessage.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Message:"
        '
        'txtSmsPhone
        '
        Me.txtSmsPhone.Location = New System.Drawing.Point(96, 67)
        Me.txtSmsPhone.Name = "txtSmsPhone"
        Me.txtSmsPhone.Size = New System.Drawing.Size(173, 20)
        Me.txtSmsPhone.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Phone Number:"
        '
        'grpTemplates
        '
        Me.grpTemplates.Controls.Add(Me.txtOutTemplate)
        Me.grpTemplates.Controls.Add(Me.Label10)
        Me.grpTemplates.Controls.Add(Me.txtInTemplate)
        Me.grpTemplates.Controls.Add(Me.Label11)
        Me.grpTemplates.Controls.Add(Me.btnSaveTemplates)
        Me.grpTemplates.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpTemplates.Location = New System.Drawing.Point(0, 0)
        Me.grpTemplates.Name = "grpTemplates"
        Me.grpTemplates.Size = New System.Drawing.Size(565, 292)
        Me.grpTemplates.TabIndex = 1
        Me.grpTemplates.TabStop = False
        Me.grpTemplates.Text = "Message Templates"
        '
        'txtOutTemplate
        '
        Me.txtOutTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutTemplate.Location = New System.Drawing.Point(6, 160)
        Me.txtOutTemplate.Multiline = True
        Me.txtOutTemplate.Name = "txtOutTemplate"
        Me.txtOutTemplate.Size = New System.Drawing.Size(842, 88)
        Me.txtOutTemplate.TabIndex = 4
        Me.txtOutTemplate.Text = "Dear Parent/Guardian," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Your child {studname} has checked OUT at {datetime}." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Even" &
    "t: {remarks}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Thank you."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 137)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "OUT Message Template"
        '
        'txtInTemplate
        '
        Me.txtInTemplate.Location = New System.Drawing.Point(6, 35)
        Me.txtInTemplate.Multiline = True
        Me.txtInTemplate.Name = "txtInTemplate"
        Me.txtInTemplate.Size = New System.Drawing.Size(842, 92)
        Me.txtInTemplate.TabIndex = 2
        Me.txtInTemplate.Text = "Dear Parent/Guardian," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Your child {studname} has checked IN at {datetime}." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Event" &
    ": {remarks}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Thank you."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "IN Message Template"
        '
        'btnSaveTemplates
        '
        Me.btnSaveTemplates.Location = New System.Drawing.Point(6, 262)
        Me.btnSaveTemplates.Name = "btnSaveTemplates"
        Me.btnSaveTemplates.Size = New System.Drawing.Size(120, 23)
        Me.btnSaveTemplates.TabIndex = 0
        Me.btnSaveTemplates.Text = "Save Templates"
        Me.btnSaveTemplates.UseVisualStyleBackColor = True
        '
        'grpAutoSend
        '
        Me.grpAutoSend.Controls.Add(Me.numCheckInterval)
        Me.grpAutoSend.Controls.Add(Me.Label12)
        Me.grpAutoSend.Controls.Add(Me.chkAutoCheckEnabled)
        Me.grpAutoSend.Controls.Add(Me.btnSaveConfig)
        Me.grpAutoSend.Controls.Add(Me.btnCheckNewRecords)
        Me.grpAutoSend.Controls.Add(Me.btnViewLog)
        Me.grpAutoSend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpAutoSend.Location = New System.Drawing.Point(0, 0)
        Me.grpAutoSend.Name = "grpAutoSend"
        Me.grpAutoSend.Size = New System.Drawing.Size(565, 542)
        Me.grpAutoSend.TabIndex = 2
        Me.grpAutoSend.TabStop = False
        Me.grpAutoSend.Text = "Auto-Send Configuration"
        '
        'numCheckInterval
        '
        Me.numCheckInterval.Location = New System.Drawing.Point(319, 21)
        Me.numCheckInterval.Maximum = New Decimal(New Integer() {60000, 0, 0, 0})
        Me.numCheckInterval.Minimum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numCheckInterval.Name = "numCheckInterval"
        Me.numCheckInterval.Size = New System.Drawing.Size(80, 20)
        Me.numCheckInterval.TabIndex = 4
        Me.numCheckInterval.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(219, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Check Interval (ms):"
        '
        'chkAutoCheckEnabled
        '
        Me.chkAutoCheckEnabled.AutoSize = True
        Me.chkAutoCheckEnabled.Checked = True
        Me.chkAutoCheckEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoCheckEnabled.Location = New System.Drawing.Point(12, 24)
        Me.chkAutoCheckEnabled.Name = "chkAutoCheckEnabled"
        Me.chkAutoCheckEnabled.Size = New System.Drawing.Size(132, 17)
        Me.chkAutoCheckEnabled.TabIndex = 2
        Me.chkAutoCheckEnabled.Text = "Enable Auto-Checking"
        Me.chkAutoCheckEnabled.UseVisualStyleBackColor = True
        '
        'btnSaveConfig
        '
        Me.btnSaveConfig.Location = New System.Drawing.Point(405, 19)
        Me.btnSaveConfig.Name = "btnSaveConfig"
        Me.btnSaveConfig.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveConfig.TabIndex = 1
        Me.btnSaveConfig.Text = "Save Config"
        Me.btnSaveConfig.UseVisualStyleBackColor = True
        '
        'btnCheckNewRecords
        '
        Me.btnCheckNewRecords.Location = New System.Drawing.Point(150, 19)
        Me.btnCheckNewRecords.Name = "btnCheckNewRecords"
        Me.btnCheckNewRecords.Size = New System.Drawing.Size(63, 23)
        Me.btnCheckNewRecords.TabIndex = 0
        Me.btnCheckNewRecords.Text = "Check Now"
        Me.btnCheckNewRecords.UseVisualStyleBackColor = True
        '
        'btnViewLog
        '
        Me.btnViewLog.Location = New System.Drawing.Point(486, 19)
        Me.btnViewLog.Name = "btnViewLog"
        Me.btnViewLog.Size = New System.Drawing.Size(0, 0)
        Me.btnViewLog.TabIndex = 0
        Me.btnViewLog.Text = "View Log"
        Me.btnViewLog.UseVisualStyleBackColor = True
        '
        'grpSentMessages
        '
        Me.grpSentMessages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSentMessages.Controls.Add(Me.dgvSentMessages)
        Me.grpSentMessages.Location = New System.Drawing.Point(2, 0)
        Me.grpSentMessages.Name = "grpSentMessages"
        Me.grpSentMessages.Size = New System.Drawing.Size(697, 542)
        Me.grpSentMessages.TabIndex = 0
        Me.grpSentMessages.TabStop = False
        Me.grpSentMessages.Text = "Sent Messages Log"
        '
        'dgvSentMessages
        '
        Me.dgvSentMessages.AllowUserToAddRows = False
        Me.dgvSentMessages.AllowUserToDeleteRows = False
        Me.dgvSentMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSentMessages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTime, Me.colPhone, Me.colSentBy, Me.colMessage})
        Me.dgvSentMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSentMessages.Location = New System.Drawing.Point(3, 16)
        Me.dgvSentMessages.Name = "dgvSentMessages"
        Me.dgvSentMessages.ReadOnly = True
        Me.dgvSentMessages.Size = New System.Drawing.Size(691, 523)
        Me.dgvSentMessages.TabIndex = 0
        '
        'colTime
        '
        Me.colTime.Frozen = True
        Me.colTime.HeaderText = "Time"
        Me.colTime.Name = "colTime"
        Me.colTime.ReadOnly = True
        Me.colTime.Width = 70
        '
        'colPhone
        '
        Me.colPhone.Frozen = True
        Me.colPhone.HeaderText = "Phone Number"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.ReadOnly = True
        Me.colPhone.Width = 120
        '
        'colSentBy
        '
        Me.colSentBy.Frozen = True
        Me.colSentBy.HeaderText = "Sent By"
        Me.colSentBy.Name = "colSentBy"
        Me.colSentBy.ReadOnly = True
        Me.colSentBy.Width = 80
        '
        'colMessage
        '
        Me.colMessage.HeaderText = "Message"
        Me.colMessage.Name = "colMessage"
        Me.colMessage.ReadOnly = True
        Me.colMessage.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colMessage.Width = 350
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'TimerSMS
        '
        Me.TimerSMS.Interval = 5000
        '
        'attendanceUpdateTimer
        '
        Me.attendanceUpdateTimer.Interval = 5000
        '
        'FormAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1285, 697)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAttendance"
        Me.Text = "Attendance & SMS System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contextMenu.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpSmsSettings.ResumeLayout(False)
        Me.grpSmsSettings.PerformLayout()
        Me.grpTemplates.ResumeLayout(False)
        Me.grpTemplates.PerformLayout()
        Me.grpAutoSend.ResumeLayout(False)
        Me.grpAutoSend.PerformLayout()
        CType(Me.numCheckInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSentMessages.ResumeLayout(False)
        CType(Me.dgvSentMessages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents cbSearch As ComboBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents BStart As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents cbOutIn As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbInOut As ComboBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents tbSearch As TextBox
    Friend WithEvents BLoad As Button
    Friend WithEvents cbforinandout As ComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grpSmsSettings As GroupBox
    Friend WithEvents lblSmsStatus As Label
    Friend WithEvents btnSmsConnect As Button
    Friend WithEvents btnRefreshPorts As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbSmsPorts As ComboBox
    Friend WithEvents btnSendSms As Button
    Friend WithEvents txtSmsMessage As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSmsPhone As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents grpTemplates As GroupBox
    Friend WithEvents txtOutTemplate As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtInTemplate As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnSaveTemplates As Button
    Friend WithEvents grpAutoSend As GroupBox
    Friend WithEvents numCheckInterval As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents chkAutoCheckEnabled As CheckBox
    Friend WithEvents btnSaveConfig As Button
    Friend WithEvents btnCheckNewRecords As Button
    Friend WithEvents btnViewLog As Button
    Friend WithEvents grpSentMessages As GroupBox
    Friend WithEvents dgvSentMessages As DataGridView
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents TimerSMS As Timer
    Friend WithEvents updateTimer As Timer
    Friend WithEvents btnViewLog2 As Button
    Friend WithEvents colTime As DataGridViewTextBoxColumn
    Friend WithEvents colPhone As DataGridViewTextBoxColumn
    Friend WithEvents colSentBy As DataGridViewTextBoxColumn
    Friend WithEvents colMessage As DataGridViewTextBoxColumn
    Friend WithEvents contextMenu As ContextMenuStrip
    Friend WithEvents deleteMenuItem As ToolStripMenuItem
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents cbProgramFilter As ComboBox
    Private WithEvents lblAdvancedFilter As Label
    Private WithEvents btnClearFilters As Button
End Class