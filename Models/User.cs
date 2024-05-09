using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DenemeProject.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public string? IpAdress { get; set; }

        public string Jobs { get; set; }

        public string ImagePath { get; set; }

        public string Age { get; set; }

        public string Github{ get; set; }

        public string Linkedin { get; set; }
        public string Instagram { get; set; }










    }

}
