Clunker
=======

The goal of Clunker is simple.  Provide a COM accessible standard library for 
use in common scripting languages that lack advanced data types or builtin
methods.

Currently only the collections library is being worked on but there will be 
support for expanding existing tools like database access and subprocess
handling.

The collection library is based on the scala library to not compete with the
.NET libraries and  so you can bring some functional programming principles to
your language.

Due to the limitations of COM and Clunker's use of immutable data objects.  All
object creation is done through the Factory object.  Simply create a Factory
object as a global or local variable and create Clunker collections from it.

    Dim clunk As New Clunker.Factory
    Set list = Clunker.seq(1, 2, 3, 4)
    Set f = Clunker.onObject("indexWhere", 3)
    f.apply(list) ' result = 2
    Set f = Clunker.onObject("indexWhere", 3)
    f.apply(list).show() ' Clunker.Some(2)

