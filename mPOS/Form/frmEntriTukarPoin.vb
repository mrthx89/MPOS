Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmEntriTukarPoin
    Public NoID As Long
    Dim KodeLama As String = ""
    Dim pStatusBaru As Boolean = False
    Dim SQL As String = ""

    Private Sub RefreshDataKontak()
        Dim ds As New DataSet
        Try
            SQL = "SELECT NoID, Kode, Nama FROM HKontak WHERE IsAktif=1 AND IsCustomer=1"
            EksekusiDataset(ds, "Data", SQL)
            txtIDCustomer.Properties.DataSource = ds.Tables("Data")
            txtIDCustomer.Properties.DisplayMember = "Nama"
            txtIDCustomer.Properties.ValueMember = "NoID"
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmEntriUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
    End Sub
    Private Sub HitungPoin()
        Try
            txtSisaPoin.EditValue = txtSaldoPoin.EditValue - txtPoinYgDitukar.EditValue
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmEntriUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet
        Dim SQL As String = "", NoUrut As Long = -1
        Try
            RefreshDataKontak()
            If pStatusBaru Then
                SQL = "SELECT CONVERT(INT, MAX(SUBSTRING(HTukarPoin.Kode,3,5))) FROM HTukarPoin"
                NoUrut = NullToLong(EksekusiScalar(SQL)) + 1
                txtKode.Text = "TP" & NoUrut.ToString("00000")
                txtIDCustomer.EditValue = -1
            Else
                SQL = "SELECT * FROM HTukarPoin WHERE NoID= " & NoID
                EksekusiDataset(ds, "HTukarPoin", SQL)
                If ds.Tables("HTukarPoin").Rows.Count >= 1 Then
                    txtKode.Text = NullToStr(ds.Tables("HTukarPoin").Rows(0).Item("Kode"))
                    KodeLama = txtKode.Text
                    txtTanggal.DateTime = NullToDate(ds.Tables("HTukarPoin").Rows(0).Item("Tanggal"))
                    txtIDCustomer.EditValue = NullToLong(ds.Tables("HTukarPoin").Rows(0).Item("IDCustomer"))
                    txtSaldoPoin.EditValue = NullToDbl(ds.Tables("HTukarPoin").Rows(0).Item("SaldoPoin"))
                    txtPoinYgDitukar.EditValue = NullToDbl(ds.Tables("HTukarPoin").Rows(0).Item("TukarPoin"))
                    txtSisaPoin.EditValue = txtSaldoPoin.EditValue - txtPoinYgDitukar.EditValue
                    txtKeterangan.Text = NullToStr(ds.Tables("HTukarPoin").Rows(0).Item("Keterangan"))
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
        If txtIDCustomer.Text = "" Then
            XtraMessageBox.Show("Customer masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtIDCustomer.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtKode.Text = "" Then
            XtraMessageBox.Show("Kode masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKode.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtKeterangan.Text = "" Then
            XtraMessageBox.Show("Keterangan masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKeterangan.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtSaldoPoin.EditValue - txtPoinYgDitukar.EditValue < 0 Then
            XtraMessageBox.Show("Saldo Poin tidak mencukupi.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtSaldoPoin.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If CekKodeValid(txtKode.Text, KodeLama, "HTukarPoin", "Kode", Not pStatusBaru) Then
            XtraMessageBox.Show("Kode sudah dipakai.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKode.Focus()
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
                    NoID = GetNewID("HTukarPoin")
                    SQL = "INSERT INTO [HTukarPoin] ([NoID],[Kode],[Tanggal],[IDCustomer],[SaldoPoin],[TukarPoin],[Keteragan]) VALUES (" & vbCrLf & _
                          NoID & ", '" & FixApostropi(txtKode.Text) & "', '" & txtTanggal.DateTime.ToString("yyyy-MM-dd") & "', " & NullToLong(txtIDCustomer.EditValue) & ", " & FixKoma(txtSaldoPoin.EditValue) & ", " & FixKoma(txtPoinYgDitukar.EditValue) & ", '" & FixApostropi(txtKeterangan.Text) & "')"
                Else
                    SQL = "UPDATE [HTukarPoin]" & vbCrLf & _
                          " SET [Kode] = '" & FixApostropi(txtKode.Text) & "'" & vbCrLf & _
                          " ,[Tanggal] = '" & txtTanggal.DateTime.ToString("yyyy-MM-dd") & "'" & vbCrLf & _
                          " ,[IDCustomer] = " & NullToLong(txtIDCustomer.EditValue) & vbCrLf & _
                          " ,[SaldoPoin] = " & FixKoma(txtSaldoPoin.EditValue) & vbCrLf & _
                          " ,[TukarPoin] = " & FixKoma(txtPoinYgDitukar.EditValue) & vbCrLf & _
                          " ,[Keteragan] = '" & FixApostropi(txtKeterangan.Text) & "'" & vbCrLf & _
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

    Private Sub txtIDCustomer_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDCustomer.EditValueChanged
        Try
            SQL = "SELECT SUM(HKartuPoin.PoinMasuk-HKartuPoin.PoinKeluar) FROM HKartuPoin WHERE IDCustomer=" & NullToLong(txtIDCustomer.EditValue)
            txtSaldoPoin.EditValue = NullToDbl(EksekusiScalar(SQL))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSaldoPoin_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaldoPoin.EditValueChanged, txtPoinYgDitukar.EditValueChanged
        HitungPoin()
    End Sub
End Class