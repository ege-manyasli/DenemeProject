
namespace DenemeProject.Models.ViewModels
{
    public class UserCreateVM
    {
        public int Id { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }
        
        public string UserName { get; set; }
        
        public string Jobs { get; set; }
        
        public string ImagePath { get; set; }
        
        public bool Active { get; set; }
        
        public string Age { get; set; }
        
        public bool Error { get; set; }
        
        public string Message { get; set; }
        
       

    }
    
}   
