Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmEntriKontak
    Public NoID As Long
    Dim KodeLama As String = ""
    Dim pStatusBaru As Boolean = False
    Dim SQL As String = ""

    Private Sub RefreshDataKontak()
        Dim ds As New DataSet
        Try
            SQL = "SELECT NoID, Kode, Nama FROM HKontak WHERE IsAktif=1 AND IsPegawai=1"
            EksekusiDataset(ds, "Data", SQL)
            txtIDSalesman.Properties.DataSource = ds.Tables("Data")
            txtIDSalesman.Properties.ValueMember = "NoID"
            txtIDSalesman.Properties.DisplayMember = "Nama"
        Catch ex As Exception

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
        Dim SQL As String = ""
        Try
            RefreshDataKontak()
            If pStatusBaru Then
                ckAktif.Checked = True
            Else
                SQL = "SELECT * FROM HKontak WHERE NoID= " & NoID
                EksekusiDataset(ds, "HKontak", SQL)
                If ds.Tables("HKontak").Rows.Count >= 1 Then
                    txtKode.Text = NullToStr(ds.Tables("HKontak").Rows(0).Item("Kode"))
                    KodeLama = txtKode.Text
                    txtNama.Text = NullToStr(ds.Tables("HKontak").Rows(0).Item("Nama"))
                    txtAlamat.Text = NullToStr(ds.Tables("HKontak").Rows(0).Item("Alamat"))
                    txtKota.Text = NullToStr(ds.Tables("HKontak").Rows(0).Item("Kota"))
                    txtTelp.Text = NullToStr(ds.Tables("HKontak").Rows(0).Item("Telp"))
                    txtCell.Text = NullToStr(ds.Tables("HKontak").Rows(0).Item("HP"))
                    txtKeterangan.Text = NullToStr(ds.Tables("HKontak").Rows(0).Item("Keterangan"))
                    txtKontakPerson.Text = NullToStr(ds.Tables("HKontak").Rows(0).Item("ContactPerson"))
                    txtJTCustomer.EditValue = NullToDbl(ds.Tables("HKontak").Rows(0).Item("JTCustomer"))
                    txtJTSupplier.EditValue = NullToDbl(ds.Tables("HKontak").Rows(0).Item("JTSupplier"))
                    txtLimitHutang.EditValue = NullToDbl(ds.Tables("HKontak").Rows(0).Item("LimitHutang"))
                    txtLimitPiutang.EditValue = NullToDbl(ds.Tables("HKontak").Rows(0).Item("LimitPiutang"))
                    txtIDSalesman.EditValue = NullToLong(ds.Tables("HKontak").Rows(0).Item("IDSalesman"))
                    ckAktif.Checked = NullToBool(ds.Tables("HKontak").Rows(0).Item("IsAktif"))
                    ckCustomer.Checked = NullToBool(ds.Tables("HKontak").Rows(0).Item("IsCustomer"))
                    ckSupplier.Checked = NullToBool(ds.Tables("HKontak").Rows(0).Item("IsSupplier"))
                    ckPegawai.Checked = NullToBool(ds.Tables("HKontak").Rows(0).Item("IsPegawai"))
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
        If txtKode.Text = "" Then
            XtraMessageBox.Show("Kode masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKode.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtNama.Text = "" Then
            XtraMessageBox.Show("Nama masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtNama.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If CekKodeValid(txtKode.Text, KodeLama, "HKontak", "Kode", Not pStatusBaru) Then
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
                    NoID = GetNewID("HKontak")
                    SQL = "INSERT INTO [HKontak] ([NoID],[Kode],[Nama],[Alamat],[Kota],[Telp],[HP],[ContactPerson],[Keterangan],[JTSupplier],[JTCustomer],[LimitHutang],[LimitPiutang],[IsAktif],[IsSupplier],[IsCustomer],[IsPegawai],[IDSalesman]) VALUES (" & vbCrLf & _
                          NoID & ", '" & FixApostropi(txtKode.Text) & "', '" & FixApostropi(txtNama.Text) & "', '" & FixApostropi(txtAlamat.Text) & "', '" & FixApostropi(txtKota.Text) & "', '" & FixApostropi(txtTelp.Text) & "', " & _
                          "'" & FixApostropi(txtCell.Text) & "', '" & FixApostropi(txtKontakPerson.Text) & "', '" & FixApostropi(txtKeterangan.Text) & "', " & FixKoma(txtJTSupplier.EditValue) & ", " & FixKoma(txtJTCustomer.EditValue) & ", " & _
                          FixKoma(txtLimitHutang.EditValue) & ", " & FixKoma(txtLimitPiutang.EditValue) & ", " & IIf(ckAktif.Checked, 1, 0) & ", " & IIf(ckSupplier.Checked, 1, 0) & ", " & IIf(ckCustomer.Checked, 1, 0) & ", " & IIf(ckPegawai.Checked, 1, 0) & ", " & NullToLong(txtIDSalesman.EditValue) & " )"
                Else
                    SQL = "UPDATE [HKontak] SET " & vbCrLf & _
                          " [Kode]='" & FixApostropi(txtKode.Text) & "', [Nama]='" & FixApostropi(txtNama.Text) & "', [Alamat]='" & FixApostropi(txtAlamat.Text) & "', [Kota]='" & FixApostropi(txtKota.Text) & "', [Telp]='" & FixApostropi(txtTelp.Text) & "', [IDSalesman]=" & NullToLong(txtIDSalesman.EditValue) & ", " & _
                          " [HP]='" & FixApostropi(txtCell.Text) & "', [ContactPerson]='" & FixApostropi(txtKontakPerson.Text) & "', [Keterangan]='" & FixApostropi(txtKeterangan.Text) & "', [JTSupplier]=" & FixKoma(txtJTSupplier.EditValue) & ", [JTCustomer]=" & FixKoma(txtJTCustomer.EditValue) & ", " & _
                          " [LimitHutang]=" & FixKoma(txtLimitHutang.EditValue) & ", [LimitPiutang]=" & FixKoma(txtLimitPiutang.EditValue) & ", [IsAktif]=" & IIf(ckAktif.Checked, 1, 0) & ", [IsSupplier]=" & IIf(ckSupplier.Checked, 1, 0) & ", [IsCustomer]=" & IIf(ckCustomer.Checked, 1, 0) & ", [IsPegawai]=" & IIf(ckPegawai.Checked, 1, 0) & _
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