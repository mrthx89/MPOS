Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmSettingPoin
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
            SQL = "SELECT * FROM HSettingPoin WHERE NoID= 1"
            EksekusiDataset(ds, "HSettingPoin", SQL)
            If ds.Tables("HSettingPoin").Rows.Count >= 1 Then
                txtMinimumBelanja.EditValue = NullToDbl(ds.Tables("HSettingPoin").Rows(0).Item("MinimumBelanjaDapatPoin"))
                txtSyaratBelanja.EditValue = NullToDbl(ds.Tables("HSettingPoin").Rows(0).Item("SyaratBelanjaDapatPoin"))
                txtNilaiPoin.EditValue = NullToDbl(ds.Tables("HSettingPoin").Rows(0).Item("NilaiPoin"))
                ckKelipatan.Checked = NullToBool(ds.Tables("HSettingPoin").Rows(0).Item("IsKelipatan"))
                ckCustomer.Checked = NullToBool(ds.Tables("HSettingPoin").Rows(0).Item("IsCustomer"))
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

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            SQL = "DELETE FROM HSettingPoin"
            EksekusiSQL(SQL)

            SQL = "INSERT INTO [HSettingPoin] ([NoID],[MinimumBelanjaDapatPoin],[SyaratBelanjaDapatPoin],[IsKelipatan],[NilaiPoin],[IsCustomer]) VALUES (" & vbCrLf & _
              "1, " & FixKoma(txtMinimumBelanja.EditValue) & ", " & FixKoma(txtSyaratBelanja.EditValue) & ", " & IIf(ckKelipatan.Checked, 1, 0) & ", " & FixKoma(txtNilaiPoin.EditValue) & ", " & IIf(ckCustomer.Checked, 1, 0) & ")"
            If EksekusiSQL(SQL) >= 1 Then
                DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class