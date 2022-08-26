Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class Paymentt
    Dim con As New SqlConnection
    Dim pcmd1, pcmd11 As New SqlCommand
    Dim bol As Boolean
    Dim Price As Integer
    Dim dr2 As SqlDataReader
    Dim phoneee As String
    Dim i As Integer

    Private Sub Paymentt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        phoneee = LoginForm.phone
        If phoneee = "" Then
            phoneee = FormSignUp.phone
        End If
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ajayn\Documents\Mall.mdf;Integrated Security=True;Connect Timeout=30"
            con.Open()
        pcmd1.Connection = con
        pcmd11.Connection = con
        pcmd1.CommandText = "select ParkingId,ParkingPrice from Parking where CustomerPhoneNO='" & phoneee & "'"

        Dim adapter1 As New SqlDataAdapter(pcmd1)

        Dim table1 As New DataTable

        adapter1.Fill(table1)

        GridView2.DataSource = table1
        For index As Integer = 0 To GridView2.RowCount - 1
            Price += Convert.ToInt32(GridView2.Rows(index).Cells(1).Value)

            'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
        Next
        priceee.Text = Price


        pcmd1.CommandText = "select iName,company,price from Orderrr where CustomerPhoneNO='" & phoneee & "'"

        Dim adapter As New SqlDataAdapter(pcmd1)

        Dim table As New DataTable

        adapter.Fill(table)

        GridView1.DataSource = table

        For index As Integer = 0 To GridView1.RowCount - 1
            Price += Convert.ToInt32(GridView1.Rows(index).Cells(2).Value)

            'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
        Next
        priceee.Text = Price

        i = GetRandom(2, 1715)

        pcmd1.CommandText = "select BillingId from Billing where BillingId='" & i & "'"
        Dim dr1 As SqlDataReader
        dr1 = pcmd1.ExecuteReader
        While dr1.Read
            i = GetRandom(2, 1715)
        End While
        dr1.Close()




    End Sub

    Public Function GetRandom(ByVal min As Integer, ByVal max As Integer) As Integer
        Static staticRandomGenerator As New System.Random
        max += 1
        Return staticRandomGenerator.Next(If(min > max, max, min), If(min > max, min, max))
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try

        pcmd11.Connection = con
        pcmd11.CommandText = "INSERT INTO Billing(BillingId,TotalPrice,PaymentType,CustomerPhoneNO) VALUES(@BillingId,@TotalPrice,@PaymentType,@CustomerPhoneNO)"
        Dim paramPId As New SqlParameter("@BillingId", SqlDbType.VarChar, 55)
            paramPId.Value = i
            Dim paramTotalPrice As New SqlParameter("@TotalPrice", SqlDbType.VarChar, 55)
            paramTotalPrice.Value = priceee.Text

            Dim paramPaymentType As New SqlParameter("@PaymentType", SqlDbType.VarChar, 55)
            If COD.Checked Then
                paramPaymentType.Value = COD.Text

            ElseIf UPI.Checked Then
                paramPaymentType.Value = UPI.Text
            End If


        Dim parampCustno As New SqlParameter("@CustomerPhoneNO", SqlDbType.VarChar, 55)
        parampCustno.Value = phoneee




        pcmd11.Parameters.Add(paramPId)
        pcmd11.Parameters.Add(paramTotalPrice)
        pcmd11.Parameters.Add(paramPaymentType)
        pcmd11.Parameters.Add(parampCustno)



        Dim da As New SqlDataAdapter

        da.InsertCommand = pcmd11
        da.InsertCommand.ExecuteNonQuery()
            MsgBox(" Payment Successfull ")
            Form1.Show()
            Me.Hide()
        'Catch ee As Exception
        '    MessageBox.Show("Empty Order")
        'End Try

    End Sub

    Private Sub COD_CheckedChanged(sender As Object, e As EventArgs) Handles COD.CheckedChanged

    End Sub
End Class