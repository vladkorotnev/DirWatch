Public Class Form1
    Dim first As Boolean = True
    Dim fileCache As New ArrayList
    Enum ActionKind
        NoAction = -1
        ExecuteFile = 0
        MoveFiles = 1
        CopyFiles = 2
    End Enum
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End

    End Sub
    Sub createCache()
        fileCache.Clear()

        For Each file In My.Computer.FileSystem.GetFiles(My.Settings.watchDir)
            If Not fileCache.Contains(file) Then
                fileCache.Add(file)
                My.Settings.Save()

            End If

        Next
        For Each D In My.Computer.FileSystem.GetDirectories(My.Settings.watchDir)
            If Not fileCache.Contains(D) Then

                fileCache.Add(D)
                My.Settings.Save()
            End If

        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
        createCache()

        ico.Visible = True
        timer.Enabled = True
        ico.ShowBalloonTip(1000, "Watching...", "Now watching " + My.Settings.watchDir.Split("\").Last + " for changes", ToolTipIcon.Info)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim d As New FolderBrowserDialog
        d.ShowNewFolderButton = False
        If d.ShowDialog <> Windows.Forms.DialogResult.OK Then Return
        My.Settings.watchDir = d.SelectedPath
        TextBox1.Text = d.SelectedPath
        My.Settings.Save()
        fileCache.Clear()
        My.Settings.Save()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        delay.Value = My.Settings.delay
        timer.Interval = My.Settings.delay
        TextBox1.Text = My.Settings.watchDir


    End Sub

    Private Sub delay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delay.ValueChanged
        My.Settings.delay = delay.Value
        My.Settings.Save()
        timer.Interval = delay.Value
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ico.Visible = False
        timer.Enabled = False
        notificate.Checked = My.Settings.notify
        actionparam.Text = My.Settings.parameter
        action.SelectedIndex = My.Settings.action + 1
        If My.Settings.action > -1 Then
            actionparam.Visible = True
            parhint.Visible = True
            Button4.Visible = True
            Select Case My.Settings.action
                Case ActionKind.MoveFiles
                    parhint.Text = "Move to:"
                Case ActionKind.ExecuteFile
                    parhint.Text = "Execute:"
                Case ActionKind.CopyFiles
                    parhint.Text = "Copy to:"
            End Select
        Else
            actionparam.Visible = False
            parhint.Visible = False
            Button4.Visible = False
        End If
        If My.Settings.watchDir <> "" And first = True And My.Computer.FileSystem.DirectoryExists(My.Settings.watchDir) Then
            Me.Hide()
            createCache()
            Me.WindowState = FormWindowState.Minimized
            timer.Enabled = True
            ico.Visible = True
        End If
        first = False
    End Sub

    Private Sub ico_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ico.MouseDoubleClick
        Shell("explorer " + Chr(34) + My.Settings.watchDir + Chr(34), AppWinStyle.NormalFocus)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub OpenFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFolderToolStripMenuItem.Click
        Shell("explorer " + Chr(34) + My.Settings.watchDir + Chr(34), AppWinStyle.NormalFocus)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        ico.Visible = False
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer.Tick
        Dim changes As Integer = 0
        Dim changedFilenames As New ArrayList
        For Each file In My.Computer.FileSystem.GetFiles(My.Settings.watchDir)
            If Not fileCache.Contains(file) Then
                fileCache.Add(file)
                My.Settings.Save()
                changes += 1
                changedFilenames.Add(file)
            End If

        Next
        For Each D In My.Computer.FileSystem.GetDirectories(My.Settings.watchDir)
            If Not fileCache.Contains(D) Then
                changes += 1
                fileCache.Add(D)
                My.Settings.Save()
                changedFilenames.Add(D)
            End If

        Next
        If changes > 0 And My.Settings.notify Then
            If changes = 1 Then
                ico.ShowBalloonTip(2000, "Folder changed!", changedFilenames.Item(0).ToString.Split("\").Last + " has been added to " + My.Settings.watchDir.Split("\").Last, ToolTipIcon.Info)
            ElseIf changes = 2 Then
                ico.ShowBalloonTip(2000, "Folder changed!", changedFilenames.Item(0).ToString.Split("\").Last + " and " + changedFilenames.Item(1).ToString.Split("\").Last + " have been added to " + My.Settings.watchDir.Split("\").Last, ToolTipIcon.Info)
            Else
                ico.ShowBalloonTip(2000, "Folder changed!", changedFilenames.Item(0).ToString.Split("\").Last + ", " + changedFilenames.Item(1).ToString.Split("\").Last + " and " + CStr(changes - 2) + " more files have been added to " + My.Settings.watchDir.Split("\").Last, ToolTipIcon.Info)
            End If
        End If
        If My.Settings.action <> ActionKind.NoAction And changes > 0 Then
            Select Case My.Settings.action
                Case ActionKind.ExecuteFile
                    If My.Computer.FileSystem.FileExists(My.Settings.parameter) Then Shell(My.Settings.parameter, AppWinStyle.NormalNoFocus, False)
                Case ActionKind.CopyFiles
                    For Each fff As String In changedFilenames
                        If My.Computer.FileSystem.FileExists(fff) Then
                            ' MsgBox("Moving " + fff + " as file")
                            Try
                                My.Computer.FileSystem.CopyFile(fff, My.Settings.parameter + "\" + fff.Split("\").Last)

                            Catch ex As Exception
                                fileCache.Remove(fff)
                            End Try
                        ElseIf My.Computer.FileSystem.DirectoryExists(fff) Then
                            ' MsgBox("Moving " + fff + " as dir")
                            Try
                                My.Computer.FileSystem.CopyDirectory(fff, My.Settings.parameter + "\" + fff.Split("\").Last)

                            Catch ex As Exception
                                fileCache.Remove(fff)
                            End Try
                        End If
                    Next
                Case ActionKind.MoveFiles
                    For Each fff As String In changedFilenames
                        If My.Computer.FileSystem.FileExists(fff) Then
                            '  MsgBox("Moving " + fff + " as file")
                            Try
                                My.Computer.FileSystem.MoveFile(fff, My.Settings.parameter + "\" + fff.Split("\").Last, True)

                            Catch ex As Exception
                                'couldn't move so try on next scan
                                fileCache.Remove(fff)
                            End Try

                        ElseIf My.Computer.FileSystem.DirectoryExists(fff) Then
                            ' MsgBox("Moving " + fff + " as dir")
                            Try
                                My.Computer.FileSystem.MoveDirectory(fff, My.Settings.parameter + "\" + fff.Split("\").Last)

                            Catch ex As Exception
                                fileCache.Remove(fff)
                            End Try

                        End If
                    Next
            End Select
        End If
    End Sub

    Private Sub action_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles action.SelectedIndexChanged
        My.Settings.action = action.SelectedIndex - 1
        My.Settings.Save()
        If My.Settings.action > -1 Then
            actionparam.Visible = True
            parhint.Visible = True
            Button4.Visible = True
            Select Case My.Settings.action
                Case ActionKind.MoveFiles
                    parhint.Text = "Move to:"
                Case ActionKind.ExecuteFile
                    parhint.Text = "Execute:"
                Case ActionKind.CopyFiles
                    parhint.Text = "Copy to:"
            End Select
        Else
            actionparam.Visible = False
            parhint.Visible = False
            Button4.Visible = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If My.Settings.action = ActionKind.ExecuteFile Then
            Dim f As New OpenFileDialog
            f.CheckFileExists = True
            f.CheckPathExists = True
            f.Multiselect = False
            f.ShowReadOnly = False
            If f.ShowDialog <> Windows.Forms.DialogResult.OK Then Return
            actionparam.Text = f.FileName
            My.Settings.parameter = actionparam.Text
            My.Settings.Save()

        Else
            Dim f As New FolderBrowserDialog
            f.ShowNewFolderButton = True
            If f.ShowDialog <> Windows.Forms.DialogResult.OK Then Return
            actionparam.Text = f.SelectedPath
            My.Settings.parameter = actionparam.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub notificate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles notificate.CheckedChanged
        My.Settings.notify = notificate.Checked
        My.Settings.Save()
    End Sub
End Class
