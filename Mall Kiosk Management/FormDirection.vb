Imports System.Speech
Public Class FormDirection
        Dim synth As New Synthesis.SpeechSynthesizer
        Dim WithEvents reco As New Recognition.SpeechRecognitionEngine
        Dim textt As String
        Private Sub btnPuma_Click(sender As Object, e As EventArgs) Handles btnPuma.Click
        'PictureBox2.Image = Image.FromFile("C:\Users\Sneha Badrinath\Desktop\company\aj\Puma.jpg")
        RichTextBox1.Text = btnPuma.Text & vbNewLine& + " Ground Floor,Head West, 3rd store in the right "
            textt = RichTextBox1.Text
            synth.SpeakAsync(textt)

        'PictureBox2.Visible = True
        RichTextBox1.Visible = True
        'pictureboxmain.Visible = False
    End Sub
        Private Sub btnLevis_Click(sender As Object, e As EventArgs) Handles btnLevis.Click

        'PictureBox2.Visible = True
        RichTextBox1.Visible = True
        ' pictureboxmain.Visible = False
        'PictureBox2.Image = Image.FromFile("C:\Users\SnehaBadrinath\Desktop\company\aj\Puma.jpg")
        RichTextBox1.Text = btnLevis.Text & vbNewLine& + "Third Floor, Store no 36"
            textt = RichTextBox1.Text
            synth.Speak(textt)
        End Sub


    Private Sub btnSpar_Click(sender As Object, e As EventArgs) Handles btnSpar.Click
        'PictureBox2.Visible = True
        RichTextBox1.Visible = True
        ' pictureboxmain.Visible = False
        ' PictureBox2.Image = Image.FromFile("C:\Users\Sneha Badrinath\Desktop\company\aj\spar.jpg")

        RichTextBox1.Text = btnSpar.Text & vbNewLine& + "Entry 1: Ground Floor, Head east for 10meters. " & vbNewLine & "Entry 2: First Floor,head north east,the first enterance"
            textt = RichTextBox1.Text
            synth.Speak(textt)
        End Sub

    Private Sub btniStore_Click(sender As Object, e As EventArgs) Handles btniStore.Click
        ' PictureBox2.Visible = True
        RichTextBox1.Visible = True
        ' pictureboxmain.Visible = False
        'PictureBox2.Image = Image.FromFile("C:\Users\Sneha Badrinath\Desktop\company\aj\iStore.jpg")
        RichTextBox1.Text = btniStore.Text & vbNewLine& + "ground Floor, Store no 3"
            textt = RichTextBox1.Text
            synth.Speak(textt)
        End Sub




    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'PictureBox2.Visible = False
        RichTextBox1.Visible = False
        'pictureboxmain.Visible = True
        ' pictureboxmain.Image = Image.FromFile("C:\Users\Sneha Badrinath\Desktop\company\aj\aaa.png")
        reco.SetInputToDefaultAudioDevice()

        Dim gram As New Recognition.SrgsGrammar.SrgsDocument

        Dim storeRule As New Recognition.SrgsGrammar.SrgsRule("store")

        Dim storesList As New Recognition.SrgsGrammar.SrgsOneOf("return", "exit", "end", "previous", "go back", "puma", "spar", "levis", "i store")

        storeRule.Add(storesList)

        gram.Rules.Add(storeRule)

        gram.Root = storeRule

        reco.LoadGrammar(New Recognition.Grammar(gram))

        reco.RecognizeAsync()

        Panel1.HorizontalScroll.Visible = True
        Panel1.AutoScroll = True
        Panel1.VerticalScroll.Visible = False


    End Sub
    Private Sub reco_RecognizeCompleted(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognizeCompletedEventArgs) Handles reco.RecognizeCompleted

        reco.RecognizeAsync()

    End Sub


    'speech recognition
    Private Sub reco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognized

        Select Case e.Result.Text

            Case "puma"
                btnPuma_Click(sender, New EventArgs)
            Case "levi's"
                btnLevis_Click(sender, New EventArgs)

            Case "jockey"

            Case "i store"
                btniStore_Click(sender, New EventArgs)



            Case "go back"
                Form1.Show()
                Me.Hide()
            Case "previous"
                Form1.Show()
                Me.Hide()
            Case "return"
                Form1.Show()
                Me.Hide()
            Case "exit"
                Form1.Show()
                Me.Hide()
            Case "end"
                Form1.Show()
                Me.Hide()
        End Select

    End Sub


End Class
