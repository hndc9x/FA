using AutoMapper;
using FPTCertification.Business;
using FPTCertification.Business.Models;
using FPTCertification.Business.Services;
using FPTCertification.Data.Models;
using FPTCertification.WebApi.Helpers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTCertification.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ExamController : ControllerBase
    {
        private readonly ExamServices _examServices;

        public ExamController(ExamServices examServices)
        {
            _examServices = examServices;
        }
        [HttpGet("all")]
        public IActionResult GetAllExam()
        {
            List<ResponseOnLyExam> response = new List<ResponseOnLyExam>();
            var exam = _examServices.GetAllExams().ToList();
            Global.Mapper.Map(exam, response);
            return Ok(response);
        }

        // GET: api/<ExamController>
        [HttpGet("only")]
        public IActionResult GetOnlyExams()
        {
            List<ResponseOnLyExam> response = new List<ResponseOnLyExam>();
            var exams = _examServices.GetAllExams().ToList();
            Global.Mapper.Map(exams, response);
            return Ok(response);
        }

        // GET api/<ExamController>/5
        [HttpGet("{id}")]
        public IActionResult GetExamById(int id)
        {
            ResponseOnLyExam response = new ResponseOnLyExam();
            var exam = _examServices.GetById(id);
            Global.Mapper.Map(exam, response);
            if (exam != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<ExamController>
        [HttpPost]
        public IActionResult CreateExam([FromBody] RequestCreateExam _exam)
        {
            Exam entity;
            if (ModelState.IsValid)
            {
                entity = _examServices.CreateExam(_exam);
                _examServices.Commit();
                return Created($"api/exam/{entity.Id}", _exam);
            }
            else
                return BadRequest();
        }

        // PUT api/<ExamController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RequestUpdateExam _exam)
        {
            if (id != _exam.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Exam exa = _examServices.GetExamById(_exam.Id);
                Exam entity = _examServices.UpdateExam(_exam.CopyTo(exa));
                _examServices.Commit();
                return Ok(entity);
            }
            else
                return BadRequest();
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!id.Equals(""))
            {
                var _exam = _examServices.GetExamById(id);
                if (_exam != null)
                {
                    _examServices.DeleteExam(_exam);
                    _examServices.Commit();
                    return Ok();
                }
                else
                    return NotFound();
            }
            else
                return BadRequest();
        }
    }
}
