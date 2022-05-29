Option Compare Text
Imports System
Imports System.Math
Imports System.Drawing
Imports System.IO
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports FRCCoreFile

Public Class PAK
    Inherits StreamEx

    Private Const Key As Int32 = &HB6B6B6B6
    Private Const KeyByte As Byte = &HB6

    Private Sub New(ByVal Path As String, ByVal FileMode As FileMode, ByVal Access As FileAccess, ByVal Share As FileShare)
        MyBase.New(Path, FileMode, Access, Share)
    End Sub
    Shared Function Open(ByVal Path As String) As PAK
        Dim pf As PAK = Nothing
#If CONFIG <> "Debug" Then
        Try
#End If
        Dim FileName As String() = LinhaDeComando.GetFileNameList(Path)

        pf = New PAK(Path, FileMode.Open, FileAccess.Read, FileShare.Read)
        If pf.ReadSimpleString(11) <> "SBPAK V 1.0" Then Throw New InvalidDataException
        pf.Position = 36
        Dim Num As Integer = pf.ReadInt32 Xor Key
        pf.Position += 4
        Dim DataPosition As Integer = pf.ReadInt32 Xor Key
        pf.Position += 4

        pf.RootValue = New FileDB("", PAK.FileDB.FileType.Directory, 0, 0)
        Dim FileDB As New List(Of FileDB)
        For n As Integer = 0 To Num - 1
            Dim f As New FileDB(pf)
            f.Address += DataPosition
            FileDB.Add(f)
        Next
        FileDB.Sort(AddressOf Compare)

        If FileName.GetLength(0) <> Num Then
            Throw New InvalidDataException
        End If

        For n As Integer = 0 To Num - 1
            FileDB(n).Name = FileName(n)
            FileDB(n).Decode = Not FileName(n).EndsWith(".bik")
            pf.PushFileToDir(FileDB(n), pf.RootValue)
        Next

        Return pf
#If CONFIG <> "Debug" Then
        Catch
            Try
                pf.Close()
            Catch
            End Try
            Throw
        End Try
#End If
    End Function
    Private Sub PushFileToDir(ByVal f As FileDB, ByRef d As FileDB)
        Dim Dir As String = ""
        If f.Name.Contains("\") Then Dir = PopFirstDir(f.Name)
        If Dir = "" Then
            d.SubFileDB.Add(f)
            f.ParentFileDB = d
        Else
            If d.SubFileDBRef Is Nothing Then d.SubFileDBRef = New Dictionary(Of String, Integer)(StringComparer.InvariantCultureIgnoreCase)
            If Not d.SubFileDBRef.ContainsKey(Dir) Then
                Dim DirDB As FileDB = FileDB.CreateDirectory(Dir)
                d.SubFileDBRef.Add(DirDB.Name, d.SubFileDB.Count)
                d.SubFileDB.Add(DirDB)
                DirDB.ParentFileDB = d
            End If
            PushFileToDir(f, d.SubFileDB(d.SubFileDBRef(Dir)))
        End If
    End Sub
    Private Shared Function PopFirstDir(ByRef Path As String) As String
        Dim ret As String
        If Path = "" Then Return ""
        Dim NameS As Integer
        NameS = Path.IndexOf("\"c, NameS)
        If NameS < 0 Then
            ret = Path
            Path = ""
            Return ret
        Else
            ret = Path.Substring(0, NameS)
            Path = Path.Substring(NameS + 1)
            Return ret
        End If
    End Function
    Private Shared Function Compare(ByVal Left As FileDB, ByVal Right As FileDB) As Integer
        If Left.Address < Right.Address Then Return -1
        If Left.Address > Right.Address Then Return 1
        Return 0
    End Function
    Private Shared Function MatchIdentifier(ByVal s As StreamEx, ByVal Identifier As String) As Boolean
        Dim h As String = ReadFixedString(s, Identifier.Length)
        s.Position -= Identifier.Length
        Return h = Identifier
    End Function
    Private Shared Function MatchTrailer(ByVal s As StreamEx, ByVal Trailer As String) As Boolean
        s.Position -= Trailer.Length
        Dim h As String = ReadFixedString(s, Trailer.Length)
        Return h = Trailer
    End Function
    Private Shared Function ReadFixedString(ByVal s As StreamEx, ByVal Count As Integer) As String
        Dim c As Char() = New Char(Count - 1) {}
        Dim n As Integer
        For n = 0 To Count - 1
            c(n) = ChrW(s.ReadByte Xor KeyByte)
        Next
        Return c
    End Function

    Private RootValue As FileDB
    Public ReadOnly Property Root() As FileDB
        Get
            Return RootValue
        End Get
    End Property

    Public Function TryGetFileDB(ByVal Path As String) As FileDB
        Dim p As String = Path
        Dim ret As FileDB = Root
        Dim d As String = PopFirstDir(p)
        If d = "" Then Return ret
        If d <> ret.Name Then Return Nothing
        While ret IsNot Nothing
            d = PopFirstDir(p)
            If d = "" Then Return ret
            For n As Integer = 0 To ret.SubFileDB.Count - 1
                If d = ret.SubFileDB(n).Name Then
                    ret = ret.SubFileDB(n)
                    Continue While
                End If
            Next
            Return Nothing
        End While
        Return Nothing
    End Function

    Public Sub Extract(ByVal File As FileDB, ByVal Directory As String, Optional ByVal Mask As String = "*.*")
        With File
            Dim Dir As String = Directory.Trim.TrimEnd("\")
            If Dir <> "" AndAlso Not IO.Directory.Exists(Dir) Then IO.Directory.CreateDirectory(Dir)
            Select Case .Type
                Case FileDB.FileType.File
                    If IsMatchFileMask(.Name, Mask) Then
                        Position = .Address
                        Dim t As New StreamEx(GetPath(Dir, .Name), FileMode.Create)
                        If .Decode Then
                            For n As Integer = 0 To .Length - 1
                                t.WriteByte(BaseStream.ReadByte Xor KeyByte)
                            Next
                        Else
                            For n As Integer = 0 To .Length - 1
                                t.WriteByte(BaseStream.ReadByte)
                            Next
                        End If
                        t.Close()
                    End If
                Case FileDB.FileType.Directory
                    For Each FileDB As FileDB In .SubFileDB
                        Extract(FileDB, GetPath(Dir, .Name), Mask)
                    Next
            End Select
        End With
    End Sub


    Shared Sub Create(ByVal Source As String, ByVal Path As String)
        Dim FileQueue As New Queue(Of String)
        ImportDirectory(Source, Source, FileQueue)
        LinhaDeComando.PackFileInList(Source, Path, FileQueue.ToArray)
    End Sub
    Shared Sub CreateWithListFile(ByVal Source As String, ByVal Path As String, ByVal ListFilePath As String)
        Dim FileQueue As New Queue(Of String)
        Dim ListFile As New StreamReader(ListFilePath, System.Text.Encoding.Default)
        While Not ListFile.EndOfStream
            Dim Line As String = ListFile.ReadLine
            If Line <> "" Then Line = Line.Trim
            If Line <> "" Then FileQueue.Enqueue(Line)
        End While
        LinhaDeComando.PackFileInList(Source, Path, FileQueue.ToArray)
    End Sub
    Private Shared Sub ImportDirectory(ByVal Dir As String, ByVal Source As String, ByVal FileQueue As Queue(Of String))
        For Each f As String In Directory.GetFiles(Dir)
            FileQueue.Enqueue(GetRelativePath(f, Source))
        Next
        For Each d As String In Directory.GetDirectories(Dir)
            ImportDirectory(d, Source, FileQueue)
        Next
    End Sub

    'Fim da classe
    'Iniciao das SubClasses

    Public Class FileDB
        Public Name As String
        Public Type As FileType
        Public Length As Int32
        Public Address As Int32
        Public Unknown As Int32
        Public Decode As Boolean = False

        Public Const DBLength As Integer = 48
        Public ParentFileDB As FileDB
        Public SubFileDB As New List(Of FileDB)
        Public SubFileDBRef As Dictionary(Of String, Integer)
        Public Sub New(ByVal Name As String, ByVal Type As FileType, ByVal Length As Int32, ByVal Address As Int32)
            If Name <> "" Then Me.Name = Name
            Me.Type = Type
            Me.Length = Length
            Me.Address = Address
        End Sub
        Public Sub New(ByVal s As PAK)
            Length = s.ReadInt32 Xor Key
            Address = s.ReadInt32 Xor Key
            Name = (s.ReadInt32 Xor Key).ToString("000")
            Unknown = s.ReadInt32() Xor Key
            Type = FileType.File
        End Sub
        Public Enum FileType As Int32
            File = 0
            Directory = 1
            DirectoryEnd = 255
        End Enum
        Public Shared Function CreateFile(ByVal Name As String, ByVal Length As Int32, ByVal Address As Int32) As FileDB
            Return New FileDB(Name, FileType.File, Length, Address)
        End Function
        Public Shared Function CreateDirectory(ByVal Name As String) As FileDB
            Return New FileDB(Name, FileType.Directory, &HFFFFFFFF, 0)
        End Function
        Public Shared Function CreateDirectoryEnd() As FileDB
            Return New FileDB(Nothing, FileType.DirectoryEnd, &HFFFFFFFF, &HFFFFFFFF)
        End Function
        Public Sub WriteToFile(ByVal s As PAK)
        End Sub
    End Class
End Class
