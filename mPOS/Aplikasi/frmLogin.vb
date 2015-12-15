Imports DevExpress.XtraEditors
Imports System.Data
Imports System.Data.SqlClient
Imports Elliteserv.Fungsi.Utils

Public Class frmLogin

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If IsValidasiLogin(TextEdit1.Text.ToUpper, EncryptText(TextEdit2.Text.ToUpper, "Elliteserv")) Then
            XtraMessageBox.Show("Selamat Datang di " & NamaAplikasi & " " & NamaUserAktif & vbCrLf & "Selamat bertugas. Gudanakan Aplikasi dengan baik dan benar.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            IsLogin = True
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            XtraMessageBox.Show("User ID atau Password Salah.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub cmdDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDB.Click
        Dim x As New frmSettingDatabase
        If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Login Please - " & NamaPerusahaan.ToUpper
    End Sub
End Class