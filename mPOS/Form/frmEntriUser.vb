Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmEntriUser
    Public NoID As Long
    Dim KodeLama As String = ""
    Dim pStatusBaru As Boolean = False
    Dim repckedit As New RepositoryItemCheckEdit
    Dim repdateedit As New RepositoryItemDateEdit
    Dim reptextedit As New RepositoryItemTextEdit
    Dim reppicedit As New RepositoryItemPictureEdit
    Dim SQL As String = ""

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmEntriUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GridView1.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & GridView1.Name & ".xml")
        LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
    End Sub

    Private Sub frmEntriUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet
        Dim SQL As String = ""
        Try
            If pStatusBaru Then
                ckAktif.Checked = True
                ckSupervisor.Checked = True
            Else
                SQL = "SELECT * FROM HUser WHERE NoID= " & NoID
                EksekusiDataset(ds, "HUser", SQL)
                If ds.Tables("HUser").Rows.Count >= 1 Then
                    txtKodeUser.Text = NullToStr(ds.Tables("HUser").Rows(0).Item("Kode"))
                    KodeLama = txtKodeUser.Text
                    txtNamaUser.Text = NullToStr(ds.Tables("HUser").Rows(0).Item("Nama"))
                    txtPwd.Text = DecryptText(NullToStr(ds.Tables("HUser").Rows(0).Item("Password")), "Elliteserv")
                    txtRePwd.Text = txtPwd.Text
                    ckAktif.Checked = NullToBool(ds.Tables("HUser").Rows(0).Item("IsAktif"))
                    ckSupervisor.Checked = NullToBool(ds.Tables("HUser").Rows(0).Item("IsSupervisor"))
                End If
            End If
            RefreshMenu()

            With GridView1
                For i As Integer = 0 To .Columns.Count - 1
                    Select Case .Columns(i).ColumnType.Name.ToLower
                        Case "int32", "int64", "int"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            .Columns(i).DisplayFormat.FormatString = "n0"
                        Case "decimal", "single", "money", "double"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            .Columns(i).DisplayFormat.FormatString = "n2"
                        Case "string"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
                            .Columns(i).DisplayFormat.FormatString = ""
                        Case "date"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            .Columns(i).DisplayFormat.FormatString = "dd-MM-yyyy"
                        Case "datetime"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            .Columns(i).DisplayFormat.FormatString = "dd-MM-yyyy HH:mm"
                        Case "byte[]"
                            reppicedit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
                            .Columns(i).OptionsColumn.AllowGroup = False
                            .Columns(i).OptionsColumn.AllowSort = False
                            .Columns(i).OptionsFilter.AllowFilter = False
                            .Columns(i).ColumnEdit = reppicedit
                        Case "boolean"
                            .Columns(i).ColumnEdit = repckedit
                    End Select
                    .ShowFindPanel()
                Next
            End With
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml") Then
                LayoutControl1.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
            End If
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & GridView1.Name & ".xml") Then
                GridView1.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & GridView1.Name & ".xml")
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK)
        Finally
            If Not ds Is Nothing Then
                ds.Dispose()
            End If
        End Try
    End Sub

    Private Sub RefreshMenu()
        Dim ds As New DataSet
        Dim SQL As String = ""
        Try
            If NoID >= 1 Then
                SQL = "INSERT INTO [HUserD] ([IDUser],[IDMenu],[Enable],[Visible]) " & vbCrLf & _
                      " SELECT " & NoID & ", HMenu.NoID, 1, 1 FROM HMenu WHERE IsAktif=1 AND NoID NOT IN (SELECT IDMenu FROM HUserD WHERE IDUser=" & NoID & ")"
                EksekusiSQL(SQL)
            End If
            SQL = "SELECT HUserD.*, HMenu.Caption, HParent.Caption AS Parent " & vbCrLf & _
                  " FROM HUserD " & vbCrLf & _
                  " INNER JOIN HMenu ON HMenu.NoID=HUserD.IDMenu " & vbCrLf & _
                  " LEFT JOIN HMenu HParent ON HParent.NoID=HMenu.IDParent WHERE HUserD.IDUser=" & NoID
            EksekusiDataset(ds, "Data", SQL)
            If Not ds.Tables("Data") Is Nothing Then
                GridControl1.DataSource = ds.Tables("Data")
            Else
                GridControl1.DataSource = Nothing
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK)
        Finally
            If Not ds Is Nothing Then
                ds.Dispose()
            End If
        End Try
    End Sub
    Public Sub New(ByVal IsNew As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        pStatusBaru = IsNew
    End Sub

    Private Sub GridView1_FocusedColumnChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        Select Case e.FocusedColumn.FieldName.ToLower
            Case "Visible".ToLower, "Enable".ToLower
                GridView1.OptionsBehavior.Editable = True
            Case Else
                GridView1.OptionsBehavior.Editable = False
        End Select
    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Select Case GridView1.FocusedColumn.FieldName.ToLower
            Case "Visible".ToLower, "Enable".ToLower
                GridView1.OptionsBehavior.Editable = True
            Case Else
                GridView1.OptionsBehavior.Editable = False
        End Select
    End Sub

    Private Function IsValidasi() As Boolean
        Dim Hasil As Boolean = True
        If txtKodeUser.Text = "" Then
            XtraMessageBox.Show("Kode masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKodeUser.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtNamaUser.Text = "" Then
            XtraMessageBox.Show("Nama masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtNamaUser.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtPwd.Text = "" Or txtRePwd.Text = "" Then
            XtraMessageBox.Show("Password masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtPwd.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtPwd.Text <> txtRePwd.Text Then
            XtraMessageBox.Show("Password dan Re-Password masih belum sama.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtPwd.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If CekKodeValid(txtKodeUser.Text, KodeLama, "HUser", "Kode", Not pStatusBaru) Then
            XtraMessageBox.Show("Kode sudah dipakai.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKodeUser.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        Return Hasil
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            If IsValidasi() Then
                If pStatusBaru Then
                    NoID = GetNewID("HUser")
                    SQL = "INSERT INTO [HUser] ([NoID],[Kode],[Nama],[Password],[IsAktif],[IsSupervisor]) VALUES (" & vbCrLf & _
                          NoID & ", '" & FixApostropi(txtKodeUser.Text) & "', '" & FixApostropi(txtNamaUser.Text) & "', '" & FixApostropi(EncryptText(txtPwd.Text, "Elliteserv")) & "', " & IIf(ckAktif.Checked, 1, 0) & ", " & IIf(ckSupervisor.Checked, 1, 0) & ")"
                Else
                    SQL = "UPDATE [HUser] SET " & vbCrLf & _
                          " [Kode] = '" & FixApostropi(txtKodeUser.Text) & "'" & vbCrLf & _
                          " ,[Nama] = '" & FixApostropi(txtNamaUser.Text) & "'" & vbCrLf & _
                          " ,[Password] = '" & FixApostropi(EncryptText(txtPwd.Text, "Elliteserv")) & "'" & vbCrLf & _
                          " ,[IsAktif] = " & IIf(ckAktif.Checked, 1, 0) & vbCrLf & _
                          " ,[IsSupervisor] = " & IIf(ckSupervisor.Checked, 1, 0) & vbCrLf & _
                          " WHERE NoID=" & NoID
                End If
                If EksekusiSQL(SQL) >= 1 Then
                    SQL = "DELETE FROM HUserD WHERE IDMenu IN (SELECT HMenu.NoID FROM HMenu WHERE ISNULL(HMenu.IsAktif,0)=0) AND IDUser=" & NoID
                    EksekusiSQL(SQL)
                    If pStatusBaru Then
                        RefreshMenu()
                    Else
                        For i As Integer = 0 To GridView1.RowCount - 1
                            SQL = "UPDATE HUserD SET [Enable]=" & IIf(NullToBool(GridView1.GetRowCellValue(i, "Enable")), 1, 0) & ", [Visible]=" & IIf(NullToBool(GridView1.GetRowCellValue(i, "Visible")), 1, 0) & " WHERE NoID=" & NullToLong(GridView1.GetRowCellValue(i, "NoID"))
                            EksekusiSQL(SQL)
                        Next
                        DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class