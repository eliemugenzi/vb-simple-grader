Imports System
Imports System.Data


Interface IMarksCalculation
    Function calculateTotal(ByVal catM As Double, ByVal examM As Double)
    Sub setGrade(ByVal marks As Double)
    
End Interface

Class Student
    Implements IMarksCalculation
    protected Dim names As String, catMarks As Double, examMarks As Double, grade As Char

    Public Sub New (ByVal _names As String, ByVal _catMarks As Double, _examMarks As Double)
        names = _names
        catMarks = _catMarks
        examMarks = _examMarks
    End Sub
    
    Sub setGrade(ByVal finalMarks As Double) Implements  IMarksCalculation.setGrade
        If finalMarks > 85 Then
            grade = "A"
            Else If finalMarks <= 85 And  finalMarks > 75 Then
                grade = "B"
                Else If finalMarks <= 75 And finalMarks > 60 Then
                    grade = "C"
                    Else If finalMarks <=60 And finalMarks >= 50 Then
                        grade = "D"
                        Else 
                            grade = "F"
        End If
        
    End Sub
    
    Function GetGrade()
        Return grade
        
    End Function
    
    Public Function getTotalMarks(ByVal x As Double, ByVal y As Double) Implements  IMarksCalculation.calculateTotal
        Dim finalMarks As Double = x + y
        setGrade(finalMarks)
        Return finalMarks
    End Function
    
    Public  Function returnMarks()
        Return getTotalMarks(catMarks, examMarks)
    End Function
    
    Public Function getNames()
        Return names
    End Function
    
End Class




Module Program
    Sub Main(args As String())
        Dim studentList As New List(Of Student)
        Dim studentCount As Integer
        Console.WriteLine("How many students do you want to record?")
        studentCount = Console.ReadLine()
        
        For i = 1 To studentCount
            Dim studentName As String, studentCatMarks As Double, studentExamMarks As Double
            Console.WriteLine("Enter the student names")
            studentName = Console.ReadLine()
            Console.WriteLine("Enter the CAT marks for {0} (out of 50)", studentName)
            studentCatMarks = Console.ReadLine()
            Console.WriteLine("Enter the exam marks for {0} (out of 50)", studentName)
            studentExamMarks = Console.ReadLine()
            
            If (studentCatMarks > 50 And studentCatMarks < 0) Or (studentExamMarks > 50 And studentExamMarks < 0) Then
                Console.WriteLine("None of CAT or exam marks should be between 0 and 50")
                Else 
                    Dim student As New Student(studentName, studentCatMarks, studentExamMarks)
                    studentList.Add(student) 
            End If
        Next
        
        ' Sort the students by their final marks
        For j = 0 To studentList.Count - 1
            For x = j + 1 To studentList.Count - 1
                
                If studentList(j).returnMarks() < studentList(x).returnMarks() Then
                    Dim temp = studentList(j)
                    studentList(j) = studentList(x)
                    studentList(x) = temp
                End If
            Next
        Next
        Console.WriteLine("Student results")
        For xx = 0 To studentList.Count - 1
            Console.WriteLine("{0}. {1}: Final marks: {2}, Grade: {3}", xx + 1, studentList(xx).getNames(), studentList(xx).returnMarks(), studentList(xx).GetGrade())
            
        Next
        
    End Sub
End Module
