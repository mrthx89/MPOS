Imports System.Data
Imports System.Data.SqlClient
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors

Module mdlUpdateSQL
    Public Sub BatchUpdateFromFile(ByRef cn As SqlConnection, ByRef com As SqlCommand)
        Dim PathSQL As String = Application.StartupPath & "\System\SQL\"
        Dim PathCurrentSQL As String = Application.StartupPath & "\System\CurrentSQL\"
        Dim FileSQL As System.IO.FileInfo() = Nothing
        Dim Reader As System.IO.StreamReader = Nothing
        Dim DirSQL As System.IO.DirectoryInfo
        Try
            If Not System.IO.Directory.Exists(PathSQL) Then
                System.IO.Directory.CreateDirectory(PathSQL)
            End If
            If Not System.IO.Directory.Exists(PathCurrentSQL) Then
                System.IO.Directory.CreateDirectory(PathCurrentSQL)
            End If
            DirSQL = New System.IO.DirectoryInfo(PathSQL)
            FileSQL = DirSQL.GetFiles
            For i As Integer = 0 To FileSQL.Length - 1
                If FileSQL(i).Extension.ToUpper = ".SQL".ToUpper Then
                    Reader = New System.IO.StreamReader(FileSQL(i).FullName)
                    com.CommandText = Reader.ReadToEnd
                    Reader.Close()
                    Reader.Dispose()
                    Try
                        If com.ExecuteNonQuery() >= 1 Then 'Moving to CurrentSQL
                            FileSQL(i).MoveTo(PathCurrentSQL & "\" & FileSQL(i).Name)
                        End If
                    Catch ex As Exception

                    End Try
                End If
            Next
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            
        End Try
    End Sub

    Public Sub UpdateSistemData()
        Dim cn As New SqlConnection
        Dim com As New SqlCommand
        Dim oDA As New SqlDataAdapter
        Dim ds As New DataSet
        Dim SQL As String
        Try
            cn.ConnectionString = KoneksiString
            cn.Open()
            com.Connection = cn
            Try
                SQL = "SELECT COUNT(HMenu.NoID) FROM HMenu WHERE UPPER(Kode)=UPPER('LaporanPembelianDetil')"
                com.CommandText = SQL
                If NullToLong(com.ExecuteScalar()) = 0 Then
                    SQL = "INSERT INTO [HMenu] ([Kode],[Caption],[CaptionInDaftar],[ObjectToRun],[Icon],[NoUrut],[IsAktif],[IDParent],[IsBarSubItem],[IDBarSubItem],[TypeMenu],[IsBeginGroup]) VALUES (" & vbCrLf & _
                          "'LaporanPembelianDetil', 'Laporan Pembelian Detil', 'Laporan Pembelian Detil', 'LaporanPembelianDetil', 5, 8, 1, 6, NULL, NULL, 0, 1)"
                    com.CommandText = SQL
                    com.ExecuteNonQuery()
                End If
            Catch ex As Exception

            End Try
            Try
                SQL = "ALTER TABLE HKontak ADD IDSalesman INT NULL"
                com.CommandText = SQL
                com.ExecuteNonQuery()
            Catch ex As Exception

            End Try
            Try
                SQL = "CREATE TABLE [dbo].[HBarangDBarcode](" & vbCrLf & _
                      " [NoID] [int] NOT NULL," & vbCrLf & _
                      " [IDBarang] [int] NULL," & vbCrLf & _
                      " [Barcode] [varchar](20) NULL," & vbCrLf & _
                      " CONSTRAINT [PK_HBarangDBarcode] PRIMARY KEY CLUSTERED " & vbCrLf & _
                      " (" & vbCrLf & _
                      " [NoID] Asc " & vbCrLf & _
                      " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & vbCrLf & _
                      " ) ON [PRIMARY]"
                com.CommandText = SQL
                com.ExecuteNonQuery()
            Catch ex As Exception

            End Try
            Try
                SQL = "CREATE UNIQUE INDEX IX_Barcode" & vbCrLf & _
                      " ON dbo.HBarangDBarcode (Barcode)"
                com.CommandText = SQL
                com.ExecuteNonQuery()
            Catch ex As Exception

            End Try
            Try
                SQL = "ALTER TABLE HBarang ADD [Photo] IMAGE NULL"
                com.CommandText = SQL
                com.ExecuteNonQuery()
            Catch ex As Exception

            End Try
            Try
                oDA.SelectCommand = com
                com.CommandText = "SELECT HBarang.NoID, HBarang.Barcode FROM HBarang WHERE ISNULL((SELECT COUNT(HBarangDBarcode.NoID) FROM HBarangDBarcode WHERE HBarangDBarcode.IDBarang=HBarang.NoID),0)=0 ORDER BY HBarang.NoID"
                oDA.Fill(ds, "Data")
                For i As Integer = 0 To ds.Tables("Data").Rows.Count - 1
                    Try
                        com.CommandText = "SELECT MAX(NoID) FROM HBarangDBarcode"
                        com.CommandText = "INSERT INTO HBarangDBarcode (NoID, IDBarang, Barcode) VALUES (" & NullToLong(com.ExecuteScalar()) + 1 & "," & NullToLong(ds.Tables("Data").Rows(i).Item("NoID")) & ",'" & FixApostropi(NullToStr(ds.Tables("Data").Rows(i).Item("Barcode"))) & "')"
                        com.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try
                Next
            Catch ex As Exception

            End Try
            BatchUpdateFromFile(cn, com)
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
            com.Dispose()
            oDA.Dispose()
            ds.Dispose()
        End Try
    End Sub
End Module
