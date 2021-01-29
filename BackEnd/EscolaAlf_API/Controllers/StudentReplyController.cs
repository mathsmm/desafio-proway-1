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
    public class StudentReplyController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IStudentReply _iStudentReply;
        private readonly ITemplate _iTemplate;
        private readonly GradeCalculationService _gradeCalculationService;
        public StudentReplyController(IRepository repository, IStudentReply iStudentReply, ITemplate iTemplate, GradeCalculationService gradeCalculationService)
        {
            this._repository = repository;
            this._iStudentReply = iStudentReply;
            this._iTemplate = iTemplate;
            this._gradeCalculationService = gradeCalculationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _iStudentReply.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting all the replies, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("id={studentReplyId}")]
        public async Task<IActionResult> GetById(int studentReplyId)
        {
            try
            {
                return Ok(await _iStudentReply.GetByIdAsync(studentReplyId, includeTestQuestion: true));
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting the reply by its id, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("studentid={studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            try
            {
                return Ok(await _iStudentReply.GetByStudentIdAsync(studentId));
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting the reply by its student_id, an error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentReply studentReply)
        {
            try
            {
                _repository.Add(studentReply);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(studentReply);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When posting the reply, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("id={studentReplyId}")]
        public async Task<IActionResult> Put(int studentReplyId, StudentReply studentReply)
        {
            try
            {
                if (await _iStudentReply.GetByIdAsync(studentReplyId, includeTestQuestion: false) == null)
                {
                    return NotFound();
                }
                _repository.Update(studentReply);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(studentReply);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the reply, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("id={studentReplyId}")]
        public async Task<IActionResult> Delete(int studentReplyId)
        {
            try
            {
                var registeredStudentReply = await _iStudentReply.GetByIdAsync(studentReplyId, includeTestQuestion: false);
                if (registeredStudentReply == null)
                {
                    return NotFound();
                }
                _repository.Delete(registeredStudentReply);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(new {message="Deleted!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When deleting the reply, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }
    }
}