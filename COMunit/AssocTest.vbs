Public Sub AssocMain()
    BasicConstructor
    Wscript.Echo "Clunker.Assoc passed all tests"
End Sub

Private Sub BasicConstructor()

    Dim clunk
    Set clunk = Factory()

    Dim assocFactory
    Set assocFactory = clunk.Assoc

    Dim a
    Set a = assocFactory.assoc("key", "val")

    Wscript.Echo a.show
    Assert a.key = "key", "Key is incorrect"
    Assert a.value = "val", "Value is incorrect"

End Sub
