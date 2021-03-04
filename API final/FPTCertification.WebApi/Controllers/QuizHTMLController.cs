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
    public class QuizHTMLController : ControllerBase
    {
        private readonly QuizHTMLServices _quizhtmlServices;
        public QuizHTMLController(QuizHTMLServices quizhtmlServices)
        {
            _quizhtmlServices = quizhtmlServices;
        }
        // GET: api/skills/only
        /// <summary>
        /// Get only Quiz
        /// </summary>
        /// <returns>
        /// List entities of skills follow model ResponseOnlySkills
        /// </returns>
        [HttpGet("only")]
        public IActionResult GetQuizHTML()
        {
            List<ResponseOnlyQuizHTML> response = new List<ResponseOnlyQuizHTML>();
            var skills = _quizhtmlServices.GetAllQuizHTML().ToList();
            Global.Mapper.Map(skills, response);
            return Ok(response);
        }

        // GET: api/skills/2
        /// <summary>
        /// Get Quiz by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return a Skill with specific Id</returns>
        [HttpGet("{id}")]
        public IActionResult GetQuizHTMLById(int id)
        {
            ResponseOnlyQuizHTML response = new ResponseOnlyQuizHTML();
            var _skill = _quizhtmlServices.GetQuizHTMLById(id);
            Global.Mapper.Map(_skill, response);
            if (_skill != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Skills/name/java
        /// <summary>
        /// Get Skills By Name
        /// </summary>
        /// <param name="search"></param>
        /// <returns>return a list Skill contains search param</returns>
        //[HttpGet("name/{search}")]
        //public IActionResult GetSkillsByName(string search)
        //{
        //    if (search.Equals(""))
        //    {
        //        return BadRequest();
        //    }
        //    List<ResponseOnlySkill> response = new List<ResponseOnlySkill>();
        //    var skills = _quizhtmlServices.GetSkillsByName(search);
        //    Global.Mapper.Map(skills, response);
        //    if (skills.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(response);
        //    }
        //}

        // POST: api/Skills
        /// <summary>
        /// Create new Quiz Test HTML
        /// </summary>
        /// <param name="_skill">follow the model RequestCreateSkill</param>
        /// <returns>return entity Skill</returns>
        [HttpPost]
        public IActionResult CreateClasses([FromBody] RequestCreateQuizHTML _skill)
        {
            QuizHTML entity;
            if (ModelState.IsValid)
            {
                entity = _quizhtmlServices.CreateQuiz(_skill);
                _quizhtmlServices.Commit();
                return Created($"api/skills/{entity.Id}", _skill);
            }
            else
                return BadRequest();
        }

        // PUT api/Skill/5
        /// <summary>
        /// Update Skill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_skill"> follow model RequesteUpdateSkill</param>
        /// <returns>Updated Skill</returns>
        //[HttpPut("{id}")]
        //public IActionResult UpdateSkill(int id, [FromBody] RequestUpdateSkill _skill)
        //{
        //    if (id != _skill.Id)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        Skill skill = _quizhtmlServices.GetSkillById(_skill.Id);
        //        Skill entity = _quizhtmlServices.UpdateSkill(_skill.CopyTo(skill));
        //        _skill.ToModel(entity);
        //        _quizhtmlServices.Commit();
        //        return Ok(_skill);
        //    }
        //    else
        //        return BadRequest();
        //}

        // DELETE api/Skill/5
        /// <summary>
        /// Delete Skill
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return deleted Skill</returns>
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    if (id != 0)
        //    {
        //        var _skill = _quizhtmlServices.GetSkillById(id);
        //        if (_skill != null)
        //        {
        //            _quizhtmlServices.DeleteSkill(_skill);
        //            _quizhtmlServices.Commit();
        //            return Ok(_skill);
        //        }
        //        else
        //            return NotFound();
        //    }
        //    else
        //        return BadRequest();
        //}

        // PATCH: api/skills/2/activated
        /// <summary>
        /// Change Status of a Skill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_skill"></param>
        /// <returns>Updated Status Skill</returns>
        //[HttpPatch("{id}/activated")]
        //public IActionResult ChangeStatus(int id, [FromBody] RequestUpdateStatusSkill _skill)
        //{
        //    if (id != _skill.Id)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        Skill skill = _quizhtmlServices.ChangeStatus(_skill);
        //        _quizhtmlServices.Commit();
        //        _skill.ToModel(skill);
        //        return Ok(_skill);
        //    }
        //    else
        //        return BadRequest();
        //}
    }
}
