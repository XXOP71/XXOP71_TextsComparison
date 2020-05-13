Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Linq
Imports System.Xml.Linq
Imports System.Text



Public NotInheritable Class CFrmRoot
    Public Sub New()
        InitializeComponent()
    End Sub


    Private Shared Sub ppResetWindowPosition(tfrm As Form)
        Dim tcs As Screen = Screen.FromPoint(Cursor.Position)
        Dim tsb As Rectangle = tcs.Bounds
        Dim tlp As Point = New Point(tsb.Right, tsb.Bottom)
        Dim tws As Size = tfrm.Size
        tlp.Offset(-(tws.Width + 40), -(tws.Height + 40))
        tfrm.Location = tlp
    End Sub


    Private Const _strVer As String = "v1.00"

    Protected Overrides Sub OnLoad(tea As EventArgs)
        MyBase.OnLoad(tea)

        Me.Text = String.Format("{0}  {1}", Me.GetType().Namespace, _strVer)
        ppResetWindowPosition(Me)
    End Sub




    ''' <summary>
    ''' Clear
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pp_btn1_Click(tsd As Object, tea As EventArgs)
        Try
            _txb1.Clear()
            _txb2.Clear()
            _txb3.Clear()
        Catch
        End Try
    End Sub


    ''' <summary>
    ''' Compare
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pp_btn2_Click(tsd As Object, tea As EventArgs)
        Try
            Dim tstr1 As String = _txb1.Text
            Dim tstr2 As String = _txb2.Text
            If Not String.IsNullOrEmpty(tstr1) AndAlso Not String.IsNullOrEmpty(tstr2) Then
                Dim trv As Integer = String.Compare(tstr1, tstr2, True)
                Dim tl1 As Integer = tstr1.Length
                Dim tl2 As Integer = tstr2.Length
                If trv = 0 Then
                    _txb3.Text = String.Format("(1 = 2) Two texts equal. (1Count={0}, 2Count={1})", tl1, tl2)
                ElseIf trv < 0 Then
                    _txb3.Text = String.Format("(1 < 2) Two texts different. (1Count={0}, 2Count={1})", tl1, tl2)
                ElseIf trv > 0 Then
                    _txb3.Text = String.Format("(1 > 2) Two texts different. (1Count={0}, 2Count={1})", tl1, tl2)
                End If
            End If
        Catch
        End Try
    End Sub


    ''' <summary>
    ''' Paste1
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pp_btn3_Click(tsd As Object, tea As EventArgs) Handles _btn1.Click
        Try
            _txb1.Text = Clipboard.GetText()
        Catch
        End Try
    End Sub


    ''' <summary>
    ''' Paste2
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pp_btn4_Click(tsd As Object, tea As EventArgs) Handles _btn4.Click
        Try
            _txb2.Text = Clipboard.GetText()
        Catch
        End Try
    End Sub



    Private Sub ppKeyDown(tsd As Object, tkea As KeyEventArgs) Handles MyBase.KeyDown
        If tkea.Control Then
            If tkea.KeyCode = Keys.D1 Then
                pp_btn3_Click(Nothing, Nothing)
            ElseIf tkea.KeyCode = Keys.D2 Then
                pp_btn4_Click(Nothing, Nothing)
            ElseIf tkea.KeyCode = Keys.E Then
                pp_btn2_Click(Nothing, Nothing)
            ElseIf tkea.KeyCode = Keys.Q Then
                pp_btn1_Click(Nothing, Nothing)
            End If
        End If
    End Sub

End Class
