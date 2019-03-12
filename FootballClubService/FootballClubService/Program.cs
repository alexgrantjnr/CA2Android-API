using System;
using System.Linq;

namespace FootballClubService
{
    class Program
    {
        //Pushign to the DB
        static void Add()
        {
            using (PlayerContext db = new PlayerContext())
            {
                try
                {
                    //Add 3 Players, omit identity column vals..
                    Player p1 = new Player() { FirstName = "Diego", LastName = "Maradona", Age = 52, Salary = 120000 };
                    Player p2 = new Player() { FirstName = "Henrik", LastName = "Larssson", Age = 45, Salary = 110000 };
                    Player p3 = new Player() { FirstName = "George", LastName = "Best", Age = 65, Salary = 150000 };
                    Player p4 = new Player() { FirstName = "Jack", LastName = "Charlton", Age = 68, Salary = 65000 };
                    db.Players.Add(p1);
                    db.Players.Add(p2);
                    db.Players.Add(p3);
                    db.Players.Add(p4);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());                    
                }
                
            }
        }

        //Get ALL Players
        /*static void ReturnAllPlayers()
        {
            using (PlayerContext db = new PlayerContext())
            {
                // LINQ to entities
                var query = db.Players.OrderBy(player => player.ID);
                foreach (var player in query)
                {
                    Console.WriteLine(player);
                }
            }
        }*/
        static void Main()
        {           
            Console.WriteLine("Hello World!");

            Add();
            //ReturnAllPlayers();
            /*Update();
            Delete();*/

            //Controlling out the program exe...
            Console.WriteLine("\nPress any key to Continue....\n");
            Console.ReadKey();
        }
    }
}
