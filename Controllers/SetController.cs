using System.Collections;
using Framework.Data;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Controllers
{
    [ApiController]
    [Route("/api/set")]
    public class SetController : ControllerBase
    {
        private ISetRepo _repo;
        public SetController(ISetRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable> GetAllSets()
        {
            var result = _repo.GetSets();
            if (result != null)
                return Ok(result);
            return NotFound();
        }

    }
}