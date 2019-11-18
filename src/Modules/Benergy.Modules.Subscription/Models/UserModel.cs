namespace Benergy.Modules.Subscription.Models
{
    /// <summary>
    /// DTO for User Entity
    /// </summary>
    public class UserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }    
        public string Password { get; set; }    
        public string Email { get; set; }   
        public string Role { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }   
        public string FullName { get; set; } 
    }
}