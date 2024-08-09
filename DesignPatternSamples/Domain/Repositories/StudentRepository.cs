using DesignPatternSamples.Domain.Models;

namespace DesignPatternSamples.Domain.Repositories
{
    public class StudentRepository
    {
        private List<Student> students;

        public StudentRepository()
        {
            students = new List<Student>
        {
            new Student { ID = 1, Name = "Alice" },
            new Student { ID = 2, Name = "Bob" },
            new Student { ID = 3, Name = "Charlie" }
        };
        }

        public Student GetStudentByID(int id)
        {
            return students.FirstOrDefault(s => s.ID == id)!;
        }
    }

}
