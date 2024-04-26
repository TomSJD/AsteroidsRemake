Public Class Utils

    ' A method that takes x, y, outputX and outputY as arguments and
    ' wraps the coordinates around the screen.
    Public Shared Sub WrapCoordinates(ByVal x As Short, ByVal y As Short, ByRef ox As Short, ByRef oy As Short)
        ox = x
        oy = y
        If x < 0 Then ox = x + Game.WindowSize.Width
        If x > Game.WindowSize.Width Then ox = x - Game.WindowSize.Width
        If y < 0 Then oy = y + Game.WindowSize.Height
        If y > Game.WindowSize.Height Then oy = y - Game.WindowSize.Height
    End Sub
End Class
