using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PC_ControllerApi.Implementations;
using PC_ControllerApi.Interfaces;
using PC_ControllerApi.Models;
using System.Diagnostics;

namespace PC_ControllerApi.Controllers
{
    [Route("api/pc")]
    [ApiController]
    public class PC_Controller : ControllerBase
    {

        ApplicationContext _context { get; set; } = null!;
        DbManager<PC> dbManager { get; set; } = null!;

        

        public PC_Controller(ApplicationContext context, IDbManagerFactory factory)
        {
           
            _context = context;
            dbManager = factory.GetDbManager<PC>();
        }



        [Route("sendMessage/{token}/{message}")]
        public async Task SendAsync(Guid token,string message)
        {
 
            await ChatHub.ClientProxies[token].SendAsync("ReceiveMessage", message);
        }

        

        [HttpGet]
        [Route("getPC/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            
            Guid guid;
            if (!Guid.TryParse(id, out guid)) return BadRequest("Incorrect guid formatt");
            
            else
            {
                PC? pc = await _context.PCes.FirstOrDefaultAsync(p => p.Id == guid);

                if (pc == null) return NotFound();
                else return Ok(pc);
               
            }
        }

    }
}
