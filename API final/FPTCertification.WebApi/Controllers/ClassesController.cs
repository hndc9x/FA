using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FPTCertification.Data;
using FPTCertification.Data.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using FPTCertification.Business;
using FPTCertification.Business.Services;
using System.Net;
using FPTCertification.WebApi.Helpers;
using FPTCertification.Business.Models;
using log4net;

namespace FPTCertification.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ClassesController : ControllerBase
    {
        private readonly ClassServices _classServices;
        private readonly MemberServices _memberServices;
        private readonly ILog log;

        public ClassesController(ClassServices classServices, MemberServices memberServices)
        {
            log = this.Log();
            log.Info("my message");
            _classServices = classServices;
            _memberServices = memberServices;
        }

        // GET: api/classes/only
        /// <summary>
        /// Get only classes
        /// </summary>
        /// <returns>
        /// List entities of classes follow model ReponseGetOnlyClasses
        /// </returns>
        [HttpGet("only")]
        public IActionResult GetOnlyClasses()
        {
            List<ReponseGetOnlyClasses> response = new List<ReponseGetOnlyClasses>();
            var classes = _classServices.GetAllClasses().ToList();
            Global.Mapper.Map(classes, response);
            return Ok(response);
        }

        // Get: api/classes/all
        [HttpGet("all")]
        public IActionResult GetAllClasses()
        {
            List<ReponseGetAllClasses> response = new List<ReponseGetAllClasses>();
            var classes = _classServices.GetAllClasses().ToList();
            Global.Mapper.Map(classes, response);
            foreach (var item in response)
            {
                var members = _memberServices.GetMemberByClassId(item.Id);
                List<ResponseSelectMember> responseMember = new List<ResponseSelectMember>();
                Global.Mapper.Map(members,responseMember);
                item.Member = responseMember;
            }       
            return Ok(response);
        }

        // GET: api/classes/2
        /// <summary>
        /// Get Class by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return a class with specific Id</returns>
        [HttpGet("{id}")]
        public IActionResult GetClassById(int id)
        {
            ReponseGetAllClasses response = new ReponseGetAllClasses();
            var _class = _classServices.GetClassById(id);
            Global.Mapper.Map(_class, response);
            var members = _memberServices.GetMemberByClassId(_class.Id);
            List<ResponseSelectMember> responseMember = new List<ResponseSelectMember>();
            Global.Mapper.Map(members, responseMember);
            response.Member = responseMember;

            if (_class != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Classes/name/java
        /// <summary>
        /// Get Classes By Name
        /// </summary>
        /// <param name="search"></param>
        /// <returns>return a list Class contains search param</returns>
        [HttpGet("name/{search}")]
        public IActionResult GetClassesByName(string search)
        {
            if (search.Equals(""))
            {
                return BadRequest();
            }
            List<ReponseGetOnlyClasses> response = new List<ReponseGetOnlyClasses>();
            var classes = _classServices.GetClassesByName(search);
            Global.Mapper.Map(classes, response);
            if(classes.Count == 0)
            {
                return NotFound();
            }
            else { 
                return Ok(response);
            }
        }

        // POST: api/Classes
        /// <summary>
        /// Create new Class
        /// </summary>
        /// <param name="_classes"></param>
        /// <returns>return entity Classes</returns>
        [HttpPost]
        public IActionResult CreateClasses([FromBody] RequestCreateClasses _classes)
        {
            Classes entity;
            if (ModelState.IsValid)
            {   
                entity = _classServices.CreateClasses(_classes);
                _classServices.Commit();
                return Created($"api/classes/{entity.Id}", _classes);
            }
            else
                return BadRequest();
        }

        // PUT api/Classes/5
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_classes"> follow model RequesteUpdateClasses</param>
        /// <returns>N/A</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateClass(int id, [FromBody] RequesteUpdateClasses _classes)
        {
            if(id != _classes.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Classes classes = _classServices.GetClassById(_classes.Id);
                Classes entity = _classServices.UpdateClasses(_classes.CopyTo(classes));
                _classServices.Commit();
                _classes.ToModel(entity);
                return Ok(_classes);
            }
            else
                return BadRequest();
        }

        // DELETE api/Classes/5
        /// <summary>
        /// Delete Class
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return deleted Class</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var _classes = _classServices.GetClassById(id);
                if (_classes != null)
                {
                    _classServices.DeleteClasses(_classes);
                    _classServices.Commit();
                    return Ok(_classes);
                }
                else
                    return NotFound();
            }
            else
                return BadRequest();
        }

        // PATCH: api/classes/2/activated
        /// <summary>
        /// Change Status of a Class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_classes"></param>
        /// <returns>Updated Status Class</returns>
        [HttpPatch("{id}/activated")]
        public IActionResult ChangeStatus(int id, [FromBody] RequestUpdateStatusClass _classes)
        {
            if (id != _classes.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Classes classes = _classServices.ChangeStatus(_classes);
                _classServices.Commit();
                _classes.ToModel(classes);
                return Ok(_classes);
            }
            else
                return BadRequest();
        }
    }
}
