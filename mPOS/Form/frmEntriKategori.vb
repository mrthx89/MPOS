Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmEntriKategori
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
        'SearchLookUpEdit1View.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & SearchLookUpEdit1View.Name & ".xml")
    End Sub

    Private Sub frmEntriUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet
        Dim SQL As String = ""
        Try
            SQL = "SELECT NoID, Kode, Nama FROM HKategori WHERE IsAktif=1"
            EksekusiDataset(ds, "MKategori", SQL)
            txtIDKategori.Properties.DataSource = ds.Tables("MKategori")
            txtIDKategori.Properties.ValueMember = "NoID"
            txtIDKategori.Properties.DisplayMember = "Nama"

            If pStatusBaru Then
                ckAktif.Checked = True
            Else
                SQL = "SELECT * FROM HKategori WHERE NoID= " & NoID
                EksekusiDataset(ds, "HKategori", SQL)
                If ds.Tables("HKategori").Rows.Count >= 1 Then
                    txtKodeUser.Text = NullToStr(ds.Tables("HKategori").Rows(0).Item("Kode"))
                    KodeLama = txtKodeUser.Text
                    txtNamaUser.Text = NullToStr(ds.Tables("HKategori").Rows(0).Item("Nama"))
                    txtKeterangan.Text = NullToStr(ds.Tables("HKategori").Rows(0).Item("Keterangan"))
                    ckAktif.Checked = NullToBool(ds.Tables("HKategori").Rows(0).Item("IsAktif"))
                    txtIDKategori.EditValue = NullToLong(ds.Tables("HKategori").Rows(0).Item("IDKategori"))
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
        If CekKodeValid(txtKodeUser.Text, KodeLama, "HKategori", "Kode", Not pStatusBaru) Then
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
                    NoID = GetNewID("HKategori")
                    SQL = "INSERT INTO [HKategori] ([NoID],[Kode],[Nama],[Keterangan],[IsAktif],[IDKategori]) VALUES (" & vbCrLf & _
                          NoID & ", '" & FixApostropi(txtKodeUser.Text) & "', '" & FixApostropi(txtNamaUser.Text) & "', '" & FixApostropi(txtKeterangan.Text) & "', " & IIf(ckAktif.Checked, 1, 0) & "," & NullToLong(txtIDKategori.EditValue) & ")"
                Else
                    SQL = "UPDATE [HKategori] SET " & vbCrLf & _
                          " [Kode] = '" & FixApostropi(txtKodeUser.Text) & "'" & vbCrLf & _
                          " ,[Nama] = '" & FixApostropi(txtNamaUser.Text) & "'" & vbCrLf & _
                          " ,[Keterangan] = '" & FixApostropi(txtKeterangan.Text) & "'" & vbCrLf & _
                          " ,[IsAktif] = " & IIf(ckAktif.Checked, 1, 0) & vbCrLf & _
                          " ,[IDKategori] = " & NullToLong(txtIDKategori.EditValue) & vbCrLf & _
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