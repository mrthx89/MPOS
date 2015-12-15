Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.Fungsi.Ini

Public Class Connect
    Public Shared NamaServerMSSQL As String = "(local)\SQLEXPRESS"
    Public Shared NamaDatabaseMSSQL As String = "DBMPOS"
    Public Shared NamaUIDMSSQL As String = "sa"
    Public Shared NamaPasswordMSSQL As String = "elliteserv"
    Public Shared NamaTimeOutMSSQL As String = 15
    Public Shared NamaODBCMSSQL As String = "DBMPOS"
    Public Shared KoneksiString As String = "Server=" & NamaServerMSSQL & ";initial Catalog=" & NamaDatabaseMSSQL & ";User ID=" & NamaUIDMSSQL & ";Password=" & NamaPasswordMSSQL & ";TimeOut=" & NamaTimeOutMSSQL
    Private Shared NamaAplikasi As String = "mPOS - System"

    Public Shared Function EksekusiSQL(ByVal Query As String, Optional ByVal StrKon As String = "") As Long
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
            MsgBox("Info Kesalahan : " & ex.Message & vbCrLf & "SQL : " & Query, MsgBoxStyle.Exclamation, NamaAplikasi)
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
    Public Shared Function EksekusiSQL(ByRef cn As SqlConnection, ByRef com As SqlCommand, ByVal Query As String) As Long
        Dim Hasil As Long = -1
        Try
            com.CommandText = Query
            Hasil = NullToLong(com.ExecuteNonQuery)
        Catch ex As Exception
            MsgBox("Info Kesalahan : " & ex.Message & vbCrLf & "SQL : " & Query, MsgBoxStyle.Exclamation, NamaAplikasi)
        End Try
        Return Hasil
    End Function
    Public Shared Function EksekusiScalar(ByVal Query As String, Optional ByVal StrKon As String = "") As Object
        Dim Hasil As Object = -1
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
            Hasil = com.ExecuteScalar
        Catch ex As Exception
            MsgBox("Info Kesalahan : " & ex.Message & vbCrLf & "SQL : " & Query, MsgBoxStyle.Exclamation, NamaAplikasi)
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
    Public Shared Function EksekusiScalar(ByRef cn As SqlConnection, ByRef com As SqlCommand, ByVal Query As String) As Object
        Dim Hasil As Object = -1
        Try
            com.CommandText = Query
            Hasil = com.ExecuteScalar
        Catch ex As Exception
            MsgBox("Info Kesalahan : " & ex.Message & vbCrLf & "SQL : " & Query, MsgBoxStyle.Exclamation, NamaAplikasi)
        End Try
        Return Hasil
    End Function
    Public Shared Function EksekusiDataset(ByRef Ds As DataSet, ByVal NamaTabel As String, ByVal Query As String, Optional ByVal StrKon As String = "") As Boolean
        Dim Hasil As Boolean = False
        Dim cn As New SqlConnection
        Dim com As New SqlCommand
        Dim oDA As New SqlDataAdapter
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
            oDA.SelectCommand = com
            If Ds Is Nothing Then
                Ds = New DataSet
            End If
            If Not Ds.Tables(NamaTabel) Is Nothing Then
                Ds.Tables.Clear()
            End If
            oDA.Fill(Ds, NamaTabel)
            If Ds.Tables(NamaTabel).Rows.Count >= 1 Then
                Hasil = True
            End If
        Catch ex As Exception
            MsgBox("Info Kesalahan : " & ex.Message & vbCrLf & "SQL : " & Query, MsgBoxStyle.Exclamation, NamaAplikasi)
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
            oDA.Dispose()
        End Try
        Return Hasil
    End Function
    Public Shared Function EksekusiDataset(ByRef cn As SqlConnection, ByRef com As SqlCommand, ByRef Ds As DataSet, ByVal NamaTabel As String, ByVal Query As String) As Boolean
        Dim Hasil As Boolean = False
        Dim oDA As New SqlDataAdapter
        Try
            com.CommandText = Query
            oDA.SelectCommand = com
            If Ds Is Nothing Then
                Ds = New DataSet
            End If
            If Not Ds.Tables(NamaTabel) Is Nothing Then
                Ds.Tables.Clear()
            End If
            oDA.Fill(Ds, NamaTabel)
            Hasil = True
        Catch ex As Exception
            MsgBox("Info Kesalahan : " & ex.Message & vbCrLf & "SQL : " & Query, MsgBoxStyle.Exclamation, NamaAplikasi)
        Finally
            oDA.Dispose()
        End Try
        Return Hasil
    End Function
    Public Shared Function EksekusiDataReader(ByRef oDR As SqlClient.SqlDataReader, ByVal Query As String, Optional ByVal StrKon As String = "") As Boolean
        Dim Hasil As Boolean = False
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
            oDR = com.ExecuteReader
            Hasil = True
        Catch ex As Exception
            MsgBox("Info Kesalahan : " & ex.Message & vbCrLf & "SQL : " & Query, MsgBoxStyle.Exclamation, NamaAplikasi)
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
    Public Shared Function EksekusiDataReader(ByRef cn As SqlConnection, ByRef com As SqlCommand, ByRef oDR As SqlClient.SqlDataReader, ByVal Query As String) As Boolean
        Dim Hasil As Boolean = False
        Try
            com.CommandText = Query
            oDR = com.ExecuteReader
            Hasil = True
        Catch ex As Exception
            MsgBox("Info Kesalahan : " & ex.Message & vbCrLf & "SQL : " & Query, MsgBoxStyle.Exclamation, NamaAplikasi)
        End Try
        Return Hasil
    End Function
End Class
