Imports System.IO
Imports System.Math
Imports System.Console
Imports System.Random

'Queue uses FIFO Princible
'So the first item in, is the first out

Module Module1
    Dim Queue(49) As String
    Dim HeadPointer As Integer
    Dim TailPointer As Integer
    Dim Records(49) As RecordData
    Dim NumberOfRecords As Integer
    Sub Main()
        'ALWAYS initalize in submain
        HeadPointer = 0
        TailPointer = 0
        ReadData()
        NumberOfRecords = 0
        While HeadPointer <> TailPointer
            TotalData()
        End While
        OutputRecords()
        ReadKey()
    End Sub

    Sub Enqueue(Value As String) ' If the queue is full the procedure outputs suitable message, if the queue is not full the procedure inserts the parameter into the queue and updates the relevant pointers
        If TailPointer = 49 Then ' If Tailpointer points to the last avaiable slot in the queue it is full
            WriteLine("The queue is currently full")
        Else
            Queue(TailPointer) = Value
            TailPointer = TailPointer + 1
            If HeadPointer = -1 Then ' The headpointer is the front of the queue, and we dont want it to be a number outside of the range of the queue, as we need to use it to check if the queue is empty
                HeadPointer = 0
            End If
        End If
    End Sub
    Function Dequeue() ' if the queue is empty the function outputs suitable message and returns Empty, if the queue is not empty the function returns the first element in the queue and updates the relevant pointers
        If HeadPointer = -1 Or HeadPointer = TailPointer Then
            WriteLine("Queue is Empty")
            Return "Empty"
        Else
            HeadPointer = HeadPointer + 1
            Return Queue(HeadPointer - 1)
        End If
    End Function
    Sub ReadData()
        Try
            Dim GameDataReader As New System.IO.StreamReader("C:\Computer Science Files\9618_41_O_N_23\QueueData.txt")
            Do Until GameDataReader.EndOfStream
                Enqueue(GameDataReader.ReadLine)
            Loop
            GameDataReader.Close()
        Catch ex As Exception
            WriteLine("No File")
        End Try
    End Sub
    Structure RecordData
        Dim ID As String
        Dim Total As Integer
    End Structure
    Sub TotalData()
        Dim DataAccessed As String
        Dim Flag As Boolean
        DataAccessed = Dequeue()
        Flag = False

        If NumberOfRecords = 0 Then
            Records(NumberOfRecords).ID = DataAccessed
            Records(NumberOfRecords).Total = 1
            Flag = True
            NumberOfRecords = NumberOfRecords + 1
        Else
            For X = 0 To NumberOfRecords - 1
                If Records(X).ID = DataAccessed Then
                    Records(X).Total = Records(X).Total + 1
                    Flag = True
                End If
            Next X
        End If

        If Flag = False Then
            Records(NumberOfRecords).ID = DataAccessed
            Records(NumberOfRecords).Total = 1
            NumberOfRecords = NumberOfRecords + 1
        End If
    End Sub
    Sub OutputRecords()
        For X = 0 To NumberOfRecords - 1
            WriteLine("ID" & Records(X).ID & " Total " & Records(X).Total)
        Next
    End Sub
End Module
