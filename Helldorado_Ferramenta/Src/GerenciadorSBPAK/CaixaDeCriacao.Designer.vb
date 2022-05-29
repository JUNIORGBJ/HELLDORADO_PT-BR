<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaixaDeCriacao
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_Start = New System.Windows.Forms.Button()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.FileButton_PAKFile = New System.Windows.Forms.Button()
        Me.Label_Y64File = New System.Windows.Forms.Label()
        Me.TextBox_PAKFile = New System.Windows.Forms.TextBox()
        Me.TextBox_SourceDirectory = New System.Windows.Forms.TextBox()
        Me.Label_SourceDirectory = New System.Windows.Forms.Label()
        Me.FileButton_SourceDirectory = New System.Windows.Forms.Button()
        Me.TextBox_ListFile = New System.Windows.Forms.TextBox()
        Me.Label_ListFile = New System.Windows.Forms.Label()
        Me.FileButton_ListFile = New System.Windows.Forms.Button()
        Me.TextBox_Output = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button_Start, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_Cancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(299, 120)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Button_Start
        '
        Me.Button_Start.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_Start.Location = New System.Drawing.Point(3, 3)
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.Size = New System.Drawing.Size(67, 23)
        Me.Button_Start.TabIndex = 0
        Me.Button_Start.Text = "Iniciar"
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancel.Location = New System.Drawing.Point(76, 3)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(67, 23)
        Me.Button_Cancel.TabIndex = 1
        Me.Button_Cancel.Text = "Cancelar"
        '
        'FileButton_PAKFile
        '
        Me.FileButton_PAKFile.Location = New System.Drawing.Point(402, 26)
        Me.FileButton_PAKFile.Name = "FileButton_PAKFile"
        Me.FileButton_PAKFile.Size = New System.Drawing.Size(31, 25)
        Me.FileButton_PAKFile.TabIndex = 27
        Me.FileButton_PAKFile.Text = "..."
        Me.FileButton_PAKFile.UseVisualStyleBackColor = True
        '
        'Label_Y64File
        '
        Me.Label_Y64File.AutoSize = True
        Me.Label_Y64File.Location = New System.Drawing.Point(10, 31)
        Me.Label_Y64File.Name = "Label_Y64File"
        Me.Label_Y64File.Size = New System.Drawing.Size(88, 13)
        Me.Label_Y64File.TabIndex = 25
        Me.Label_Y64File.Text = "Arq. PAK Original"
        '
        'TextBox_PAKFile
        '
        Me.TextBox_PAKFile.Location = New System.Drawing.Point(129, 28)
        Me.TextBox_PAKFile.Name = "TextBox_PAKFile"
        Me.TextBox_PAKFile.Size = New System.Drawing.Size(267, 20)
        Me.TextBox_PAKFile.TabIndex = 26
        '
        'TextBox_SourceDirectory
        '
        Me.TextBox_SourceDirectory.Location = New System.Drawing.Point(129, 60)
        Me.TextBox_SourceDirectory.Name = "TextBox_SourceDirectory"
        Me.TextBox_SourceDirectory.Size = New System.Drawing.Size(267, 20)
        Me.TextBox_SourceDirectory.TabIndex = 26
        '
        'Label_SourceDirectory
        '
        Me.Label_SourceDirectory.AutoSize = True
        Me.Label_SourceDirectory.Location = New System.Drawing.Point(10, 63)
        Me.Label_SourceDirectory.Name = "Label_SourceDirectory"
        Me.Label_SourceDirectory.Size = New System.Drawing.Size(111, 13)
        Me.Label_SourceDirectory.TabIndex = 25
        Me.Label_SourceDirectory.Text = "Pasta Arq. Modificado"
        '
        'FileButton_SourceDirectory
        '
        Me.FileButton_SourceDirectory.Location = New System.Drawing.Point(402, 57)
        Me.FileButton_SourceDirectory.Name = "FileButton_SourceDirectory"
        Me.FileButton_SourceDirectory.Size = New System.Drawing.Size(31, 25)
        Me.FileButton_SourceDirectory.TabIndex = 27
        Me.FileButton_SourceDirectory.Text = "..."
        Me.FileButton_SourceDirectory.UseVisualStyleBackColor = True
        '
        'TextBox_ListFile
        '
        Me.TextBox_ListFile.Location = New System.Drawing.Point(129, 91)
        Me.TextBox_ListFile.Name = "TextBox_ListFile"
        Me.TextBox_ListFile.Size = New System.Drawing.Size(267, 20)
        Me.TextBox_ListFile.TabIndex = 26
        '
        'Label_ListFile
        '
        Me.Label_ListFile.AutoSize = True
        Me.Label_ListFile.Location = New System.Drawing.Point(10, 94)
        Me.Label_ListFile.Name = "Label_ListFile"
        Me.Label_ListFile.Size = New System.Drawing.Size(118, 13)
        Me.Label_ListFile.TabIndex = 25
        Me.Label_ListFile.Text = "Arquivo Lista (Opcional)"
        '
        'FileButton_ListFile
        '
        Me.FileButton_ListFile.Location = New System.Drawing.Point(402, 89)
        Me.FileButton_ListFile.Name = "FileButton_ListFile"
        Me.FileButton_ListFile.Size = New System.Drawing.Size(31, 25)
        Me.FileButton_ListFile.TabIndex = 27
        Me.FileButton_ListFile.Text = "..."
        Me.FileButton_ListFile.UseVisualStyleBackColor = True
        '
        'TextBox_Output
        '
        Me.TextBox_Output.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Output.Location = New System.Drawing.Point(12, 156)
        Me.TextBox_Output.Multiline = True
        Me.TextBox_Output.Name = "TextBox_Output"
        Me.TextBox_Output.ReadOnly = True
        Me.TextBox_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_Output.Size = New System.Drawing.Size(435, 159)
        Me.TextBox_Output.TabIndex = 26
        '
        'CaixaDeCriacao
        '
        Me.AcceptButton = Me.Button_Start
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button_Cancel
        Me.ClientSize = New System.Drawing.Size(459, 332)
        Me.Controls.Add(Me.FileButton_ListFile)
        Me.Controls.Add(Me.Label_ListFile)
        Me.Controls.Add(Me.FileButton_SourceDirectory)
        Me.Controls.Add(Me.Label_SourceDirectory)
        Me.Controls.Add(Me.TextBox_Output)
        Me.Controls.Add(Me.TextBox_ListFile)
        Me.Controls.Add(Me.FileButton_PAKFile)
        Me.Controls.Add(Me.TextBox_SourceDirectory)
        Me.Controls.Add(Me.Label_Y64File)
        Me.Controls.Add(Me.TextBox_PAKFile)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CaixaDeCriacao"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Criar Arquivo PAK"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button_Start As System.Windows.Forms.Button
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents FileButton_PAKFile As System.Windows.Forms.Button
    Friend WithEvents Label_Y64File As System.Windows.Forms.Label
    Friend WithEvents TextBox_PAKFile As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_SourceDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label_SourceDirectory As System.Windows.Forms.Label
    Friend WithEvents FileButton_SourceDirectory As System.Windows.Forms.Button
    Friend WithEvents TextBox_ListFile As System.Windows.Forms.TextBox
    Friend WithEvents Label_ListFile As System.Windows.Forms.Label
    Friend WithEvents FileButton_ListFile As System.Windows.Forms.Button
    Friend WithEvents TextBox_Output As System.Windows.Forms.TextBox

End Class
