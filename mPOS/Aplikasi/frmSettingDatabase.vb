Imports System.IO.File
Imports Elliteserv.SQLServer.Connect
Imports Elliteserv.SQLServer
Imports Elliteserv.Fungsi.Ini
Imports Elliteserv.Fungsi.Utils
Imports DevExpress.XtraEditors
Imports Elliteserv.Fungsi.ODBC
Public Class frmSettingDatabase

    Private Sub frmSettingDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtServer.Text = NamaServerMSSQL
        txtUserID.Text = NamaUIDMSSQL
        txtPwd.Text = NamaPasswordMSSQL
        txtTimeOut.EditValue = NullToLong(NamaTimeOutMSSQL)
        GetListFromDBS()
        txtDatabase.Text = NamaDatabaseMSSQL
        txtODBC.Text = NamaODBCMSSQL
    End Sub

    Private Sub txtODBC_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtODBC.ButtonClick
        If e.Button.Index = 0 Then
            RunODBC()
        Else
            CekKoneksiODBC()
        End If
    End Sub

    Sub RunODBC()
        Shell("odbcad32.exe", AppWinStyle.NormalFocus, True)
    End Sub

    Private Function CekKoneksiODBC() As Boolean
        Dim cn As New Odbc.OdbcConnection
        Dim Hasil As Boolean = False
        Try
            cn.ConnectionString = "Dsn=" & txtODBC.Text & ";uid=" & txtUserID.Text & ";pwd=" & txtPwd.Text
            cn.Open()
            Hasil = True
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
        End Try
        Return Hasil
    End Function
    Private Function CekKoneksiSQLServer(ByVal NamaDatabase As String) As Boolean
        Dim cn As New SqlClient.SqlConnection
        Dim Hasil As Boolean = False
        Try
            cn.ConnectionString = "Data Source=" & txtServer.Text & _
                                  ";Initial Catalog=" & NamaDatabase & _
                                  ";User ID=" & txtUserID.Text & _
                                  ";Password=" & txtPwd.Text & _
                                  ";Connect Timeout=" & NullToLong(txtTimeOut.EditValue)
            cn.Open()
            Hasil = True
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
        End Try
        Return Hasil
    End Function

    Private Sub txtDatabase_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDatabase.ButtonClick
        If e.Button.Index = 0 Then
            'RunODBC()
        Else
            GetListFromDBS()
        End If
    End Sub

    Private Sub GetListFromDBS()
        Dim cn As New SqlClient.SqlConnection
        Dim com As New SqlClient.SqlCommand
        Dim oDR As SqlClient.SqlDataReader = Nothing
        Try
            CekKoneksiSQLServer("master")
            cn.ConnectionString = "Data Source=" & txtServer.Text & _
                                  ";Initial Catalog=master" & _
                                  ";User ID=" & txtUserID.Text & _
                                  ";Password=" & txtPwd.Text & _
                                  ";Connect Timeout=" & NullToLong(txtTimeOut.EditValue)
            cn.Open()
            com.Connection = cn
            com.CommandText = "SELECT d.[name] as Nama FROM sys.databases d" & vbCrLf & _
                              " WHERE d.database_id>4 ORDER BY d.[name]"
            oDR = com.ExecuteReader
            txtDatabase.Properties.Items.Clear()
            Do While oDR.Read
                txtDatabase.Properties.Items.Add(NullToStr(oDR.Item("Nama")))
            Loop
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
            com.Dispose()
            If Not oDR Is Nothing Then
                oDR.Close()
            End If
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function IsValidasi()
        'Dim Hasil As Boolean = False
        If Not CekKoneksiSQLServer(txtDatabase.Text) Then
            Return False
            Exit Function
        End If
        If Not CekKoneksiODBC() Then
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If IsValidasi() Then
            NamaServerMSSQL = txtServer.Text
            NamaDatabaseMSSQL = txtDatabase.Text
            NamaUIDMSSQL = txtUserID.Text
            NamaPasswordMSSQL = txtPwd.Text
            NamaTimeOutMSSQL = NullToLong(txtTimeOut.EditValue)
            NamaODBCMSSQL = txtODBC.Text
            TulisIni("DBConfig", "Server", txtServer.Text)
            TulisIni("DBConfig", "Database", txtDatabase.Text)
            TulisIni("DBConfig", "UserID", txtUserID.Text)
            TulisIni("DBConfig", "Password", EncryptText(txtPwd.Text, "Elliteserv"))
            TulisIni("DBConfig", "TimeOut", NullToLong(txtTimeOut.EditValue))
            CreateSystemDSN(txtODBC.Text, txtServer.Text, txtUserID.Text, txtPwd.Text, txtDatabase.Text, NamaAplikasi)
            KoneksiString = "Server=" & NamaServerMSSQL & ";initial Catalog=" & NamaDatabaseMSSQL & ";User ID=" & NamaUIDMSSQL & ";Password=" & NamaPasswordMSSQL & ";TimeOut=" & NamaTimeOutMSSQL
            XtraMessageBox.Show("Koneksi terhubung.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class