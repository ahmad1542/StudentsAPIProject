using Microsoft.AspNetCore.Mvc;
using StudentApiBusinessLayer.Services;
using StudentDataAccessLayer.Models;
namespace StudentApi.Controllers {
    [ApiController]
    [Route("api/Students")]

    public class StudentsController(IStudentService stService) : ControllerBase {

        private readonly IStudentService _stService = stService;


        [HttpGet("All", Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllStudents() {
            var studentsList = await _stService.GetAllStudents();
            if (studentsList == null)
                return NotFound("No Student Found!");
            return Ok(studentsList);
        }

        [HttpGet("Passed", Name = "GetPassedStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPassedStudents() {
            var studentsList = await _stService.GetPassedStudents();
            if (studentsList == null) return NotFound("No Students Found!");
            return Ok(studentsList);
        }

        [HttpGet("AverageGrade", Name = "GetAverageGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAverageGrade() {
            var studentsAvgGrade = await _stService.GetAverageGrade();
            if (studentsAvgGrade == 0) return NotFound("There is no student found!");
            return Ok(studentsAvgGrade);
        }


        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentById(int id) {
            if (id < 1)
                return BadRequest($"This ID {id} not accepted");

            var st = await _stService.GetStudentById(id);
            if (st == null) return NotFound($"There is no student exist with id: {id}!");
            return Ok(st);
        }

        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStudent(StudentDTO newStudent) {

            if (newStudent == null || String.IsNullOrEmpty(newStudent.Name) || newStudent.Age <= 0)
                return BadRequest("Invalid student data!");

            var stId = await _stService.AddStudent(newStudent);
            return CreatedAtRoute("GetStudentById", new { id = newStudent.Id }, newStudent);
        }

        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(int id) {

            if (id < 1)
                return BadRequest($"This ID {id} not accepted");

            if (!await _stService.DeleteStudent(id))
                return NotFound($"There is no student exist with id: {id}");
            return Ok($"Student with id {id} has been deleted successfully.");
        }

        [HttpPut("{id}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(int id, StudentDTO updatedStudent) {
            if (id < 1 || updatedStudent == null || String.IsNullOrEmpty(updatedStudent.Name) || updatedStudent.Age <= 0)
                return BadRequest("Invalid student data!");
            if (!await _stService.UpdateStudent(id, updatedStudent))
                return NotFound($"There is no student exist with id: {id}");
            updatedStudent.Id = id;
            return Ok(updatedStudent);
        }


    }
}
