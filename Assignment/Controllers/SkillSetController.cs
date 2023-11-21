using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillSetController : Controller
    {
        private readonly ISkillSetService _skillSetService;

        public SkillSetController(ISkillSetService skillSetService)
        {
            _skillSetService = skillSetService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _skillSetService.GetAllSkillSet());
        }
    }
}
