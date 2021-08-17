using System;
using System.Threading.Tasks;
using dropbox.Models;
using Microsoft.AspNetCore.Mvc;

namespace dropbox.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly dropbox.Data.dropboxContext _context;

        public DeleteController(dropbox.Data.dropboxContext context)
        {
            _context = context;
        }
        
        [HttpDelete]
        public async Task<ActionResult> Index()
        {
            var o = Request.Query["Id"];
            if (o.Count == 0) return BadRequest("ID not found");

            int id;
            if (!Int32.TryParse(o[0], out id)) return BadRequest("ID not valid");

            _context.Item.Remove(new Item {Id = id});
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}