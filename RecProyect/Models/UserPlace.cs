using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecProyect.Models
{
    public class UserPlace
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        [Required]
        [ForeignKey("UserFK")]
        public string UserFK { get; set; }
        [Required]
        public Place Place { get; set; }
        [Required]
        [ForeignKey("PlaceFK")]
        public int PlaceFK { get; set; }
    }
}
