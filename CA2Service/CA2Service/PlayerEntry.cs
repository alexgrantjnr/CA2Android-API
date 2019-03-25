using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CA2Service
{
    public class PlayerEntry
    {

        public int ID { get; set; } //PK -> Unique
        
        [Required]
        [MinLength(1, ErrorMessage = "Forname Must be at least 1 Character!")] //
        [MaxLength(30, ErrorMessage = "Name out of Max-Length range!")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Surname Must be at least 1 Character!")]
        [MaxLength(30, ErrorMessage = "Name out of Max-Length range!")]
        public string LastName { get; set; }
        [Required]
        //public DateTime DateOfBirth { get; set; }   //Player's age
        [Range(5, 50)]
        public int Age { get; set; }   //Player's age
        //Possible calculation to get the Player's age here
        [Required]
        public double Salary { get; set; }

    }
}
