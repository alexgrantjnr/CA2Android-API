﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA2Service.Data
{
    //Database connection class
    public class PlayerContext : DbContext
    {
        public  PlayerContext (DbContextOptions<PlayerContext> options)
            : base(options)
        {
        }

        //Get & Set property for the players in DB
        public DbSet<PlayerEntry> Players { get; set; }
    }
}
