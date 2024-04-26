Public Class GameState : Inherits State

    Private p_asteroids As List(Of Asteroid)
    Private p_player As Player

    Public Overrides Sub Init()
        p_asteroids = New List(Of Asteroid)
        Dim asteroid As New Asteroid(10, 10, 128) With {
            .DX = 4,
            .DY = 4
        }
        p_asteroids.Add(asteroid)
        p_player = New Player(Game.WindowSize.Width / 2, Game.WindowSize.Height / 2, 64)
    End Sub

    Public Overrides Sub Tick()
        p_player.Tick()
        For Each asteroid As Asteroid In p_asteroids
            asteroid.Tick()
        Next
    End Sub

    Public Overrides Sub Render(device As Graphics)
        p_player.Render(device)
        For Each asteroid As Asteroid In p_asteroids
            asteroid.Render(device)
        Next
    End Sub

    Public Overrides Sub Clean()

    End Sub
End Class
