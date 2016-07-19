Sub Assert(pred, msg)

    If Not pred Then
        Wscript.Echo msg
    End If

End Sub
