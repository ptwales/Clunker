Public Sub AssocMain()
    BasicConstructor
End Sub

Private Sub BasicConstructor()

    Dim clunk
    Set clunk = Factory()

    Dim a
    Set a = clunk.assoc("key", "val")

    Assert a.key = "key", "Key is incorrect"
    Assert a.value = "val", "Value is incorrect"

End Sub
