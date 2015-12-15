Imports System.IO
Imports DevExpress.XtraEditors
Imports Elliteserv.Fungsi.Ini
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.SQLServer.Connect
Imports System.Data.SqlClient

Module mdlPublic
    Public NamaAplikasi As String = "mPOS - System"
    Public FolderLayouts As String = Application.StartupPath & "\System\Layouts\"
    Public TanggalSystem As Date = Date.Now

    Public NamaPerusahaan As String = "CV. LANGGENG JAYA"
    Public AlamatPerusahaan As String = "SURABAYA"
    Public KotaPerusahaan As String = "SURABAYA"
    Public IsEditReport As Boolean = False

    Public Sub Main()
        If Not IO.Directory.Exists(Application.StartupPath & "\System\") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\System\")
        End If
        If Not IO.Directory.Exists(Application.StartupPath & "\Report\") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\Report\")
        End If
        If Not IO.Directory.Exists(Application.StartupPath & "\System\Layouts\") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\System\Layouts\")
        End If
        BacaSettinganDatabase()
        DevExpress.UserSkins.OfficeSkins.Register()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New frmUtama())
    End Sub
    Public Sub BacaSettinganDatabase()
        Dim Namafile As String = ""
        Try
            Namafile = Application.StartupPath & "\System\Setting.ini"
            If File.Exists(Namafile) Then
                NamaServerMSSQL = BacaIni("DBConfig", "Server", "(local)\SQLEXPRESS")
                NamaDatabaseMSSQL = BacaIni("DBConfig", "Database", "DBMPOS")
                NamaUIDMSSQL = BacaIni("DBConfig", "UserID", "sa")
                NamaPasswordMSSQL = DecryptText(BacaIni("DBConfig", "Password", "elliteserv"), "Elliteserv")
                NamaTimeOutMSSQL = BacaIni("DBConfig", "TimeOut", "15")
                NamaODBCMSSQL = BacaIni("DBConfig", "ODBC", "DBMPOS")
                KoneksiString = "Server=" & NamaServerMSSQL & ";initial Catalog=" & NamaDatabaseMSSQL & ";User ID=" & NamaUIDMSSQL & ";Password=" & NamaPasswordMSSQL & ";TimeOut=" & NamaTimeOutMSSQL
            Else
                TulisIni("DBConfig", "Server", "(local)\SQLEXPRESS")
                TulisIni("DBConfig", "Database", "DBMPOS")
                TulisIni("DBConfig", "ODBC", "DBMPOS")
                TulisIni("DBConfig", "UserID", "sa")
                TulisIni("DBConfig", "Password", EncryptText("elliteserv", "Elliteserv"))
                TulisIni("DBConfig", "TimeOut", "15")

                KoneksiString = "Server=" & "(local)" & ";initial Catalog=" & "DBMPOS" & ";User ID=" & "sa" & ";Password=" & "elliteserv"
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Public Function CekKodeValid(ByVal Kode As String, ByVal KodeOld As String, ByVal NamaTabel As String, ByVal Field As String, ByVal IsEdit As Boolean, Optional ByVal Filternya As String = "") As Boolean
        Dim x As Boolean
        Dim dbs As New DataSet
        Dim rs As String
        Try
            If IsEdit Then
                rs = "SELECT " & Field & " FROM " & NamaTabel & _
                            " WHERE " & Field & "='" & Replace(Kode, "'", "''") & "' and " & Field & "<>'" & Replace(KodeOld, "'", "''") & "'" & " " & Filternya
            Else
                rs = "SELECT " & Field & " FROM " & NamaTabel & _
                             " WHERE " & Field & "='" & Replace(Kode, "'", "''") & "'" & " " & Filternya
            End If
            EksekusiDataset(dbs, NamaTabel, rs)
            If dbs.Tables(NamaTabel).Rows.Count >= 1 Then
                x = True
            Else
                x = False
            End If
        Catch ex As Exception
            x = False
        Finally
            dbs.Dispose()
        End Try
        Return x
    End Function
    Public Function GetNewID(ByVal tabel As String, Optional ByVal nmField As String = "NoID", Optional ByVal FilterButuhWhere As String = "") As Long
        Dim oConn As SqlConnection
        Dim ocmd As SqlCommand
        Dim NoID As Long
        Dim strsql As String
        strsql = "Select max(" & nmField & ") as NewNoID from " & tabel
        If FilterButuhWhere.Trim <> "" Then
            strsql &= FilterButuhWhere
        End If
        oConn = New SqlConnection(KoneksiString)
        ocmd = New SqlCommand(strsql, oConn)
        oConn.Open()
        NoID = NullToLong(ocmd.ExecuteScalar) + 1
        ocmd.Dispose()
        oConn.Close()
        oConn.Dispose()
        Return NoID
    End Function
    Public Function MintaKodeBaru(ByVal KodeDepan As String, ByVal Tabel As String, ByVal Tanggal As Date, Optional ByVal Digit As Integer = 5, Optional ByVal FilterTambahanTidakPakaiAND As String = "")
        Dim TmpKode As String = ""
        Dim TmpKodeDepan As String = KodeDepan
        Dim xFormat As String = ""
        Dim SQL As String = ""
        Dim ds As New DataSet
        Try
            SQL = " 1=1 "
            SQL &= " AND MONTH(" & Tabel & ".Tanggal)=" & Format(Tanggal, "MM")
            SQL &= " AND YEAR(" & Tabel & ".Tanggal)=" & Format(Tanggal, "yyyy")
            If FilterTambahanTidakPakaiAND <> "" Then
                SQL &= " AND " & FilterTambahanTidakPakaiAND
            End If
            TmpKodeDepan = TmpKodeDepan & "/" & Tanggal.ToString("yyyy") & "/" & fnRomawi(CInt(Tanggal.ToString("MM"))) & "/"
            TmpKode = NullToLong(GetNewKodeTablebyFilter(Tabel, "Kode", SQL, Len(TmpKodeDepan) + 1, Digit))
            xFormat = ""
            For i As Integer = 1 To Digit
                If i = 1 Then
                    xFormat = "0"
                Else
                    xFormat &= "#"
                End If
            Next
            TmpKode = TmpKodeDepan & Format(CDbl(TmpKode), xFormat)
        Catch ex As Exception
            XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not ds Is Nothing Then
                ds.Dispose()
            End If
        End Try
        Return TmpKode
    End Function
    Private Function fnRomawi(ByVal input As Integer) As String
        Select Case input
            Case 1
                Return "I"
            Case 2
                Return "II"
            Case 3
                Return "III"
            Case 4
                Return "IV"
            Case 5
                Return "V"
            Case 6
                Return "VI"
            Case 7
                Return "VII"
            Case 8
                Return "VIII"
            Case 9
                Return "IX"
            Case 10
                Return "X"
            Case 11
                Return "XI"
            Case 12
                Return "XII"
            Case Else
                Return "XX"
        End Select
    End Function
    Public Function GetNewKodeTablebyFilter(ByVal NamaTabel As String, ByVal field As String, ByVal Filter As String, ByVal iStart As Integer, ByVal iLeght As Integer) As Object
        Dim oDs As New DataSet
        Dim StrCekRecord As String, x As Object
        Try
            StrCekRecord = "select " & vbCrLf
            StrCekRecord = StrCekRecord & " max(" & vbCrLf
            StrCekRecord = StrCekRecord & " cast(" & vbCrLf
            StrCekRecord = StrCekRecord & " (CASE WHEN IsNumeric(Substring(" & NamaTabel & "." & field & "," & iStart & "," & iLeght & "))=1 THEN Substring(" & NamaTabel & "." & field & "," & iStart & "," & iLeght & ") ELSE 1 END" & vbCrLf
            StrCekRecord = StrCekRecord & " ) as int)) As idMax from " & NamaTabel & " WHERE " & Filter & vbCrLf

            EksekusiDataset(oDs, NamaTabel, StrCekRecord)
            If oDs.Tables(NamaTabel).Rows.Count = 0 Then
                x = 1
            Else
                x = NullToLong(oDs.Tables(NamaTabel).Rows(0).Item(0)) + 1
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            x = 1
        Finally
            oDs.Dispose()
        End Try
        Return x
    End Function
End Module
