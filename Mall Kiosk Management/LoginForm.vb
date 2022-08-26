Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Speech

Public Class LoginForm

    Dim con As New SqlConnection
    Dim synth As New Synthesis.SpeechSynthesizer
    Dim pcmd1 As New SqlCommand
    Dim dr2 As SqlDataReader
    Public phone As String
    Dim userstring As String
    Dim BolPhone As Boolean = False


    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ajayn\Documents\Mall.mdf;Integrated Security=True;Connect Timeout=30"
        con.Open()
        ' connections
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
            phone = TextBox1.Text
            BolPhone = True
        End If
        If BolPhone = True Then

            Try
                ' MsgBox(TextBox2.Text)

                pcmd1.CommandText = "Select CustomerName from CustDetails where CustomerPhoneNO Like'" & phone & "'"
                pcmd1.Connection = con
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    TextBox3.Text = dr2("CustomerName")
                End While
                dr2.Close()
            Catch ex As Exception
                MessageBox.Show("Number Not Registered")
                FormSignUp.Show()
                Me.Hide()

            End Try
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pcmd1.CommandText = "SELECT * FROM CustDetails WHERE CustomerPhoneNO = '" & TextBox1.Text & "' AND CustomerPassword = '" & TextBox2.Text & "'"
        pcmd1.Connection = con

        Dim dr6 As SqlDataReader = pcmd1.ExecuteReader



        Try

            If dr6.Read = False Then

                dr6.Close()

                synth.Speak("InCorrect Password")
                MessageBox.Show("InCorrect Password")

            Else

                dr6.Close()
                synth.Speak("Login Successful...")
                Me.Hide()
                Form1.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If con.State <> ConnectionState.Closed Then
            con.Close()
        End If
    End Sub



    Private Sub lblValidatioMessage_Click(sender As Object, e As EventArgs) Handles lblValidatioMessage.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormSignUp.Show()
        Me.Hide()
    End Sub
End Class