Public Class InputManager

    Private Shared keys(256) As Boolean

    Public Shared Sub Initialize(parent As PictureBox)

    End Sub

    Public Shared Sub KeyDown(sender As Object, keyEventArgs As KeyEventArgs)
        If keyEventArgs.KeyCode > keys.Length Or keyEventArgs.KeyCode < 0 Then
            Return
        End If
        keys(keyEventArgs.KeyCode) = True
    End Sub

    Public Shared Sub KeyUp(sender As Object, keyEventArgs As KeyEventArgs)
        If keyEventArgs.KeyCode > keys.Length Or keyEventArgs.KeyCode < 0 Then
            Return
        End If
        keys(keyEventArgs.KeyCode) = False
    End Sub

    Public Shared Function IsKeyDown(key As Integer) As Boolean
        If key > keys.Length Or key < 0 Then
            Return False
        End If
        Return keys(key)
    End Function
End Class
