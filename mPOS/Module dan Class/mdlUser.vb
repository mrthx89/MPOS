Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.SQLServer.Connect

Module mdlUser
    Public NamaUserAktif As String = "YH"
    Public KodeUserAktif As String = "YH"
    Public IDUserAktif As Long = -1
    Public IsLogin As Boolean = False
    Public IsSupervisor As Boolean = False

    Public Function IsValidasiLogin(ByVal Kode As String, ByVal Pwd As String) As Boolean
        Dim Hasil As Boolean = False
        Dim ds As New DataSet, SQL As String = ""
        Try
            SQL = "SELECT MUser.* FROM HUser MUser WHERE UPPER(KODE)=UPPER('" & FixApostropi(Kode.ToUpper) & "') AND Password='" & FixApostropi(Pwd) & "' AND MUser.IsAktif=1"
            If EksekusiDataset(ds, "MUser", SQL) Then
                IDUserAktif = NullToLong(ds.Tables("MUser").Rows(0).Item("NoID"))
                NamaUserAktif = NullToStr(ds.Tables("MUser").Rows(0).Item("Nama"))
                KodeUserAktif = NullToStr(ds.Tables("MUser").Rows(0).Item("Kode"))
                IsSupervisor = NullToBool(ds.Tables("MUser").Rows(0).Item("IsSupervisor"))
                Hasil = True
            Else
                IDUserAktif = -1
                NamaUserAktif = ""
                KodeUserAktif = ""
                IsSupervisor = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ds.Dispose()
        End Try
        Return Hasil
    End Function
End Module
