<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRegistration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRegistration))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbStudentId = New System.Windows.Forms.TextBox()
        Me.bCancel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbContactN = New System.Windows.Forms.TextBox()
        Me.tbContactP = New System.Windows.Forms.TextBox()
        Me.tbRFIDno = New System.Windows.Forms.TextBox()
        Me.bSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bUpdate = New System.Windows.Forms.Button()
        Me.BLook = New System.Windows.Forms.Button()
        Me.tbStudName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbGetUID = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tbGetUID2 = New System.Windows.Forms.Button()
        Me.tbRFIDNo2 = New System.Windows.Forms.TextBox()
        Me.tbContactP2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BSave2 = New System.Windows.Forms.Button()
        Me.BUpdate2 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tbStudentId2 = New System.Windows.Forms.TextBox()
        Me.tbContactN2 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(585, 81)
        Me.Panel2.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(107, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 19)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Student Id"
        '
        'tbStudentId
        '
        Me.tbStudentId.BackColor = System.Drawing.Color.LightYellow
        Me.tbStudentId.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStudentId.Location = New System.Drawing.Point(224, 44)
        Me.tbStudentId.Name = "tbStudentId"
        Me.tbStudentId.Size = New System.Drawing.Size(181, 26)
        Me.tbStudentId.TabIndex = 23
        Me.tbStudentId.Text = "      Look for ID  ----------------------->"
        '
        'bCancel
        '
        Me.bCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bCancel.FlatAppearance.BorderSize = 0
        Me.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bCancel.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bCancel.Location = New System.Drawing.Point(353, 228)
        Me.bCancel.Name = "bCancel"
        Me.bCancel.Size = New System.Drawing.Size(94, 36)
        Me.bCancel.TabIndex = 22
        Me.bCancel.Text = "      &Cancel"
        Me.bCancel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(107, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 19)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Contact Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(107, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 19)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Contact Person"
        '
        'tbContactN
        '
        Me.tbContactN.BackColor = System.Drawing.Color.LightYellow
        Me.tbContactN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbContactN.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbContactN.Location = New System.Drawing.Point(224, 187)
        Me.tbContactN.Name = "tbContactN"
        Me.tbContactN.Size = New System.Drawing.Size(181, 26)
        Me.tbContactN.TabIndex = 19
        '
        'tbContactP
        '
        Me.tbContactP.BackColor = System.Drawing.Color.LightYellow
        Me.tbContactP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbContactP.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbContactP.Location = New System.Drawing.Point(224, 151)
        Me.tbContactP.Name = "tbContactP"
        Me.tbContactP.Size = New System.Drawing.Size(181, 26)
        Me.tbContactP.TabIndex = 18
        '
        'tbRFIDno
        '
        Me.tbRFIDno.BackColor = System.Drawing.Color.LightYellow
        Me.tbRFIDno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbRFIDno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRFIDno.Location = New System.Drawing.Point(224, 116)
        Me.tbRFIDno.Name = "tbRFIDno"
        Me.tbRFIDno.Size = New System.Drawing.Size(181, 26)
        Me.tbRFIDno.TabIndex = 17
        '
        'bSave
        '
        Me.bSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bSave.FlatAppearance.BorderSize = 0
        Me.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bSave.Location = New System.Drawing.Point(154, 228)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(94, 36)
        Me.bSave.TabIndex = 16
        Me.bSave.Text = "      &Save"
        Me.bSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(107, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 19)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "RFID No"
        '
        'bUpdate
        '
        Me.bUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bUpdate.FlatAppearance.BorderSize = 0
        Me.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bUpdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bUpdate.Location = New System.Drawing.Point(254, 228)
        Me.bUpdate.Name = "bUpdate"
        Me.bUpdate.Size = New System.Drawing.Size(94, 36)
        Me.bUpdate.TabIndex = 25
        Me.bUpdate.Text = "      &Update"
        Me.bUpdate.UseVisualStyleBackColor = True
        '
        'BLook
        '
        Me.BLook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BLook.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BLook.Location = New System.Drawing.Point(409, 44)
        Me.BLook.Name = "BLook"
        Me.BLook.Size = New System.Drawing.Size(85, 26)
        Me.BLook.TabIndex = 26
        Me.BLook.Text = "&Get ID"
        Me.BLook.UseVisualStyleBackColor = True
        '
        'tbStudName
        '
        Me.tbStudName.BackColor = System.Drawing.Color.LightYellow
        Me.tbStudName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbStudName.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStudName.Location = New System.Drawing.Point(224, 80)
        Me.tbStudName.Name = "tbStudName"
        Me.tbStudName.Size = New System.Drawing.Size(181, 26)
        Me.tbStudName.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(107, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 19)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Student Name"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.Panel1.Controls.Add(Me.tbGetUID)
        Me.Panel1.Controls.Add(Me.tbRFIDno)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tbContactP)
        Me.Panel1.Controls.Add(Me.tbStudName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.BLook)
        Me.Panel1.Controls.Add(Me.bSave)
        Me.Panel1.Controls.Add(Me.bUpdate)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.bCancel)
        Me.Panel1.Controls.Add(Me.tbStudentId)
        Me.Panel1.Controls.Add(Me.tbContactN)
        Me.Panel1.Location = New System.Drawing.Point(0, 76)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(585, 300)
        Me.Panel1.TabIndex = 29
        '
        'tbGetUID
        '
        Me.tbGetUID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbGetUID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGetUID.Location = New System.Drawing.Point(409, 116)
        Me.tbGetUID.Name = "tbGetUID"
        Me.tbGetUID.Size = New System.Drawing.Size(85, 26)
        Me.tbGetUID.TabIndex = 29
        Me.tbGetUID.Text = "&Get UID"
        Me.tbGetUID.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.tbGetUID2)
        Me.Panel3.Controls.Add(Me.tbRFIDNo2)
        Me.Panel3.Controls.Add(Me.tbContactP2)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.BSave2)
        Me.Panel3.Controls.Add(Me.BUpdate2)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Button4)
        Me.Panel3.Controls.Add(Me.tbStudentId2)
        Me.Panel3.Controls.Add(Me.tbContactN2)
        Me.Panel3.Location = New System.Drawing.Point(3, 79)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(585, 297)
        Me.Panel3.TabIndex = 30
        '
        'tbGetUID2
        '
        Me.tbGetUID2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbGetUID2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGetUID2.Location = New System.Drawing.Point(409, 79)
        Me.tbGetUID2.Name = "tbGetUID2"
        Me.tbGetUID2.Size = New System.Drawing.Size(85, 26)
        Me.tbGetUID2.TabIndex = 30
        Me.tbGetUID2.Text = "&Get UID"
        Me.tbGetUID2.UseVisualStyleBackColor = True
        '
        'tbRFIDNo2
        '
        Me.tbRFIDNo2.BackColor = System.Drawing.Color.LightYellow
        Me.tbRFIDNo2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbRFIDNo2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRFIDNo2.Location = New System.Drawing.Point(224, 78)
        Me.tbRFIDNo2.Name = "tbRFIDNo2"
        Me.tbRFIDNo2.Size = New System.Drawing.Size(181, 26)
        Me.tbRFIDNo2.TabIndex = 17
        '
        'tbContactP2
        '
        Me.tbContactP2.BackColor = System.Drawing.Color.LightYellow
        Me.tbContactP2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbContactP2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbContactP2.Location = New System.Drawing.Point(224, 112)
        Me.tbContactP2.Name = "tbContactP2"
        Me.tbContactP2.Size = New System.Drawing.Size(181, 26)
        Me.tbContactP2.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(107, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 19)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Contact Person"
        '
        'BSave2
        '
        Me.BSave2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BSave2.FlatAppearance.BorderSize = 0
        Me.BSave2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BSave2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSave2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BSave2.Location = New System.Drawing.Point(137, 205)
        Me.BSave2.Name = "BSave2"
        Me.BSave2.Size = New System.Drawing.Size(96, 43)
        Me.BSave2.TabIndex = 16
        Me.BSave2.Text = "  &Save"
        Me.BSave2.UseVisualStyleBackColor = True
        '
        'BUpdate2
        '
        Me.BUpdate2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BUpdate2.FlatAppearance.BorderSize = 0
        Me.BUpdate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BUpdate2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BUpdate2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BUpdate2.Location = New System.Drawing.Point(238, 205)
        Me.BUpdate2.Name = "BUpdate2"
        Me.BUpdate2.Size = New System.Drawing.Size(96, 43)
        Me.BUpdate2.TabIndex = 25
        Me.BUpdate2.Text = "      &Update"
        Me.BUpdate2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(107, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 19)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Contact Number"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(107, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 19)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Student Id"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(107, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 19)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "RFID No"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(339, 205)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(96, 43)
        Me.Button4.TabIndex = 22
        Me.Button4.Text = "       &Cancel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'tbStudentId2
        '
        Me.tbStudentId2.BackColor = System.Drawing.Color.LightYellow
        Me.tbStudentId2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbStudentId2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStudentId2.Location = New System.Drawing.Point(224, 44)
        Me.tbStudentId2.Name = "tbStudentId2"
        Me.tbStudentId2.Size = New System.Drawing.Size(181, 26)
        Me.tbStudentId2.TabIndex = 23
        '
        'tbContactN2
        '
        Me.tbContactN2.BackColor = System.Drawing.Color.LightYellow
        Me.tbContactN2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbContactN2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbContactN2.Location = New System.Drawing.Point(224, 146)
        Me.tbContactN2.Name = "tbContactN2"
        Me.tbContactN2.Size = New System.Drawing.Size(181, 26)
        Me.tbContactN2.TabIndex = 19
        '
        'FormRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 376)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormRegistration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registration From"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents tbStudentId As TextBox
    Friend WithEvents bCancel As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tbContactN As TextBox
    Friend WithEvents tbContactP As TextBox
    Friend WithEvents tbRFIDno As TextBox
    Friend WithEvents bSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bUpdate As Button
    Friend WithEvents BLook As Button
    Friend WithEvents tbStudName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents tbRFIDNo2 As TextBox
    Friend WithEvents tbContactP2 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents BSave2 As Button
    Friend WithEvents BUpdate2 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents tbStudentId2 As TextBox
    Friend WithEvents tbContactN2 As TextBox
    Friend WithEvents tbGetUID As Button
    Friend WithEvents tbGetUID2 As Button
End Class
