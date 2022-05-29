Option Compare Text

Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Diagnostics
Imports System.Windows.Forms
Imports FRCCoreFile

Public Module LinhaDeComando
    Private TempDir As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\GerenciadorSBPAKTemp"
    Private TempAppPath As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\GerenciadorSBPAKTemp\SBPacker.exe"
    Private TempInput As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\GerenciadorSBPAKTemp\input.txt"

    Function GetFileNameList(ByVal PackPath As String) As String()
        IO.Directory.SetCurrentDirectory(Application.StartupPath)
        GenerateApp()

        Dim p As Process = New Process()
        p.StartInfo.FileName = TempAppPath
        p.StartInfo.Arguments = "EN -l " & """" & PackPath & """"
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.UseShellExecute = False
        p.StartInfo.CreateNoWindow = True
        p.Start()

        Sleep(1000)

        Dim o As StreamReader = p.StandardOutput
        o.ReadLine()
        o.ReadLine()
        o.ReadLine()
        o.ReadLine()
        Dim l As New List(Of String)

        Dim n As Integer = 0
        While True
            If p.WaitForExit(500) Then Exit While
            While Not o.EndOfStream
                l.Add(o.ReadLine())
            End While
            If n = 20 Then
                p.Kill()
                Throw New TimeoutException
            End If
        End While

        While Not o.EndOfStream
            l.Add(o.ReadLine())
        End While

        RemoveApp()

        Return l.ToArray
    End Function
    Sub PackFileInList(ByVal Source As String, ByVal PackPath As String, ByVal List As String())
        Source = GetAbsolutePath(Source, Application.StartupPath)
        PackPath = GetAbsolutePath(PackPath, Application.StartupPath)
        IO.Directory.SetCurrentDirectory(Source)
        GenerateApp()

        Dim i As New StreamWriter(TempInput, False, System.Text.Encoding.Default)
        For Each Line As String In List
            If Line.EndsWith(".bik") AndAlso Not Line.StartsWith("*") Then
                i.WriteLine("*" & Line)
            Else
                i.WriteLine(Line)
            End If
        Next
        i.Close()

        Dim p As Process = New Process()
        p.StartInfo.FileName = TempAppPath
        p.StartInfo.Arguments = "EN -a " & """" & TempInput & """ """ & PackPath & """"
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.UseShellExecute = False
        p.StartInfo.CreateNoWindow = True
        p.Start()

        Sleep(1000)

        Dim o As StreamReader = p.StandardOutput
        o.ReadLine()
        o.ReadLine()
        o.ReadLine()
        o.ReadLine()
        Dim err As New Text.StringBuilder

        Dim n As Integer = 0
        While True
            If p.WaitForExit(500) Then Exit While
            While Not o.EndOfStream
                Dim Line As String = o.ReadLine()
                If Line <> "" Then Line = Line.Trim
                If Line.StartsWith("Arquivo lista inválido") Then Throw New Exception("1")
                If Line.StartsWith("AVISO arquivo não existe:") Then err.AppendLine(Line.Substring("AVISO arquivo não existe:".Length) & "���1")
                If Line.StartsWith("Não há arquivos para criar. Pasta com arquivos vazios não são permitidos") Then err.AppendLine("1")
            End While
            If n = 20 Then
                p.Kill()
                Throw New TimeoutException
            End If
        End While

        While Not o.EndOfStream
            Dim Line As String = o.ReadLine()
            If Line <> "" Then Line = Line.Trim
            If Line.StartsWith("Arquivo lista inválido") Then Throw New Exception("1")
            If Line.StartsWith("AVISO arquivo não existe:") Then err.AppendLine(Line.Substring("AVISO arquivo não existe:".Length) & "���1")
            If Line.StartsWith("Não há arquivos para criar. Pasta com arquivos vazios não são permitidos!") Then err.AppendLine("1")
        End While

        If err.Length <> 0 Then Throw New Exception(err.ToString)

        RemoveApp()
        IO.Directory.SetCurrentDirectory(Application.StartupPath)
    End Sub
    Sub GenerateApp()
        If Not Directory.Exists(TempDir) Then Directory.CreateDirectory(TempDir)
        Dim Executable As New StreamEx(TempAppPath, FileMode.Create)
        Executable.Write(My.Resources.SBPacker, 0, My.Resources.SBPacker.GetLength(0))
        Executable.Close()
    End Sub
    Sub RemoveApp()
        Try
            File.Delete(TempAppPath)
            Sleep(2000)
            Directory.Delete(TempDir, True)
        Catch
        End Try
    End Sub
    Public Sub Sleep(ByVal msec As Integer)
        Dim Last As Long = System.Environment.TickCount
        While System.Environment.TickCount - Last < msec
            Application.DoEvents()
        End While
    End Sub
End Module
