﻿namespace DenemeProject.Controllers
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public string? IpAdress { get; set; }
    }
}