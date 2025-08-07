using Microsoft.EntityFrameworkCore;
using StudentDataAccessLayer.Models;

namespace StudentDataAccessLayer.Repository {
    public class StudentRepo : IStudentRepo {

        private readonly AppDbContext _db;

        public StudentRepo(AppDbContext db) {
            _db = db;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudents() {
            return await _db.Students.ToListAsync();
        }

        public async Task<IEnumerable<StudentDTO>> GetPassedStudents() {
            return await _db.Students.Where(student => student.Grade >= 50).ToListAsync();
        }

        public async Task<double> GetAverageGrade() {
            try {
                return await _db.Students.AverageAsync(student => student.Grade);
            } catch {
                return 0;
            }
        }

        public async Task<StudentDTO> GetStudentById(int id) {
            return await _db.Students.FindAsync(id);
        }

        public async Task<int> AddStudent(StudentDTO newStudent) {
            await _db.Students.AddAsync(newStudent);
            await _db.SaveChangesAsync();
            return newStudent.Id;
        }

        public async Task<bool> DeleteStudent(int id) {
            var st = await _db.Students.FindAsync(id);
            
            if (st == null)
                return false;

            _db.Students.Remove(st);
            var rowsAffected = await _db.SaveChangesAsync();
            return (rowsAffected > 0);
        }

        public async Task<bool> UpdateStudent(int id, StudentDTO updatedStudent) {
            var st = await _db.Students.FindAsync(id);
            if (st == null) return false;
            st.Name = updatedStudent.Name;
            st.Age = updatedStudent.Age;
            st.Grade = updatedStudent.Grade;
            var rowsAffected = await _db.SaveChangesAsync();
            return (rowsAffected > 0);
        }
    }
}
