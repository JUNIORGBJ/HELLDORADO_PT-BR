<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GerenciadorPAK
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GerenciadorPAK))
        Me.FileListView = New System.Windows.Forms.ListView()
        Me.FileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FileLength = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Offset = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FileType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.Menu_File = New System.Windows.Forms.MenuItem()
        Me.Menu_File_OpenDP2C = New System.Windows.Forms.MenuItem()
        Me.Menu_File_CreateDP2C = New System.Windows.Forms.MenuItem()
        Me.Menu_File_Close = New System.Windows.Forms.MenuItem()
        Me.Menu_File_RecentFiles = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.Menu_File_Exit = New System.Windows.Forms.MenuItem()
        Me.Menu_About = New System.Windows.Forms.MenuItem()
        Me.Menu_About_About = New System.Windows.Forms.MenuItem()
        Me.Path = New System.Windows.Forms.TextBox()
        Me.Spliter = New System.Windows.Forms.SplitContainer()
        Me.Spliter2 = New System.Windows.Forms.SplitContainer()
        Me.Mask = New System.Windows.Forms.TextBox()
        Me.ContextMenu = New System.Windows.Forms.ContextMenu()
        Me.ContextMenu_Extract = New System.Windows.Forms.MenuItem()
        CType(Me.Spliter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Spliter.Panel1.SuspendLayout()
        Me.Spliter.Panel2.SuspendLayout()
        Me.Spliter.SuspendLayout()
        CType(Me.Spliter2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Spliter2.Panel1.SuspendLayout()
        Me.Spliter2.Panel2.SuspendLayout()
        Me.Spliter2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FileListView
        '
        Me.FileListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FileName, Me.FileLength, Me.Offset, Me.FileType})
        Me.FileListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileListView.HideSelection = False
        Me.FileListView.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.FileListView.Location = New System.Drawing.Point(0, 0)
        Me.FileListView.Name = "FileListView"
        Me.FileListView.Size = New System.Drawing.Size(543, 425)
        Me.FileListView.TabIndex = 0
        Me.FileListView.UseCompatibleStateImageBehavior = False
        Me.FileListView.View = System.Windows.Forms.View.Details
        '
        'FileName
        '
        Me.FileName.Text = "Nome"
        Me.FileName.Width = 268
        '
        'FileLength
        '
        Me.FileLength.Text = "Tamanho"
        Me.FileLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.FileLength.Width = 98
        '
        'Offset
        '
        Me.Offset.Text = "OffSet"
        Me.Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Offset.Width = 76
        '
        'FileType
        '
        Me.FileType.Text = "Tipo"
        Me.FileType.Width = 69
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Menu_File, Me.Menu_About})
        '
        'Menu_File
        '
        Me.Menu_File.Index = 0
        Me.Menu_File.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Menu_File_OpenDP2C, Me.Menu_File_CreateDP2C, Me.Menu_File_Close, Me.Menu_File_RecentFiles, Me.MenuItem4, Me.Menu_File_Exit})
        Me.Menu_File.Text = "Arquivo(&F)"
        '
        'Menu_File_OpenDP2C
        '
        Me.Menu_File_OpenDP2C.Index = 0
        Me.Menu_File_OpenDP2C.Text = "Carregar arquivo PAK(&1)..."
        '
        'Menu_File_CreateDP2C
        '
        Me.Menu_File_CreateDP2C.Index = 1
        Me.Menu_File_CreateDP2C.Text = "Criar arquivo PAK(&2)..."
        '
        'Menu_File_Close
        '
        Me.Menu_File_Close.Index = 2
        Me.Menu_File_Close.Text = "Fechar(&C)"
        '
        'Menu_File_RecentFiles
        '
        Me.Menu_File_RecentFiles.Enabled = False
        Me.Menu_File_RecentFiles.Index = 3
        Me.Menu_File_RecentFiles.Text = "Arquivos Recentes(&R)"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 4
        Me.MenuItem4.Text = "-"
        '
        'Menu_File_Exit
        '
        Me.Menu_File_Exit.Index = 5
        Me.Menu_File_Exit.Text = "Sair(&X)"
        '
        'Menu_About
        '
        Me.Menu_About.Index = 1
        Me.Menu_About.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Menu_About_About})
        Me.Menu_About.Text = "Sobre(&A)"
        '
        'Menu_About_About
        '
        Me.Menu_About_About.Index = 0
        Me.Menu_About_About.Text = "Sobre(&A)..."
        '
        'Path
        '
        Me.Path.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Path.Location = New System.Drawing.Point(0, 0)
        Me.Path.Name = "Path"
        Me.Path.ReadOnly = True
        Me.Path.Size = New System.Drawing.Size(516, 20)
        Me.Path.TabIndex = 1
        '
        'Spliter
        '
        Me.Spliter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Spliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.Spliter.IsSplitterFixed = True
        Me.Spliter.Location = New System.Drawing.Point(0, 0)
        Me.Spliter.Name = "Spliter"
        Me.Spliter.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Spliter.Panel1
        '
        Me.Spliter.Panel1.Controls.Add(Me.Spliter2)
        Me.Spliter.Panel1MinSize = 20
        '
        'Spliter.Panel2
        '
        Me.Spliter.Panel2.Controls.Add(Me.FileListView)
        Me.Spliter.Panel2MinSize = 20
        Me.Spliter.Size = New System.Drawing.Size(543, 452)
        Me.Spliter.SplitterDistance = 25
        Me.Spliter.SplitterWidth = 2
        Me.Spliter.TabIndex = 2
        '
        'Spliter2
        '
        Me.Spliter2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Spliter2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.Spliter2.IsSplitterFixed = True
        Me.Spliter2.Location = New System.Drawing.Point(0, 0)
        Me.Spliter2.Name = "Spliter2"
        '
        'Spliter2.Panel1
        '
        Me.Spliter2.Panel1.Controls.Add(Me.Path)
        '
        'Spliter2.Panel2
        '
        Me.Spliter2.Panel2.Controls.Add(Me.Mask)
        Me.Spliter2.Size = New System.Drawing.Size(543, 25)
        Me.Spliter2.SplitterDistance = 516
        Me.Spliter2.SplitterWidth = 2
        Me.Spliter2.TabIndex = 2
        '
        'Mask
        '
        Me.Mask.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Mask.Location = New System.Drawing.Point(0, 0)
        Me.Mask.Name = "Mask"
        Me.Mask.Size = New System.Drawing.Size(25, 20)
        Me.Mask.TabIndex = 1
        Me.Mask.Text = "*"
        '
        'ContextMenu
        '
        Me.ContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ContextMenu_Extract})
        '
        'ContextMenu_Extract
        '
        Me.ContextMenu_Extract.Index = 0
        Me.ContextMenu_Extract.Text = "Extrair(&E)..."
        '
        'GerenciadorPAK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(543, 452)
        Me.Controls.Add(Me.Spliter)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu
        Me.Name = "GerenciadorPAK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gerenciador de Arquivos SBPAK"
        Me.Spliter.Panel1.ResumeLayout(False)
        Me.Spliter.Panel2.ResumeLayout(False)
        CType(Me.Spliter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Spliter.ResumeLayout(False)
        Me.Spliter2.Panel1.ResumeLayout(False)
        Me.Spliter2.Panel1.PerformLayout()
        Me.Spliter2.Panel2.ResumeLayout(False)
        Me.Spliter2.Panel2.PerformLayout()
        CType(Me.Spliter2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Spliter2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FileListView As System.Windows.Forms.ListView
    Friend WithEvents FileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents FileLength As System.Windows.Forms.ColumnHeader
    Friend WithEvents Offset As System.Windows.Forms.ColumnHeader
    Friend WithEvents FileType As System.Windows.Forms.ColumnHeader
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents Menu_File As System.Windows.Forms.MenuItem
    Friend WithEvents Menu_File_OpenDP2C As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents Menu_File_Exit As System.Windows.Forms.MenuItem
    Friend WithEvents Menu_About As System.Windows.Forms.MenuItem
    Friend WithEvents Menu_About_About As System.Windows.Forms.MenuItem
    Friend WithEvents Menu_File_RecentFiles As System.Windows.Forms.MenuItem
    Friend WithEvents Path As System.Windows.Forms.TextBox
    Private WithEvents Spliter As System.Windows.Forms.SplitContainer
    Friend WithEvents Spliter2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Mask As System.Windows.Forms.TextBox
    Friend Shadows WithEvents ContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents ContextMenu_Extract As System.Windows.Forms.MenuItem
    Friend WithEvents Menu_File_Close As System.Windows.Forms.MenuItem
    Friend WithEvents Menu_File_CreateDP2C As System.Windows.Forms.MenuItem

End Class
