Public Class Asteroid : Inherits GameObject

    Public Sub New(x As Single, y As Single, size As Single)
        MyBase.New(x, y, size)
    End Sub

    Public Overrides Sub Tick()
        X += DX
        Y += DY
        Utils.WrapCoordinates(X, Y, X, Y)
    End Sub

    Public Overrides Sub Render(device As Graphics)
        For ix As Short = 0 To Size
            For iy As Short = 0 To Size
                Dim fx As Single = X + ix
                Dim fy As Single = Y + iy
                Utils.WrapCoordinates(fx, fy, fx, fy)
                device.FillRectangle(Brushes.White, fx, fy, 1, 1)
            Next
        Next
    End Sub
End Class
