using StudentDataAccessLayer.Models;

namespace StudentApiBusinessLayer.Services {
    public interface IStudentService {

        Task<IEnumerable<StudentDTO>> GetAllStudents();
        Task<IEnumerable<StudentDTO>> GetPassedStudents();
        Task<double> GetAverageGrade();
        Task<StudentDTO> GetStudentById(int id);
        Task<int> AddStudent(StudentDTO newStudent);
        Task<bool> DeleteStudent(int id);
        Task<bool> UpdateStudent(int id, StudentDTO updatedStudent);

    }
}
