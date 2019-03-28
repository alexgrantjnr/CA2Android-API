using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


//Install sql server and tools
//Add-Migration InitialCreate
//Update-Database

//This is the Model Class Entity that holds the Business logic of the application

namespace FootballClubService
{
    public class Player
    {
        public int ID { get; set; } //PK -> Unique

        //[Required]
        public string PhotoURL { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Forname Must be at least 1 Character")] //"Forname Must be at least 1 Character!"
        [MaxLength(30, ErrorMessage = "Name out of Max-Length range!")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Surname Must be at least 1 Character!")]
        [MaxLength(30, ErrorMessage = "Name out of Max-Length range!")]
        public string LastName { get; set; }

        [Required]
        //public DateTime DateOfBirth { get; set; }   //Player's age
        [Range(5,50)]
        public int Age { get; set; }   //Player's age

        //Possible calculation to get the Player's age 
        [Required]
        [MinLength(3, ErrorMessage = "Nationality Must be at least 1 Character")] //"nationality Must be at least 1 Character!"
        [MaxLength(30, ErrorMessage = "Name out of Max-Length range!")]
        public string Nationality { set; get; }

        [Required]
        [MinLength(2, ErrorMessage = "Position Must be at least 1 Character")] //"nationality Must be at least 1 Character!"
        [MaxLength(3, ErrorMessage = "Position out of Max-Length range!")]
        public string Position { set; get; }


        /*
            [ GoalsScored, YellowCards, RedCards, Contract(Years) ]
         */
    }
}
