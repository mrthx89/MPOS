Module mdlUtils
    Public Function EncryptText(ByVal strText As String, ByVal strPwd As String) As String
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
    Public Function DecryptText(ByVal strText As String, ByVal strPwd As String) As String
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

    Public Function FixApostropi(ByVal Str As String) As String
        Return Str.Replace("'", "''")
    End Function
    Public Function FixKoma(ByVal Str As String) As String
        Return Str.Replace(",", ".")
    End Function
    Public Function NullToStr(ByVal Value As Object) As String
        If IsDBNull(Value) Then
            Return ""
        ElseIf Value Is Nothing Then
            Return ""
        Else
            Return Value
        End If
    End Function
    Public Function NullToLong(ByVal Value As Object) As Long
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
    Public Function NullTolInt(ByVal Value As Object) As Integer
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
    Public Function NullToDate(ByVal X As Object) As Date
        If TypeOf X Is Date Then
            Return CDate(X)
        Else
            Return CDate("1/1/1900")
        End If
    End Function
    Public Function NullToDbl(ByVal Value As Object) As Double
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
    Public Function NullToBool(ByVal Value As Object) As Boolean
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
    Public Function checksum_ean8(ByVal data As String()) As Integer
        ' Test string for correct length
        If data.Length <> 7 AndAlso data.Length <> 8 Then
            Return -1
        End If

        ' Test string for being numeric
        For i As Integer = 0 To data.Length - 1
            If data(i) < &H30 OrElse data(i) > &H39 Then
                Return -1
            End If
        Next

        Dim sum As Integer = 0

        For i As Integer = 6 To 0 Step -1
            Dim digit As Integer = data(i) - &H30
            If (i And 1) = 1 Then
                sum += digit
            Else
                sum += digit * 3
            End If
        Next
        Dim [mod] As Integer = sum Mod 10
        Return If([mod] = 0, 0, 10 - [mod])
    End Function
    Public Function checksum_ean13(ByVal data As String()) As Integer
        ' Test string for correct length
        If data.Length <> 12 AndAlso data.Length <> 13 Then
            Return -1
        End If

        ' Test string for being numeric
        For i As Integer = 0 To data.Length - 1
            If data(i) < &H30 OrElse data(i) > &H39 Then
                Return -1
            End If
        Next

        Dim sum As Integer = 0

        For i As Integer = 11 To 0 Step -1
            Dim digit As Integer = data(i) - &H30
            If (i And 1) = 1 Then
                sum += digit
            Else
                sum += digit * 3
            End If
        Next
        Dim [mod] As Integer = sum Mod 10
        Return If([mod] = 0, 0, 10 - [mod])
    End Function
    Public Function EAN8_Checksum(ByVal EAN8_Barcode As String) As String
        'http://www.barcodeisland.com/ean8.phtml

        Dim ChecksumCalculation As Integer
        ChecksumCalculation = 0
        Dim Position As Integer
        Position = 1
        Dim i As Integer
        For i = Len(EAN8_Barcode) - 1 To 0 Step -1
            If Position Mod 2 = 1 Then
                'odd position
                ChecksumCalculation = ChecksumCalculation + CLng(Mid(EAN8_Barcode, i + 1, 1)) * 3
            Else
                'even position
                ChecksumCalculation = ChecksumCalculation + CLng(Mid(EAN8_Barcode, i + 1, 1)) * 1
            End If
            Position = Position + 1
        Next

        Dim Checksum As Integer
        Checksum = (10 - (ChecksumCalculation Mod 10)) Mod 10
        If Checksum = 10 Then
            Checksum = 0
        End If
        If EAN8_Barcode.Length >= 7 Then
            Return EAN8_Barcode.Substring(0, 7) & Format$(Checksum, "0")
        Else
            Return EAN8_Barcode.ToString() & Format$(Checksum, "0")
        End If
    End Function
    Public Function Bulatkan(ByVal x As Double, ByVal Koma As Integer) As Double
        If Koma >= 0 Then
            Bulatkan = System.Math.Round(x, CInt(Koma))
            If System.Math.Round(x - Bulatkan, CInt(Koma + 5)) >= 0.5 / (10 ^ Koma) Then Bulatkan = Bulatkan + 1 / (10 ^ Koma)
        Else
            Bulatkan = x
        End If
    End Function
End Module
