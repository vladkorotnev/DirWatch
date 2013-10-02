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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ico = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.icomenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.notificate = New System.Windows.Forms.CheckBox()
        Me.action = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.parhint = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.actionparam = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.icomenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.DirWatch.My.Resources.Resources._1374086193_manilla_folder_downloads
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(130, 124)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(150, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(286, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(442, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Browse.."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ico
        '
        Me.ico.ContextMenuStrip = Me.icomenu
        Me.ico.Icon = CType(resources.GetObject("ico.Icon"), System.Drawing.Icon)
        Me.ico.Text = "DirWatcher"
        Me.ico.Visible = True
        '
        'icomenu
        '
        Me.icomenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFolderToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.icomenu.Name = "icomenu"
        Me.icomenu.Size = New System.Drawing.Size(132, 76)
        '
        'OpenFolderToolStripMenuItem
        '
        Me.OpenFolderToolStripMenuItem.Name = "OpenFolderToolStripMenuItem"
        Me.OpenFolderToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.OpenFolderToolStripMenuItem.Text = "Open folder"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(128, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(441, 140)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 24)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Location = New System.Drawing.Point(366, 140)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 24)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Watch"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'notificate
        '
        Me.notificate.AutoSize = True
        Me.notificate.Checked = True
        Me.notificate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.notificate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.notificate.Location = New System.Drawing.Point(150, 39)
        Me.notificate.Name = "notificate"
        Me.notificate.Size = New System.Drawing.Size(94, 17)
        Me.notificate.TabIndex = 7
        Me.notificate.Text = "Notify from tray"
        Me.notificate.UseVisualStyleBackColor = True
        '
        'action
        '
        Me.action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.action.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.action.FormattingEnabled = True
        Me.action.Items.AddRange(New Object() {"Do nothing", "Execute program", "Move files", "Copy files"})
        Me.action.Location = New System.Drawing.Point(6, 0)
        Me.action.Name = "action"
        Me.action.Size = New System.Drawing.Size(137, 21)
        Me.action.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.parhint)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.actionparam)
        Me.GroupBox1.Controls.Add(Me.action)
        Me.GroupBox1.Location = New System.Drawing.Point(150, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(367, 64)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'parhint
        '
        Me.parhint.AutoSize = True
        Me.parhint.Location = New System.Drawing.Point(6, 29)
        Me.parhint.Name = "parhint"
        Me.parhint.Size = New System.Drawing.Size(23, 13)
        Me.parhint.TabIndex = 11
        Me.parhint.Text = "To:"
        Me.parhint.Visible = False
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Location = New System.Drawing.Point(298, 24)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(63, 23)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "Browse.."
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'actionparam
        '
        Me.actionparam.BackColor = System.Drawing.Color.White
        Me.actionparam.Location = New System.Drawing.Point(56, 26)
        Me.actionparam.Name = "actionparam"
        Me.actionparam.ReadOnly = True
        Me.actionparam.Size = New System.Drawing.Size(236, 20)
        Me.actionparam.TabIndex = 9
        Me.actionparam.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "DirWatch 1.1 by vladkorotnev"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 177)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.notificate)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "DirWatch"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.icomenu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ico As System.Windows.Forms.NotifyIcon
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents icomenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents notificate As System.Windows.Forms.CheckBox
    Friend WithEvents action As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents parhint As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents actionparam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
