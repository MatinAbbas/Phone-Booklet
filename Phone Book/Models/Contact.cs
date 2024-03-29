﻿using System.ComponentModel.DataAnnotations;

namespace Phone_Book.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? LastName { get; set; }    
        public string? PhoneNumber { get; set; }
    }
}
