<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUser))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.bImage = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFullname1 = New System.Windows.Forms.TextBox()
        Me.tbConPass1 = New System.Windows.Forms.TextBox()
        Me.tbPassword1 = New System.Windows.Forms.TextBox()
        Me.cbAccType1 = New System.Windows.Forms.ComboBox()
        Me.bSave = New System.Windows.Forms.Button()
        Me.tbUsername1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.UpSelectImage = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbConPass2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbFullname2 = New System.Windows.Forms.TextBox()
        Me.tbNewPass = New System.Windows.Forms.TextBox()
        Me.tbOldPass = New System.Windows.Forms.TextBox()
        Me.cbAccType2 = New System.Windows.Forms.ComboBox()
        Me.bUpdate = New System.Windows.Forms.Button()
        Me.tbUsername2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbOldpass2 = New System.Windows.Forms.TextBox()
        Me.bDelete = New System.Windows.Forms.Button()
        Me.tbUsername3 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(669, 392)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.bImage)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.tbFullname1)
        Me.TabPage1.Controls.Add(Me.tbConPass1)
        Me.TabPage1.Controls.Add(Me.tbPassword1)
        Me.TabPage1.Controls.Add(Me.cbAccType1)
        Me.TabPage1.Controls.Add(Me.bSave)
        Me.TabPage1.Controls.Add(Me.tbUsername1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(661, 360)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Create Account"
        '
        'bImage
        '
        Me.bImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bImage.FlatAppearance.BorderSize = 0
        Me.bImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bImage.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bImage.Location = New System.Drawing.Point(75, 221)
        Me.bImage.Name = "bImage"
        Me.bImage.Size = New System.Drawing.Size(93, 36)
        Me.bImage.TabIndex = 12
        Me.bImage.Text = "Select Image"
        Me.bImage.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(48, 95)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(149, 113)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(254, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Account Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(254, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 19)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Full Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(254, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Comfirm Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(254, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Password"
        '
        'tbFullname1
        '
        Me.tbFullname1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbFullname1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFullname1.Location = New System.Drawing.Point(386, 197)
        Me.tbFullname1.Name = "tbFullname1"
        Me.tbFullname1.Size = New System.Drawing.Size(222, 26)
        Me.tbFullname1.TabIndex = 4
        '
        'tbConPass1
        '
        Me.tbConPass1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbConPass1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbConPass1.Location = New System.Drawing.Point(386, 156)
        Me.tbConPass1.Name = "tbConPass1"
        Me.tbConPass1.Size = New System.Drawing.Size(222, 26)
        Me.tbConPass1.TabIndex = 3
        Me.tbConPass1.UseSystemPasswordChar = True
        '
        'tbPassword1
        '
        Me.tbPassword1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbPassword1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPassword1.Location = New System.Drawing.Point(386, 115)
        Me.tbPassword1.Name = "tbPassword1"
        Me.tbPassword1.Size = New System.Drawing.Size(222, 26)
        Me.tbPassword1.TabIndex = 2
        Me.tbPassword1.UseSystemPasswordChar = True
        '
        'cbAccType1
        '
        Me.cbAccType1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAccType1.FormattingEnabled = True
        Me.cbAccType1.Items.AddRange(New Object() {"Administrator", "Guest", "Clerk", "Guard"})
        Me.cbAccType1.Location = New System.Drawing.Point(386, 237)
        Me.cbAccType1.Name = "cbAccType1"
        Me.cbAccType1.Size = New System.Drawing.Size(222, 27)
        Me.cbAccType1.TabIndex = 5
        Me.cbAccType1.Text = "<Select>"
        '
        'bSave
        '
        Me.bSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bSave.FlatAppearance.BorderSize = 0
        Me.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bSave.Location = New System.Drawing.Point(298, 297)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(93, 36)
        Me.bSave.TabIndex = 6
        Me.bSave.Text = "&Save"
        Me.bSave.UseVisualStyleBackColor = False
        '
        'tbUsername1
        '
        Me.tbUsername1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbUsername1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUsername1.Location = New System.Drawing.Point(386, 75)
        Me.tbUsername1.Name = "tbUsername1"
        Me.tbUsername1.Size = New System.Drawing.Size(222, 26)
        Me.tbUsername1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(254, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.UpSelectImage)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.tbConPass2)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.tbFullname2)
        Me.TabPage2.Controls.Add(Me.tbNewPass)
        Me.TabPage2.Controls.Add(Me.tbOldPass)
        Me.TabPage2.Controls.Add(Me.cbAccType2)
        Me.TabPage2.Controls.Add(Me.bUpdate)
        Me.TabPage2.Controls.Add(Me.tbUsername2)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(661, 360)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Update Account"
        '
        'UpSelectImage
        '
        Me.UpSelectImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.UpSelectImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UpSelectImage.FlatAppearance.BorderSize = 0
        Me.UpSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpSelectImage.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpSelectImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UpSelectImage.Location = New System.Drawing.Point(75, 191)
        Me.UpSelectImage.Name = "UpSelectImage"
        Me.UpSelectImage.Size = New System.Drawing.Size(93, 36)
        Me.UpSelectImage.TabIndex = 25
        Me.UpSelectImage.Text = "Select Image"
        Me.UpSelectImage.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(249, 187)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 19)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Comfirm Password"
        '
        'tbConPass2
        '
        Me.tbConPass2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbConPass2.Enabled = False
        Me.tbConPass2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbConPass2.Location = New System.Drawing.Point(381, 184)
        Me.tbConPass2.Name = "tbConPass2"
        Me.tbConPass2.Size = New System.Drawing.Size(222, 26)
        Me.tbConPass2.TabIndex = 22
        Me.tbConPass2.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(249, 269)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 19)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Account Type"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(249, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 19)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Full Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(249, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 19)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "New Password"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(249, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 19)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Old Password"
        '
        'tbFullname2
        '
        Me.tbFullname2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbFullname2.Enabled = False
        Me.tbFullname2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFullname2.Location = New System.Drawing.Point(381, 224)
        Me.tbFullname2.Name = "tbFullname2"
        Me.tbFullname2.Size = New System.Drawing.Size(222, 26)
        Me.tbFullname2.TabIndex = 17
        '
        'tbNewPass
        '
        Me.tbNewPass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbNewPass.Enabled = False
        Me.tbNewPass.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNewPass.Location = New System.Drawing.Point(381, 143)
        Me.tbNewPass.Name = "tbNewPass"
        Me.tbNewPass.Size = New System.Drawing.Size(222, 26)
        Me.tbNewPass.TabIndex = 16
        Me.tbNewPass.UseSystemPasswordChar = True
        '
        'tbOldPass
        '
        Me.tbOldPass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbOldPass.Enabled = False
        Me.tbOldPass.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbOldPass.Location = New System.Drawing.Point(381, 102)
        Me.tbOldPass.Name = "tbOldPass"
        Me.tbOldPass.Size = New System.Drawing.Size(222, 26)
        Me.tbOldPass.TabIndex = 15
        Me.tbOldPass.UseSystemPasswordChar = True
        '
        'cbAccType2
        '
        Me.cbAccType2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAccType2.FormattingEnabled = True
        Me.cbAccType2.Items.AddRange(New Object() {"Administrator", "Guest", "Clerk", "Guard"})
        Me.cbAccType2.Location = New System.Drawing.Point(381, 265)
        Me.cbAccType2.Name = "cbAccType2"
        Me.cbAccType2.Size = New System.Drawing.Size(222, 27)
        Me.cbAccType2.TabIndex = 14
        Me.cbAccType2.Text = "<Select>"
        '
        'bUpdate
        '
        Me.bUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.bUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bUpdate.FlatAppearance.BorderSize = 0
        Me.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bUpdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bUpdate.Location = New System.Drawing.Point(294, 315)
        Me.bUpdate.Name = "bUpdate"
        Me.bUpdate.Size = New System.Drawing.Size(110, 36)
        Me.bUpdate.TabIndex = 13
        Me.bUpdate.Text = "&Update"
        Me.bUpdate.UseVisualStyleBackColor = False
        '
        'tbUsername2
        '
        Me.tbUsername2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbUsername2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUsername2.Location = New System.Drawing.Point(381, 61)
        Me.tbUsername2.Name = "tbUsername2"
        Me.tbUsername2.Size = New System.Drawing.Size(222, 26)
        Me.tbUsername2.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(249, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 19)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Username"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(47, 65)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(149, 113)
        Me.PictureBox2.TabIndex = 24
        Me.PictureBox2.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.tbOldpass2)
        Me.TabPage3.Controls.Add(Me.bDelete)
        Me.TabPage3.Controls.Add(Me.tbUsername3)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(661, 360)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Delete Account"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(129, 167)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 19)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Password"
        '
        'tbOldpass2
        '
        Me.tbOldpass2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbOldpass2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbOldpass2.Location = New System.Drawing.Point(245, 165)
        Me.tbOldpass2.Name = "tbOldpass2"
        Me.tbOldpass2.Size = New System.Drawing.Size(222, 26)
        Me.tbOldpass2.TabIndex = 22
        Me.tbOldpass2.UseSystemPasswordChar = True
        '
        'bDelete
        '
        Me.bDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bDelete.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.bDelete.FlatAppearance.BorderSize = 0
        Me.bDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bDelete.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bDelete.Location = New System.Drawing.Point(274, 263)
        Me.bDelete.Name = "bDelete"
        Me.bDelete.Size = New System.Drawing.Size(101, 36)
        Me.bDelete.TabIndex = 21
        Me.bDelete.Text = "&Delete"
        Me.bDelete.UseVisualStyleBackColor = False
        '
        'tbUsername3
        '
        Me.tbUsername3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbUsername3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUsername3.Location = New System.Drawing.Point(245, 124)
        Me.tbUsername3.Name = "tbUsername3"
        Me.tbUsername3.Size = New System.Drawing.Size(222, 26)
        Me.tbUsername3.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(129, 127)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 19)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Username"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FormUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 391)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormUser"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbFullname1 As TextBox
    Friend WithEvents tbConPass1 As TextBox
    Friend WithEvents tbPassword1 As TextBox
    Friend WithEvents cbAccType1 As ComboBox
    Friend WithEvents bSave As Button
    Friend WithEvents tbUsername1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label11 As Label
    Friend WithEvents tbConPass2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tbFullname2 As TextBox
    Friend WithEvents tbNewPass As TextBox
    Friend WithEvents tbOldPass As TextBox
    Friend WithEvents cbAccType2 As ComboBox
    Friend WithEvents bUpdate As Button
    Friend WithEvents tbUsername2 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents tbOldpass2 As TextBox
    Friend WithEvents bDelete As Button
    Friend WithEvents tbUsername3 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents bImage As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents UpSelectImage As Button
    Friend WithEvents PictureBox2 As PictureBox
End Class
