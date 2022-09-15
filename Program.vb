Imports System

Module Program
    Sub Main(args As String())

        Dim llbdf() As String = {"the", "a", "an"}
        Dim x = New With {.Conn = "TEST", .Num = 59}
        Dim xList = {x}.ToList()
        Parallel.ForEach(llbdf, Function()
                                    Return New With {.Conn = "", .Num = 0
                                     }
                                End Function, Function(item, loopState, local)

                                                  local.Conn = item
                                                  local.Num += 1

                                                  Return local
                                              End Function, Function(locals)
                                                                xList.Add(locals)
                                                            End Function)


        Console.WriteLine(xList)
    End Sub
End Module
