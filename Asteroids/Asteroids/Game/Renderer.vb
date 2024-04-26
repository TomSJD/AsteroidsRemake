﻿Imports System.Reflection.Metadata

Public Class Renderer
    ' A method that takes in 2 points and draws a line made of rectangles of a given size passed in between them using Graphics.
    Public Shared Sub DrawLine(ByVal device As Graphics, ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal size As Single)
        Dim dx As Single = x2 - x1
        Dim dy As Single = y2 - y1
        Dim length As Single = Math.Sqrt(dx * dx + dy * dy)
        Dim angle As Single = Math.Atan2(dy, dx)
        Dim cos As Single = Math.Cos(angle)
        Dim sin As Single = Math.Sin(angle)
        For i As Single = 0 To length Step size
            Dim x As Single = x1 + cos * i
            Dim y As Single = y1 + sin * i
            Utils.WrapCoordinates(x, y, x, y)
            device.FillRectangle(Brushes.White, x, y, size, size)
        Next
    End Sub

    Public Shared Sub DrawWireFrameModel(device As Graphics, vecModelCoords() As PointF, x As Single, y As Single, rotation As Single, scale As Single, colour As Brush)
        Dim vertexCount As Integer = vecModelCoords.Count
        Dim transformedCoords(vertexCount) As PointF

        ' Rotate points
        For i As Integer = 0 To vertexCount - 1
            transformedCoords(i) = New PointF(
                vecModelCoords(i).X * Math.Cos(rotation) - vecModelCoords(i).Y * Math.Sin(rotation),
                vecModelCoords(i).X * Math.Sin(rotation) + vecModelCoords(i).Y * Math.Cos(rotation)
            )
        Next

        ' Scale points
        For i As Integer = 0 To vertexCount - 1
            transformedCoords(i) = New PointF(
                transformedCoords(i).X * scale,
                transformedCoords(i).Y * scale
            )
        Next

        ' Translate points
        For i As Integer = 0 To vertexCount - 1
            transformedCoords(i) = New PointF(
                transformedCoords(i).X + x,
                transformedCoords(i).Y + y
            )
        Next

        ' Draw lines between points
        For i As Integer = 0 To vertexCount - 1
            Dim j As Integer = i + 1
            DrawLine(device,
                     transformedCoords(i Mod vertexCount).X,
                     transformedCoords(i Mod vertexCount).Y,
                     transformedCoords(j Mod vertexCount).X,
                     transformedCoords(j Mod vertexCount).Y,
                     8
            )
        Next
    End Sub
End Class
