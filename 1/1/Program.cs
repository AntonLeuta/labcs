using System;

class Student : IEquatable<Student>
{
    private string firstName;
    private string lastName;
    private string group;
    private string studentId;
    private int course;

    public Student(string firstName, string lastName, string group, string studentId, int course)
    {
        if (firstName == null || lastName == null || group == null || studentId == null)
            throw new ArgumentNullException();

        this.firstName = firstName;
        this.lastName = lastName;
        this.group = group;
        this.studentId = studentId;
        this.course = course;
    }

    public string FirstName
    {
        get { return firstName; }
    }

    public string LastName
    {
        get { return lastName; }
    }

    public string Group
    {
        get { return group; }
    }

    public string StudentId
    {
        get { return studentId; }
    }

    public int Course
    {
        get { return course; }
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} - {studentId}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Student))
            return false;

        return Equals((Student)obj);
    }

    public override int GetHashCode()
    {
        return studentId.GetHashCode();
    }

    public bool Equals(Student other)
    {
        return studentId == other.studentId;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Student student = new Student("FirstName", "LastName", "Group1", "123456", 2);
            Console.WriteLine(student.FirstName); // FirstName
            Console.WriteLine(student.LastName); // LastName
            Console.WriteLine(student.Group); // Group1
            Console.WriteLine(student.StudentId); // 123456
            Console.WriteLine(student.Course); // 2
            Console.WriteLine(student); // FirstName LastName - 123456

            Student student2 = new Student("FirstName1", "LastName1", "Group2", "654321", 4);
            Console.WriteLine(student.Equals(student2)); // False

            Console.WriteLine(student.GetHashCode()); // 123456.GetHashCode()
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("An argument is null.");
        }
    }
}