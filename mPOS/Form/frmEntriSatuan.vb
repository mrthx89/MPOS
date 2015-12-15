Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmEntriSatuan
    Public NoID As Long
    Dim KodeLama As String = ""
    Dim pStatusBaru As Boolean = False
    Dim SQL As String = ""

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmEntriUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
    End Sub

    Private Sub frmEntriUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet
        Dim SQL As String = ""
        Try
            If pStatusBaru Then
                ckAktif.Checked = True
            Else
                SQL = "SELECT * FROM HSatuan WHERE NoID= " & NoID
                EksekusiDataset(ds, "HSatuan", SQL)
                If ds.Tables("HSatuan").Rows.Count >= 1 Then
                    txtKodeUser.Text = NullToStr(ds.Tables("HSatuan").Rows(0).Item("Kode"))
                    KodeLama = txtKodeUser.Text
                    txtNamaUser.Text = NullToStr(ds.Tables("HSatuan").Rows(0).Item("Nama"))
                    txtKonversi.EditValue = NullToDbl(ds.Tables("HSatuan").Rows(0).Item("Konversi"))
                    ckAktif.Checked = NullToBool(ds.Tables("HSatuan").Rows(0).Item("IsAktif"))
                End If
            End If
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml") Then
                LayoutControl1.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
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
        If CekKodeValid(txtKodeUser.Text, KodeLama, "HSatuan", "Kode", Not pStatusBaru) Then
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
                    NoID = GetNewID("HSatuan")
                    SQL = "INSERT INTO [HSatuan] ([NoID],[Kode],[Nama],[Konversi],[IsAktif]) VALUES (" & vbCrLf & _
                          NoID & ", '" & FixApostropi(txtKodeUser.Text) & "', '" & FixApostropi(txtNamaUser.Text) & "', " & FixKoma(txtKonversi.EditValue) & ", " & IIf(ckAktif.Checked, 1, 0) & ")"
                Else
                    SQL = "UPDATE [HSatuan] SET " & vbCrLf & _
                          " [Kode] = '" & FixApostropi(txtKodeUser.Text) & "'" & vbCrLf & _
                          " ,[Nama] = '" & FixApostropi(txtNamaUser.Text) & "'" & vbCrLf & _
                          " ,[Konversi] = " & FixKoma(txtKonversi.Text) & vbCrLf & _
                          " ,[IsAktif] = " & IIf(ckAktif.Checked, 1, 0) & vbCrLf & _
                          " WHERE NoID=" & NoID
                End If
                If EksekusiSQL(SQL) >= 1 Then
                    DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class