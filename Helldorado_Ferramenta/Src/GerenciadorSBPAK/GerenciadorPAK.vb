Option Compare Text
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports FRCCoreFile
Imports Microsoft.VisualBasic

Public Class GerenciadorPAK

#Region " 1 "
    Private Opt As INI
    Private LanFull As String
    Private INISettingNotice As String = "Arquivo INI do Gerenciador de arquivos SBPAK" & Environment.NewLine & "Não altere este arquivo a menos que você saiba exatamente o que está fazendo"
    Private Title As String
    Private DebugTip As String = "1" & Environment.NewLine & "1"
    Private RecentFiles(5) As String
    Private Readme As String

    Private Sub GerenciadorPAK_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Opt = New INI("..\Ini\GerenciadorPAK.ini")
        LoadOpt()
        Title = Me.Text

        Dim ImageList As New ImageList()
        ImageList.Images.Add(My.Resources.File)
        ImageList.Images.Add(My.Resources.Directory)
        ImageList.ColorDepth = ColorDepth.Depth32Bit
        FileListView.SmallImageList = ImageList
        FileListView.ContextMenu = ContextMenu

        RefreshRecent()
    End Sub
    Private Sub GerenciadorPAK_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not pfClosed Then pf.Close()
        ChDir(Application.StartupPath)
        SaveOpt()
        Opt.WriteToFile("/*" & Environment.NewLine & INISettingNotice & Environment.NewLine & "*/" & Environment.NewLine)
    End Sub

    Sub LoadOpt()
        LanFull = ""
        Opt.ReadValue("Option", "CurrentCulture", LanFull)
        Opt.ReadValue("Option", "Recent0", RecentFiles(0))
        Opt.ReadValue("Option", "Recent1", RecentFiles(1))
        Opt.ReadValue("Option", "Recent2", RecentFiles(2))
        Opt.ReadValue("Option", "Recent3", RecentFiles(3))
        Opt.ReadValue("Option", "Recent4", RecentFiles(4))
        Opt.ReadValue("Option", "Recent5", RecentFiles(5))
    End Sub
    Sub SaveOpt()
        Opt.WriteValue("Option", "CurrentCulture", LanFull)
        Opt.WriteValue("Option", "Recent0", RecentFiles(0), False)
        Opt.WriteValue("Option", "Recent1", RecentFiles(1), False)
        Opt.WriteValue("Option", "Recent2", RecentFiles(2), False)
        Opt.WriteValue("Option", "Recent3", RecentFiles(3), False)
        Opt.WriteValue("Option", "Recent4", RecentFiles(4), False)
        Opt.WriteValue("Option", "Recent5", RecentFiles(5), False)
    End Sub

    Sub MsgBox(ByVal ex As Exception)
        Dim r As MsgBoxResult = Microsoft.VisualBasic.MsgBox(DebugTip & Environment.NewLine & Environment.NewLine & "1" & Environment.NewLine & Environment.NewLine & ex.ToString, MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, Title)
        If r = MsgBoxResult.Yes Then
            My.Computer.Clipboard.SetText("1" & Environment.NewLine & Environment.NewLine & ex.ToString)
        End If
    End Sub
    Sub MsgBox(ByVal s As String)
        Microsoft.VisualBasic.MsgBox(s, MsgBoxStyle.OkOnly, Title)
    End Sub
#End Region

    Private pf As Object
    Private pfCurDirDB As Object
    Private pfClosed As Boolean = True
    Private TempDir As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\GerenciadorPAKTemp"
    Private TempList As Collections.Specialized.StringCollection

    Private Sub GerenciadorPAK_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If IO.Directory.Exists(TempDir) Then
            Try
                IO.Directory.Delete(TempDir, True)
            Catch
            End Try
        End If
    End Sub

    Private Sub RefreshList()
        If pfCurDirDB Is Nothing Then Return
        Dim Item As ListViewItem
        Dim n As Integer = 0
        Dim Sorter As New List(Of ListViewItem)
        Dim FileMask As String = Mask.Text
        Dim DirectoryOffsetFlag As Boolean = Not False
        For Each f As Object In pfCurDirDB.SubFileDB
            Select Case f.Type
                Case PAK.FileDB.FileType.File
                    If IsMatchFileMask(f.Name, FileMask) Then
                        Item = New ListViewItem(New String() {f.Name, f.Length, f.Address, GetExtendedFileName(f.Name), n, 1}, 0)
                    Else
                        Item = Nothing
                    End If
                Case PAK.FileDB.FileType.Directory
                    If DirectoryOffsetFlag Then
                        Item = New ListViewItem(New String() {f.Name, "", CStr(f.Address).TrimStart("0"), "", n, 0}, 1)
                    Else
                        Item = New ListViewItem(New String() {f.Name, "", "", "", n, 0}, 1)
                    End If
                Case Else
                    Item = Nothing
            End Select
            If Item IsNot Nothing Then Sorter.Add(Item)
            n += 1
        Next
        If FileListViewMajorCompareeIndex <> -1 Then Sorter.Sort(AddressOf Comparison)

        With FileListView.Items
            .Clear()
            If pfCurDirDB.ParentFileDB IsNot Nothing Then
                .Add(New ListViewItem(New String() {"..", "", "", "", -1, 0}, 1))
            End If
            .AddRange(Sorter.ToArray)
        End With
    End Sub
    Public FileListViewMajorCompareeIndex As Integer = -1

    Private Function Comparison(ByVal x As ListViewItem, ByVal y As ListViewItem) As Integer
        If x.SubItems(5).Text < y.SubItems(5).Text Then Return -1
        If x.SubItems(5).Text > y.SubItems(5).Text Then Return 1

        Select Case FileListViewMajorCompareeIndex
            Case 0, 3
                If x.SubItems(FileListViewMajorCompareeIndex).Text < y.SubItems(FileListViewMajorCompareeIndex).Text Then Return -1
                If x.SubItems(FileListViewMajorCompareeIndex).Text > y.SubItems(FileListViewMajorCompareeIndex).Text Then Return 1
            Case 1, 2
                If CInt(x.SubItems(5).Text) <> 0 Then
                    If CInt(x.SubItems(FileListViewMajorCompareeIndex).Text) < CInt(y.SubItems(FileListViewMajorCompareeIndex).Text) Then Return -1
                    If CInt(x.SubItems(FileListViewMajorCompareeIndex).Text) > CInt(y.SubItems(FileListViewMajorCompareeIndex).Text) Then Return 1
                End If
        End Select

        If x.SubItems(0).Text < y.SubItems(0).Text Then Return -1
        If x.SubItems(0).Text > y.SubItems(0).Text Then Return 1

        If x.SubItems(2).Text < y.SubItems(2).Text Then Return -1
        If x.SubItems(2).Text > y.SubItems(2).Text Then Return 1
        Return 0
    End Function

    Friend Sub DoOpenDP2C(ByVal PAKPath As String)
        If Not pfClosed Then pf.Close()
        pf = PAK.Open(PAKPath)
        pfCurDirDB = pf.Root
        Path.Text = pfCurDirDB.Name & "\"
        Path.Text = Path.Text.TrimStart("\")
        RefreshList()
        AddRecent(PAKPath & ",2")
        pfClosed = False
        Me.Text = Title & " - " & PAKPath
    End Sub

    Friend Sub DoClose()
        If Not pfClosed Then pf.Close()
        pfCurDirDB = Nothing
        FileListView.Items.Clear()
        Path.Text = ""
        pfClosed = True
        Me.Text = Title
    End Sub

    Private Sub Menu_File_OpenDP2C_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_OpenDP2C.Click
#If CONFIG <> "Debug" Then
        Try
#End If
        Static d As Windows.Forms.OpenFileDialog
        If d Is Nothing Then d = New Windows.Forms.OpenFileDialog
        d.Filter = "PAK(*.PAK)|*.PAK"
        If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DoOpenDP2C(d.FileName)
        End If
#If CONFIG <> "Debug" Then
        Catch ex As Exception
            MsgBox(ex)
        End Try
#End If
    End Sub

    Private Sub Menu_File_CreateDP2C_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_CreateDP2C.Click
        My.Forms.CaixaDeCriacao.Show(Me)
        Me.Enabled = False
    End Sub

    Private Sub Menu_File_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_Close.Click
        DoClose()
    End Sub

    Private d As Windows.Forms.FolderBrowserDialog

    Private Sub FileListView_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileListView.ItemActivate
        If pfClosed Then Return
        Dim Item As ListViewItem = FileListView.SelectedItems.Item(0)
        Dim n As Integer = Item.SubItems(4).Text
        If Item.SubItems(5).Text = 1 Then
            If d Is Nothing Then d = New Windows.Forms.FolderBrowserDialog
            If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
                pf.Extract(pfCurDirDB.SubFileDB(n), d.SelectedPath, Mask.Text)
            End If
        Else
            If n < 0 Then
                pfCurDirDB = pfCurDirDB.ParentFileDB
                Path.Text = Path.Text.Substring(0, Path.Text.Length - 1)
                If Path.Text.Contains("\") Then
                    Path.Text = Path.Text.Substring(0, Path.Text.LastIndexOf("\")) & "\"
                Else
                    Path.Text = ""
                End If
            Else
                pfCurDirDB = pfCurDirDB.SubFileDB(n)
                Path.Text = (GetPath(Path.Text, pfCurDirDB.Name) & "\")
            End If
            Path.Text = Path.Text.TrimStart("\")
            RefreshList()
        End If
    End Sub

    Private Sub ContextMenu_Extract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu_Extract.Click
        If d Is Nothing Then d = New Windows.Forms.FolderBrowserDialog
        If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each Item As ListViewItem In FileListView.SelectedItems
                Dim n As Integer = Item.SubItems(4).Text
                If n < 0 Then Continue For
                pf.Extract(pfCurDirDB.SubFileDB(n), d.SelectedPath, Mask.Text)
            Next
        End If
    End Sub

    Private Sub Menu_File_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_Exit.Click
        Me.Close()
    End Sub

    Private Sub FileListView_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles FileListView.ItemDrag
        Dim Data As New DataObject

        TempList = New Collections.Specialized.StringCollection
        For Each Item As ListViewItem In FileListView.SelectedItems
            If Item.SubItems.Count < 4 Then Return
            Dim n As Integer = Item.SubItems(4).Text
            If n < 0 Then Continue For
            pf.Extract(pfCurDirDB.SubFileDB(n), TempDir, Mask.Text)
            TempList.Add(TempDir & "\" & pfCurDirDB.SubFileDB(n).Name)
        Next
        Data.SetFileDropList(TempList)

        FileListView.DoDragDrop(Data, DragDropEffects.Move)
    End Sub

    Private Sub Mask_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask.TextChanged
        If pfClosed Then Return
        Dim Timer As Double = DateAndTime.Timer
        While DateAndTime.Timer - Timer < 2
            Application.DoEvents()
        End While
        RefreshList()
    End Sub

    Private Sub Menu_About_About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_About_About.Click
        MsgBox("Traduções gBj
Este software serve para extrair e criar arquivo PAK do jogo Helldorado versão PC")
    End Sub

    Private Sub AddRecent(ByVal s As String)
        For n As Integer = 0 To 5
            If RecentFiles(n) = s Then
                For m As Integer = n To 4
                    RecentFiles(m) = RecentFiles(m + 1)
                Next
                RecentFiles(5) = Nothing
                Exit For
            End If
        Next
        For n As Integer = 4 To 0 Step -1
            RecentFiles(n + 1) = RecentFiles(n)
        Next
        RecentFiles(0) = s
        RefreshRecent()
    End Sub
    Private Sub RemoveRecent(ByVal Index As Integer)
        RecentFiles(Index) = Nothing
        For m As Integer = Index To 4
            RecentFiles(m) = RecentFiles(m + 1)
        Next
        RecentFiles(5) = Nothing
        RefreshRecent()
    End Sub
    Private Sub RefreshRecent()
        Dim c As Menu.MenuItemCollection = Menu_File_RecentFiles.MenuItems
        c.Clear()
        For n As Integer = 0 To 5
            If RecentFiles(n) = Nothing Then
                Exit For
            End If
            Dim i As New MenuItem("&" & n & " " & RecentFiles(n))
            c.Add(i)
            AddHandler i.Click, AddressOf RecentFilesHandler
        Next
        Menu_File_RecentFiles.Enabled = (c.Count <> 0)
    End Sub
    Private Sub RecentFilesHandler(ByVal sender As Object, ByVal e As EventArgs)
#If CONFIG <> "Debug" Then
        Try
#End If
        Dim r As MenuItem = sender
        Dim Path As String = r.Text.Substring(3)
        If Not r.Text.Contains(",") Then RemoveRecent(r.Text.Substring(0, 1))
        Dim Version As String = ""
        If Path.Contains(",") Then
            Version = Path.Substring(Path.LastIndexOf(",") + 1)
        End If
        Path = Path.Substring(0, Path.Length - Version.Length - 1)
        If Not pfClosed Then pf.Close()
        pf = PAK.Open(Path)
        pfCurDirDB = pf.Root
        Me.Path.Text = pfCurDirDB.Name & "\"
        Me.Path.Text = Me.Path.Text.TrimStart("\")
        RefreshList()
        AddRecent(Path & ",2")
        pfClosed = False
        Me.Text = Title & " - " & Path
#If CONFIG <> "Debug" Then
        Catch ex As Exception
            MsgBox(ex)
            RemoveRecent(sender.Text.Substring(1, 1))
        End Try
#End If
    End Sub

    Private Sub FileListView_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FileListView.KeyUp
        Select Case e.KeyData
            Case Keys.Back
                If pfClosed Then Return
                If pfCurDirDB.ParentFileDB Is Nothing Then Return
                pfCurDirDB = pfCurDirDB.ParentFileDB
                Path.Text = Path.Text.Substring(0, Path.Text.Length - 1)
                If Path.Text.Contains("\") Then
                    Path.Text = Path.Text.Substring(0, Path.Text.LastIndexOf("\")) & "\"
                Else
                    Path.Text = ""
                End If
                Path.Text = Path.Text.TrimStart("\")
                RefreshList()
            Case Keys.Control + Keys.A
                FileListView.BeginUpdate()
                For Each Item As ListViewItem In FileListView.Items
                    Item.Selected = True
                Next
                If FileListView.Items(0).SubItems(0).Text = ".." Then FileListView.Items(0).Selected = False
                FileListView.EndUpdate()
        End Select
    End Sub

    Private Sub FileListView_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles FileListView.ColumnClick
        FileListViewMajorCompareeIndex = e.Column
        RefreshList()
    End Sub
End Class
