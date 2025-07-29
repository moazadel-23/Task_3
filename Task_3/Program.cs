
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Task_3
{
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        List<Course> Courses { get; set; }

        public Student(int studentId, string name, int age, List<Course> courses)
        {
            StudentId = studentId;
            Name = name;
            this.age = age;
            Courses = courses;
        }
        public string Enroll(Course course)
        {
            if (Courses.Any(s => s.CourseId == course.CourseId))
                return ("this course is adding");
            else
            {
                Courses.Add(course);
                return ("Adding sucssefly");
            }
        }

        public string StudentDetials()
        {
            return($"StudentId : {StudentId} Name : {Name} age : {age}");
        }
    }

    class Course
    {
       
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor instructor { get; set; }
        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            this.instructor = instructor;
        }
        public string CourseDetials()
        {
            string instructorName = instructor != null ? instructor.Name : "No instructor";
            return ($"CourseId : {CourseId} Title : {Title} instructor : {instructorName}");
        }
    }

    class Instructor
    {

        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }
        public string InstructorDetials()
        {
            return ($"InstructorId : {InstructorId} Name : {Name} Specialization : {Specialization}");
        }
    }

    class StudentManeger 
    {
        List<Student>Students = new List<Student>();
        List<Course> Courses = new List<Course>();
        List<Instructor> Instructors = new List<Instructor>();

       

        public bool AddStudent(Student student)
        {
            if (Students.Contains(student)) 
               return false;
            Students.Add(student);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (Instructors.Contains(instructor))
                return false;
            Instructors.Add(instructor);
            return true;
        }

        public bool AddCourse(Course course)
        {
            if (Courses.Contains(course))
                return false;
            Courses.Add(course);
            return true;
        }

        public void PrintAllStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            Console.WriteLine("All Students:");
            Students.ForEach(s => Console.WriteLine(s.StudentDetials()));
        }
        public void PrintAllCourse()
        {
            if (Courses.Count == 0)
            {
                Console.WriteLine("No Course available.");
                return;
            }

            Console.WriteLine("All Courses:");
            foreach(Course course in Courses)
            {
                Console.WriteLine(course.CourseDetials());
            }
        }
        public void PrintInstructor()
        {
            if (Instructors.Count == 0)
            {
                Console.WriteLine("No Instructors available.");
                return;
            }

            Console.WriteLine("All Instructors:");
            foreach (Instructor instructors in Instructors)
            {
                Console.WriteLine(instructors.InstructorDetials());
            }
        }
        public string SearchStudent(int id , string name)
        {
           
            for(int i =0; i < Students.Count; i++)
            {
              if(Students[i].StudentId == id || Students[i].Name == name)
                    return "is found";
              else 
                    return "not found";
            }
            return "no";
        }
        public string SearchCourse(int id, string name)
        {

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == id || Courses[i].Title == name)
                    return "is found";
                else
                    return "not found";
            }
            return "no";
        }
    }
    internal class Program
    { 

        static void Main(string[] args)
        {
            StudentManeger manager = new StudentManeger();

            int input;
            do 
            { 
               Console.WriteLine("1.Add Student");
               Console.WriteLine("2.Add Instructor");
               Console.WriteLine("3. Add Course");
               Console.WriteLine("4. Enroll Student in Course");
               Console.WriteLine("5. Show All Students");
               Console.WriteLine("6. Show All Courses");
               Console.WriteLine("7. Show All Instructors");
               Console.WriteLine("8. Find the student by id or name");
               Console.WriteLine("9. Fine the course by id or name");
               Console.WriteLine("10. Exit");
                input = Convert.ToInt32(Console.ReadLine());
            

                switch (input)
                {
                    case 1:
                        Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = Convert.ToInt32(Console.ReadLine());

                        Student newStudent = new Student(id, name, age, new List<Course>());
                        if (manager.AddStudent(newStudent))
                            Console.WriteLine("Student added successfully.");
                        else
                            Console.WriteLine("Student already exists.");
                        break;

                    case 2:
                        Console.Write("Enter Instructor ID: ");
                        int instId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string instName = Console.ReadLine();
                        Console.Write("Enter Specialization: ");
                        string specialization = Console.ReadLine();

                        Instructor newInstructor = new Instructor(instId, instName, specialization);
                        if (manager.AddInstructor(newInstructor))
                            Console.WriteLine("Instructor added successfully.");
                        else
                            Console.WriteLine("Instructor already exists.");
                        break;

                    case 3:
                        Console.Write("Enter Course ID: ");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Course Title: ");
                        string title = Console.ReadLine();
                        Course newCourse = new Course(courseId, title, null);
                        if (manager.AddCourse(newCourse))
                            Console.WriteLine("Course added successfully.");
                        else
                            Console.WriteLine("Course already exists.");
                        break;

                    case 4:
                        Student student = new Student(1, "moaz", 21, new List<Course>());
                        Console.WriteLine("Enter CourseId");
                        int Course_Id = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Title");
                        string Title_book = Console.ReadLine();

                        Course course = new(Course_Id, Title_book, null);

                        student.Enroll(course);
                        Console.WriteLine(student.Enroll(course));

                        break;

                    case 5:
                        manager.PrintAllStudents();
                        break;

                    case 6:
                        manager.PrintAllCourse();
                        break;

                    case 7:
                        manager.PrintInstructor();
                        break;

                    case 8:
                        manager.SearchStudent(23115, "moaz" );
                        break;
                    case 9:
                        manager.SearchCourse(23115, "Database");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
                } while (input != 10);
        }
    }
}
