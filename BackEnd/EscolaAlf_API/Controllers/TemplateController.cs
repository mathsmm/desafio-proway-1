using System;
using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ITemplate _iTemplate;
        public TemplateController(IRepository repository, ITemplate iTemplate)
        {
            this._repository = repository;
            this._iTemplate = iTemplate;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _iTemplate.GetAllAsync(includeTestQuestion: true));
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting all the templates, an error occurred: {ex.Message}");
            }
        }

        [HttpGet("id={studentReplyId}")]
        public async Task<IActionResult> GetById(int studentReplyId)
        {
            try
            {
                return Ok(await _iTemplate.GetByIdAsync(studentReplyId, includeTestQuestion: true));
            }
            catch (Exception ex)
            {
                return BadRequest($"While getting the template by its id, an error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Template template)
        {
            try
            {
                _repository.Add(template);
                if (await this._repository.SaveChangesAsync())
                {
                    return Ok(template);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When posting the template, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("id={templateId}")]
        public async Task<IActionResult> Put(int templateId, Template template)
        {
            try
            {
                if (await _iTemplate.GetByIdAsync(templateId, includeTestQuestion: false) == null)
                {
                    return NotFound();
                }
                _repository.Update(template);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(template);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When updating the template, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("id={templateId}")]
        public async Task<IActionResult> Delete(int templateId)
        {
            try
            {
                var registeredTemplate = await _iTemplate.GetByIdAsync(templateId, includeTestQuestion: false);
                if (registeredTemplate == null)
                {
                    return NotFound();
                }
                _repository.Delete(registeredTemplate);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok(new {message="Deleted!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"When deleting the template, an error ocurred: {ex.Message}");
            }
            return BadRequest();
        }
    }
}