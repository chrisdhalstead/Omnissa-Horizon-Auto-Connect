<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lblClient = New System.Windows.Forms.Label()
        Me.grpPool = New System.Windows.Forms.GroupBox()
        Me.RadioApp = New System.Windows.Forms.RadioButton()
        Me.txtPool = New System.Windows.Forms.TextBox()
        Me.lblPool = New System.Windows.Forms.Label()
        Me.RadioDT = New System.Windows.Forms.RadioButton()
        Me.GrpProtocol = New System.Windows.Forms.GroupBox()
        Me.radRDP = New System.Windows.Forms.RadioButton()
        Me.radPCOIP = New System.Windows.Forms.RadioButton()
        Me.GrpCS = New System.Windows.Forms.GroupBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.grpsettings = New System.Windows.Forms.GroupBox()
        Me.btnRefreshCMD = New System.Windows.Forms.Button()
        Me.txtCustString = New System.Windows.Forms.TextBox()
        Me.chkHideClient = New System.Windows.Forms.CheckBox()
        Me.chkCustCmd = New System.Windows.Forms.CheckBox()
        Me.chkQuitClient = New System.Windows.Forms.CheckBox()
        Me.chkShade = New System.Windows.Forms.CheckBox()
        Me.chkAutoConnect = New System.Windows.Forms.CheckBox()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.chkUSBInsert = New System.Windows.Forms.CheckBox()
        Me.chkUSBStartup = New System.Windows.Forms.CheckBox()
        Me.txtDomain = New System.Windows.Forms.TextBox()
        Me.lblDomain = New System.Windows.Forms.Label()
        Me.txtPW = New System.Windows.Forms.TextBox()
        Me.lblPW = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.cmbDTLayout = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkCurrentUser = New System.Windows.Forms.CheckBox()
        Me.chkSilent = New System.Windows.Forms.CheckBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdateSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.rtbNoClient = New System.Windows.Forms.RichTextBox()
        Me.PnlNoClient = New System.Windows.Forms.Panel()
        Me.grpPool.SuspendLayout()
        Me.GrpProtocol.SuspendLayout()
        Me.GrpCS.SuspendLayout()
        Me.grpsettings.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.PnlNoClient.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblClient
        '
        Me.lblClient.AutoSize = True
        Me.lblClient.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.Location = New System.Drawing.Point(12, 30)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(114, 13)
        Me.lblClient.TabIndex = 1
        Me.lblClient.Text = "Is Client Detected?"
        '
        'grpPool
        '
        Me.grpPool.Controls.Add(Me.RadioApp)
        Me.grpPool.Controls.Add(Me.txtPool)
        Me.grpPool.Controls.Add(Me.lblPool)
        Me.grpPool.Controls.Add(Me.RadioDT)
        Me.grpPool.Location = New System.Drawing.Point(12, 50)
        Me.grpPool.Name = "grpPool"
        Me.grpPool.Size = New System.Drawing.Size(446, 70)
        Me.grpPool.TabIndex = 2
        Me.grpPool.TabStop = False
        Me.grpPool.Text = "Connect Directly to Application or Desktop Pool?"
        '
        'RadioApp
        '
        Me.RadioApp.AutoSize = True
        Me.RadioApp.Location = New System.Drawing.Point(85, 20)
        Me.RadioApp.Name = "RadioApp"
        Me.RadioApp.Size = New System.Drawing.Size(77, 17)
        Me.RadioApp.TabIndex = 6
        Me.RadioApp.TabStop = True
        Me.RadioApp.Text = "Application"
        Me.RadioApp.UseVisualStyleBackColor = True
        '
        'txtPool
        '
        Me.txtPool.Location = New System.Drawing.Point(194, 43)
        Me.txtPool.Name = "txtPool"
        Me.txtPool.Size = New System.Drawing.Size(236, 21)
        Me.txtPool.TabIndex = 4
        '
        'lblPool
        '
        Me.lblPool.AutoSize = True
        Me.lblPool.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPool.Location = New System.Drawing.Point(11, 44)
        Me.lblPool.Name = "lblPool"
        Me.lblPool.Size = New System.Drawing.Size(83, 13)
        Me.lblPool.TabIndex = 5
        Me.lblPool.Text = "Name of Pool:"
        '
        'RadioDT
        '
        Me.RadioDT.AutoSize = True
        Me.RadioDT.Location = New System.Drawing.Point(14, 20)
        Me.RadioDT.Name = "RadioDT"
        Me.RadioDT.Size = New System.Drawing.Size(64, 17)
        Me.RadioDT.TabIndex = 4
        Me.RadioDT.TabStop = True
        Me.RadioDT.Text = "Desktop"
        Me.RadioDT.UseVisualStyleBackColor = True
        '
        'GrpProtocol
        '
        Me.GrpProtocol.Controls.Add(Me.radRDP)
        Me.GrpProtocol.Controls.Add(Me.radPCOIP)
        Me.GrpProtocol.Location = New System.Drawing.Point(12, 126)
        Me.GrpProtocol.Name = "GrpProtocol"
        Me.GrpProtocol.Size = New System.Drawing.Size(141, 70)
        Me.GrpProtocol.TabIndex = 3
        Me.GrpProtocol.TabStop = False
        Me.GrpProtocol.Text = "Protocol:"
        '
        'radRDP
        '
        Me.radRDP.AutoSize = True
        Me.radRDP.Location = New System.Drawing.Point(78, 30)
        Me.radRDP.Name = "radRDP"
        Me.radRDP.Size = New System.Drawing.Size(45, 17)
        Me.radRDP.TabIndex = 4
        Me.radRDP.Text = "RDP"
        Me.radRDP.UseVisualStyleBackColor = True
        '
        'radPCOIP
        '
        Me.radPCOIP.AutoSize = True
        Me.radPCOIP.Location = New System.Drawing.Point(16, 30)
        Me.radPCOIP.Name = "radPCOIP"
        Me.radPCOIP.Size = New System.Drawing.Size(56, 17)
        Me.radPCOIP.TabIndex = 3
        Me.radPCOIP.Text = "PCOIP"
        Me.radPCOIP.UseVisualStyleBackColor = True
        '
        'GrpCS
        '
        Me.GrpCS.Controls.Add(Me.txtServer)
        Me.GrpCS.Location = New System.Drawing.Point(159, 126)
        Me.GrpCS.Name = "GrpCS"
        Me.GrpCS.Size = New System.Drawing.Size(299, 70)
        Me.GrpCS.TabIndex = 4
        Me.GrpCS.TabStop = False
        Me.GrpCS.Text = "View Connection Server:"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(21, 30)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(262, 21)
        Me.txtServer.TabIndex = 5
        '
        'grpsettings
        '
        Me.grpsettings.Controls.Add(Me.btnRefreshCMD)
        Me.grpsettings.Controls.Add(Me.txtCustString)
        Me.grpsettings.Controls.Add(Me.chkHideClient)
        Me.grpsettings.Controls.Add(Me.chkCustCmd)
        Me.grpsettings.Controls.Add(Me.chkQuitClient)
        Me.grpsettings.Controls.Add(Me.chkShade)
        Me.grpsettings.Controls.Add(Me.chkAutoConnect)
        Me.grpsettings.Controls.Add(Me.btnTest)
        Me.grpsettings.Controls.Add(Me.chkUSBInsert)
        Me.grpsettings.Controls.Add(Me.chkUSBStartup)
        Me.grpsettings.Controls.Add(Me.txtDomain)
        Me.grpsettings.Controls.Add(Me.lblDomain)
        Me.grpsettings.Controls.Add(Me.txtPW)
        Me.grpsettings.Controls.Add(Me.lblPW)
        Me.grpsettings.Controls.Add(Me.txtUsername)
        Me.grpsettings.Controls.Add(Me.lblUserName)
        Me.grpsettings.Controls.Add(Me.cmbDTLayout)
        Me.grpsettings.Controls.Add(Me.Label1)
        Me.grpsettings.Controls.Add(Me.chkCurrentUser)
        Me.grpsettings.Controls.Add(Me.chkSilent)
        Me.grpsettings.Location = New System.Drawing.Point(12, 202)
        Me.grpsettings.Name = "grpsettings"
        Me.grpsettings.Size = New System.Drawing.Size(446, 241)
        Me.grpsettings.TabIndex = 5
        Me.grpsettings.TabStop = False
        Me.grpsettings.Text = "Settings:"
        '
        'btnRefreshCMD
        '
        Me.btnRefreshCMD.Location = New System.Drawing.Point(173, 145)
        Me.btnRefreshCMD.Name = "btnRefreshCMD"
        Me.btnRefreshCMD.Size = New System.Drawing.Size(59, 25)
        Me.btnRefreshCMD.TabIndex = 30
        Me.btnRefreshCMD.Text = "Refresh"
        Me.btnRefreshCMD.UseVisualStyleBackColor = True
        Me.btnRefreshCMD.Visible = False
        '
        'txtCustString
        '
        Me.txtCustString.Location = New System.Drawing.Point(9, 173)
        Me.txtCustString.Name = "txtCustString"
        Me.txtCustString.Size = New System.Drawing.Size(430, 21)
        Me.txtCustString.TabIndex = 29
        Me.txtCustString.Visible = False
        '
        'chkHideClient
        '
        Me.chkHideClient.AutoSize = True
        Me.chkHideClient.Location = New System.Drawing.Point(242, 148)
        Me.chkHideClient.Name = "chkHideClient"
        Me.chkHideClient.Size = New System.Drawing.Size(167, 17)
        Me.chkHideClient.TabIndex = 28
        Me.chkHideClient.Text = "Hide View Client After Launch"
        Me.chkHideClient.UseVisualStyleBackColor = True
        '
        'chkCustCmd
        '
        Me.chkCustCmd.AutoSize = True
        Me.chkCustCmd.Location = New System.Drawing.Point(11, 148)
        Me.chkCustCmd.Name = "chkCustCmd"
        Me.chkCustCmd.Size = New System.Drawing.Size(164, 17)
        Me.chkCustCmd.TabIndex = 27
        Me.chkCustCmd.Text = "Use Custom Command String"
        Me.chkCustCmd.UseVisualStyleBackColor = True
        '
        'chkQuitClient
        '
        Me.chkQuitClient.AutoSize = True
        Me.chkQuitClient.Location = New System.Drawing.Point(11, 125)
        Me.chkQuitClient.Name = "chkQuitClient"
        Me.chkQuitClient.Size = New System.Drawing.Size(195, 17)
        Me.chkQuitClient.TabIndex = 26
        Me.chkQuitClient.Text = "Quit Application when Session Ends"
        Me.chkQuitClient.UseVisualStyleBackColor = True
        '
        'chkShade
        '
        Me.chkShade.AutoSize = True
        Me.chkShade.Location = New System.Drawing.Point(242, 102)
        Me.chkShade.Name = "chkShade"
        Me.chkShade.Size = New System.Drawing.Size(93, 17)
        Me.chkShade.TabIndex = 24
        Me.chkShade.Text = "Disable Shade"
        Me.chkShade.UseVisualStyleBackColor = True
        '
        'chkAutoConnect
        '
        Me.chkAutoConnect.AutoSize = True
        Me.chkAutoConnect.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoConnect.Location = New System.Drawing.Point(8, 212)
        Me.chkAutoConnect.Name = "chkAutoConnect"
        Me.chkAutoConnect.Size = New System.Drawing.Size(184, 20)
        Me.chkAutoConnect.TabIndex = 23
        Me.chkAutoConnect.Text = "Enable AutoConnection?"
        Me.chkAutoConnect.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(326, 210)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(114, 24)
        Me.btnTest.TabIndex = 22
        Me.btnTest.Text = "Test Connection"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'chkUSBInsert
        '
        Me.chkUSBInsert.AutoSize = True
        Me.chkUSBInsert.Location = New System.Drawing.Point(242, 79)
        Me.chkUSBInsert.Name = "chkUSBInsert"
        Me.chkUSBInsert.Size = New System.Drawing.Size(175, 17)
        Me.chkUSBInsert.TabIndex = 21
        Me.chkUSBInsert.Text = "Connect USB Devices on Insert"
        Me.chkUSBInsert.UseVisualStyleBackColor = True
        '
        'chkUSBStartup
        '
        Me.chkUSBStartup.AutoSize = True
        Me.chkUSBStartup.Location = New System.Drawing.Point(242, 54)
        Me.chkUSBStartup.Name = "chkUSBStartup"
        Me.chkUSBStartup.Size = New System.Drawing.Size(182, 17)
        Me.chkUSBStartup.TabIndex = 20
        Me.chkUSBStartup.Text = "Connect USB Devices on Startup"
        Me.chkUSBStartup.UseVisualStyleBackColor = True
        '
        'txtDomain
        '
        Me.txtDomain.Location = New System.Drawing.Point(73, 96)
        Me.txtDomain.Name = "txtDomain"
        Me.txtDomain.Size = New System.Drawing.Size(95, 21)
        Me.txtDomain.TabIndex = 19
        '
        'lblDomain
        '
        Me.lblDomain.AutoSize = True
        Me.lblDomain.Location = New System.Drawing.Point(22, 99)
        Me.lblDomain.Name = "lblDomain"
        Me.lblDomain.Size = New System.Drawing.Size(46, 13)
        Me.lblDomain.TabIndex = 18
        Me.lblDomain.Text = "Domain:"
        '
        'txtPW
        '
        Me.txtPW.Location = New System.Drawing.Point(73, 71)
        Me.txtPW.Name = "txtPW"
        Me.txtPW.Size = New System.Drawing.Size(95, 21)
        Me.txtPW.TabIndex = 17
        Me.txtPW.UseSystemPasswordChar = True
        '
        'lblPW
        '
        Me.lblPW.AutoSize = True
        Me.lblPW.Location = New System.Drawing.Point(11, 74)
        Me.lblPW.Name = "lblPW"
        Me.lblPW.Size = New System.Drawing.Size(57, 13)
        Me.lblPW.TabIndex = 16
        Me.lblPW.Text = "Password:"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(73, 46)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(95, 21)
        Me.txtUsername.TabIndex = 15
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(8, 49)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(59, 13)
        Me.lblUserName.TabIndex = 14
        Me.lblUserName.Text = "Username:"
        '
        'cmbDTLayout
        '
        Me.cmbDTLayout.FormattingEnabled = True
        Me.cmbDTLayout.Items.AddRange(New Object() {"fullscreen", "multimonitor", "windowLarge", "windowSmall"})
        Me.cmbDTLayout.Location = New System.Drawing.Point(304, 22)
        Me.cmbDTLayout.Name = "cmbDTLayout"
        Me.cmbDTLayout.Size = New System.Drawing.Size(125, 21)
        Me.cmbDTLayout.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(216, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Desktop Layout:"
        '
        'chkCurrentUser
        '
        Me.chkCurrentUser.AutoSize = True
        Me.chkCurrentUser.Location = New System.Drawing.Point(8, 22)
        Me.chkCurrentUser.Name = "chkCurrentUser"
        Me.chkCurrentUser.Size = New System.Drawing.Size(135, 17)
        Me.chkCurrentUser.TabIndex = 7
        Me.chkCurrentUser.Text = "Login as Current User?"
        Me.chkCurrentUser.UseVisualStyleBackColor = True
        '
        'chkSilent
        '
        Me.chkSilent.AutoSize = True
        Me.chkSilent.Location = New System.Drawing.Point(242, 125)
        Me.chkSilent.Name = "chkSilent"
        Me.chkSilent.Size = New System.Drawing.Size(178, 17)
        Me.chkSilent.TabIndex = 0
        Me.chkSilent.Text = "Launch Desktop Session Silently"
        Me.chkSilent.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "VMware View AutoConnect"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateSettingsToolStripMenuItem, Me.ExitToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(158, 48)
        '
        'UpdateSettingsToolStripMenuItem
        '
        Me.UpdateSettingsToolStripMenuItem.Name = "UpdateSettingsToolStripMenuItem"
        Me.UpdateSettingsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.UpdateSettingsToolStripMenuItem.Text = "Update Settings"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Gnome-Preferences-Desktop-Remote-Desktop-64.ico")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(466, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Timer1
        '
        '
        'rtbNoClient
        '
        Me.rtbNoClient.BackColor = System.Drawing.Color.Yellow
        Me.rtbNoClient.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbNoClient.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbNoClient.Location = New System.Drawing.Point(3, 0)
        Me.rtbNoClient.Name = "rtbNoClient"
        Me.rtbNoClient.ReadOnly = True
        Me.rtbNoClient.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rtbNoClient.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtbNoClient.Size = New System.Drawing.Size(453, 78)
        Me.rtbNoClient.TabIndex = 0
        Me.rtbNoClient.Text = "No VMware View Client Detected.  " & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Please download and install the latest 3.x cli" & _
    "ent from the following URL:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "https://www.vmware.com/go/viewclients"
        '
        'PnlNoClient
        '
        Me.PnlNoClient.Controls.Add(Me.rtbNoClient)
        Me.PnlNoClient.Location = New System.Drawing.Point(12, 50)
        Me.PnlNoClient.Name = "PnlNoClient"
        Me.PnlNoClient.Size = New System.Drawing.Size(460, 76)
        Me.PnlNoClient.TabIndex = 9
        Me.PnlNoClient.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 453)
        Me.Controls.Add(Me.PnlNoClient)
        Me.Controls.Add(Me.grpsettings)
        Me.Controls.Add(Me.GrpCS)
        Me.Controls.Add(Me.GrpProtocol)
        Me.Controls.Add(Me.grpPool)
        Me.Controls.Add(Me.lblClient)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VMware Horizon View AutoConnect"
        Me.grpPool.ResumeLayout(False)
        Me.grpPool.PerformLayout()
        Me.GrpProtocol.ResumeLayout(False)
        Me.GrpProtocol.PerformLayout()
        Me.GrpCS.ResumeLayout(False)
        Me.GrpCS.PerformLayout()
        Me.grpsettings.ResumeLayout(False)
        Me.grpsettings.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PnlNoClient.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblClient As System.Windows.Forms.Label
    Friend WithEvents grpPool As System.Windows.Forms.GroupBox
    Friend WithEvents lblPool As System.Windows.Forms.Label
    Friend WithEvents RadioDT As System.Windows.Forms.RadioButton
    Friend WithEvents GrpProtocol As System.Windows.Forms.GroupBox
    Friend WithEvents radRDP As System.Windows.Forms.RadioButton
    Friend WithEvents radPCOIP As System.Windows.Forms.RadioButton
    Friend WithEvents txtPool As System.Windows.Forms.TextBox
    Friend WithEvents GrpCS As System.Windows.Forms.GroupBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents grpsettings As System.Windows.Forms.GroupBox
    Friend WithEvents chkSilent As System.Windows.Forms.CheckBox
    Friend WithEvents chkCurrentUser As System.Windows.Forms.CheckBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbDTLayout As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents txtDomain As System.Windows.Forms.TextBox
    Friend WithEvents lblDomain As System.Windows.Forms.Label
    Friend WithEvents txtPW As System.Windows.Forms.TextBox
    Friend WithEvents lblPW As System.Windows.Forms.Label

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rtbNoClient As System.Windows.Forms.RichTextBox
    Friend WithEvents chkAutoConnect As System.Windows.Forms.CheckBox
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents chkUSBInsert As System.Windows.Forms.CheckBox
    Friend WithEvents chkUSBStartup As System.Windows.Forms.CheckBox
    Friend WithEvents PnlNoClient As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UpdateSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadioApp As System.Windows.Forms.RadioButton
    Friend WithEvents chkShade As System.Windows.Forms.CheckBox
    Friend WithEvents txtCustString As System.Windows.Forms.TextBox
    Friend WithEvents chkHideClient As System.Windows.Forms.CheckBox
    Friend WithEvents chkCustCmd As System.Windows.Forms.CheckBox
    Friend WithEvents chkQuitClient As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefreshCMD As System.Windows.Forms.Button
End Class
