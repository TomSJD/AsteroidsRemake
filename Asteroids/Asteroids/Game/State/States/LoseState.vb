Public Class LoseState : Inherits State

    Private p_score As Integer

    Public Sub New(score As Integer)
        p_score = score
    End Sub

    Public Overrides Sub Init()

    End Sub

    Public Overrides Sub Tick()
        If InputManager.IsKeyDown(Keys.Space) Then
            Game.StateManager.ChangeState(New GameState)
        End If
    End Sub

    Public Overrides Sub Render(device As Graphics)
        device.DrawString("You Lose!", New Font("Arial", 24), Brushes.White, 100, 100)
        device.DrawString("Score: " & p_score, New Font("Arial", 24), Brushes.White, 100, 150)
        device.DrawString("Press Enter to play again", New Font("Arial", 24), Brushes.White, 100, 200)
    End Sub

    Public Overrides Sub Clean()

    End Sub
End Class
