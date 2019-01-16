﻿using System;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}