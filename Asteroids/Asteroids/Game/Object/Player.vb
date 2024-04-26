Public Class Player : Inherits GameObject

    Private p_shipModel As List(Of PointF) = New List(Of PointF) From {
        New PointF(0, -5.5),
        New PointF(-2.5, 2.5),
        New PointF(2.5, 2.5)
    }

    Public Sub New(x As Single, y As Single, size As Single)
        MyBase.New(x, y, size)
    End Sub

    Public Overrides Sub Tick()
        If InputManager.IsKeyDown(Keys.Left) Then
            Angle -= 0.1
        ElseIf InputManager.IsKeyDown(Keys.Right) Then
            Angle += 0.1
        End If

        If InputManager.IsKeyDown(Keys.Up) Then
            DX += Math.Sin(Angle) * 2
            DY += -Math.Cos(Angle) * 2
        End If

        X += DX
        Y += DY
        Utils.WrapCoordinates(X, Y, X, Y)
    End Sub

    Public Overrides Sub Render(device As Graphics)
        Renderer.DrawWireFrameModel(device, p_shipModel, X, Y, Angle, 10, Brushes.White)
    End Sub
End Class
