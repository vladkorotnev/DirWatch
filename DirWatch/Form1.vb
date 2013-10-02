Imports System.IO
Imports System.Diagnostics

Public Class Form1
    Dim first As Boolean = True
    Dim fileCache As New ArrayList
    Dim watchfolder As FileSystemWatcher
    Enum ActionKind
        NoAction = -1
        ExecuteFile = 0
        MoveFiles = 1
        CopyFiles = 2
    End Enum
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End

    End Sub

    Sub onChange(ByVal source As Object, ByVal e As  _
                        System.IO.FileSystemEventArgs)
        If notificate.Checked Then
            Dim title As String
            Dim subtitle As String
            Select Case e.ChangeType
                Case WatcherChangeTypes.Changed
                    title = "File changed"
                    subtitle = "changed"
                Case WatcherChangeTypes.Created
                    title = "File created"
                    subtitle = "created"
                Case WatcherChangeTypes.Deleted
                    title = "File deleted"
                    subtitle = "deleted"
                Case WatcherChangeTypes.Renamed
                    Return 'not our cup of tea
                Case Else
                    title = "Folder change!"
                    subtitle = "modified (or at least seems so)"
            End Select
            title = e.ChangeType.ToString
            ico.ShowBalloonTip(500, title, _
                               String.Format("{0} has been {1} in {2}", e.Name, subtitle, TextBox1.Text.Split("\").Last) _
                               , ToolTipIcon.Info)

        End If

        If My.Settings.action <> ActionKind.NoAction Then
            Select Case My.Settings.action
                Case ActionKind.ExecuteFile
                    If My.Computer.FileSystem.FileExists(My.Settings.parameter) Then Shell(My.Settings.parameter, AppWinStyle.NormalNoFocus, False)
                Case ActionKind.CopyFiles
                    If e.ChangeType <> WatcherChangeTypes.Deleted Then
                        Dim fff = e.FullPath
                        If My.Computer.FileSystem.FileExists(fff) Then
                            ' MsgBox("Moving " + fff + " as file")
                            Try
                                My.Computer.FileSystem.CopyFile(fff, My.Settings.parameter + "\" + fff.Split("\").Last, True)

                            Catch ex As Exception

                            End Try
                        ElseIf My.Computer.FileSystem.DirectoryExists(fff) Then
                            ' MsgBox("Moving " + fff + " as dir")
                            Try
                                My.Computer.FileSystem.CopyDirectory(fff, My.Settings.parameter + "\" + fff.Split("\").Last, True)

                            Catch ex As Exception

                            End Try
                        End If
                    End If

                Case ActionKind.MoveFiles
                    Dim fff = e.FullPath
                    If e.ChangeType <> WatcherChangeTypes.Deleted Then
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
                    End If
            End Select
        End If


    End Sub

    Sub onRename(ByVal source As Object, ByVal e As  _
                        System.IO.FileSystemEventArgs)
        If notificate.Checked Then ico.ShowBalloonTip(500, "File renamed", _
                              String.Format("{0} has been renamed in {1}", e.Name, TextBox1.Text.Split("\").Last) _
                              , ToolTipIcon.Info)
        If My.Settings.action <> ActionKind.NoAction Then
            Select Case My.Settings.action
                Case ActionKind.ExecuteFile
                    If My.Computer.FileSystem.FileExists(My.Settings.parameter) Then Shell(My.Settings.parameter, AppWinStyle.NormalNoFocus, False)
                Case ActionKind.CopyFiles
                        Dim fff = e.FullPath
                        If My.Computer.FileSystem.FileExists(fff) Then
                            ' MsgBox("Moving " + fff + " as file")
                            Try
                                My.Computer.FileSystem.CopyFile(fff, My.Settings.parameter + "\" + fff.Split("\").Last, True)

                            Catch ex As Exception

                            End Try
                        ElseIf My.Computer.FileSystem.DirectoryExists(fff) Then
                            ' MsgBox("Moving " + fff + " as dir")
                            Try
                                My.Computer.FileSystem.CopyDirectory(fff, My.Settings.parameter + "\" + fff.Split("\").Last, True)

                            Catch ex As Exception

                            End Try
                        End If

                Case ActionKind.MoveFiles
                    Dim fff = e.FullPath

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
            End Select
        End If

    End Sub

    Sub beginWatch()
        If Not watchfolder Is Nothing Then watchfolder.EnableRaisingEvents = False : watchfolder.Dispose()
        watchfolder = New System.IO.FileSystemWatcher()

        'this is the path we want to monitor
        watchfolder.Path = TextBox1.Text

        'Add a list of Filter we want to specify
        'make sure you use OR for each Filter as we need to
        'all of those 

        watchfolder.NotifyFilter = IO.NotifyFilters.DirectoryName
        watchfolder.NotifyFilter = watchfolder.NotifyFilter Or _
                                   IO.NotifyFilters.FileName
        watchfolder.NotifyFilter = watchfolder.NotifyFilter Or _
                                   IO.NotifyFilters.Attributes

        ' add the handler to each event
        AddHandler watchfolder.Changed, AddressOf onChange
        AddHandler watchfolder.Created, AddressOf onChange
        AddHandler watchfolder.Deleted, AddressOf onChange

        ' add the rename handler as the signature is different
        AddHandler watchfolder.Renamed, AddressOf onRename

        'Set this property to true to start watching
        watchfolder.EnableRaisingEvents = True

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
        beginWatch()

        ico.Visible = True
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

        TextBox1.Text = My.Settings.watchDir

    End Sub


    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ico.Visible = False
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
            ico.Visible = True
            BeginWatch()
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

    Private Sub timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

       
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

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Label2.Text = Label2.Text.Replace("vladkorotnev", "AkasakaRyuunosuke")

    End Sub
End Class
