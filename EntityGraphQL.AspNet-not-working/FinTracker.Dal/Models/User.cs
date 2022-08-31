﻿namespace FinTracker.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
