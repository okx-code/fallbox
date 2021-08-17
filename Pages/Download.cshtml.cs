using System;
using System.Threading.Tasks;
using dropbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dropbox.Pages
{
    public class DownloadModel : PageModel
    {
        private readonly dropbox.Data.dropboxContext _context;

        public DownloadModel(dropbox.Data.dropboxContext context)
        {
            _context = context;
        }
        
        public async Task<ActionResult> OnGetAsync()
        {
            var o = Request.Query["Id"];
            if (o.Count == 0) return NotFound("ID not found");

            int id;
            if (!Int32.TryParse(o[0], out id)) return NotFound("ID not valid");

            Item item = await _context.Item.FindAsync(id);
            if (item == null) return NotFound("Cannot find item");
            
            return File(item.Contents, "application/octet-stream", item.DisplayName ?? "unknown");
        }
    }
}