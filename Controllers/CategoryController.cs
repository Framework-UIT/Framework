
using Microsoft.AspNetCore.Mvc;
using Framework.Data;
using System.Collections.Generic;
using Framework.Models;


namespace Framework.Controllers
{
    [Route("/api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _repo;

        public CategoryController(ICategoryRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _repo.GetCategories();
            if (categories != null)
                return Ok(categories);
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var cat = _repo.GetCategoryById(id);
            if (cat != null)
                return Ok(cat);
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Category> CreateCategory(Category cat)
        {
            _repo.CreateCategory(cat);
            _repo.SaveChanges();
            return Ok(cat);
        }
    }
}