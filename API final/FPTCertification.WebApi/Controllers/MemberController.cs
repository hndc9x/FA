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
    public class MemberController : ControllerBase
    {
        private readonly MemberServices _memberServices;

        public MemberController(MemberServices memberServices)
        {
            _memberServices = memberServices;
        }
        // GET: api/<MemberController>
        [HttpGet("all")]
        public IActionResult GetAllMember()
        {
            List<ResponseAllMember> response = new List<ResponseAllMember>();
            var member = _memberServices.GetAllMembers().ToList();
            Global.Mapper.Map(member, response);
            foreach (var item in response)
            {
                //    var members = _memberServices.GetMemberByClassId(item.Id);
                //    List<ResponseSelectMember> responseMember = new List<ResponseSelectMember>();
                //    Global.Mapper.Map(members, responseMember);
                //    item.Member = responseMember;
            }
            return Ok(response);
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public IActionResult GetMemberById(string id)
        {
            ResponseAllMember response = new ResponseAllMember();
            var member = _memberServices.GetById(id);
            Global.Mapper.Map(member, response);
            if (!member.Equals(""))
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<MemberController>
        [HttpPost]
        public IActionResult CreateMember([FromBody] RequestCreateMember _member)
        {
            AppUser user = new AppUser();
            Member entity;
            if (ModelState.IsValid)
            {
                entity = _memberServices.CreateMember(_member);
                _memberServices.Commit();
                return Created($"api/member/{entity.Id}", _member);
            }
            else
                return BadRequest();
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] AdminRequestUpdateMember _member)
        {
            if (!id.Equals(id))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Member mem = _memberServices.GetById(id);
                Member entity = _memberServices.UpdateMember(_member.CopyTo(mem));
                _memberServices.Commit();
                return Ok(entity);
            }
            else
                return BadRequest();
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!id.Equals(""))
            {
                var _member = _memberServices.GetMemberById(id);
                if (_member != null)
                {
                    _memberServices.DeleteMember(_member);
                    _memberServices.Commit();
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
