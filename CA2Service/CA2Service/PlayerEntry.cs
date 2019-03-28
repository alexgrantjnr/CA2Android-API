using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/*
 Developers:
 Bren Dempsey & Alex Grant
 4th Year Software Students
 EAD2 - CA2[Elapsed]
 Out: 28/02/2019
 Due: 31/03/2019
*/

namespace CA2Service
{
    public class PlayerEntry
    {
        public int ID { get; set; } //PK -> Unique Azure auto-generates ID

        //[Required]
        public string PhotoURL { set; get; }

        //Firstname is required
        [Required]
        [MinLength(1, ErrorMessage = "Forname Must be at least 1 Character!")] //Validations..
        [MaxLength(30, ErrorMessage = "Name out of Max-Length range!")] //Validations..
        public string FirstName { get; set; }

        //Surname is required
        [Required]
        [MinLength(1, ErrorMessage = "Surname Must be at least 1 Character!")] //Validations..
        [MaxLength(30, ErrorMessage = "Name out of Max-Length range!")] //Validations..
        public string LastName { get; set; }

        //Age is required
        [Required]
        //public DateTime DateOfBirth { get; set; }   //Player's age
        [Range(5, 50)]
        public int Age { get; set; }   //Player's age

        //Possible calculation to get the Player's age here
        [MinLength(3, ErrorMessage = "Nationality Must be at least 1 Character")] //"nationality Must be at least 1 Character!"
        [MaxLength(30, ErrorMessage = "Name out of Max-Length range!")]
        public string Nationality { set; get; }

        [Required]
        [MinLength(2, ErrorMessage = "Possition Must be at least 1 Character")] //"nationality Must be at least 1 Character!"
        [MaxLength(3, ErrorMessage = "possition out of Max-Length range!")]
        public string Position { set; get; }

    }
}
