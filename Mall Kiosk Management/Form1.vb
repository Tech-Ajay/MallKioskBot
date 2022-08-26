

Imports System.Speech
Imports System.Data.SqlClient
Public Class Form1
    Dim con As New SqlConnection
    Dim pcmd1 As New SqlCommand
    'SPEECH SYNTHESIZER 
    Dim synth As New Synthesis.SpeechSynthesizer
    'SPEECH RECOGNISOR 
    Dim WithEvents reco As New Recognition.SpeechRecognitionEngine
    Dim second As Integer
    Dim strDaySection As String
    Dim tmpTime As Integer


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        second = second + 1
        If second >= 6 Then
            Timer1.Stop() 'Timer stops functioning

            synth.Speak(strDaySection)

            synth.Speak("Max, at your service")

            Dim str As String
            pcmd1.CommandText = "select CustomerName from CustDetails where CustomerPhoneNO='" & LoginForm.phone & "'"
            Dim dr1 As SqlDataReader
            dr1 = pcmd1.ExecuteReader
            While dr1.Read
                str = dr1("CustomerName")
                synth.Speak("HEY  " & str &
                            " ....ENJOY YOUR SHOPPING!")
            End While
            dr1.Close()

        End If
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        FormDirection.Show()
        Me.Hide()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        FoemStock1.Show()
        Me.Hide()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ajayn\Documents\Mall.mdf;Integrated Security=True;Connect Timeout=30"
        con.Open()
        ' connections
        pcmd1.Connection = con
        Timer1.Start()
        'Timer starts functioning

        tmpTime = Now().Hour
        If tmpTime > 0 And tmpTime < 12 Then
            strDaySection = "Good Morning"

        ElseIf tmpTime > 12 And tmpTime < 18 Then
        strDaySection = "Good Afternoon"

        ElseIf tmpTime > 18 And tmpTime < 0 Then
        strDaySection = "Good Evening"
        Else
            strDaySection = "Hey"
        End If
        reco.SetInputToDefaultAudioDevice()
        Dim gram As New Recognition.SrgsGrammar.SrgsDocument
        Dim storeRule As New Recognition.SrgsGrammar.SrgsRule("option")

        Dim storesList As New Recognition.SrgsGrammar.SrgsOneOf("Direction", "navigation", "goods", "stock", "parking")
        storeRule.Add(storesList)
        gram.Rules.Add(storeRule)
        gram.Root = storeRule
        reco.LoadGrammar(New Recognition.Grammar(gram))
        reco.RecognizeAsync()
    End Sub
    Private Sub reco_RecognizeCompleted(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognizeCompletedEventArgs) Handles reco.RecognizeCompleted
        reco.RecognizeAsync()
    End Sub
    Private Sub reco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognized
        Dim synth As New Synthesis.SpeechSynthesizer
        Select Case e.Result.Text
            Case "direction"
                Me.Hide()
                FormDirection.Show()
                synth.Speak("direction")
                Exit Select
            Case "navigation"
                Me.Hide()
                FormDirection.Show()
                synth.Speak("navigation")
                Exit Select
            Case "goods"
                FoemStock1.Show()
                synth.Speak("goods")
                Me.Close()
                Exit Select

            Case "parking"
                Parking.Show()
                synth.Speak("parking")
                Me.Close()
                Exit Select
            Case "stock"
                FoemStock1.Show()
                synth.Speak("stock")
                Me.Close()

        End Select
    End Sub
    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click

        FormDirection.Show()
        synth.Speak("direction")
        Me.Hide()
    End Sub
    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        FoemStock1.Show()
        synth.Speak("stock")

        Me.Hide()
    End Sub

    Private Sub Panel3_Click(sender As Object, e As PaintEventArgs) Handles Panel3.Click
        synth.Speak("Parking")
        Parking.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        synth.Speak("Parking")
        Parking.Show()
        Me.Hide()
    End Sub
End Class
