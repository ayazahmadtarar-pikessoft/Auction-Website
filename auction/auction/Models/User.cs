using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace auction.Models
{
     
public class DummyUser : IdentityUser
    {

    }
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Use 5-20 characters")]
        public string  username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Date)]
        public string Dob { get; set; }


        public string City { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string MobileNo { get; set; }

        public string userimgName { get; set; }
        
        public string userimgPath { get; set; }

    }
}