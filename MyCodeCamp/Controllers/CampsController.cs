using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCodeCamp.Data;

namespace MyCodeCamp.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class CampsController : Controller
    {
        private ICampRepository _repo;

        public CampsController(ICampRepository repo)
        {
            _repo = repo;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var camps = _repo.GetAllCamps();

            return Ok(camps);
        }

        public IActionResult Get(int id)
        {
            var camp = _repo.GetCamp(id);

            if (camp == null) return NotFound();
        }
    }
}