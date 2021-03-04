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
    public class CertificationsController : ControllerBase
    {
        private readonly CertificationServices _certificationServices;

        public CertificationsController(CertificationServices certificationServices)
        {
            _certificationServices = certificationServices;
        }

        // GET: api/certifications
        /// <summary>
        /// Get All Certifications
        /// </summary>
        /// <returns>A List of Certification with Skills</returns>
        [HttpGet]
        public IActionResult GetAllCertifications()
        {
            List<ResponseAllCertification> response = new List<ResponseAllCertification>();
            var certification = _certificationServices.GetAllCertifications().ToList();
            Global.Mapper.Map(certification, response);
            foreach (var item in response)
            {
                var skills = _certificationServices.GetSkillByCertificationId(item.Id);
                List<ResponseSelectSkill> responseSkill = new List<ResponseSelectSkill>();
                Global.Mapper.Map(skills, responseSkill);
                item.Skills = responseSkill;
            }
            return Ok(response);
        }

        // GET: api/certifications/2
        /// <summary>
        /// Get Certification by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return a certification with specific Id</returns>
        [HttpGet("{id}")]
        public IActionResult GetCertificationById(int id)
        {
            ResponseAllCertification response = new ResponseAllCertification();
            var _certification = _certificationServices.GetCertificationById(id);
            Global.Mapper.Map(_certification, response);
            if (_certification != null)
            {
                var skills = _certificationServices.GetSkillByCertificationId(_certification.Id);
                List<ResponseSelectSkill> responseSkill = new List<ResponseSelectSkill>();
                Global.Mapper.Map(skills, responseSkill);
                response.Skills = responseSkill;
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/certifications
        /// <summary>
        /// Create New Certification
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Created Certification</returns>
        [HttpPost] 
        public IActionResult CreateCertification([FromBody] RequestCreateCertification model)      
        {
            Certification certification;        
            if (ModelState.IsValid)             
            {
                certification = _certificationServices.CreateCertification(model);
                var skills = _certificationServices.GetSkillByCertificationId(certification.Id);
                Global.Mapper.Map(skills, model.Skills);
                model.ToModel(certification);
                return Created($"api/certifications/{certification.Id}", model);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/Certifications/5
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Updated Certification</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateCertification(int id, [FromBody] RequestUpdateCertification model)
        {
            Certification certification;
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                certification = _certificationServices.UpdateCertification(model);
                var skills = _certificationServices.GetSkillByCertificationId(model.Id);
                Global.Mapper.Map(skills, model.Skills);
                model.ToModel(certification);
                _certificationServices.Commit();
                return Ok(model);
            }
            else
                return BadRequest();
        }

        // DELETE: api/certifications/5
        /// <summary>
        /// Delete a Certification
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCertification(int id)
        {
            if (id != 0)
            {
                var _certification = _certificationServices.GetCertificationById(id);
                if (_certification != null)
                {
                    _certificationServices.DeleteCertification(_certification);
                    _certificationServices.Commit();
                    return Ok();
                }
                else
                    return NotFound();
            }
            else
                return BadRequest();
        }

        // PATCH: api/2/activated
        /// <summary>
        /// Change Status of a Certification
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_certification"></param>
        /// <returns>Updated Status Certification</returns>
        [HttpPatch("{id}/activated")]
        public IActionResult ChangeStatus(int id, [FromBody] RequestUpdateStatusCertification _certification)
        {
            if (id != _certification.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Certification cer = _certificationServices.ChangeStatus(_certification);
                _certificationServices.Commit();
                _certification.ToModel(cer);
                return Ok(_certification) ;
            }
            else
                return BadRequest();
        }
    }
}
