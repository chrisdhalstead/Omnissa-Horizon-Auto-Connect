Imports System.IO
Imports Microsoft.Win32


Public Class Form1

    Const sclientpath32 = "C:\Program Files\VMware\VMware Horizon View Client\"
    Const sclientpath64 = "C:\Program Files (x86)\VMware\VMware Horizon View Client\"
    Const sclientcu32 = "Software\VMware, Inc.\VMware VDM\Client"
    Const sclientcu64 = "SOFTWARE\Wow6432Node\VMware, Inc.\VMware VDM\Client"
    Public bis64 As Boolean = Environment.Is64BitOperatingSystem
    Public sclientpath As String = ""
    Public spooltype As String = ""
    Public sprotocol As String = ""
    Public sserver As String = ""
    Public spool As String = ""
    Public sdtlayout As String = ""
    Public bsilent As Boolean
    Public bautoconnect As Boolean = False
    Public bnoclient As Boolean
    Public btest As Boolean
    Public herrors As New Hashtable
    Public sclientregpath As String = ""
    Public blauncherror As Boolean = False
    Public sstring As String = ""
    Public sver As FileVersionInfo
    Public sversion As String = ""
    Public bquitonsessionend As Boolean = False
    Public bcustomcommand As Boolean = False

    Function Reg_Read(ByVal spath As String, ByVal sname As String) As String

        Dim regKey As RegistryKey
        Dim svalue As String

        Try

            regKey = Registry.CurrentUser.OpenSubKey(spath, True)

            'regKey.GetAccessControl(System.Security.AccessControl.AccessControlSections.All)

            svalue = regKey.GetValue(sname)
            If svalue = Nothing Then

                Return "NO_VALUE"

            End If

            Return svalue
            regKey.Close()

        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
            Return "ERROR"

        End Try



    End Function

    Function Reg_Read_LM(ByVal spath As String, ByVal sname As String) As String

        Dim regKey As RegistryKey
        Dim svalue As String

        Try

            regKey = Registry.LocalMachine.OpenSubKey(spath, True)
            svalue = regKey.GetValue(sname)
            If svalue = Nothing Then

                Return "NO_VALUE"

            End If

            Return svalue
            regKey.Close()

        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
            Return "ERROR"

        End Try



    End Function



    Sub Reg_Write(ByVal spath As String, ByVal sname As String, ByVal svalue As String)

        Dim regKey As RegistryKey

        Try

            regKey = Registry.CurrentUser.OpenSubKey(spath, True)
            regKey.SetValue(sname, svalue)
            regKey.Close()

        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)


        End Try

    End Sub

    Sub Reg_Write_LM(ByVal spath As String, ByVal sname As String, ByVal svalue As String)

        Dim regKey As RegistryKey

        Try

            regKey = Registry.LocalMachine.OpenSubKey(spath, True)
            regKey.SetValue(sname, svalue)
            regKey.Close()

        Catch ex As Exception

            If ex.Message = "Requested registry access is not allowed." Then

                MessageBox.Show("Permission Error: Please right-click the application and choose to ""Run as Administrator"" to make this registry change.")

            End If


        End Try

    End Sub

    Private Sub Form1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        If Me.Disposing Then
            NotifyIcon1.Dispose()
        End If

    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            'The user has requested the form be closed so mimimise to the system tray instead.
            e.Cancel = True
            Me.Visible = False
            Me.NotifyIcon1.Visible = True
        End If

    End Sub


    Function CheckIfRunning() As Boolean

        Dim myProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()

        Dim iproc As Integer = myProcess.Id

        Dim p() As Process
        p = Process.GetProcessesByName("View_AutoConnect")

        If p.Count > 0 Then

            For i = 0 To p.Count - 1

                If p(i).Id <> iproc Then

                    Return True

                End If

            Next

            Return False

        Else
            Return False
        End If

    End Function



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim arguments As String() = Environment.GetCommandLineArgs()

        If CheckIfRunning() = True Then

            MsgBox("The View AutoConnection utility is already running on this system. Please check the system tray.", MsgBoxStyle.Information, "Already Running")

            End

        End If

        'Create reg key for settings
        If reg_key_exists("Software\VMware Flings\View AutoConnect") = False Then

            Try
                Registry.CurrentUser.CreateSubKey("Software\VMware Flings\View AutoConnect")

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message)

            End Try

        End If

        If reg_key_exists(sclientcu32) = False Then

            Try
                Registry.CurrentUser.CreateSubKey(sclientcu32)

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message)

            End Try

        End If


        If bis64 = True Then

            sclientpath = sclientpath64
            sclientregpath = sclientcu64

        Else

            sclientpath = sclientpath32
            sclientregpath = sclientcu32

        End If


        If reg_key_exists(sclientregpath) = False Then

            Try
                Registry.CurrentUser.CreateSubKey(sclientregpath)

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message)

            End Try

        End If


        If File.Exists(sclientpath & "vmware-view.exe") Then

            sver = FileVersionInfo.GetVersionInfo(sclientpath & "vmware-view.exe")

            sversion = sver.FileVersion

            lblClient.Text = "Found View Client Version:  " & sver.FileVersion

            Reg_Write("Software\VMware Flings\View AutoConnect", "Client Version", sver.FileVersion)

            bnoclient = False

        Else

            PnlNoClient.Visible = True
            rtbNoClient.SelectionAlignment = HorizontalAlignment.Center
            GrpCS.Enabled = False
            grpsettings.Enabled = False
            grpPool.Enabled = False
            GrpProtocol.Enabled = False
            lblClient.Text = "No View Client Detected"
            bnoclient = True


        End If

        If bnoclient = False Then

            pop_errors()

            If Reg_Read("Software\VMware Flings\View AutoConnect", "Client Version") <> "NO_VALUE" Then

                txtServer.Text = Reg_Read("Software\VMware Flings\View AutoConnect", "Connection Server")

            End If

            If Reg_Read("Software\VMware Flings\View AutoConnect", "Desktop Layout") <> "NO_VALUE" Then

                cmbDTLayout.SelectedItem = Reg_Read("Software\VMware Flings\View AutoConnect", "Desktop Layout")

            End If


            If Reg_Read("Software\VMware Flings\View AutoConnect", "Pool Name") <> "NO_VALUE" Then

                txtPool.Text = Reg_Read("Software\VMware Flings\View AutoConnect", "Pool Name")

            End If

            If Reg_Read("Software\VMware Flings\View AutoConnect", "Launch Silent") <> "NO_VALUE" Then

                chkSilent.Checked = Reg_Read("Software\VMware Flings\View AutoConnect", "Launch Silent")

            End If

            If sversion < "3.1" Then

                chkHideClient.Checked = False
                chkHideClient.Enabled = False

            Else

                If Reg_Read("Software\VMware Flings\View AutoConnect", "Hide Client") <> "NO_VALUE" Then

                    chkHideClient.Checked = Reg_Read("Software\VMware Flings\View AutoConnect", "Hide Client")

                End If

            End If

            If Reg_Read("Software\VMware Flings\View AutoConnect", "USB Startup") <> "NO_VALUE" Then

                chkUSBStartup.Checked = Reg_Read("Software\VMware Flings\View AutoConnect", "USB Startup")

            End If


            If Reg_Read("Software\VMware Flings\View AutoConnect", "Custom Command") <> "NO_VALUE" Then

                chkCustCmd.Checked = Reg_Read("Software\VMware Flings\View AutoConnect", "Custom Command")

                If chkCustCmd.Checked = True Then

                    If Reg_Read("Software\VMware Flings\View AutoConnect", "Command") <> "NO_VALUE" Then

                        txtCustString.Text = Reg_Read("Software\VMware Flings\View AutoConnect", "Command")

                    End If


                End If



            End If

        End If


        If Reg_Read("Software\VMware Flings\View AutoConnect", "USB Insert") <> "NO_VALUE" Then

            chkUSBInsert.Checked = Reg_Read("Software\VMware Flings\View AutoConnect", "USB Insert")

        End If

        If Reg_Read("Software\VMware Flings\View AutoConnect", "Quit App on Session End") <> "NO_VALUE" Then

            chkQuitClient.Checked = Reg_Read("Software\VMware Flings\View AutoConnect", "Quit App on Session End")

        End If

        If Reg_Read("Software\VMware Flings\View AutoConnect", "Login as Current User") <> "NO_VALUE" Then

            chkCurrentUser.Checked = Reg_Read("Software\VMware Flings\View AutoConnect", "Login as Current User")

            If chkCurrentUser.Checked = False Then

                Reg_Write("Software\VMware Flings\View AutoConnect", "Login as Current User", "False")


            End If


        End If

        If Reg_Read(sclientcu32, "UserName") <> "NO_VALUE" Then

            txtUsername.Text = Reg_Read(sclientcu32, "UserName")

        Else

            txtUsername.Text = ""

        End If

        If Reg_Read(sclientcu32, "Password") <> "NO_VALUE" Then

            txtPW.Text = Reg_Read(sclientcu32, "Password")

        Else

            txtPW.Text = ""

        End If

        If Reg_Read(sclientcu32, "EnableShade") <> "NO_VALUE" Then

            Dim txttemp As Boolean = Reg_Read(sclientcu32, "EnableShade")

            If txttemp = False Then

                chkShade.Checked = True

            End If

            If txttemp = True Then

                chkShade.Checked = False

            End If

        End If

        If Reg_Read("Software\VMware Flings\View AutoConnect", "Domain") <> "NO_VALUE" Then

            txtDomain.Text = Reg_Read("Software\VMware Flings\View AutoConnect", "Domain")

        Else

            txtDomain.Text = ""

        End If

        If Reg_Read("Software\VMware Flings\View AutoConnect", "Connection Server") <> "NO_VALUE" Then

            txtServer.Text = Reg_Read("Software\VMware Flings\View AutoConnect", "Connection Server")

        Else

            txtServer.Text = ""

        End If

        If Reg_Read("Software\VMware Flings\View AutoConnect", "Pool Type") <> "NO_VALUE" Then

            Dim spooltype As String

            spooltype = Reg_Read("Software\VMware Flings\View AutoConnect", "Pool Type")

            Select Case spooltype

                Case "App"

                    RadioApp.Checked = True

                Case "DT"

                    RadioDT.Checked = True

                Case Else


                    RadioApp.Checked = False
                    RadioDT.Checked = False


            End Select


        End If

        If Reg_Read("Software\VMware Flings\View AutoConnect", "Protocol") <> "NO_VALUE" Then

            Dim sprottype As String

            sprottype = Reg_Read("Software\VMware Flings\View AutoConnect", "Protocol")

            Select Case sprottype

                Case "PCOIP"

                    radPCOIP.Checked = True

                Case "RDP"

                    radRDP.Checked = True

                Case Else

            End Select


        End If

        If Reg_Read("Software\VMware Flings\View AutoConnect", "AutoConnect") <> "NO_VALUE" Then

            Dim bauto As Boolean

            bauto = Reg_Read("Software\VMware Flings\View AutoConnect", "AutoConnect")

            If bauto = True Then

                bautoconnect = True
                chkAutoConnect.Checked = bautoconnect

            Else

                bautoconnect = False
                chkAutoConnect.Checked = bautoconnect

            End If

        End If

        If chkAutoConnect.Checked = True Then

            Timer1.Interval = 100
            Timer1.Enabled = True

            Launch_Desktop()

        End If


    End Sub

    Private Sub RadioApp_CheckedChanged(sender As Object, e As EventArgs)


        If RadioApp.Checked = True Then

            lblPool.Text = "Enter name of Application Pool: "
            spooltype = "-appname "

            Reg_Write("Software\VMware Flings\View AutoConnect", "Pool Type", "App")


        End If



    End Sub

    Private Sub RadioDT_CheckedChanged(sender As Object, e As EventArgs) Handles RadioDT.CheckedChanged


        If RadioDT.Checked = True Then


            lblPool.Text = "Enter name of Desktop Pool: "
            spooltype = "-desktopname "

            Reg_Write("Software\VMware Flings\View AutoConnect", "Pool Type", "DT")



        End If

    End Sub


    Private Sub txtServer_TextChanged(sender As Object, e As EventArgs) Handles txtServer.TextChanged


        Reg_Write("Software\VMware Flings\View AutoConnect", "Connection Server", txtServer.Text)

        sserver = txtServer.Text


    End Sub

    Private Sub chkSilent_CheckedChanged(sender As Object, e As EventArgs) Handles chkSilent.CheckedChanged

        If chkSilent.CheckState = CheckState.Checked Then

            Reg_Write("Software\VMware Flings\View AutoConnect", "Launch Silent", "True")
            bsilent = True
        Else

            Reg_Write("Software\VMware Flings\View AutoConnect", "Launch Silent", "False")
            bsilent = False

        End If

    End Sub

    Private Sub txtPool_TextChanged(sender As Object, e As EventArgs) Handles txtPool.TextChanged


        Reg_Write("Software\VMware Flings\View AutoConnect", "Pool Name", txtPool.Text)

        spool = txtPool.Text


    End Sub

    Sub Launch_Desktop()

        blauncherror = False

        Dim icount As Integer = 0

        build_string()

        Dim serrorstring As String = "Cannot Connect to Desktop - The following information is missing:" & vbCrLf & vbCrLf


        If RadioApp.Checked = False And RadioDT.Checked = False Then

            blauncherror = True
            serrorstring = serrorstring & "Pool Type Not Selected" & vbCrLf

        End If

        If txtPool.Text = "" Then

            blauncherror = True
            serrorstring = serrorstring & "Pool Information Missing" & vbCrLf

        End If

        If radPCOIP.Checked = False And radRDP.Checked = False Then

            blauncherror = True
            serrorstring = serrorstring & "Protocol Type Not Selected" & vbCrLf

        End If

        If txtServer.Text = "" Then

            blauncherror = True
            serrorstring = serrorstring & "View Connection Server Not Specified" & vbCrLf

        End If

        If cmbDTLayout.Text = "" Then

            blauncherror = True
            serrorstring = serrorstring & "No Desktop Layout Type Specified" & vbCrLf

        End If

        If chkCurrentUser.Checked = False Then

            If txtUsername.Text = "" Then

                blauncherror = True
                serrorstring = serrorstring & "Username Not Specified" & vbCrLf

            End If

            If txtPW.Text = "" Then

                blauncherror = True
                serrorstring = serrorstring & "Password Not Specified" & vbCrLf

            End If

            If txtDomain.Text = "" Then

                blauncherror = True
                serrorstring = serrorstring & "Domain Not Specified" & vbCrLf

            End If


        End If

        If blauncherror = True Then

            MessageBox.Show(serrorstring, "Error Connection to Desktop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub

        End If

        If bcustomcommand = True Then

            sstring = txtCustString.Text

        End If

        If btest = True Then

            btest = False

        End If

        Dim trdlaunchthread As New Threading.Thread(AddressOf launch_process_thread)

        trdlaunchthread.Start(sstring)

    End Sub

    Sub build_string()

        sstring = spooltype & """" & spool & """" & " -serverURL " & sserver & " -desktopLayout " & sdtlayout & " -desktopProtocol " & sprotocol

        If chkCurrentUser.Checked = True Then

            sstring = sstring & " -logInAsCurrentUser true "

        Else

            sstring = sstring & " -domainName " & txtDomain.Text & " -userName " & txtUsername.Text & " -password " & txtPW.Text


        End If

        If chkUSBInsert.Checked = True Then

            sstring = sstring & " -connectUSBOnInsert true "

        End If

        If chkHideClient.Checked = True Then

            sstring = sstring & " -hideClientAfterLaunchSession true "

        End If

        If chkUSBStartup.Checked = True Then

            sstring = sstring & " -connectUSBOnStartup true "

        End If

        If chkSilent.Checked Then sstring = sstring & " -noninteractive"


    End Sub



    Sub launch_process_thread(ByVal sstring As String)

        Dim myprocess As New Process

        Try

            Dim myProcessStartInfo As New ProcessStartInfo(sclientpath & "vmware-view.exe", sstring)

            myProcessStartInfo.UseShellExecute = False
            myProcessStartInfo.RedirectStandardError = True
            myprocess.StartInfo = myProcessStartInfo
            myprocess.Start()

            NotifyIcon1.BalloonTipText = "Connecting to " & spool & " on " & sserver & "."
            NotifyIcon1.ShowBalloonTip(5000)


            myprocess.WaitForExit()

            'wait for process to exit

            If myprocess.ExitCode <> 0 Then

                MessageBox.Show("There was an error when attempting to connect to the pool " & txtPool.Text & vbCrLf & "ERROR: " & get_shorterrorcode(myprocess.ExitCode), "VMware View AutoConnect - Error Launching Desktop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If


            If bquitonsessionend = True Then

                End

            End If



        Finally


            ' If Not myprocess Is Nothing Then
            ' myprocess.Close()
            'End If

        End Try



    End Sub



    Function get_shorterrorcode(ByVal icode As Integer) As String

        Dim serror As String = herrors(icode)

        Return serror

    End Function



    Private Sub chkCurrentUser_CheckedChanged(sender As Object, e As EventArgs) Handles chkCurrentUser.CheckedChanged

        If chkCurrentUser.Checked = True Then

            Reg_Write("Software\VMware Flings\View AutoConnect", "Login as Current User", "True")

            lblUserName.Enabled = False
            lblPW.Enabled = False
            lblDomain.Enabled = False
            txtUsername.Enabled = False
            txtPW.Enabled = False
            txtDomain.Enabled = False


        ElseIf chkCurrentUser.Checked = False Then

            Reg_Write("Software\VMware Flings\View AutoConnect", "Login as Current User", "False")

            lblUserName.Enabled = True
            lblPW.Enabled = True
            lblDomain.Enabled = True
            txtUsername.Enabled = True
            txtPW.Enabled = True
            txtDomain.Enabled = True

        End If


    End Sub

    Private Sub Form1_MenuStart(sender As Object, e As EventArgs) Handles Me.MenuStart

    End Sub

    Private Sub chkCurrentUser_Disposed(sender As Object, e As EventArgs) Handles chkCurrentUser.Disposed

        NotifyIcon1.Dispose()

    End Sub


    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Minimized
                NotifyIcon1.Visible = True
                Me.Hide()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

        Timer1.Stop()

        Me.Show()




    End Sub

    Function reg_key_exists(ByVal spath As String) As Boolean

        Dim regExists As RegistryKey
        regExists = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(spath, False)
        If regExists Is Nothing Then

            Return False

        Else

            Return True

        End If
    End Function


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        If MessageBox.Show("Are you sure you want to exit?", "Exit VMware View AutoConnect?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            NotifyIcon1.Visible = False

            End

        End If
    End Sub

    Private Sub cmbDTLayout_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDTLayout.SelectedIndexChanged

        Reg_Write("Software\VMware Flings\View AutoConnect", "Desktop Layout", cmbDTLayout.SelectedItem)

        sdtlayout = cmbDTLayout.SelectedItem

        Select Case cmbDTLayout.SelectedItem

            Case "fullscreen"

                chkShade.Enabled = True

            Case "multimonitor"

                chkShade.Enabled = True

            Case Else

                chkShade.Enabled = False
                chkShade.Checked = False

        End Select


    End Sub

    Private Sub radPCOIP_CheckedChanged(sender As Object, e As EventArgs) Handles radPCOIP.CheckedChanged


        sprotocol = "PCOIP"

        Reg_Write("Software\VMware Flings\View AutoConnect", "Protocol", "PCOIP")



    End Sub


    Private Sub radRDP_CheckedChanged(sender As Object, e As EventArgs) Handles radRDP.CheckedChanged

        sprotocol = "RDP"

        Reg_Write("Software\VMware Flings\View AutoConnect", "Protocol", "RDP")

    End Sub

    Private Sub chkAutoConnect_CheckedChanged(sender As Object, e As EventArgs)

        If chkAutoConnect.Checked = True Then

            If bautoconnect = False Then

                If MessageBox.Show("Are you sure you want to enable Auto-Connect?" & vbCrLf & "This will automatically launch the configured View Session" & vbCrLf & "You will need to access the VMware View Auto-Connection icon in the system tray to change configuration items.", "Enable Auto-Connection?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Reg_Write("Software\VMware Flings\View AutoConnect", "AutoConnect", "True")
                    bautoconnect = True

                End If

            Else

                Reg_Write("Software\VMware Flings\View AutoConnect", "AutoConnect", "True")
                bautoconnect = False

            End If


        Else

            Reg_Write("Software\VMware Flings\View AutoConnect", "AutoConnect", "False")
            chkAutoConnect.Text = "Enable Autoconnect"

        End If


    End Sub

   
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If chkAutoConnect.Checked = True Then

            Me.Visible = False

        End If

        Timer1.Enabled = False

    End Sub

   
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

        MessageBox.Show("VMware View AutoConnnect" & vbCrLf & "Chris Halstead" & vbCrLf & "Twitter: @chrisdhalstead" & vbCrLf & "Version 1.0" & vbCrLf & "2014", "About", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub rtbNoClient_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles rtbNoClient.LinkClicked

        System.Diagnostics.Process.Start(e.LinkText)

    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

        If txtUsername.Text <> "" Then

            Reg_Write(sclientcu32, "UserName", txtUsername.Text)

        End If

    End Sub

    Private Sub txtPW_TextChanged(sender As Object, e As EventArgs) Handles txtPW.TextChanged

        If txtPW.Text <> "" Then

            Reg_Write(sclientcu32, "Password", txtPW.Text)

        End If


    End Sub

    Private Sub txtDomain_TextChanged(sender As Object, e As EventArgs) Handles txtDomain.TextChanged

        If txtDomain.Text <> "" Then

            Reg_Write("Software\VMware Flings\View AutoConnect", "Domain", txtDomain.Text)

        End If

    End Sub

    Private Sub chkAutoConnect_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkAutoConnect.CheckedChanged

        If chkAutoConnect.Checked = True Then

            Reg_Write("Software\VMware Flings\View AutoConnect", "AutoConnect", "True")
            bautoconnect = True
        Else

            Reg_Write("Software\VMware Flings\View AutoConnect", "AutoConnect", "False")
            bautoconnect = False

        End If


    End Sub


    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click

        btest = True
        Launch_Desktop()

    End Sub


    Sub pop_errors()


        herrors.Add(1, "Connection Failed")
        herrors.Add(2, "Login Failed")
        herrors.Add(3, "Desktop Failed to Start")
        herrors.Add(4, "RDP Failed to Start")
        herrors.Add(5, "RDP Operation Failed")
        herrors.Add(6, "Tunnel Connection Lost")
        herrors.Add(11, "Unknown result received during authentication")
        herrors.Add(12, "Authenticaion Error")
        herrors.Add(13, "Received request to use an unknown authentication method")
        herrors.Add(14, "Invalid server response")
        herrors.Add(15, "Desktop was disconnected")
        herrors.Add(16, "Tunnel was disconnected")
        herrors.Add(20, "Remote mouse, keyboard, or screen (RMKS) connection error")
        herrors.Add(23, "Password mismatch")
        herrors.Add(24, "View Connection Server error")
        herrors.Add(25, "Desktop was not available")


    End Sub


    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click

        If MessageBox.Show("Are you sure you want to exit?", "Exit VMware View AutoConnect?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            NotifyIcon1.Visible = False

            End

        End If

    End Sub

    Private Sub UpdateSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateSettingsToolStripMenuItem.Click

        Me.Show()


    End Sub

    Private Sub RadioApp_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioApp.CheckedChanged

        If RadioApp.Checked = True Then


            lblPool.Text = "Enter name of Application Pool: "
            spooltype = "-appName "

            Reg_Write("Software\VMware Flings\View AutoConnect", "Pool Type", "App")


        End If



    End Sub


    Private Sub chkUSBStartup_CheckedChanged(sender As Object, e As EventArgs) Handles chkUSBStartup.CheckedChanged

        If chkUSBStartup.Checked = True Then

            Reg_Write("Software\VMware Flings\View AutoConnect", "USB Startup", "True")

        Else

            Reg_Write("Software\VMware Flings\View AutoConnect", "USB Startup", "False")

        End If


    End Sub

   
    Private Sub chkUSBInsert_CheckedChanged(sender As Object, e As EventArgs) Handles chkUSBInsert.CheckedChanged

        If chkUSBInsert.Checked = True Then

            Reg_Write("Software\VMware Flings\View AutoConnect", "USB Insert", "True")

        Else

            Reg_Write("Software\VMware Flings\View AutoConnect", "USB Insert", "False")

        End If


    End Sub


   
    Private Sub chkShade_CheckedChanged(sender As Object, e As EventArgs) Handles chkShade.CheckedChanged

            If chkShade.Checked = True Then

            Reg_Write(sclientcu32, "EnableShade", "False")

            Else

            Reg_Write(sclientcu32, "EnableShade", "True")

            End If


    End Sub

    Private Sub chkCustCmd_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustCmd.CheckedChanged

        If chkCustCmd.Checked = True Then

            bcustomcommand = True
            Reg_Write("Software\VMware Flings\View AutoConnect", "Custom Command", "True")

            txtCustString.Visible = True
            btnRefreshCMD.Visible = True

        Else
            bcustomcommand = False
            Reg_Write("Software\VMware Flings\View AutoConnect", "Custom Command", "False")

            txtCustString.Visible = False
            btnRefreshCMD.Visible = False

        End If



    End Sub

   
    Private Sub btnRefreshCMD_Click(sender As Object, e As EventArgs) Handles btnRefreshCMD.Click

        txtCustString.Text = ""

        build_string()

        Reg_Write("Software\VMware Flings\View AutoConnect", "Command", sstring)
        txtCustString.Text = sstring



    End Sub

    Private Sub chkHideClient_CheckedChanged(sender As Object, e As EventArgs) Handles chkHideClient.CheckedChanged

        If chkHideClient.Checked = True Then

            Reg_Write("Software\VMware Flings\View AutoConnect", "Hide Client", "True")

        Else

            Reg_Write("Software\VMware Flings\View AutoConnect", "Hide Client", "False")

        End If

    End Sub

    Private Sub chkQuitClient_CheckedChanged(sender As Object, e As EventArgs) Handles chkQuitClient.CheckedChanged

        If chkQuitClient.Checked = True Then

            Reg_Write("Software\VMware Flings\View AutoConnect", "Quit App on Session End", "True")
            bquitonsessionend = True
        Else

            Reg_Write("Software\VMware Flings\View AutoConnect", "Quit App on Session End", "False")

        End If


    End Sub
End Class
