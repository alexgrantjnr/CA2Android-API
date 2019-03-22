using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA2Service.Data
{
    public class PlayerContext : DbContext
    {
        public  PlayerContext (DbContextOptions<PlayerContext> options)
            : base(options)
        {
        }

        public DbSet<CA2Service.PlayerEntry> PlayerEntry { get; set; }
    }
}
