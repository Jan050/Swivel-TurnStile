<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormStudentDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStudentDetails))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbStudentNo = New System.Windows.Forms.TextBox()
        Me.tbLastname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFirstname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbMiddlename = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.cbProgram = New System.Windows.Forms.ComboBox()
        Me.cbNameExt = New System.Windows.Forms.ComboBox()
        Me.bSave = New System.Windows.Forms.Button()
        Me.bUpdate = New System.Windows.Forms.Button()
        Me.bCancel = New System.Windows.Forms.Button()
        Me.BSelectImage = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cbDepartment = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbType = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(832, 81)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(290, 108)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Student ID"
        '
        'tbStudentNo
        '
        Me.tbStudentNo.BackColor = System.Drawing.Color.LightYellow
        Me.tbStudentNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbStudentNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStudentNo.Location = New System.Drawing.Point(456, 103)
        Me.tbStudentNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tbStudentNo.Name = "tbStudentNo"
        Me.tbStudentNo.Size = New System.Drawing.Size(204, 26)
        Me.tbStudentNo.TabIndex = 1
        '
        'tbLastname
        '
        Me.tbLastname.BackColor = System.Drawing.Color.LightYellow
        Me.tbLastname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbLastname.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLastname.Location = New System.Drawing.Point(456, 141)
        Me.tbLastname.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tbLastname.Name = "tbLastname"
        Me.tbLastname.Size = New System.Drawing.Size(342, 26)
        Me.tbLastname.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(290, 147)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Last Name"
        '
        'tbFirstname
        '
        Me.tbFirstname.BackColor = System.Drawing.Color.LightYellow
        Me.tbFirstname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbFirstname.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFirstname.Location = New System.Drawing.Point(456, 181)
        Me.tbFirstname.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tbFirstname.Name = "tbFirstname"
        Me.tbFirstname.Size = New System.Drawing.Size(342, 26)
        Me.tbFirstname.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(290, 183)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "First Name"
        '
        'tbMiddlename
        '
        Me.tbMiddlename.BackColor = System.Drawing.Color.LightYellow
        Me.tbMiddlename.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbMiddlename.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMiddlename.Location = New System.Drawing.Point(456, 217)
        Me.tbMiddlename.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tbMiddlename.Name = "tbMiddlename"
        Me.tbMiddlename.Size = New System.Drawing.Size(342, 26)
        Me.tbMiddlename.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(290, 222)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Middle Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(290, 298)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Program/Department"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(290, 260)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 19)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Name Ext."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(290, 374)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Address"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(424, 267)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 15)
        Me.Label8.TabIndex = 13
        '
        'tbAddress
        '
        Me.tbAddress.BackColor = System.Drawing.Color.LightYellow
        Me.tbAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbAddress.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddress.Location = New System.Drawing.Point(456, 369)
        Me.tbAddress.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tbAddress.Multiline = True
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.Size = New System.Drawing.Size(342, 82)
        Me.tbAddress.TabIndex = 8
        '
        'cbProgram
        '
        Me.cbProgram.BackColor = System.Drawing.Color.LightYellow
        Me.cbProgram.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProgram.FormattingEnabled = True
        Me.cbProgram.Items.AddRange(New Object() {"Bachelor of Science in Electrical Engineering (BSEE)", "Bachelor of Science in Computer Engineering (BSCpE)", "Bachelor of Science in Information Technology (BSIT)", "Electrical Engineering Technology (EET)", "Diploma in Computer Technology (DCT)", "Bachelor of Science in Hospitality Management (BSHM)", "Bachelor of Science in Tourism Management (BSTM)", "Bachelor of Science in Food and Beverage Service Management(BSFBSM)", "Bachelor of Science in Industrial Technology Major in Architectural Drafting Tech" &
                "nology", "Bachelor of Science in Industrial Technology Major in Automotive Technology", "Bachelor of Science in Industrial Technology Major in Civil Technology", "Bachelor of Science in Industrial Technology Major in Electrical Technology", "Bachelor of Science in Industrial Technology Major in Electronics Technology", "Bachelor of Science in Industrial Technology Major in Food Preparation & Services" &
                " Management Technology", "Bachelor of Science in Industrial Technology Major in Garments, Fashion & Design " &
                "Technology", "Bachelor of Science in Industrial Technology Major in Welding and Fabrication Tec" &
                "hnology", "Bachelor of Technical – Vocational Teacher Education Major in Architectural Draft" &
                "ing", "Bachelor of Technical – Vocational Teacher Education Major in Automotive Technolo" &
                "gy", "Bachelor of Technical – Vocational Teacher Education Major in Civil and Construct" &
                "ion Technology", "Bachelor of Technical – Vocational Teacher Education Major in Electrical Technolo" &
                "gy", "Bachelor of Technical – Vocational Teacher Education Major in Electronics Technol" &
                "ogy", "Bachelor of Technical – Vocational Teacher Education Major in Food Service Manage" &
                "ment", "Bachelor of Technical – Vocational Teacher Education Major in Garments, Fashion a" &
                "nd Design", "Bachelor of Technical – Vocational Teacher Education Major in Welding & Fabricati" &
                "on Technology", "Bachelor of Technology and Livelihood Education Major in Home Economics", "Bachelor of Technology and Livelihood Education Major in Industrial Arts" & Global.Microsoft.VisualBasic.ChrW(9), "Bachelor of Science in Accountancy (BSA)", "Bachelor of Science in Management Accounting (BSMA)", "Bachelor of Science in Office Administration (BSOA)", "Bachelor of Science in Business Administration (BSBA)", "Bachelor of Science in Entrepreneurship (BSEntrep)"})
        Me.cbProgram.Location = New System.Drawing.Point(456, 293)
        Me.cbProgram.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbProgram.Name = "cbProgram"
        Me.cbProgram.Size = New System.Drawing.Size(342, 27)
        Me.cbProgram.TabIndex = 6
        Me.cbProgram.Text = "<Select>"
        '
        'cbNameExt
        '
        Me.cbNameExt.BackColor = System.Drawing.Color.LightYellow
        Me.cbNameExt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNameExt.FormattingEnabled = True
        Me.cbNameExt.Items.AddRange(New Object() {"Jr.", "Sr.", "II", "III", "IV", "V", "VI"})
        Me.cbNameExt.Location = New System.Drawing.Point(456, 255)
        Me.cbNameExt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbNameExt.Name = "cbNameExt"
        Me.cbNameExt.Size = New System.Drawing.Size(342, 27)
        Me.cbNameExt.TabIndex = 5
        Me.cbNameExt.Text = "<Select>"
        '
        'bSave
        '
        Me.bSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bSave.FlatAppearance.BorderSize = 0
        Me.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bSave.Location = New System.Drawing.Point(265, 473)
        Me.bSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(92, 42)
        Me.bSave.TabIndex = 18
        Me.bSave.Text = "&Save"
        Me.bSave.UseVisualStyleBackColor = True
        '
        'bUpdate
        '
        Me.bUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bUpdate.FlatAppearance.BorderSize = 0
        Me.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bUpdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bUpdate.Location = New System.Drawing.Point(378, 473)
        Me.bUpdate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bUpdate.Name = "bUpdate"
        Me.bUpdate.Size = New System.Drawing.Size(92, 42)
        Me.bUpdate.TabIndex = 19
        Me.bUpdate.Text = " &Update"
        Me.bUpdate.UseVisualStyleBackColor = True
        '
        'bCancel
        '
        Me.bCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bCancel.FlatAppearance.BorderSize = 0
        Me.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancel.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCancel.Location = New System.Drawing.Point(488, 473)
        Me.bCancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bCancel.Name = "bCancel"
        Me.bCancel.Size = New System.Drawing.Size(92, 42)
        Me.bCancel.TabIndex = 20
        Me.bCancel.Text = " &Cancel"
        Me.bCancel.UseVisualStyleBackColor = True
        '
        'BSelectImage
        '
        Me.BSelectImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BSelectImage.FlatAppearance.BorderSize = 0
        Me.BSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BSelectImage.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSelectImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BSelectImage.Location = New System.Drawing.Point(97, 333)
        Me.BSelectImage.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BSelectImage.Name = "BSelectImage"
        Me.BSelectImage.Size = New System.Drawing.Size(105, 42)
        Me.BSelectImage.TabIndex = 22
        Me.BSelectImage.Text = "&Select Image"
        Me.BSelectImage.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'cbDepartment
        '
        Me.cbDepartment.BackColor = System.Drawing.Color.LightYellow
        Me.cbDepartment.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepartment.FormattingEnabled = True
        Me.cbDepartment.Items.AddRange(New Object() {"CEIT", "CTHM"})
        Me.cbDepartment.Location = New System.Drawing.Point(456, 293)
        Me.cbDepartment.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Size = New System.Drawing.Size(342, 27)
        Me.cbDepartment.TabIndex = 23
        Me.cbDepartment.Text = "<Select>"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(424, 343)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 15)
        Me.Label9.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(290, 336)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 19)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Type"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(49, 133)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 184)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'tbType
        '
        Me.tbType.BackColor = System.Drawing.Color.LightYellow
        Me.tbType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbType.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbType.Location = New System.Drawing.Point(456, 330)
        Me.tbType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tbType.Name = "tbType"
        Me.tbType.Size = New System.Drawing.Size(342, 26)
        Me.tbType.TabIndex = 7
        '
        'FormStudentDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(832, 554)
        Me.Controls.Add(Me.tbType)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.BSelectImage)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bCancel)
        Me.Controls.Add(Me.bUpdate)
        Me.Controls.Add(Me.bSave)
        Me.Controls.Add(Me.cbNameExt)
        Me.Controls.Add(Me.tbAddress)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbMiddlename)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbFirstname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbLastname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbStudentNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbProgram)
        Me.Controls.Add(Me.cbDepartment)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FormStudentDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student / Faculty Details"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents tbStudentNo As TextBox
    Friend WithEvents tbLastname As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbFirstname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbMiddlename As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tbAddress As TextBox
    Friend WithEvents cbProgram As ComboBox
    Friend WithEvents cbNameExt As ComboBox
    Friend WithEvents bSave As Button
    Friend WithEvents bUpdate As Button
    Friend WithEvents bCancel As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BSelectImage As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents cbDepartment As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tbType As TextBox
End Class
