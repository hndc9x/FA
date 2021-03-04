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
    public class QuestionTypeController : ControllerBase
    {
        private readonly QuestionTypeServices questionTypeServices;
        

        public QuestionTypeController(QuestionTypeServices _questionTypeServices)
        {
            questionTypeServices = _questionTypeServices;
        }

        // GET: api/questiontypes/only
        /// <summary>
        /// Get Question Type
        /// </summary>
        /// <returns>
        /// List entities of Question Type
        /// </returns>
        [HttpGet("only")]
        public IActionResult GetAllQuestionTypes()
        {
            List<ResponseGetQuestionType> response = new List<ResponseGetQuestionType>();
            var questionType = questionTypeServices.GetAllQuestionType().ToList();
            Global.Mapper.Map(questionType, response);
            return Ok(response);
        }

        // POST: api/questionType
        /// <summary>
        /// Create new Question Type
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns>return Created Question Type</returns>
        [HttpPost]
        public IActionResult CreateQuestionType([FromBody] RequestCreateQuestionType questionType)
        {
            QuestionType entity;
            if (ModelState.IsValid)
            {
                entity = questionTypeServices.CreateQuestionType(questionType);
                questionTypeServices.Commit();
                return Created($"api/questiontypes/{entity.Code}", questionType);
            }
            else
                return BadRequest();
        }   
    }
}
