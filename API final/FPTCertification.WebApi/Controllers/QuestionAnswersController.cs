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
    public class QuestionAnswersController : ControllerBase
    {
        private readonly QuestionServices questionServices;
        private readonly AnswerServices answerServices;

        public QuestionAnswersController(QuestionServices _questionServices, AnswerServices _answerServices)
        {
            questionServices = _questionServices;
            answerServices = _answerServices;
        }

        // POST: api/questionanswers
        /// <summary>
        /// Create new Question
        /// </summary>
        /// <param name="question"></param>
        /// <returns>return Created Question Type</returns>
        [HttpPost]
        public IActionResult CreateQuestion([FromBody] RequestCreateQuestion question)
        {
            Question entity;
            if (ModelState.IsValid)
            {
                entity = questionServices.CreateQuestion(question);
                questionServices.Commit();
                question.ToModel(entity);
                return Created($"api/questiontypes/{entity.Id}", question);
            }
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuestonAnswer(int id, [FromBody] RequestUpdateQuestion model)
        {
            Question question;
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                question = questionServices.UpdateQuestion(model);            
                model.ToModel(question);
                questionServices.Commit();
                return Ok(model);
            }
            else
                return BadRequest();
        }

    }
}
