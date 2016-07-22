Private Const DLL = "C:\Users\cheez\Documents\Code\Clunker\Clunker\bin\Debug\Clunker.dll"
Private Const FACTORY_OBJECT_NAME = "Clunker.Factory"

Public Function Factory()

    Set Factory = GetObject(DLL, FACTORY_OBJECT_NAME)

End Function
