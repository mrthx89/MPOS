Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmEntriPenyesuaianD
    Public NoID As Long

    Dim pStatusBaru As Boolean = False
    Dim SQL As String = ""
    Dim IDHeader As Long = -1
    Dim HPP As Double = 0

    Private Sub RefreshDataKontak()
        Dim ds As New DataSet
        Try
            SQL = "SELECT HBarang.NoID, HBarang.Kode, HBarang.Nama, HSatuan.Kode AS Satuan, HBarang.HPP FROM HBarang LEFT JOIN HSatuan ON HSatuan.NOID=HBarang.IDSatuanJual WHERE HBarang.IsAktif=1 "
            EksekusiDataset(ds, "Data", SQL)
            txtIDBarang.Properties.DataSource = ds.Tables("Data")
            txtIDBarang.Properties.DisplayMember = "Kode"
            txtIDBarang.Properties.ValueMember = "NoID"

            SQL = "SELECT NoID, Kode, Nama FROM HSatuan WHERE IsAktif=1 "
            EksekusiDataset(ds, "Data", SQL)
            txtSatuan.Properties.DataSource = ds.Tables("Data")
            txtSatuan.Properties.DisplayMember = "Kode"
            txtSatuan.Properties.ValueMember = "NoID"

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
    Private Sub frmEntriUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet
        Dim SQL As String = "", NoUrut As Long = -1
        Try
            RefreshDataKontak()
            If pStatusBaru Then
                txtIDBarang.EditValue = -1
            Else
                SQL = "SELECT * FROM HPenyesuaianD WHERE NoID= " & NoID
                EksekusiDataset(ds, "HPenyesuaianD", SQL)
                If ds.Tables("HPenyesuaianD").Rows.Count >= 1 Then
                    txtIDBarang.EditValue = NullToLong(ds.Tables("HPenyesuaianD").Rows(0).Item("IDBarang"))
                    txtSatuan.EditValue = NullToLong(ds.Tables("HPenyesuaianD").Rows(0).Item("IDSatuan"))
                    txtKonversi.EditValue = NullToDbl(ds.Tables("HPenyesuaianD").Rows(0).Item("Konversi"))
                    txtQty.EditValue = NullToDbl(ds.Tables("HPenyesuaianD").Rows(0).Item("Qty"))
                    txtHarga.EditValue = NullToDbl(ds.Tables("HPenyesuaianD").Rows(0).Item("HargaPokok"))
                    txtJumlah.EditValue = NullToDbl(ds.Tables("HPenyesuaianD").Rows(0).Item("Jumlah"))
                    txtKeterangan.Text = NullToStr(ds.Tables("HPenyesuaianD").Rows(0).Item("Keterangan"))
                End If
            End If
            HitungTotal()
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

    Public Sub New(ByVal IsNew As Boolean, ByVal IDParent As Long)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        pStatusBaru = IsNew
        IDHeader = IDParent
    End Sub

    Private Function IsValidasi() As Boolean
        Dim Hasil As Boolean = True
        If txtIDBarang.Text = "" Then
            XtraMessageBox.Show("Barang masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtIDBarang.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtSatuan.Text = "" Then
            XtraMessageBox.Show("Satuan masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtSatuan.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtKonversi.EditValue <= 0 Then
            XtraMessageBox.Show("Konversi masih kurang atau sama dengan 0.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtQty.Focus()
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
                    NoID = GetNewID("HPenyesuaianD")
                    SQL = "INSERT INTO [HPenyesuaianD] ([NoID],[IDHeader],[IDBarang],[IDSatuan],[Konversi],[Qty],[HargaPokok],[Jumlah],[Keterangan]) VALUES (" & vbCrLf & _
                          NoID & ", " & IDHeader & ", " & NullToLong(txtIDBarang.EditValue) & ", " & NullToLong(txtSatuan.EditValue) & ", " & FixKoma(txtKonversi.EditValue) & ", " & FixKoma(txtQty.EditValue) & ", " & vbCrLf & _
                          FixKoma(txtHarga.EditValue) & ", " & FixKoma(txtJumlah.EditValue) & ", '" & FixApostropi(txtKeterangan.Text) & "')"
                Else
                    SQL = "UPDATE [HPenyesuaianD] SET " & vbCrLf & _
                          "[IDBarang]=" & NullToLong(txtIDBarang.EditValue) & ", [IDSatuan]=" & NullToLong(txtSatuan.EditValue) & ", [Konversi]=" & FixKoma(txtKonversi.EditValue) & ", [Qty]=" & FixKoma(txtQty.EditValue) & ", " & vbCrLf & _
                          "[HargaPokok]=" & FixKoma(txtHarga.EditValue) & ", [Jumlah]=" & FixKoma(txtJumlah.EditValue) & ", [Keterangan]='" & FixApostropi(txtKeterangan.Text) & "' " & vbCrLf & _
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

    Private Sub txtIDCustomer_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDBarang.EditValueChanged
        Dim ds As New DataSet
        Try
            SQL = "SELECT * FROM HBarang WHERE NoID=" & NullToLong(txtIDBarang.EditValue)
            EksekusiDataset(ds, "Data", SQL)
            If ds.Tables("Data").Rows.Count >= 1 Then
                txtNamaBarang.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Nama"))
                txtSatuan.EditValue = NullToLong(ds.Tables("Data").Rows(0).Item("IDSatuanJual"))
                txtKonversi.EditValue = NullToDbl(ds.Tables("Data").Rows(0).Item("KonversiJual"))
                txtHarga.EditValue = NullToDbl(ds.Tables("Data").Rows(0).Item("HPP")) * txtKonversi.EditValue
                HPP = NullToDbl(ds.Tables("Data").Rows(0).Item("HPP"))
            Else
                txtNamaBarang.Text = ""
                txtSatuan.EditValue = -1
                txtKonversi.EditValue = 1
                txtHarga.EditValue = 0
                HPP = 0
            End If
        Catch ex As Exception
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub txtQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.EditValueChanged, txtHarga.EditValueChanged, txtJumlah.EditValueChanged
        HitungTotal()
    End Sub

    Private Sub HitungTotal()
        Dim Harga As Double = 0
        Try
            Harga = txtHarga.EditValue
            txtJumlah.EditValue = Harga * txtQty.EditValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSatuan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSatuan.EditValueChanged
        Dim ds As New DataSet
        Try
            SQL = "SELECT * FROM HBarang WHERE NoID=" & NullToLong(txtIDBarang.EditValue) & " AND IDSatuanJual=" & NullToLong(txtSatuan.EditValue)
            EksekusiDataset(ds, "Data", SQL)
            If ds.Tables("Data").Rows.Count >= 1 Then
                txtKonversi.EditValue = NullToDbl(ds.Tables("Data").Rows(0).Item("KonversiJual"))
            Else
                txtKonversi.EditValue = 1
            End If
        Catch ex As Exception
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub txtKonversi_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKonversi.EditValueChanged
        txtHarga.EditValue = HPP * txtKonversi.EditValue
        HitungTotal()
    End Sub

    Private Sub txtKonversi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHarga.GotFocus, txtJumlah.GotFocus, txtKonversi.GotFocus, txtQty.GotFocus
        Try
            TryCast(sender, TextEdit).SelectAll()
        Catch ex As Exception
            'XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtDiscProsen1_MouseClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHarga.Click, txtJumlah.Click, txtKonversi.Click, txtQty.Click
        Try
            TryCast(sender, TextEdit).SelectAll()
        Catch ex As Exception
            'XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
End Class