Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class Parking
    Dim con As New SqlConnection
    Dim pcmd1 As New SqlCommand
    Dim pcmd2 As New SqlCommand
    Dim parkslot() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
    Dim bol As Boolean
    Dim Price As Integer
    Dim dr2 As SqlDataReader



    Private Sub Parking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ajayn\Documents\Mall.mdf;Integrated Security=True;Connect Timeout=30"
        con.Open()
        pcmd1.Connection = con
        pcmd2.Connection = con





        Dim i = GetRandom(2, 1715)

        pcmd1.CommandText = "select ParkingId from Parking where ParkingId='" & i & "'"
        Dim dr1 As SqlDataReader
        dr1 = pcmd1.ExecuteReader
        While dr1.Read
            i = GetRandom(2, 1715)
        End While
        dr1.Close()
        TextBox1.Text = i


        For Each x In parkslot
            pcmd2.CommandText = "select ParkingSlotNo from Parking where ParkingSlotNo='" & x & "'"
            Dim dr22 As SqlDataReader
            dr22 = pcmd2.ExecuteReader
            ComboBox1.Items.Add(x)
            While dr22.Read
                ComboBox1.Items.Remove(x)
            End While



            dr22.Close()
        Next









    End Sub
    Public Function GetRandom(ByVal min As Integer, ByVal max As Integer) As Integer
        Static staticRandomGenerator As New System.Random
        max += 1
        Return staticRandomGenerator.Next(If(min > max, max, min), If(min > max, min, max))
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If (bol = False And String.IsNullOrEmpty(ComboBox1.SelectedText)) Then
                MessageBox.Show("Select All the Fields")
            Else
                pcmd1.Connection = con
                pcmd1.CommandText = "INSERT INTO Parking(ParkingId,ParkingSlotNo,VehicleType,ParkingPrice,CustomerPhoneNO) VALUES(@ParkingId,@ParkingSlotNo,@VehicleType,@ParkingPrice,@CustomerPhoneNO)"
                Dim paramPId As New SqlParameter("@ParkingId", SqlDbType.VarChar, 55)
                paramPId.Value = TextBox1.Text
                Dim paramPSNo As New SqlParameter("@ParkingSlotNo", SqlDbType.VarChar, 55)
                paramPSNo.Value = ComboBox1.SelectedItem
                Dim paramVType As New SqlParameter("@VehicleType", SqlDbType.VarChar, 55)
                If (RadioButton1.Checked) Then
                    paramVType.Value = RadioButton1.Text
                End If
                If (RadioButton2.Checked) Then
                    paramVType.Value = RadioButton2.Text
                End If

                Dim parampprice As New SqlParameter("@ParkingPrice", SqlDbType.VarChar, 55)
                parampprice.Value = priceee.Text

                Dim parampCustno As New SqlParameter("@CustomerPhoneNO", SqlDbType.VarChar, 55)
                parampCustno.Value = FormSignUp.phone

                Dim parampCustno1 As New SqlParameter("@CustomerPhoneNO", SqlDbType.VarChar, 55)
                parampCustno1.Value = LoginForm.phone



                pcmd1.Parameters.Add(paramPId)
                pcmd1.Parameters.Add(paramPSNo)
                pcmd1.Parameters.Add(paramVType)
                pcmd1.Parameters.Add(parampprice)
                If LoginForm.phone = "" Then
                    pcmd1.Parameters.Add(parampCustno)
                Else
                    pcmd1.Parameters.Add(parampCustno1)
                End If


                Dim da As New SqlDataAdapter

                da.InsertCommand = pcmd1
                da.InsertCommand.ExecuteNonQuery()
                MsgBox(" Parking Booked ")
                Form1.Show()
                Me.Hide()
            End If
        Catch ee As Exception
            MessageBox.Show("Parking already booked from this number")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Price = 20
        bol = True
        priceee.Text = 20


    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        bol = True
        Price = 40
        priceee.Text = 40
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class