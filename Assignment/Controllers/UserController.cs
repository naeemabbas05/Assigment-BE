using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult> Get(int pageNumber, int pageSize)
        {
            return Ok(await _userService.GetAllUsers(pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _userService.GetUsersById(id));
        }


        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            return Ok(await _userService.AddUser(user));
        }

        [HttpPut]
        public async Task<ActionResult> Put(User user)
        {
            return Ok(await _userService.UpdateUser(user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _userService.DeleteUser(id));
        }
    }
}
