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

        //Salary is required
        [Required]
        public double Salary { get; set; }

    }
}
