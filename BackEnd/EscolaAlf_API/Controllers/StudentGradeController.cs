using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Data.Services;
using EscolaAlf_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentGradeController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IStudentGrade _iStudentGrade;
        private readonly IStudentReply _iStudentReply;
        private readonly ITemplate _iTemplate;
        private readonly GradeCalculationService _gradeCalculationService;
        public StudentGradeController(IRepository repository, IStudentGrade iStudentGrade, IStudentReply iStudentReply, ITemplate iTemplate, GradeCalculationService gradeCalculationService)
        {
            this._repository = repository;
            this._iStudentGrade = iStudentGrade;
            this._iStudentReply = iStudentReply;
            this._iTemplate = iTemplate;
            this._gradeCalculationService = gradeCalculationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _iStudentGrade.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting all the grades, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("studentid={studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            try
            {
                return Ok(await _iStudentGrade.GetByStudentIdAsync(studentId));
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting the grades by the student_id, an error occurred: {ex.Message}");
            }
        }

        [HttpPost("calculategrade_testid={testId}&studentid={studentId}")]
        public async Task<IActionResult> CalculateAndPostGrade(int testId, int studentId)
        {
            try
            {
                List<int> srOptionsList = _iStudentReply.ReturnStudentReplyOptionsId(testId, studentId);
                List<int> tOptionsList = _iTemplate.ReturnTemplateOptionsId(testId);
                if (srOptionsList.Count == tOptionsList.Count)
                {
                    double grade = _gradeCalculationService.CalculateGradeOfOneStudent(testId, studentId, tOptionsList, srOptionsList);
                    StudentGrade studentGrade = new StudentGrade(0, testId, studentId, grade);
                    _repository.Add(studentGrade);
                    if (await this._repository.SaveChangesAsync() != true)
                    {
                        return BadRequest();
                    }
                    return Ok(studentGrade);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"While calculatin the grade, an error occurred: {ex.Message}");
            }
        }

        [HttpPut("id={studentGradeId}")]
        public async Task<IActionResult> Put(int studentGradeId, StudentGrade studentGrade)
        {
            try
            {
                if (await _iStudentGrade.GetByIdAsync(studentGradeId) == null)
                {
                    return NotFound();
                }
                _repository.Update(studentGrade);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(studentGrade);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the grade, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("id={studentGradeId}")]
        public async Task<IActionResult> Delete(int studentGradeId)
        {
            try
            {
                var registeredStudentGrade = await _iStudentGrade.GetByIdAsync(studentGradeId);
                if (registeredStudentGrade == null)
                {
                    return NotFound();
                }
                _repository.Delete(registeredStudentGrade);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(new {message="Deleted!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When deleting the grade, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }
    }
}