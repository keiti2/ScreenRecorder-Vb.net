Imports Accord.Video.FFMPEG

Public Class Form1

    Private vf As VideoFileWriter
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        vf = New VideoFileWriter()
        vf.Open("C:\Exported_Video.avi", 1920, 1080, 10, VideoCodec.MPEG4, 3000000)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim bp = New Bitmap(1920, 1080)
        Dim gr = Graphics.FromImage(bp)
        gr.CopyFromScreen(0, 0, 0, 0, New Size(bp.Width, bp.Height))
        pictureBox1.Image = bp
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        vf.WriteVideoFrame(bp)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()

        vf.Close()
    End Sub
End Class
