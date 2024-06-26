﻿using Database.Models;
using Microsoft.AspNetCore.Identity;

namespace OmniselloTask.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName    { get; set; }
        public string? LastName     { get; set; }
        public string? Street       { get; set; }
        public string? NoStreet     { get; set; }
        public string? City         { get; set; }
        public string? Country      { get; set; }
        public ICollection<Order> Order { get; set; } = new List<Order>();
    }
}
