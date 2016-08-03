Dim clunk
Set clunk = Factory()

Public Sub ListMain()

    EmptyMake
    SingleMake
    MultipleMake
    Wscript.Echo "Clunker.List passed all tests"

End Sub
Private Sub EmptyMake()

    Dim es
    Set es = clunk.List.make()

    Wscript.Echo es.show
    Assert es.size = 0, "Size of empty List is not zero."
    Assert es.isEmpty,  "Empty List is not empty"

End Sub
Private Sub SingleMake()

    Dim ss
    Set ss = clunk.List.make("Hello")

    Wscript.Echo ss.show
    Assert ss.size = 1,        "Size of single element List is not 1"
    Assert Not ss.isEmpty,     "Single element List is empty"
    Assert ss.head = "Hello",  "Head is not ""hello"""
    Assert ss.lowerBound = 0,  "Lower bound is not 0"
    Assert ss.upperBound = 0,  "Upper bound is not 0"
    Assert ss.item(ss.lowerBound) = "Hello", "Get item at lower bound"

End Sub
Private Sub MultipleMake()

    Dim xs
    Set xs = clunk.List.make(1, "a", "b")

    Wscript.Echo xs.show
    Assert xs.size = 3,        "Size is 3"
    Assert Not xs.isEmpty,     "Is not empty"
    Assert xs.item(0) = 1,     "Get item 0"
    Assert xs.item(1) = "a",   "Get item 1"
    Assert xs.item(2) = "b",   "Get item 2"

End Sub
