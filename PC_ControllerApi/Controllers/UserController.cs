using Microsoft.AspNetCore.Mvc;
using PC_ControllerApi.Implementations;
using PC_ControllerApi.Interfaces;
using PC_ControllerApi.Models;

namespace PC_ControllerApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ApplicationContext _context { get; set; } = null!;

        DbManager<User> dbManager { get; set; } = null!;

        public UserController(IDbManagerFactory factory, ApplicationContext context)
        {
            _context = context;
            dbManager = factory.GetDbManager<User>();
        }

       

        [Route("getUser/{userName}")]
        [HttpGet]
        public async Task<IActionResult> GetUserAsync(string userName)
        {
            var user = _context.Users.FirstOrDefault(user =>  user.UserName == userName);

            return user != null ? Ok(user) : NotFound($"User with username: {userName} was not found"); 
        }

        [Route("addUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]User user)
        {
            await dbManager.SaveAsync(user);
            return CreatedAtRoute("api/users/addUsr",user);
        }

    }
}
