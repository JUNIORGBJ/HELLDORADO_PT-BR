Option Compare Text
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports FRCCoreFile

Public Class CaixaDeCriacao

    Private CloseFlag As Boolean = False
    Private Sub Button_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Start.Click
        If CloseFlag Then
            Me.Close()
        Else
            Me.Button_Start.Enabled = False
            Me.Button_Cancel.Enabled = False
            CloseFlag = True

            My.Forms.GerenciadorPAK.DoClose()

            If TextBox_ListFile.Text = "" Then
                PAK.Create(TextBox_SourceDirectory.Text, TextBox_PAKFile.Text)
            Else
                PAK.CreateWithListFile(TextBox_SourceDirectory.Text, TextBox_PAKFile.Text, TextBox_ListFile.Text)
            End If
            My.Forms.GerenciadorPAK.DoOpenDP2C(TextBox_PAKFile.Text)
            Button_Start.Text = "Fechar"
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Button_Start.Enabled = True
        End If
    End Sub

    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub DialogCreate_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Forms.GerenciadorPAK.Enabled = True
        My.Forms.GerenciadorPAK.Activate()
    End Sub

    Private Sub FileButton_PAKFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileButton_PAKFile.Click
        With TextBox_PAKFile
            Static d As Windows.Forms.OpenFileDialog
            If d Is Nothing Then d = New Windows.Forms.OpenFileDialog
            Dim dir As String = GetFileDirectory(.Text)
            If IO.Directory.Exists(dir) Then
                d.FileName = .Text
            End If
            d.Filter = "PAK(*.PAK)|*.PAK"
            d.CheckFileExists = False
            d.CheckPathExists = False
            If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim T As String = GetRelativePath(d.FileName, Application.StartupPath)
                If T <> "" AndAlso d.FileName <> "" AndAlso T.Length < d.FileName.Length Then
                    .Text = T
                Else
                    .Text = d.FileName
                End If
            End If
        End With
        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath
    End Sub
    Private Sub FileButton_SourceDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileButton_SourceDirectory.Click
        With TextBox_SourceDirectory
            Static d As Windows.Forms.FolderBrowserDialog
            If d Is Nothing Then d = New Windows.Forms.FolderBrowserDialog
            Dim dir As String = GetFileDirectory(.Text).TrimEnd("\")
            If IO.Directory.Exists(dir) Then
                d.SelectedPath = dir
            End If
            If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim T As String = GetRelativePath(d.SelectedPath, Application.StartupPath)
                If T <> "" AndAlso d.SelectedPath <> "" AndAlso T.Length < d.SelectedPath.Length Then
                    .Text = T
                Else
                    .Text = d.SelectedPath
                End If
            End If
        End With
        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath
    End Sub
    Private Sub FileButton_ListFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileButton_ListFile.Click
        With TextBox_ListFile
            Static d As Windows.Forms.OpenFileDialog
            If d Is Nothing Then d = New Windows.Forms.OpenFileDialog
            Dim dir As String = GetFileDirectory(.Text)
            If IO.Directory.Exists(dir) Then
                d.FileName = .Text
            End If
            d.Filter = "Lista(*.txt)|*.txt"
            If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim T As String = GetRelativePath(d.FileName, Application.StartupPath)
                If T <> "" AndAlso d.FileName <> "" AndAlso T.Length < d.FileName.Length Then
                    .Text = T
                Else
                    .Text = d.FileName
                End If
            End If
        End With
        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath
    End Sub

    Sub k()
    End Sub
End Class
