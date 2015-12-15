Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmEntriBeliD
    Public NoID As Long

    Dim pStatusBaru As Boolean = False
    Dim SQL As String = ""
    Dim IDHeader As Long = -1

    Private Sub RefreshDataKontak()
        Dim ds As New DataSet
        Try
            SQL = "SELECT HBarang.NoID, HBarang.Kode, HBarang.Nama, HSatuan.Kode AS Satuan, HBarang.HargaBeli FROM HBarang LEFT JOIN HSatuan ON HSatuan.NOID=HBarang.IDSatuanBeli WHERE HBarang.IsAktif=1 "
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
                SQL = "SELECT * FROM HBeliD WHERE NoID= " & NoID
                EksekusiDataset(ds, "HBeliD", SQL)
                If ds.Tables("HBeliD").Rows.Count >= 1 Then
                    txtIDBarang.EditValue = NullToLong(ds.Tables("HBeliD").Rows(0).Item("IDBarang"))
                    txtSatuan.EditValue = NullToLong(ds.Tables("HBeliD").Rows(0).Item("IDSatuan"))
                    txtKonversi.EditValue = NullToDbl(ds.Tables("HBeliD").Rows(0).Item("Konversi"))
                    txtQty.EditValue = NullToDbl(ds.Tables("HBeliD").Rows(0).Item("Qty"))
                    txtHarga.EditValue = NullToDbl(ds.Tables("HBeliD").Rows(0).Item("Harga"))
                    txtDiscProsen1.EditValue = NullToDbl(ds.Tables("HBeliD").Rows(0).Item("DiscProsen1"))
                    txtDiscProsen2.EditValue = NullToDbl(ds.Tables("HBeliD").Rows(0).Item("DiscProsen2"))
                    txtDiscRp.EditValue = NullToDbl(ds.Tables("HBeliD").Rows(0).Item("DiscRp"))
                    txtJumlah.EditValue = NullToDbl(ds.Tables("HBeliD").Rows(0).Item("Jumlah"))
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
        If txtQty.EditValue <= 0 Then
            XtraMessageBox.Show("Qty masih kurang atau sama dengan 0.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtQty.Focus()
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
        If txtHarga.EditValue <= 0 Then
            If XtraMessageBox.Show("Harga masih kurang atau sama dengan 0." & vbCrLf & "Ingin melanjutkan penyimpanan?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                txtQty.Focus()
                Hasil = False
                IsValidasi = False
                Exit Function
            End If
        End If
        Return Hasil
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            If IsValidasi() Then
                If pStatusBaru Then
                    NoID = GetNewID("HBeliD")
                    SQL = "INSERT INTO [HBeliD] ([NoID],[IDHeader],[IDBarang],[IDSatuan],[Konversi],[Qty],[Harga],[DiscProsen1],[DiscProsen2],[DiscRp],[Jumlah]) VALUES (" & vbCrLf & _
                          NoID & ", " & IDHeader & ", " & NullToLong(txtIDBarang.EditValue) & ", " & NullToLong(txtSatuan.EditValue) & ", " & FixKoma(txtKonversi.EditValue) & ", " & FixKoma(txtQty.EditValue) & ", " & vbCrLf & _
                          FixKoma(txtHarga.EditValue) & ", " & FixKoma(txtDiscProsen1.EditValue) & ", " & FixKoma(txtDiscProsen2.EditValue) & ", " & FixKoma(txtDiscRp.EditValue) & ", " & FixKoma(txtJumlah.EditValue) & ")"
                Else
                    SQL = "UPDATE [HBeliD] SET " & vbCrLf & _
                          "[IDBarang]=" & NullToLong(txtIDBarang.EditValue) & ", [IDSatuan]=" & NullToLong(txtSatuan.EditValue) & ", [Konversi]=" & FixKoma(txtKonversi.EditValue) & ", [Qty]=" & FixKoma(txtQty.EditValue) & ", " & vbCrLf & _
                          "[Harga]=" & FixKoma(txtHarga.EditValue) & ", [DiscProsen1]=" & FixKoma(txtDiscProsen1.EditValue) & ", [DiscProsen2]=" & FixKoma(txtDiscProsen2.EditValue) & ", [DiscRp]=" & FixKoma(txtDiscRp.EditValue) & ", [Jumlah]=" & FixKoma(txtJumlah.EditValue) & vbCrLf & _
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
                txtSatuan.EditValue = NullToLong(ds.Tables("Data").Rows(0).Item("IDSatuanBeli"))
                txtKonversi.EditValue = NullToDbl(ds.Tables("Data").Rows(0).Item("KonversiBeli"))
                txtHarga.EditValue = NullToDbl(ds.Tables("Data").Rows(0).Item("HargaBeli"))
            Else
                txtNamaBarang.Text = ""
                txtSatuan.EditValue = -1
                txtKonversi.EditValue = 1
                txtHarga.EditValue = 0
            End If
        Catch ex As Exception
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub txtQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.EditValueChanged, txtDiscProsen1.EditValueChanged, txtDiscProsen2.EditValueChanged, txtDiscRp.EditValueChanged, txtHarga.EditValueChanged, txtJumlah.EditValueChanged
        HitungTotal()
    End Sub

    Private Sub HitungTotal()
        Dim Harga As Double = 0
        Try
            Harga = Bulatkan(txtHarga.EditValue * (1 - txtDiscProsen1.EditValue / 100) * (1 - txtDiscProsen2.EditValue / 100), 0) - txtDiscRp.EditValue
            txtJumlah.EditValue = Harga * txtQty.EditValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSatuan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSatuan.EditValueChanged
        Dim ds As New DataSet
        Try
            SQL = "SELECT * FROM HBarang WHERE NoID=" & NullToLong(txtIDBarang.EditValue) & " AND IDSatuanBeli=" & NullToLong(txtSatuan.EditValue)
            EksekusiDataset(ds, "Data", SQL)
            If ds.Tables("Data").Rows.Count >= 1 Then
                txtKonversi.EditValue = NullToDbl(ds.Tables("Data").Rows(0).Item("KonversiBeli"))
            Else
                txtKonversi.EditValue = 1
            End If
        Catch ex As Exception
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub txtKonversi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscProsen1.GotFocus, txtDiscProsen2.GotFocus, txtDiscRp.GotFocus, txtHarga.GotFocus, txtJumlah.GotFocus, txtKonversi.GotFocus, txtQty.GotFocus
        Try
            TryCast(sender, TextEdit).SelectAll()
        Catch ex As Exception
            'XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtDiscProsen1_MouseClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscProsen1.Click, txtDiscProsen2.Click, txtDiscRp.Click, txtHarga.Click, txtJumlah.Click, txtKonversi.Click, txtQty.Click
        Try
            TryCast(sender, TextEdit).SelectAll()
        Catch ex As Exception
            'XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
End Class