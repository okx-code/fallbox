using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dropbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dropbox.Pages
{
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        private readonly dropbox.Data.dropboxContext _context;

        public IndexModel(dropbox.Data.dropboxContext context)
        {
            _context = context;
        }
        
        public IList<Item> Item { get;set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Item.ToListAsync();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            string text = Request.Form["text_upload"];
            Item item;
            if (text != null)
            {
                item = new Item
                {
                    Uploaded = DateTime.Now,
                    Contents = Encoding.UTF8.GetBytes(text)
                };
            }
            else
            {
                if (Request.Form.Files.Count < 1)
                {
                    await OnGetAsync();
                    return Page();
                }
                var file = Request.Form.Files[0];
                var contents = new byte[file.Length];
                await file.CopyToAsync(new MemoryStream(contents));

                item = new Item
                {
                    Uploaded = DateTime.Now,
                    Contents = contents,
                    DisplayName = file.FileName
                };
            }

            _context.Item.Add(item);
            
            await _context.SaveChangesAsync();

            await OnGetAsync();
            return Page();
        }
    }
}