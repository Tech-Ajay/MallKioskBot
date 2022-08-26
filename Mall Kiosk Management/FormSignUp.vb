Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class FormSignUp
    Dim con As New SqlConnection
    Dim pcmd1 As New SqlCommand
    Dim dr2 As SqlDataReader
    Dim BolEmail As Boolean = False
    Dim BolPhone As Boolean = False
    Public phone As String

    Private Sub FormSignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ajayn\Documents\Mall.mdf;Integrated Security=True;Connect Timeout=30"
        con.Open()
        pcmd1.Connection = con
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Not IsPhoneNumberValid(TextBox1.Text) Then
            Dim isvalid = False
            lblValidatioMessage.Visible = True
            lblValidatioMessage.Text = "*Invalid Phonenumber"
            BolPhone = False
        Else
            lblValidatioMessage.Visible = False
            lblValidatioMessage.Text = ""
            BolPhone = True
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim regex As Regex = New Regex("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
        Dim isValid As Boolean = regex.IsMatch(TextBox4.Text.Trim)
        If Not isValid Then
            Label5.Visible = True
            BolEmail = False
        Else
            Label5.Visible = False
            BolEmail = True
        End If
    End Sub
    Private Shared Function IsPhoneNumberValid(phoneNumber As String) As Boolean
        Dim result As String = ""
        Dim chars As Char() = phoneNumber.ToCharArray()
        For count = 0 To chars.GetLength(0) - 1
            Dim tempChar As Char = chars(count)
            If [Char].IsDigit(tempChar) Or "()+-., ".Contains(tempChar.ToString()) Then

                result += StripNonAlphaNumeric(tempChar)
            Else
                Return False
            End If
        Next
        Return result.Length = 10 'Length of US phone numbers is 10
    End Function

    Private Shared Function StripNonAlphaNumeric(value As String) As String
        Dim regex = New Regex("[^0-9a-zA-Z]", RegexOptions.None)
        Dim result As String = ""
        If regex.IsMatch(value) Then
            result = regex.Replace(value, "")
        Else
            result = value
        End If
        Return result
    End Function

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz"
        If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If BolPhone = BolEmail = True Then
                pcmd1.Connection = con
                pcmd1.CommandText = "INSERT INTO CustDetails(CustomerPhoneNO,CustomerName,CustomerEmail,CustomerPassword) VALUES(@CustomerPhoneNO,@CustomerName,@CustomerEmail,@CustomerPassword)"
                Dim paramfname As New SqlParameter("@CustomerName", SqlDbType.VarChar, 55)
                paramfname.Value = TextBox3.Text
                Dim paramphoneno As New SqlParameter("@CustomerPhoneNO", SqlDbType.VarChar, 55)
                paramphoneno.Value = TextBox1.Text
                phone = TextBox1.Text
                Dim paramemail As New SqlParameter("@CustomerEmail", SqlDbType.VarChar, 55)
                paramemail.Value = TextBox4.Text
                Dim parampass As New SqlParameter("@CustomerPassword", SqlDbType.VarChar, 55)
                parampass.Value = TextBox2.Text
                pcmd1.Parameters.Add(paramfname)
                pcmd1.Parameters.Add(paramphoneno)
                pcmd1.Parameters.Add(paramemail)
                pcmd1.Parameters.Add(parampass)
                Dim da As New SqlDataAdapter

                da.InsertCommand = pcmd1
                da.InsertCommand.ExecuteNonQuery()
                MsgBox("Inserted succesfully")
                Form1.Show()
                Me.Hide()
            Else
                MsgBox("Invalid Input")
            End If
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Phone Number Already Registered")
        End Try
    End Sub
End Class