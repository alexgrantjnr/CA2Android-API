﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Microsoft.EntityFrameworkCore;


//*** Commands Run for EF DB Configs ***

//Install-Package Microsoft.EntityFrameworkCore.SqlServer
//Install-Package Microsoft.EntityFrameworkCore.Tools

//** Set the DbContext Config >> Add Connection String from Azure

//Add-Migration InitialCreate
//Update-Database

//When re-running  program be sure to delete ALL (TRY: Remove-Migration) files in Migrations folder AND
//>>> Add-Migration InitialCreate
//>>> Update-Database

namespace FootballClubService
{
    public class PlayerContext: DbContext
    {
        //LocalDB connection string        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Azure Connection String here..
            optionsBuilder.UseSqlServer(@"Server=tcp:sportsserver.database.windows.net,1433;
            Initial Catalog=SportDB;Persist Security Info=False;User ID=AlexBren;Password=Ali-g#Bren-d;
            MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"); //UName/Password in "***"??
        }

        public DbSet<Player> Players { get; set; }

        /*static void QueryAll()
        {
            using (PlayerContext db = new PlayerContext())
            {
                // LINQ to entities
                var query = db.Players.OrderBy(player => player.FirstName);
                foreach (var player in query)
                {
                    Console.WriteLine(player);
                }
            }
        }*/
    }
}
