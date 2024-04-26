Public Class Asteroid : Inherits GameObject

    Private p_asteroidModel() As PointF
    Public Property ShouldRemove As Boolean

    Public Sub New(x As Single, y As Single, size As Single)
        MyBase.New(x, y, size)
        ShouldRemove = False
        GenerateAsteroidModel()
    End Sub

    Private Sub GenerateAsteroidModel()
        Dim vertexes As Single = 10
        ReDim p_asteroidModel(vertexes - 1)
        For i As Single = 0 To vertexes - 1
            Dim angle As Single = (i / vertexes) * (2 * Math.PI)
            Dim radius As Single = 0.8 + (Rnd() * 0.4)
            p_asteroidModel(i) = New PointF(Math.Sin(angle) * radius, Math.Cos(angle) * radius)
        Next
    End Sub

    Public Overrides Sub Tick()
        X += DX
        Y += DY
        Angle += 0.01
        Utils.WrapCoordinates(X, Y, X, Y)
    End Sub

    Public Overrides Sub Render(device As Graphics)
        Renderer.DrawWireFrameModel(device, p_asteroidModel, X, Y, Angle, Size, Brushes.White)
    End Sub
End Class
