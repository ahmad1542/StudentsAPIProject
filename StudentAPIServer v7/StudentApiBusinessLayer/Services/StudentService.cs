using StudentDataAccessLayer.Models;
using StudentDataAccessLayer.Repository;

namespace StudentApiBusinessLayer.Services {
    public class StudentService(IStudentRepo repo) : IStudentService {

        private readonly IStudentRepo _repo = repo;

        public async Task<IEnumerable<StudentDTO>> GetAllStudents() {
            return await _repo.GetAllStudents();
        }

        public async Task<IEnumerable<StudentDTO>> GetPassedStudents() {
            return await _repo.GetPassedStudents();
        }

        public async Task<double> GetAverageGrade() {
            return await _repo.GetAverageGrade();
        }

        public async Task<StudentDTO> GetStudentById(int id) {
            return await _repo.GetStudentById(id);
        }

        public async Task<int> AddStudent(StudentDTO newStudent) {
            return await _repo.AddStudent(newStudent);
        }

        public async Task<bool> DeleteStudent(int id) {
            return await _repo.DeleteStudent(id);
        }

        public async Task<bool> UpdateStudent(int id, StudentDTO updatedStudent) {
            return await _repo.UpdateStudent(id, updatedStudent);
        }
    }
}
