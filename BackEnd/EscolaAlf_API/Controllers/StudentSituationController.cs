using System;
using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Data.Services;
using EscolaAlf_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentSituationController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IStudentSituation _iStudentSituation;
        private readonly AverageCalculationService _averageCalculationService;
        public StudentSituationController(IRepository repository, IStudentSituation iStudentSituation, AverageCalculationService averageCalculationService)
        {
            this._repository = repository;
            this._iStudentSituation = iStudentSituation;
            this._averageCalculationService = averageCalculationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _iStudentSituation.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting all the situations, an error ocurred: {ex.Message}");
            }
        }

        [HttpGet("studentid={studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            try
            {
                return Ok(await _iStudentSituation.GetByStudentIdAsync(studentId));
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting the situations by student_id, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("approved")]
        public async Task<IActionResult> GetApprovedStudents()
        {
            try
            {
                return Ok(await _iStudentSituation.GetByApprovalAsync(approval: true));
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting the approved students, an error occurred: {ex.Message}");
            }
        }

        [HttpPost("calculateaverage_studentid={studentId}")]
        public async Task<IActionResult> CalculateAndPostAverage(int studentId)
        {
            try
            {
                double average = _averageCalculationService.CalculateAverageOfAStudent(studentId);
                if (average >= 7)
                {
                    StudentSituation studentSituation = new StudentSituation(0, studentId, average, true);
                    _repository.Add(studentSituation);
                    if (await this._repository.SaveChangesAsync() != true)
                    {
                        return BadRequest();
                    }
                    return Ok(studentSituation);
                }
                else
                {
                    StudentSituation studentSituation = new StudentSituation(0, studentId, average, false);
                    _repository.Add(studentSituation);
                    if (await this._repository.SaveChangesAsync() != true)
                    {
                        return BadRequest();
                    }
                    return Ok(studentSituation);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When posting the situation, an error ocurred: {ex.Message}");
            }
        }

        [HttpPut("id={studentId}")]
        public async Task<IActionResult> Put(int studentSituationId, StudentSituation studentSituation)
        {
            try
            {
                if (await _iStudentSituation.GetByStudentIdAsync(studentSituationId) == null)
                {
                    return NotFound();
                }
                _repository.Update(studentSituation);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(studentSituation);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the situation, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("id={studentId}")]
        public async Task<IActionResult> Delete(int studentId)
        {
            try
            {
                var registeredStudentSituation = await _iStudentSituation.GetByIdAsync(studentId);
                if (registeredStudentSituation == null)
                {
                    return NotFound();
                }
                _repository.Delete(registeredStudentSituation);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(new {message="Deleted!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When deleting the situation, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }
    }
}