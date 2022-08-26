
Imports System.Data.SqlClient
Imports System.Speech

Public Class FoemStock1
    Dim synth As New Synthesis.SpeechSynthesizer
    Dim WithEvents reco As New Recognition.SpeechRecognitionEngine
    Dim SAPI = CreateObject("SAPI.spvoice")
    Dim textt As String
    Dim con As New SqlConnection
    Dim pcmd1 As New SqlCommand
    Dim pcmd2 As New SqlCommand
    Dim dr2 As SqlDataReader
    Dim lst As New List(Of String)
    Dim a As Integer = 12
    'AutoComplete collection that will help to filter keep the records.
    Dim MySource As New AutoCompleteStringCollection()

    Private Sub FoemStock1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ajayn\Documents\Mall.mdf;Integrated Security=True;Connect Timeout=30"
        con.Open()
        pcmd1.Connection = con

        'Me.WindowState = FormWindowState.Maximized
        PanelMain.Visible = False
        PanelPuma.Visible = False
        PanelLevis.Visible = False
        PanelSpar.Visible = False
        PanelIStore.Visible = False


        'Manually added items from database to the list
        pcmd1.CommandText = "select iName from Puma"
        Dim dr As SqlDataReader
        dr = pcmd1.ExecuteReader
        While dr.Read
            lst.Add(dr("iName"))
        End While
        dr.Close()
        pcmd1.CommandText = "select iName from Levis"
        dr = pcmd1.ExecuteReader
        While dr.Read
            lst.Add(dr("iName"))
        End While
        dr.Close()
        pcmd1.CommandText = "select iName from Spar"
        dr = pcmd1.ExecuteReader
        While dr.Read
            lst.Add(dr("iName"))
        End While
        dr.Close()
        pcmd1.CommandText = "select iName from IStore"
        dr = pcmd1.ExecuteReader
        While dr.Read
            lst.Add(dr("iName"))
        End While
        dr.Close()
        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        'this AutocompleteStringcollection binded to the textbox as custom source.
        TextBox1.AutoCompleteCustomSource = MySource
        'Auto complete mode set to suggest append so that it will sugesst one
        'or more suggested completion strings 
        TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'Set to Custom source we have filled already
        TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        con.Close()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        con.Close()
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        Form1.Show()

    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As System.Object,
ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Then   ' On enter I planned to add it the list
            If Not lst.Contains(TextBox1.Text) Then  ' If item not present already
                ' Add to the source directly
                TextBox1.AutoCompleteCustomSource.Add(TextBox1.Text)
            End If
        ElseIf e.KeyCode = Keys.Delete Then 'On delete key, planned to remove entry
            ' declare a dummy source
            Dim coll As AutoCompleteStringCollection = TextBox1.AutoCompleteCustomSource
            ' remove item from new source
            coll.Remove(TextBox1.Text)
            ' Bind the updates
            TextBox1.AutoCompleteCustomSource = coll
            ' Clear textbox
            TextBox1.Clear()
        End If                   ' End of ‘KeyCode’ condition

    End Sub

    Private Sub btnPuma_Click(sender As Object, e As EventArgs) Handles btnPuma.Click
        PanelPuma.Visible = True
        PanelLevis.Visible = False
        PanelMain.Visible = False
        PanelSpar.Visible = False
        PanelIStore.Visible = False
        textt = btnPuma.Text
        SAPI.Speak(textt)
        con.Open()

        Try
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Puma where iID=1"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                pcLabel1.Text = dr2("iCost")
                pPictureBox1.Image = Image.FromFile(dr2("iImage"))
                pPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                pLabel1.Text = dr2("iName")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    pLabelofo1.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Puma where iID=2"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                pcLabel2.Text = dr2("iCost")
                pPictureBox2.Image = Image.FromFile(dr2("iImage"))
                pPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
                pLabel2.Text = dr2("iName")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    pLabelofo2.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Puma where iID=3"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                pcLabel3.Text = dr2("iCost")
                pPictureBox3.Image = Image.FromFile(dr2("iImage"))
                pPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage

                pLabel3.Text = dr2("iName")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    pLabelofo3.Visible = True
                End If
            End While

            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Puma where iID=4"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                pcLabel4.Text = dr2("iCost")
                pPictureBox4.Image = Image.FromFile(dr2("iImage"))
                pPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage

                pLabel4.Text = dr2("iName")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    pLabelofo4.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Puma where iID=5"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                pPictureBox5.Image = Image.FromFile(dr2("iImage"))
                pPictureBox5.SizeMode = PictureBoxSizeMode.StretchImage


                pLabel5.Text = dr2("iName")
                pcLabel5.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    pLabelofo5.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Puma where iID=6"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                pcLabel6.Text = dr2("iCost")
                pPictureBox6.Image = Image.FromFile(dr2("iImage"))
                pPictureBox6.SizeMode = PictureBoxSizeMode.StretchImage

                pLabel6.Text = dr2("iName")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    pLabelofo6.Visible = True
                End If
            End While
            dr2.Close()
            con.Close()

        Catch ee As Exception
            Console.WriteLine("Exception caught:{0}", ee)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Searchh()
    End Sub
    Private Sub Searchh()
        PanelMain.Visible = True
        PanelLevis.Visible = False
        PanelPuma.Visible = False
        PanelSpar.Visible = False
        PanelIStore.Visible = False



        Dim var1 As String

        var1 = TextBox1.Text
        con.Open()

        Try
            pcmd1.CommandText = "select iId,iName,iQuantity,iImage,iCost from Puma where iName Like '" & var1 & "'"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read

                sLabel1.Visible = True
                sCostLabel1.Visible = True
                sCostLabel1.Text = dr2("iCost")
                sLabel1.Text = dr2("iName")
                sPictureBox1.Image = Image.FromFile(dr2("iImage"))
                sPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    sLabel2.Visible = True
                Else
                    sLabel2.Visible = False

                End If
            End While
            dr2.Close()

            pcmd1.CommandText = "select iId,iName,iQuantity,iImage,iCost from Levis where iName Like '" & var1 & "'"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read

                sLabel1.Visible = True
                sCostLabel1.Visible = True
                sCostLabel1.Text = dr2("iCost")
                sLabel1.Text = dr2("iName")
                sPictureBox1.Image = Image.FromFile(dr2("iImage"))
                sPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    sLabel2.Visible = True
                Else
                    sLabel2.Visible = False
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iId,iName,iQuantity,iImage,iCost from Spar where iName Like '" & var1 & "'"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                sLabel1.Visible = True
                sCostLabel1.Visible = True
                sCostLabel1.Text = dr2("iCost")
                sLabel1.Text = dr2("iName")
                sPictureBox1.Image = Image.FromFile(dr2("iImage"))
                sPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    sLabel2.Visible = True
                Else
                    sLabel2.Visible = False
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iId,iName,iQuantity,iImage,iCost from IStore where iName Like '" & var1 & "'"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read

                sLabel1.Visible = True
                sCostLabel1.Visible = True
                sCostLabel1.Text = dr2("iCost")
                sLabel1.Text = dr2("iName")
                sPictureBox1.Image = Image.FromFile(dr2("iImage"))
                sPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    sLabel2.Visible = True
                Else
                    sLabel2.Visible = False

                End If
            End While
            dr2.Close()
            con.Close()

        Catch ee As Exception
            Console.WriteLine("Exception caught:{0}", ee)
        End Try

    End Sub

    Private Sub PanelSpar_Paint(sender As Object, e As PaintEventArgs) Handles PanelSpar.Paint

    End Sub

    Private Sub btnSpar_Click(sender As Object, e As EventArgs) Handles btnSpar.Click
        textt = btnSpar.Text
        SAPI.Speak(textt)
        Button1_Click(e, e)
        Text = btnLevis.Text
        SAPI.Speak(textt)
        PanelLevis.Visible = False
        PanelIStore.Visible = False

        PanelPuma.Visible = False
        PanelMain.Visible = False
        PanelSpar.Visible = True
        con.Open()


        Try
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Spar where iID=1"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                slnLabel1.Text = dr2("iName")
                slPictureBox1.Image = Image.FromFile(dr2("iImage"))
                slPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                slcLabel1.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    sllabel1.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Spar where iID=2"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                slnLabel2.Text = dr2("iName")
                slPictureBox2.Image = Image.FromFile(dr2("iImage"))
                slPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage

                slcLabel2.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    sllabel2.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Spar where iID=3"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                slnLabel3.Text = dr2("iName")
                slPictureBox3.Image = Image.FromFile(dr2("iImage"))
                slPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage

                slcLabel3.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    slPictureBox3.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Spar where iID=4"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                slnLabel4.Text = dr2("iName")
                slPictureBox4.Image = Image.FromFile(dr2("iImage"))
                slPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage

                slcLabel4.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    sllabel4.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Spar where iID=5"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                slnLabel5.Text = dr2("iName")
                slPictureBox5.Image = Image.FromFile(dr2("iImage"))
                slPictureBox5.SizeMode = PictureBoxSizeMode.StretchImage

                slcLabel5.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    sllabel5.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Spar where iID=6"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                slnLabel6.Text = dr2("iName")
                slPictureBox6.Image = Image.FromFile(dr2("iImage"))
                slPictureBox6.SizeMode = PictureBoxSizeMode.StretchImage

                slcLabel6.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    sllabel6.Visible = True
                End If
            End While
            dr2.Close()
            con.Close()

        Catch ee As Exception
            Console.WriteLine("Exception caught:{0}", ee)
        End Try


    End Sub


    Private Sub outofstock(ByVal pparam As Integer)
        con.Open()

        Dim order As Integer
        Dim testMsg As String
        Try
            testMsg = MsgBox("Do You Want to order this item", vbYesNo + vbExclamation, "Test Message")
            If testMsg = 6 Then

                pcmd1.CommandText = "select iOrderOutOFStock from Puma where iId='" & pparam & "'"
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    order = dr2("iOrderOutOFStock")
                End While
                dr2.Close()

                order = order + 1
                pcmd1.Connection = con
                pcmd1.CommandText = "update Puma set iOrderOutOFStock='" & order & "' where iId='" & pparam & "';"
                Dim da As New SqlDataAdapter
                da.InsertCommand = pcmd1
                da.InsertCommand.ExecuteNonQuery()
                pcmd1.CommandText = "update CustDetails set CustomerOrders='Puma," & pparam & "' where CustomerPhoneNO='" & LoginForm.phone & "';"
                Dim da2 As New SqlDataAdapter
                da2.InsertCommand = pcmd1
                da2.InsertCommand.ExecuteNonQuery()

                MessageBox.Show("Your Order has been Placed!" & vbNewLine & "Your Product can be collected After 2 Working Days")
                con.Close()


            Else
                MessageBox.Show("Sorry for the Inconvenience!!" & vbNewLine & "Please do check out other products ")
                con.Close()

                ' MessageBox.Show("You have clicked the Cancel button")
            End If
        Catch EX As Exception

        End Try
    End Sub



    Private Sub pLabelofo1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pLabelofo1.LinkClicked
        outofstock(1)
    End Sub

    Private Sub pLabelofo2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pLabelofo2.LinkClicked
        outofstock(2)
    End Sub

    Private Sub pLabelofo3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pLabelofo3.LinkClicked
        outofstock(3)
    End Sub

    Private Sub pLabelofo4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pLabelofo4.LinkClicked
        outofstock(4)
    End Sub

    Private Sub pLabelofo5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pLabelofo5.LinkClicked
        outofstock(5)
    End Sub

    Private Sub pLabelofo6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pLabelofo6.LinkClicked
        outofstock(6)
    End Sub

    Private Sub Loutofstock(ByVal pparam As Integer)
        con.Open()
        Dim order As Integer
        Dim testMsg As String
        Try
            testMsg = MsgBox("Do You Want to order this item", vbYesNo + vbExclamation, "Test Message")
            If testMsg = 6 Then

                pcmd1.CommandText = "select iOrderOutOFStock from Levis where iId='" & pparam & "'"
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    order = dr2("iOrderOutOFStock")
                End While
                dr2.Close()

                order = order + 1
                pcmd1.Connection = con
                pcmd1.CommandText = "update Puma set iOrderOutOFStock='" & order & "' where iId='" & pparam & "';"
                Dim da As New SqlDataAdapter
                da.InsertCommand = pcmd1
                da.InsertCommand.ExecuteNonQuery()
                pcmd1.CommandText = "update CustDetails set CustomerOrders='Puma," & pparam & "' where CustomerPhoneNO='" & LoginForm.phone & "';"
                Dim da2 As New SqlDataAdapter
                da2.InsertCommand = pcmd1
                da2.InsertCommand.ExecuteNonQuery()
                MessageBox.Show("Your Order has been Placed!" & vbNewLine & "Your Product can be collected After 2 Working Days")
                con.Close()

            Else
                MessageBox.Show("Sorry for the Inconvenience!!" & vbNewLine & "Please do check out other products ")
                con.Close()

                ' MessageBox.Show("You have clicked the Cancel button")
            End If
        Catch EX As Exception
            MessageBox.Show(order, pparam)
        End Try
    End Sub

    Private Sub llabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llabel1.LinkClicked
        Loutofstock(1)
    End Sub

    Private Sub llabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llabel2.LinkClicked
        Loutofstock(2)

    End Sub

    Private Sub llabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llabel3.LinkClicked
        Loutofstock(3)

    End Sub

    Private Sub llabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llabel4.LinkClicked
        Loutofstock(4)

    End Sub

    Private Sub llabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llabel5.LinkClicked
        Loutofstock(5)

    End Sub

    Private Sub llabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llabel6.LinkClicked
        Loutofstock(6)

    End Sub

    Private Sub Soutofstock(ByVal pparam As Integer)
        con.Open()
        Dim order As Integer
        Dim testMsg As String
        Try
            testMsg = MsgBox("Do You Want to order this item", vbYesNo + vbExclamation, "Test Message")
            If testMsg = 6 Then

                pcmd1.CommandText = "select iOrderOutOFStock from Spar where iId='" & pparam & "'"
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    order = dr2("iOrderOutOFStock")
                End While
                dr2.Close()

                order = order + 1
                pcmd1.Connection = con
                pcmd1.CommandText = "update Spar set iOrderOutOFStock='" & order & "' where iId='" & pparam & "';"
                Dim da As New SqlDataAdapter
                da.InsertCommand = pcmd1
                da.InsertCommand.ExecuteNonQuery()
                pcmd1.CommandText = "update CustDetails set CustomerOrders='Spar," & pparam & "' where CustomerPhoneNO='" & LoginForm.phone & "';"
                Dim da2 As New SqlDataAdapter
                da2.InsertCommand = pcmd1
                da2.InsertCommand.ExecuteNonQuery()
                MessageBox.Show("Your Order has been Placed!" & vbNewLine & "Your Product can be collected After 2 Working Days")
                con.Close()

            Else
                MessageBox.Show("Sorry for the Inconvenience!!" & vbNewLine & "Please do check out other products ")
                con.Close()

                ' MessageBox.Show("You have clicked the Cancel button")
            End If
        Catch EX As Exception
            MessageBox.Show(order, pparam)
        End Try
    End Sub




    Private Sub InStock(ByVal pparam As Integer)
        Dim order As Integer
        Dim testMsg As String
        con.Open()

        'Try
        testMsg = MsgBox("Do You Want to order this item", vbYesNo + vbExclamation, "Test Message")

        If testMsg = 6 Then



            pcmd2.Connection = con
            pcmd2.CommandText = "INSERT INTO Orderrr(CustomerPhoneNO,CustomerOrders,company,price,iName) VALUES(@CustomerPhoneNO,@CustomerOrders,@company,@price,@iName)"

            Dim paramphoneno As New SqlParameter("@CustomerPhoneNO", SqlDbType.VarChar, 55)
            paramphoneno.Value = LoginForm.phone
            Dim parampass As New SqlParameter("@CustomerOrders ", SqlDbType.VarChar, 55)
            parampass.Value = pparam
            Dim paramcomp As New SqlParameter("@company ", SqlDbType.VarChar, 55)
            paramcomp.Value = "Puma"
            Dim paramprice As New SqlParameter("@price ", SqlDbType.Money, 55)
            Dim paramName As New SqlParameter("@iName ", SqlDbType.VarChar, 55)

            pcmd1.CommandText = "select iCost,iName from Puma where iId='" & pparam & "'"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                paramprice.Value = dr2("iCost")
                paramName.Value = dr2("iName")

            End While
            dr2.Close()
            While paramprice.Value = 0
                paramprice.Value = 0
                paramName.Value = ""
            End While


            pcmd2.Parameters.Add(paramphoneno)
                pcmd2.Parameters.Add(parampass)
                pcmd2.Parameters.Add(paramcomp)
            pcmd2.Parameters.Add(paramprice)
            pcmd2.Parameters.Add(paramName)




            Dim da1 As New SqlDataAdapter
                da1.InsertCommand = pcmd2
                da1.InsertCommand.ExecuteNonQuery()
                pcmd2.Parameters.Clear()

                pcmd1.CommandText = "select iOrderInStock from Puma where iId='" & pparam & "'"
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    order = dr2("iOrderInStock")
                End While
                dr2.Close()

                order = order + 1
                pcmd1.Connection = con
                pcmd1.CommandText = "update Puma set iOrderInStock='" & order & "' where iId='" & pparam & "';"
                Dim da As New SqlDataAdapter
                da.InsertCommand = pcmd1
                da.InsertCommand.ExecuteNonQuery()
                pcmd1.Parameters.Clear()
                MessageBox.Show("Your Order has been Placed!" & vbNewLine & "Your Product can be collected From the Store")
                con.Close()
                Me.Refresh()

            Else
                MessageBox.Show("Sorry for the Inconvenience!!" & vbNewLine & "Please do check out other products ")
            con.Close()

            ' MessageBox.Show("You have clicked the Cancel button")
        End If
        'Catch EX As Exception
        'End Try
    End Sub

    Private Sub pPictureBox1_Click(sender As Object, e As EventArgs) Handles pPictureBox1.Click
        InStock(1)
    End Sub

    Private Sub pPictureBox2_Click(sender As Object, e As EventArgs) Handles pPictureBox2.Click
        InStock(2)
    End Sub

    Private Sub pPictureBox3_Click(sender As Object, e As EventArgs) Handles pPictureBox3.Click
        InStock(3)

    End Sub

    Private Sub pPictureBox4_Click(sender As Object, e As EventArgs) Handles pPictureBox4.Click
        InStock(4)

    End Sub

    Private Sub pPictureBox5_Click(sender As Object, e As EventArgs) Handles pPictureBox5.Click
        InStock(5)

    End Sub

    Private Sub pPictureBox6_Click(sender As Object, e As EventArgs) Handles pPictureBox6.Click
        InStock(6)

    End Sub

    Private Sub sllabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles sllabel1.LinkClicked
        Soutofstock(1)
    End Sub

    Private Sub sllabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles sllabel2.LinkClicked
        Soutofstock(2)
    End Sub

    Private Sub sllabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles sllabel3.LinkClicked
        Soutofstock(3)
    End Sub

    Private Sub sllabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles sllabel4.LinkClicked
        Soutofstock(4)
    End Sub

    Private Sub sllabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles sllabel5.LinkClicked
        Soutofstock(5)
    End Sub

    Private Sub sllabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles sllabel6.LinkClicked
        Soutofstock(6)
    End Sub

    Private Sub LInStock(ByVal pparam As Integer)
        Dim order As Integer
        Dim testMsg As String
        con.Open()

        Try
            testMsg = MsgBox("Do You Want to order this item", vbYesNo + vbExclamation, "Test Message")

            If testMsg = 6 Then




                pcmd2.Connection = con
                pcmd2.CommandText = "INSERT INTO Orderrr(CustomerPhoneNO,CustomerOrders,company,price,iName) VALUES(@CustomerPhoneNO,@CustomerOrders,@company,@price,@iName)"

                Dim paramphoneno As New SqlParameter("@CustomerPhoneNO", SqlDbType.VarChar, 55)
                paramphoneno.Value = LoginForm.phone
                Dim parampass As New SqlParameter("@CustomerOrders ", SqlDbType.VarChar, 55)
                parampass.Value = pparam
                Dim paramcomp As New SqlParameter("@company ", SqlDbType.VarChar, 55)
                paramcomp.Value = "Levis"
                Dim paramprice As New SqlParameter("@price ", SqlDbType.Money, 55)
                Dim paramName As New SqlParameter("@iName ", SqlDbType.VarChar, 55)

                pcmd1.CommandText = "select iCost,iName from Levis where iId='" & pparam & "'"
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    paramprice.Value = dr2("iCost")
                    paramName.Value = dr2("iName")

                End While
                dr2.Close()
                While paramprice.Value = 0
                    paramprice.Value = 0
                    paramName.Value = ""
                End While


                pcmd2.Parameters.Add(paramphoneno)
                pcmd2.Parameters.Add(parampass)
                pcmd2.Parameters.Add(paramcomp)
                pcmd2.Parameters.Add(paramprice)
                pcmd2.Parameters.Add(paramName)




                Dim da1 As New SqlDataAdapter
                da1.InsertCommand = pcmd2
                da1.InsertCommand.ExecuteNonQuery()
                pcmd2.Parameters.Clear()

                pcmd1.CommandText = "select iOrderInStock from Levis where iId='" & pparam & "'"
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    order = dr2("iOrderInStock")
                End While
                dr2.Close()

                order = order + 1
                pcmd1.Connection = con
                pcmd1.CommandText = "update Levis set iOrderInStock='" & order & "' where iId='" & pparam & "';"
                Dim da As New SqlDataAdapter
                da.InsertCommand = pcmd1
                da.InsertCommand.ExecuteNonQuery()
                pcmd1.Parameters.Clear()
                MessageBox.Show("Your Order has been Placed!" & vbNewLine & "Your Product can be collected From the Store")
                con.Close()
                Me.Refresh()

            Else
                MessageBox.Show("Sorry for the Inconvenience!!" & vbNewLine & "Please do check out other products ")
                con.Close()

                MessageBox.Show("You have clicked the Cancel button")
            End If
        Catch EX As Exception
        End Try
    End Sub

    Private Sub lPictureBox1_Click(sender As Object, e As EventArgs) Handles lPictureBox1.Click
        LInStock(1)
    End Sub

    Private Sub lPictureBox2_Click(sender As Object, e As EventArgs) Handles lPictureBox2.Click
        LInStock(2)
    End Sub

    Private Sub lPictureBox3_Click(sender As Object, e As EventArgs) Handles lPictureBox3.Click
        LInStock(3)
    End Sub

    Private Sub lPictureBox4_Click(sender As Object, e As EventArgs) Handles lPictureBox4.Click
        LInStock(4)
    End Sub

    Private Sub lPictureBox5_Click(sender As Object, e As EventArgs) Handles lPictureBox5.Click
        LInStock(5)
    End Sub

    Private Sub lPictureBox6_Click(sender As Object, e As EventArgs) Handles lPictureBox6.Click
        LInStock(6)
    End Sub

    Private Sub SInStock(ByVal pparam As Integer)
        Dim order As Integer
        Dim testMsg As String
        con.Open()

        'Try
        testMsg = MsgBox("Do You Want to order this item", vbYesNo + vbExclamation, "Test Message")

        If testMsg = 6 Then

            pcmd2.Connection = con
            pcmd2.CommandText = "INSERT INTO Orderrr(CustomerPhoneNO,CustomerOrders,company,price,iName) VALUES(@CustomerPhoneNO,@CustomerOrders,@company,@price,@iName)"

            Dim paramphoneno As New SqlParameter("@CustomerPhoneNO", SqlDbType.VarChar, 55)
            paramphoneno.Value = LoginForm.phone
            Dim parampass As New SqlParameter("@CustomerOrders ", SqlDbType.VarChar, 55)
            parampass.Value = pparam
            Dim paramcomp As New SqlParameter("@company ", SqlDbType.VarChar, 55)
            paramcomp.Value = "Spar"
            Dim paramprice As New SqlParameter("@price ", SqlDbType.Money, 55)
            Dim paramName As New SqlParameter("@iName ", SqlDbType.VarChar, 55)

            pcmd1.CommandText = "select iCost,iName from Spar where iId='" & pparam & "'"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                paramprice.Value = dr2("iCost")
                paramName.Value = dr2("iName")

            End While
            dr2.Close()
            While paramprice.Value = 0
                paramprice.Value = 0
                paramName.Value = ""
            End While


            pcmd2.Parameters.Add(paramphoneno)
            pcmd2.Parameters.Add(parampass)
            pcmd2.Parameters.Add(paramcomp)
            pcmd2.Parameters.Add(paramprice)
            pcmd2.Parameters.Add(paramName)




            Dim da1 As New SqlDataAdapter
            da1.InsertCommand = pcmd2
            da1.InsertCommand.ExecuteNonQuery()
            pcmd2.Parameters.Clear()
            pcmd1.CommandText = "select iOrderInStock from Spar where iId='" & pparam & "'"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                order = dr2("iOrderInStock")
            End While
            dr2.Close()

            order = order + 1
            pcmd1.Connection = con
            pcmd1.CommandText = "update Spar set iOrderInStock='" & order & "' where iId='" & pparam & "';"
            Dim da As New SqlDataAdapter
            da.InsertCommand = pcmd1
            da.InsertCommand.ExecuteNonQuery()
            pcmd1.Parameters.Clear()
            MessageBox.Show("Your Order has been Placed!" & vbNewLine & "Your Product can be collected From the Store")
            con.Close()
            Me.Refresh()

        Else
            MessageBox.Show("Sorry for the Inconvenience!!" & vbNewLine & "Please do check out other products ")
            con.Close()

            ' MessageBox.Show("You have clicked the Cancel button")
        End If
        'Catch EX As Exception
        'End Try
    End Sub

    Private Sub slPictureBox1_Click(sender As Object, e As EventArgs) Handles slPictureBox1.Click
        SInStock(1)
    End Sub

    Private Sub slPictureBox2_Click(sender As Object, e As EventArgs) Handles slPictureBox2.Click
        SInStock(2)
    End Sub

    Private Sub slPictureBox3_Click(sender As Object, e As EventArgs) Handles slPictureBox3.Click
        SInStock(3)
    End Sub

    Private Sub slPictureBox4_Click(sender As Object, e As EventArgs) Handles slPictureBox4.Click
        SInStock(4)
    End Sub

    Private Sub slPictureBox5_Click(sender As Object, e As EventArgs) Handles slPictureBox5.Click
        SInStock(5)
    End Sub

    Private Sub slPictureBox6_Click(sender As Object, e As EventArgs) Handles slPictureBox6.Click
        SInStock(6)
    End Sub

    Private Sub btnLevis_Click(sender As Object, e As EventArgs) Handles btnLevis.Click
        textt = btnLevis.Text
        SAPI.Speak(textt)
        PanelLevis.Visible = True
        PanelPuma.Visible = False
        PanelMain.Visible = False
        con.Open()
        Try
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Levis where iId=1"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                lnLabel1.Text = dr2("iName")
                lPictureBox1.Image = Image.FromFile(dr2("iImage"))
                lPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                lcLabel1.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    llabel1.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Levis where iId=2"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                lnLabel2.Text = dr2("iName")
                lPictureBox2.Image = Image.FromFile(dr2("iImage"))
                lPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage

                lcLabel2.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    llabel2.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Levis where iId=3"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                lnLabel3.Text = dr2("iName")
                lPictureBox3.Image = Image.FromFile(dr2("iImage"))
                lPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage

                lcLabel3.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    llabel3.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Levis where iId=4"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                lnLabel4.Text = dr2("iName")
                lPictureBox4.Image = Image.FromFile(dr2("iImage"))
                lPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage

                lcLabel4.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    llabel4.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Levis where iId=5"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                lnLabel5.Text = dr2("iName")
                lPictureBox5.Image = Image.FromFile(dr2("iImage"))
                lPictureBox5.SizeMode = PictureBoxSizeMode.StretchImage

                lcLabel5.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    llabel5.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from Levis where iID=6"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                lnLabel6.Text = dr2("iName")
                lPictureBox6.Image = Image.FromFile(dr2("iImage"))
                lPictureBox6.SizeMode = PictureBoxSizeMode.StretchImage

                lcLabel6.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    llabel6.Visible = True
                End If
            End While
            dr2.Close()
        Catch ee As Exception
            Console.WriteLine("Exception caught:{0}", ee)
        End Try
        con.Close()


    End Sub

    Private Sub btniStore_Click(sender As Object, e As EventArgs) Handles btniStore.Click
        textt = btniStore.Text
        SAPI.Speak(textt)
        Button1_Click(e, e)
        PanelLevis.Visible = False
        PanelIStore.Visible = True
        PanelPuma.Visible = False
        PanelMain.Visible = False
        PanelSpar.Visible = False
        con.Open()

        Try
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from IStore where iId=1"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                islnLabel1.Text = dr2("iName")
                islPictureBox1.Image = Image.FromFile(dr2("iImage"))
                islPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                islcLabel1.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    Islabel1.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from IStore where iId=2"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                islnLabel2.Text = dr2("iName")
                islPictureBox2.Image = Image.FromFile(dr2("iImage"))
                islPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage

                islcLabel2.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    Islabel2.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from IStore where iId=3"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                islnLabel3.Text = dr2("iName")
                islPictureBox3.Image = Image.FromFile(dr2("iImage"))
                islPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage

                islcLabel3.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    Islabel3.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from IStore where iId=4"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                islnLabel4.Text = dr2("iName")
                islPictureBox4.Image = Image.FromFile(dr2("iImage"))
                islPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage

                islcLabel4.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    Islabel4.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from IStore where iId=5"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                islnLabel5.Text = dr2("iName")
                islPictureBox5.Image = Image.FromFile(dr2("iImage"))
                islPictureBox5.SizeMode = PictureBoxSizeMode.StretchImage

                islcLabel5.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    Islabel5.Visible = True
                End If
            End While
            dr2.Close()
            pcmd1.CommandText = "select iName,iImage,iQuantity,iCost from IStore where iId=6"
            dr2 = pcmd1.ExecuteReader
            While dr2.Read
                islnLabel6.Text = dr2("iName")
                islPictureBox6.Image = Image.FromFile(dr2("iImage"))
                islPictureBox6.SizeMode = PictureBoxSizeMode.StretchImage

                islcLabel6.Text = dr2("iCost")
                Dim b As Integer = dr2("iQuantity")
                If b = 0 Then
                    Islabel6.Visible = True
                End If
            End While
            dr2.Close()
            con.Close()

        Catch ee As Exception
            Console.WriteLine("Exception caught:{0}", ee)
        End Try

    End Sub
    Private Sub ISInStock(ByVal pparam As Integer)
        Dim order As Integer
        Dim testMsg As String
        con.Open()

        Try
            testMsg = MsgBox("Do You Want to order this item", vbYesNo + vbExclamation, "Test Message")

            If testMsg = 6 Then

                pcmd2.Connection = con
                pcmd2.CommandText = "INSERT INTO Orderrr(CustomerPhoneNO,CustomerOrders,company,price,iName) VALUES(@CustomerPhoneNO,@CustomerOrders,@company,@price,@iName)"

                Dim paramphoneno As New SqlParameter("@CustomerPhoneNO", SqlDbType.VarChar, 55)
                paramphoneno.Value = LoginForm.phone
                Dim parampass As New SqlParameter("@CustomerOrders ", SqlDbType.VarChar, 55)
                parampass.Value = pparam
                Dim paramcomp As New SqlParameter("@company ", SqlDbType.VarChar, 55)
                paramcomp.Value = "IStore"
                Dim paramprice As New SqlParameter("@price ", SqlDbType.Money, 55)
                Dim paramName As New SqlParameter("@iName ", SqlDbType.VarChar, 55)

                pcmd1.CommandText = "select iCost,iName from IStore where iId='" & pparam & "'"
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    paramprice.Value = dr2("iCost")
                    paramName.Value = dr2("iName")

                End While
                dr2.Close()
                While paramprice.Value = 0
                    paramprice.Value = 0
                    paramName.Value = ""
                End While


                pcmd2.Parameters.Add(paramphoneno)
                pcmd2.Parameters.Add(parampass)
                pcmd2.Parameters.Add(paramcomp)
                pcmd2.Parameters.Add(paramprice)
                pcmd2.Parameters.Add(paramName)




                Dim da1 As New SqlDataAdapter
                da1.InsertCommand = pcmd2
                da1.InsertCommand.ExecuteNonQuery()
                pcmd2.Parameters.Clear()

                pcmd1.CommandText = "select iOrderInStock from IStore where iId='" & pparam & "'"
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    order = dr2("iOrderInStock")
                End While
                dr2.Close()

                order = order + 1
                pcmd1.Connection = con
                pcmd1.CommandText = "update IStore set iOrderInStock='" & order & "' where iId='" & pparam & "';"
                Dim da As New SqlDataAdapter
                da.InsertCommand = pcmd1
                da.InsertCommand.ExecuteNonQuery()
                pcmd1.Parameters.Clear()
                MessageBox.Show("Your Order has been Placed!" & vbNewLine & "Your Product can be collected From the Store")
                con.Close()
                Me.Refresh()

            Else
                MessageBox.Show("Sorry for the Inconvenience!!" & vbNewLine & "Please do check out other products ")
                con.Close()

                MessageBox.Show("You have clicked the Cancel button")
            End If
        Catch EX As Exception
        End Try
    End Sub
    Private Sub islPictureBox1_Click(sender As Object, e As EventArgs) Handles islPictureBox1.Click
        ISInStock(1)
    End Sub

    Private Sub islPictureBox2_Click(sender As Object, e As EventArgs) Handles islPictureBox2.Click
        ISInStock(2)

    End Sub

    Private Sub islPictureBox3_Click(sender As Object, e As EventArgs) Handles islPictureBox3.Click
        ISInStock(3)

    End Sub

    Private Sub islPictureBox4_Click(sender As Object, e As EventArgs) Handles islPictureBox4.Click
        ISInStock(4)

    End Sub

    Private Sub islPictureBox5_Click(sender As Object, e As EventArgs) Handles islPictureBox5.Click
        ISInStock(5)

    End Sub

    Private Sub islPictureBox6_Click(sender As Object, e As EventArgs) Handles islPictureBox6.Click
        ISInStock(6)

    End Sub

    Private Sub ISoutofstock(ByVal pparam As Integer)
        con.Open()
        Dim order As Integer
        Dim testMsg As String
        Try
            testMsg = MsgBox("Do You Want to order this item", vbYesNo + vbExclamation, "Test Message")
            If testMsg = 6 Then

                pcmd1.CommandText = "select iOrderOutOFStock from IStore where iId='" & pparam & "'"
                dr2 = pcmd1.ExecuteReader
                While dr2.Read
                    order = dr2("iOrderOutOFStock")
                End While
                dr2.Close()

                order = order + 1
                pcmd1.Connection = con
                pcmd1.CommandText = "update IStore set iOrderOutOFStock='" & order & "' where iId='" & pparam & "';"
                Dim da As New SqlDataAdapter
                da.InsertCommand = pcmd1
                da.InsertCommand.ExecuteNonQuery()
                pcmd1.CommandText = "update CustDetails set CustomerOrders='IStore," & pparam & "' where CustomerPhoneNO='" & LoginForm.phone & "';"
                Dim da2 As New SqlDataAdapter
                da2.InsertCommand = pcmd1
                da2.InsertCommand.ExecuteNonQuery()
                MessageBox.Show("Your Order has been Placed!" & vbNewLine & "Your Product can be collected After 2 Working Days")
                con.Close()

            Else
                MessageBox.Show("Sorry for the Inconvenience!!" & vbNewLine & "Please do check out other products ")
                con.Close()

                ' MessageBox.Show("You have clicked the Cancel button")
            End If
        Catch EX As Exception
            MessageBox.Show(order, pparam)
        End Try
    End Sub

    Private Sub Islabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Islabel1.LinkClicked
        ISoutofstock(1)
    End Sub

    Private Sub Islabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Islabel2.LinkClicked
        ISoutofstock(2)
    End Sub

    Private Sub Islabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Islabel3.LinkClicked
        ISoutofstock(3)
    End Sub

    Private Sub Islabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Islabel4.LinkClicked
        ISoutofstock(4)
    End Sub

    Private Sub Islabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Islabel5.LinkClicked
        ISoutofstock(5)
    End Sub

    Private Sub Islabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Islabel6.LinkClicked
        ISoutofstock(6)
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Paymentt.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form1.Show()
    End Sub
End Class

