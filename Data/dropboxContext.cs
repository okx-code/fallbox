using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dropbox.Models;

namespace dropbox.Data
{
    public class dropboxContext : DbContext
    {
        public dropboxContext (DbContextOptions<dropboxContext> options)
            : base(options)
        {
        }

        public DbSet<dropbox.Models.Item> Item { get; set; }
    }
}
