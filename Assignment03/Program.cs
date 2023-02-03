using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
/* Use /Abstraction/ to define different classes for each person type 
 * such as Student and Instructor. These classes should have behavior 
 * for that type of person.
 */


namespace Assignment03
{
    interface IPersonService
    {
        int getAge(Person person);
        decimal getSalary(Person person);
        List<String> getAddresses(Person person);
    }

    class PersonService : IPersonService
    {
        public List<string> getAddresses(Person person)
        {
            return person.addresses;
        }

        public int getAge(Person person)
        {
            var today = DateTime.Today;
            var age = today.Year - person.dob.Year;
            if (person.dob.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        public decimal getSalary(Person person)
        {
            if (person.salary < 0)
            {
                return 0;
            }
            else
            {
                return person.salary;
            }
        }
    }
    // IStudentService and IInstructorService inherit from IPersonService
    interface IInstructorService : IPersonService
    {
        string BelongtoDept(Instructor ins);
        bool HeadDept(Instructor ins);
        int YearsofExperience(Instructor ins);
    }

    class InstructorService : IInstructorService
    {
        // Belong to Department
        public string BelongtoDept(Instructor ins)
        {
            return $"Belong to Department: {ins.dept}";
        }

        public List<string> getAddresses(Person person)
        {
            throw new NotImplementedException();
        }

        public int getAge(Person person)
        {
            throw new NotImplementedException();
        }

        public decimal getSalary(Person person)
        {
            throw new NotImplementedException();
        }

        // Wheather is the head of the department
        public bool HeadDept(Instructor ins)
        {
            if (ins.title == "HEAD")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Calculate his year of experience based on Join Date
        public int YearsofExperience(Instructor ins)
        {
            var today = DateTime.Today;
            var year = today.Year - ins.JoinDate.Year;
            if (ins.JoinDate.Date > today.AddYears(-year))
            {
                year--;
            }
            return year;
        }
    }

    interface IStudentService : IPersonService
    {
        List<string> GetCourse(Student stu);
        int calculateGPA(Student stu);
        
    }

    interface ICourseService
    {
        List<Student> StuList(Student stu);
    }

    interface IDepartmentService
    {
        Instructor HeadofDept(Department dept);
        decimal Budget(Department dept);
        
    }

    class Department
    {
        public string deptname
        {
            get;
            set;
        }
        public int deptid
        {
            get;
            set;
        }
        public decimal budget
        {
            get;
            set;
        }
    }

    class Course
    {
        public string name
        {
            get;
            set;
        }
    }

    // create abstraction class to store the types of person
    abstract class Person
    {
        // the id of person
        public int id
        {
            get;
            set;
        }
        // use Encapsulation to keep First Name and Last Name of each person
        private string FirstName;
        private string LastName;
        public Person(string FName, string LName)
        {
            this.FirstName = FName;
            this.LastName = LName;
        }

        // the Full name of person
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        // the date of birth of each person
        public DateTime dob
        {
            get;
            set;
        }
        public List<String> addresses
        {
            get;
            set;
        }
        public decimal salary
        {
            get;
            set;
        }
        
        public string gender
        {
            get;
            set;
        }
        // the Course of person
        public int course
        {
            get;
            set;
        }
        abstract public string TakeCourse();
    }

    // Use Inheritance to inherit from Person to Instructor
    class Instructor : Person
    {
        // the join date
        public DateTime JoinDate
        {
            get;
            set;
        }

        public string dept
        {
            get;
            set;
        }

        public string title
        {
            get;
            set;
        }

        public Instructor(string FName, string LName) : base(FName, LName)
        {
        }

        // Use override to accomplish Polymorphism
        public override string TakeCourse()
        {
            return $"{FullName} Teach Course {course}";
        }
    }

    // Use Inheritance to inherit from Person to Student
    class Student : Person
    {
        public Student(string FName, string LName) : base(FName, LName)
        {
        }

        // Use override to accomplish Polymorphism
        public override string TakeCourse()
        {
            return $"{FullName} Take Course {course}";
        }
    }

    

    public class Program
	{
		static void Main(string[] args)
        {
            Student Stu = new Student("Patrick", "Guo");
            Stu.course = 10001;
            Stu.dob = new DateTime(1996, 09, 23);
            Instructor Ins = new Instructor("Ravi", "Acharya");
            Ins.course = 10001;
            PersonService personService = new PersonService();
            Console.WriteLine(Stu.TakeCourse());
            Console.WriteLine(Ins.TakeCourse());
            Console.WriteLine(personService.getAge(Stu));

        }
	}
    
}




