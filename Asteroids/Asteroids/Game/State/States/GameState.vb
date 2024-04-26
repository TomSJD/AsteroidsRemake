Public Class GameState : Inherits State

    Private p_asteroids As List(Of Asteroid)
    Private Shared p_bullets As List(Of Bullet)
    Private p_player As Player
    Private p_score As Integer

    Public Overrides Sub Init()
        p_score = 0
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
        If p_asteroids.Count = 0 Then
            p_asteroids.Add(New Asteroid(2 * Math.Sin(p_player.Angle - Math.PI / 2),
                                         2 * Math.Cos(p_player.Angle - Math.PI / 2), 128) With {
                                                    .DX = Math.Sin(p_player.Angle + Rnd()) * 4,
                                                    .DY = Math.Cos(p_player.Angle + Rnd()) * 4
                                          })
            p_asteroids.Add(New Asteroid(2 * Math.Sin(p_player.Angle + Math.PI / 2),
                                         2 * Math.Cos(p_player.Angle + Math.PI / 2), 128) With {
                                                    .DX = Math.Sin(-p_player.Angle + Rnd()) * 4,
                                                    .DY = Math.Cos(-p_player.Angle + Rnd()) * 4
                                          })
        End If

        p_asteroids.RemoveAll(Function(asteroid) asteroid.ShouldRemove)
        For Each asteroid As Asteroid In p_asteroids
            If Utils.IsPointInCircle(p_player.X, p_player.Y, asteroid.X, asteroid.Y, asteroid.Size) Then
                Game.StateManager.ChangeState(New LoseState(p_score))
            End If
            asteroid.Tick()
        Next

        Randomize()
        p_bullets.RemoveAll(Function(bullet) bullet.X < 0 Or bullet.X > Game.WindowSize.Width Or bullet.Y < 0 Or bullet.Y > Game.WindowSize.Height)
        Dim newAsteroids As New List(Of Asteroid)
        For Each bullet As Bullet In p_bullets
            bullet.Tick()
            ' Collision detection
            For Each asteroid In p_asteroids
                If Utils.IsPointInCircle(bullet.X, bullet.Y, asteroid.X, asteroid.Y, asteroid.Size) And Not asteroid.ShouldRemove Then
                    p_score += 10
                    bullet.X = -100
                    asteroid.ShouldRemove = True
                    If asteroid.Size > 32 Then
                        Dim angle1 As Single = Rnd() * (Math.PI * 2)
                        Dim angle2 As Single = Rnd() * (Math.PI * 2)
                        newAsteroids.Add(New Asteroid(asteroid.X, asteroid.Y, asteroid.Size / 2) With {
                                                    .DX = Math.Sin(angle1) * 4,
                                                    .DY = Math.Cos(angle1) * 4
                                                })
                        newAsteroids.Add(New Asteroid(asteroid.X, asteroid.Y, asteroid.Size / 2) With {
                                                    .DX = Math.Sin(angle2) * 4,
                                                    .DY = Math.Cos(angle2) * 4
                                                })
                    End If
                End If
            Next
        Next
        For Each newAsteroid As Asteroid In newAsteroids
            p_asteroids.Add(newAsteroid)
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
        device.DrawString("Score: " & p_score, New Font("Arial", 24), Brushes.White, 10, 10)
    End Sub

    Public Shared Sub AddBullet(bullet As Bullet)
        p_bullets.Add(bullet)
    End Sub

    Public Overrides Sub Clean()

    End Sub
End Class
