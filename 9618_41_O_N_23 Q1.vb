Imports System.IO
Imports System.Console
Imports System.Math
Imports System.Random


Module Module1

    Sub Main()
        WriteLine(IterativeVowels("house"))
        WriteLine(RecursiveVowels("house"))
        ReadKey()

    End Sub

    Function IterativeVowels(Value As String) As Integer 'take note about how the mid function in pseudocode and in Vb are different
        Dim Total As Integer                             'VB's Mid function starts from 1 and pseudocode from 0 
        Dim LengthString As Integer
        Dim FirstCharacter As Char
        Total = 0

        LengthString = Len(Value)

        For x = 0 To LengthString - 1
            FirstCharacter = Left(Value, 1)
            If FirstCharacter = "a" Or FirstCharacter = "e" Or FirstCharacter = "i" Or FirstCharacter = "o" Or FirstCharacter = "u" Then
                Total = Total + 1
            End If
            Value = Right(Value, Len(Value) - 1)
        Next
        Return Total
    End Function 'Iterative 
    Function RecursiveVowels(Value)
        Dim Total As Integer = 0
        Dim FirstCharacter As Char

        FirstCharacter = Left(Value, 1)

        If Value = "" Then ' Base case ( so when there is no value in the string, it returns the that there are no vowels
            Return Total
        ElseIf FirstCharacter = "a" Or FirstCharacter = "e" Or FirstCharacter = "i" Or FirstCharacter = "o" Or FirstCharacter = "u" Then
            Return 1 + RecursiveVowels(Right(Value, Len(Value) - 1))
        Else
            Return RecursiveVowels(Right(Value, Len(Value) - 1))
        End If
    End Function 'Recursive


End Module
