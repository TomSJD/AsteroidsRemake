Public Class GameState : Inherits State

    Private p_asteroids As List(Of Asteroid)
    Private Shared p_bullets As List(Of Bullet)
    Private p_player As Player

    Public Overrides Sub Init()
        p_asteroids = New List(Of Asteroid)
        Dim asteroid As New Asteroid(10, 10, 128) With {
            .DX = 4,
            .DY = 4
        }
        p_asteroids.Add(asteroid)
        p_bullets = New List(Of Bullet)
        p_player = New Player(Game.WindowSize.Width / 2, Game.WindowSize.Height / 2, 64)
    End Sub

    Public Overrides Sub Tick()
        p_player.Tick()
        For Each asteroid As Asteroid In p_asteroids
            asteroid.Tick()
        Next

        p_bullets.RemoveAll(Function(bullet) bullet.X < 0 Or bullet.X > Game.WindowSize.Width Or bullet.Y < 0 Or bullet.Y > Game.WindowSize.Height)
        For Each bullet As Bullet In p_bullets
            bullet.Tick()
        Next
    End Sub

    Public Overrides Sub Render(device As Graphics)
        p_player.Render(device)
        For Each asteroid As Asteroid In p_asteroids
            asteroid.Render(device)
        Next
        For Each bullet As Bullet In p_bullets
            bullet.Render(device)
        Next
    End Sub

    Public Shared Sub AddBullet(bullet As Bullet)
        p_bullets.Add(bullet)
    End Sub

    Public Overrides Sub Clean()

    End Sub
End Class
