Imports System

Class Student
    Private name As String
    Private age As Integer

    Public Sub New(ByVal name As String, ByVal age As Integer)
        Me.name = name
        Me.age = age
    End Sub

    Public Sub UpdateDetails(ByVal name As String, ByVal age As Integer)
        Me.name = name
        Me.age = age
    End Sub

    Public Sub DisplayDetails()
        Console.WriteLine("Name: " & name)
        Console.WriteLine("Age: " & age)
    End Sub

    Public ReadOnly Property GetName() As String
        Get
            Return name
        End Get
    End Property

    Public ReadOnly Property GetAge() As Integer
        Get
            Return age
        End Get
    End Property
End Class

Module Program
    Sub Main(args As String())
        Dim students As New List(Of Student)()

        While True
            Console.WriteLine("Menu:")
            Console.WriteLine("1. Insert Student")
            Console.WriteLine("2. Update Student Details")
            Console.WriteLine("3. Delete Student")
            Console.WriteLine("4. Display Student Details")
            Console.WriteLine("5. Exit")
            Console.WriteLine("Enter your choice: ")

            Dim choice As Integer = Convert.ToInt32(Console.ReadLine())

            Select Case choice
                Case 1
                    Console.WriteLine("Enter student name: ")
                    Dim name As String = Console.ReadLine()
                    Console.WriteLine("Enter student age: ")
                    Dim age As Integer = Convert.ToInt32(Console.ReadLine())
                    Dim newStudent As New Student(name, age)
                    students.Add(newStudent)
                    Console.WriteLine("Student details inserted successfully.")
                Case 2
                    Console.WriteLine("Enter student name to update details: ")
                    Dim updateName As String = Console.ReadLine()
                    Dim found As Boolean = False
                    For Each student In students
                        If student.GetName().Equals(updateName) Then
                            Console.WriteLine("Enter new name: ")
                            Dim newName As String = Console.ReadLine()
                            Console.WriteLine("Enter new age: ")
                            Dim newAge As Integer = Convert.ToInt32(Console.ReadLine())
                            student.UpdateDetails(newName, newAge)
                            Console.WriteLine("Details updated successfully.")
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
                        Console.WriteLine("Student not found.")
                    End If
                Case 3
                    Console.WriteLine("Enter student name to delete: ")
                    Dim deleteName As String = Console.ReadLine()
                    Dim found As Boolean = False
                    For Each student In students
                        If student.GetName().Equals(deleteName) Then
                            students.Remove(student)
                            Console.WriteLine("Student deleted successfully.")
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
                        Console.WriteLine("Student not found.")
                    End If
                Case 4
                    If students.Count = 0 Then
                        Console.WriteLine("No students to display.")
                    Else
                        Console.WriteLine("Student Details:")
                        For Each student In students
                            student.DisplayDetails()
                            Console.WriteLine("-------------------------")
                        Next
                    End If
                Case 5
                    Console.WriteLine("Exiting program.")
                    Exit While
                Case Else
                    Console.WriteLine("Invalid choice. Please enter a valid option.")
            End Select
        End While
    End Sub
End Module
