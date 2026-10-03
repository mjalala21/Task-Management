using Microsoft.AspNetCore.Http.HttpResults;
using StudentApi.Models;
namespace StudentApi.Services
{
    public class StudentService
    {
        private static List<Student> students = new List<Student>();
            
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await Task.FromResult(students);
        }

        public async Task<Student?> GetStudentAsync(int id)
        {

            var student = students.FirstOrDefault(s => s.Id == id);
            return await Task.FromResult(student);
        }

        public Task AddStudentAsync(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
            return Task.CompletedTask;
        }

        public Task<Student?> UpdateStudentAsync(int id, Student student)
        {
            var excistingStudent = students.FirstOrDefault(s => s.Id == id);

            if(excistingStudent== null)
            {
                return Task.FromResult<Student?>(null);
            }

            excistingStudent.Name = student.Name;
            excistingStudent.Age = student.Age;
            excistingStudent.Address = student.Address;
            excistingStudent.phoneNo = student.phoneNo;

            return  Task.FromResult<Student?>(excistingStudent);
        }

        public Task<bool> DeleteStudentAsync(int id)
        {
            var StudentToDelete = students.FirstOrDefault(s => s.Id == id);
            if (StudentToDelete == null)
            {
                return Task.FromResult(false);
            }

            students.Remove(StudentToDelete);

            return Task.FromResult(true);

        }
    }
}
