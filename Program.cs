using System;
using System.Collections.Generic;
using System.Linq;

// Student class to represent a student
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Course { get; set; }
    public double Grade { get; set; }

    public Student(int id, string name, int age, string email, string course, double grade)
    {
        Id = id;
        Name = name;
        Age = age;
        Email = email;
        Course = course;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Age: {Age}, Email: {Email}, Course: {Course}, Grade: {Grade:F2}";
    }
}

// Student Management System class
public class StudentManagementSystem
{
    private List<Student> students;
    private int nextId;

    public StudentManagementSystem()
    {
        students = new List<Student>();
        nextId = 1;
    }

    // Add a new student
    public void AddStudent(string name, int age, string email, string course, double grade)
    {
        var student = new Student(nextId++, name, age, email, course, grade);
        students.Add(student);
        Console.WriteLine($"Student '{name}' added successfully with ID: {student.Id}");
    }

    // View all students
    public void ViewAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\n=== All Students ===");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }

    // Find student by ID
    public Student FindStudentById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    // View student by ID
    public void ViewStudentById(int id)
    {
        var student = FindStudentById(id);
        if (student != null)
        {
            Console.WriteLine($"\n=== Student Details ===");
            Console.WriteLine(student);
        }
        else
        {
            Console.WriteLine($"Student with ID {id} not found.");
        }
    }

    // Update student information
    public void UpdateStudent(int id, string name, int age, string email, string course, double grade)
    {
        var student = FindStudentById(id);
        if (student != null)
        {
            student.Name = name;
            student.Age = age;
            student.Email = email;
            student.Course = course;
            student.Grade = grade;
            Console.WriteLine($"Student with ID {id} updated successfully.");
        }
        else
        {
            Console.WriteLine($"Student with ID {id} not found.");
        }
    }

    // Delete student
    public void DeleteStudent(int id)
    {
        var student = FindStudentById(id);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine($"Student '{student.Name}' with ID {id} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Student with ID {id} not found.");
        }
    }

    // Search students by name
    public void SearchStudentsByName(string name)
    {
        var foundStudents = students.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundStudents.Count == 0)
        {
            Console.WriteLine($"No students found with name containing '{name}'.");
            return;
        }

        Console.WriteLine($"\n=== Students with name containing '{name}' ===");
        foreach (var student in foundStudents)
        {
            Console.WriteLine(student);
        }
    }

    // Get students by course
    public void GetStudentsByCourse(string course)
    {
        var courseStudents = students.Where(s => s.Course.Equals(course, StringComparison.OrdinalIgnoreCase)).ToList();

        if (courseStudents.Count == 0)
        {
            Console.WriteLine($"No students found in course '{course}'.");
            return;
        }

        Console.WriteLine($"\n=== Students in {course} ===");
        foreach (var student in courseStudents)
        {
            Console.WriteLine(student);
        }
    }

    // Calculate average grade
    public void CalculateAverageGrade()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students to calculate average grade.");
            return;
        }

        double average = students.Average(s => s.Grade);
        Console.WriteLine($"Average grade of all students: {average:F2}");
    }
}

// Main program
public class Program
{
    private static StudentManagementSystem sms = new StudentManagementSystem();

    public static void Main(string[] args)
    {
        // Add some sample data
        sms.AddStudent("John Doe", 20, "john.doe@email.com", "Computer Science", 85.5);
        sms.AddStudent("Jane Smith", 19, "jane.smith@email.com", "Mathematics", 92.0);
        sms.AddStudent("Bob Johnson", 21, "bob.johnson@email.com", "Physics", 78.5);

        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewStudent();
                    break;
                case "2":
                    sms.ViewAllStudents();
                    break;
                case "3":
                    ViewStudent();
                    break;
                case "4":
                    UpdateStudentInfo();
                    break;
                case "5":
                    DeleteStudentById();
                    break;
                case "6":
                    SearchByName();
                    break;
                case "7":
                    FilterByCourse();
                    break;
                case "8":
                    sms.CalculateAverageGrade();
                    break;
                case "9":
                    running = false;
                    Console.WriteLine("Thank you for using Student Management System!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("=== Student Management System ===");
        Console.WriteLine("1. Add New Student");
        Console.WriteLine("2. View All Students");
        Console.WriteLine("3. View Student by ID");
        Console.WriteLine("4. Update Student");
        Console.WriteLine("5. Delete Student");
        Console.WriteLine("6. Search Students by Name");
        Console.WriteLine("7. Filter Students by Course");
        Console.WriteLine("8. Calculate Average Grade");
        Console.WriteLine("9. Exit");
        Console.Write("Enter your choice (1-9): ");
    }

    private static void AddNewStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter student age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Invalid age entered.");
            return;
        }

        Console.Write("Enter student email: ");
        string email = Console.ReadLine();

        Console.Write("Enter student course: ");
        string course = Console.ReadLine();

        Console.Write("Enter student grade: ");
        if (!double.TryParse(Console.ReadLine(), out double grade))
        {
            Console.WriteLine("Invalid grade entered.");
            return;
        }

        sms.AddStudent(name, age, email, course, grade);
    }

    private static void ViewStudent()
    {
        Console.Write("Enter student ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            sms.ViewStudentById(id);
        }
        else
        {
            Console.WriteLine("Invalid ID entered.");
        }
    }

    private static void UpdateStudentInfo()
    {
        Console.Write("Enter student ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID entered.");
            return;
        }

        var student = sms.FindStudentById(id);
        if (student == null)
        {
            Console.WriteLine($"Student with ID {id} not found.");
            return;
        }

        Console.WriteLine($"Current details: {student}");
        Console.WriteLine("Enter new details:");

        Console.Write("Enter new name: ");
        string name = Console.ReadLine();

        Console.Write("Enter new age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Invalid age entered.");
            return;
        }

        Console.Write("Enter new email: ");
        string email = Console.ReadLine();

        Console.Write("Enter new course: ");
        string course = Console.ReadLine();

        Console.Write("Enter new grade: ");
        if (!double.TryParse(Console.ReadLine(), out double grade))
        {
            Console.WriteLine("Invalid grade entered.");
            return;
        }

        sms.UpdateStudent(id, name, age, email, course, grade);
    }

    private static void DeleteStudentById()
    {
        Console.Write("Enter student ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            sms.DeleteStudent(id);
        }
        else
        {
            Console.WriteLine("Invalid ID entered.");
        }
    }

    private static void SearchByName()
    {
        Console.Write("Enter name to search: ");
        string name = Console.ReadLine();
        sms.SearchStudentsByName(name);
    }

    private static void FilterByCourse()
    {
        Console.Write("Enter course name: ");
        string course = Console.ReadLine();
        sms.GetStudentsByCourse(course);
    }
}