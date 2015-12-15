Public Class Utils
    Public Shared Function EncryptText(ByVal strText As String, ByVal strPwd As String) As String
        Dim i As Integer, c As Integer
        Dim strBuff As String = Nothing

#If Not CASE_SENSITIVE_PASSWORD Then

        'Convert password to upper case
        'if not case-sensitive
        strPwd = UCase$(strPwd)

#End If

        'Encrypt string
        If CBool(Len(strPwd)) Then
            For i = 1 To Len(strText)
                c = Asc(Mid$(strText, i, 1))
                c = c + Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff = strBuff & Chr(c And &HFF)
            Next i
        Else
            strBuff = strText
        End If
        Return strBuff
    End Function
    Public Shared Function DecryptText(ByVal strText As String, ByVal strPwd As String) As String
        Dim i As Integer, c As Integer
        Dim strBuff As String = Nothing

#If Not CASE_SENSITIVE_PASSWORD Then

        'Convert password to upper case
        'if not case-sensitive
        strPwd = UCase$(strPwd)

#End If

        'Decrypt string
        If CBool(Len(strPwd)) Then
            For i = 1 To Len(strText)
                c = Asc(Mid$(strText, i, 1))
                c = c - Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff = strBuff & Chr(c And &HFF)
            Next i
        Else
            strBuff = strText
        End If
        Return strBuff
    End Function


    Public Shared Function NullToStr(ByVal Value As Object) As String
        If IsDBNull(Value) Then
            Return ""
        ElseIf Value Is Nothing Then
            Return ""
        Else
            Return Value
        End If
    End Function
    Public Shared Function NullToLong(ByVal Value As Object) As Long
        If IsDBNull(Value) Then
            Return 0
        Else
            If IsNumeric(Value) Then
                Return Value
            Else
                Return 0
            End If
        End If
    End Function
    Public Shared Function NullTolInt(ByVal Value As Object) As Integer
        If IsDBNull(Value) Then
            Return 0
        Else
            If IsNumeric(Value) Then
                Return Value
            Else
                Return 0
            End If
        End If
    End Function
    Public Shared Function NullToDate(ByVal X As Object) As Date
        If TypeOf X Is Date Then
            Return CDate(X)
        Else
            Return CDate("1/1/1900")
        End If
    End Function
    Public Shared Function NullToDbl(ByVal Value As Object) As Double
        If IsDBNull(Value) Then
            Return 0.0
        Else
            If IsNumeric(Value) Then
                Return Value
            Else
                Return 0.0
            End If

        End If
    End Function
    Public Shared Function NullToBool(ByVal Value As Object) As Boolean
        If IsDBNull(Value) Then
            Return False
        ElseIf Value Is Nothing Then
            Return False
        ElseIf Value.ToString = "" Then
            Return False
        Else
            Return CBool(Value)
        End If
    End Function
    Public Shared Function FixApostropi(ByVal str As String) As String
        Dim Hasil As String = ""
        Try
            Hasil = str.Replace("'", "''")
        Catch ex As Exception

        End Try
        Return Hasil
    End Function
    Public Shared Function FixKoma(ByVal str As String) As String
        Dim Hasil As String = ""
        Try
            Hasil = str.Replace(",", ".")
        Catch ex As Exception

        End Try
        Return Hasil
    End Function
End Class
