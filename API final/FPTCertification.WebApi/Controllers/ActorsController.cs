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

namespace FPTCertification.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ActorsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IActorServices _actorServices;

        public ActorsController(IActorServices actorServices)
        {
            var logger = this.Log();
            logger.Info("my message");
            _actorServices = actorServices;
        }

        // GET: api/Actors/all
        [HttpGet("only")]
        //[DisableCors]
        //[Authorize]
        //[Authorize(Roles = RoleName.USER)]
        public  IActionResult GetActors()
        {
            int x = int.Parse("hihi");
            List<ResponseOnlyActorModel> response = new List<ResponseOnlyActorModel>();
            var result = _actorServices.GetActors().ToList();
            Global.Mapper.Map(result, response);
            return Ok(response);
        }
        [HttpGet("all")]
        //[DisableCors]
        //[Authorize]
        //[Authorize(Roles = RoleName.USER)]
        public IActionResult GetOnlyActors()
        {
            ResponseOnlySkill result = new ResponseOnlySkill();
            return Ok(_actorServices.GetActors());
            //return StatusCode((int)HttpStatusCode.Unauthorized,default);
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var actor = await _context.Actors.FindAsync(id);

            if (actor == null)
            {
                return NotFound();
            }
            return actor;
        }

        // PUT: api/Actors/5
        /// <summary>
        /// Get booking
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, RequestUpdateSkill actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }

            _context.Entry(actor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPatch("{id}/param")]
        public async Task<IActionResult> EditLasname(int id, ActorModel actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }
            var entity = _context.Actors.Find(id);
            switch (actor.Column)
            {
                case nameof(entity.FirstName):
                    entity.FirstName = actor.Value;
                    break;

            }
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        
        /// <summary>
        /// POST: api/Actors
        /// Input: actor model
        /// Output: response actor
        /// </summary>
        [HttpPost]
        [Authorize]
        public IActionResult PostActor([FromBody]RequestCreateActorModel actor)
        {
            var entity = _actorServices.Create(actor);
            _actorServices.Commit();
            var response = new ResponseOnlyActorModel();
            response.ToModel(entity);
            return Ok(response);
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> DeleteActor(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.ID == id);
        }
    }
    public class ActorModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("column")]
        public string Column { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
