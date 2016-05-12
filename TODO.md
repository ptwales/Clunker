 
# TODO

## Documentation

Documentation will be created with doxygen, but still using Visual Studio's `///` xml notation.

## Testing

Nunit will be used for unit testing the C# code itself and integration testing for PowerShell, Microsoft Office VBA, and maybe some other scripting languages as well. An automated framework for doing the integration testing in different languages is required.


## Classes

In VBEX, collections and dictionaries were passed off to

### Mutable vs. Immutable

### Lambda

Lambdas were acheived in VBEX by parsing strings and writing functions to a blank module at run time. Since C# is compiled, source code cannot be modified at run time.  Lambdas should still be included, somehow, and still be created by parsing strings.
