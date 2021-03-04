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
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryServices _categoryServices;
        

        public CategoriesController(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: api/Categories/only
        /// <summary>
        /// Get only Categories
        /// </summary>
        /// <returns>
        /// List entities of Category follow model ResponseOnlyCategory
        /// </returns>
        [HttpGet("only")]
        public IActionResult GetOnlyCategories()
        {
            List<ResponseOnlyCategory> response = new List<ResponseOnlyCategory>();
            var categories = _categoryServices.GetCategories().ToList();
            Global.Mapper.Map(categories, response);
            return Ok(response);
        }

        // Get: api/Categories/all
        [HttpGet("all")]
        public IActionResult GetAllCategories()
        {
            List<ResponseOnlyCategory> response = new List<ResponseOnlyCategory>();
            var categories = _categoryServices.GetCategories().ToList();
            Global.Mapper.Map(categories, response);
            return Ok(response);
        }

        // GET: api/Categories/2
        /// <summary>
        /// Get Category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return a Category with specific Id</returns>
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            ResponseOnlyCategory response = new ResponseOnlyCategory();
            var category = _categoryServices.GetById(id);
            Global.Mapper.Map(category, response);
            if (category != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Categories
        /// <summary>
        /// Create new Category
        /// </summary>
        /// <param name="_category"></param>
        /// <returns>return Created Category</returns>
        [HttpPost]
        public IActionResult CreateCategory([FromBody] RequestCreateCategory _category)
        {
            Category entity;
            if (ModelState.IsValid)
            {
                entity = _categoryServices.CreateCategory(_category);
                _categoryServices.Commit();
                return Created($"api/categories/{entity.Id}", _category);
            }
            else
                return BadRequest();
        }

        // PUT api/Categories/5
        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_category"> follow model RequesteUpdateCategory</param>
        /// <returns>Updated Category</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RequestUpdateCategory _category)
        {
            if (id != _category.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Category cate = _categoryServices.GetCategoryById(_category.Id);
                Category entity = _categoryServices.UpdateCategory(_category.CopyTo(cate));
                _categoryServices.Commit();
                return Ok(entity);
            }
            else
                return BadRequest();
        }

        // DELETE api/Categories/5
        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return deleted Category</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var _category = _categoryServices.GetCategoryById(id);
                if (_category != null)
                {
                    _categoryServices.DeleteCategory(_category);
                    _categoryServices.Commit();
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
