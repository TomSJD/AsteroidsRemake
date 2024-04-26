Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim game As Game = New Game(Me, "Asteroids", New Size(1600, 900))
        game.Run()
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        InputManager.KeyUp(sender, e)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        InputManager.KeyDown(sender, e)
    End Sub
End Class
