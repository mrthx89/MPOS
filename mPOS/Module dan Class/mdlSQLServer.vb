Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Module mdlSQLServer
    Public KoneksiString As String = "Server=" & "(local)" & ";initial Catalog=" & "DBMPOS" & ";User ID=" & "sa" & ";Password=" & "elliteserv"

    Public Function EksekusiSQL(ByVal Query As String, Optional ByVal StrKon As String = "") As Long
        Dim Hasil As Long = -1
        Dim cn As New SqlConnection
        Dim com As New SqlCommand
        Dim Tran As SqlTransaction = Nothing
        Try
            If StrKon <> "" Then
                cn.ConnectionString = StrKon
            Else
                cn.ConnectionString = KoneksiString
            End If
            cn.Open()
            Tran = cn.BeginTransaction("Data")
            com.Connection = cn
            com.Transaction = Tran
            com.CommandText = Query
            Hasil = NullToLong(com.ExecuteNonQuery)
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message & vbCrLf & "SQL : " & Query, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Not Tran Is Nothing Then
                Tran.Rollback()
                Tran = Nothing
            End If
        Finally
            If Not Tran Is Nothing Then
                Tran.Commit()
                Tran = Nothing
            End If
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
            com.Dispose()
        End Try
        Return Hasil
    End Function
End Module
