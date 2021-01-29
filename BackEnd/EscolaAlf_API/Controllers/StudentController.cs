using System;
using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IStudent _iStudent;
        public StudentController(IRepository repository, IStudent iStudent)
        {
            this._repository = repository;
            this._iStudent = iStudent;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _iStudent.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting all the students, an error ocurred: {ex.Message}");
            }
        }

        [HttpGet("id={studentId}")]
        public async Task<IActionResult> GetById(int studentId)
        {
            try
            {
                return Ok(await _iStudent.GetByIdAsync(studentId));
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting the student by his id, an error ocurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            try
            {
                if (_iStudent.ReturnNumberOfStudents() >= 100)
                {
                    return BadRequest("The number of students must be less than 100!");
                }
                _repository.Add(student);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(student);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When posting the student, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("id={studentId}")]
        public async Task<IActionResult> Put(int studentId, Student student)
        {
            try
            {
                if (await _iStudent.GetByIdAsync(studentId) == null)
                {
                    return NotFound();
                }
                _repository.Update(student);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(student);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the student, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("id={studentId}")]
        public async Task<IActionResult> Delete(int studentId)
        {
            try
            {
                var registeredStudent = await _iStudent.GetByIdAsync(studentId);
                if (registeredStudent == null)
                {
                    return NotFound();
                }
                _repository.Delete(registeredStudent);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(new {message="Deleted!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When deleting the student, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }
    }
}