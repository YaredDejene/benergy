using System.ComponentModel.DataAnnotations.Schema;
using Benergy.Core.Entities;

namespace Benergy.Modules.Subscription.Entities
{
    /// <summary>
    /// User DB Entity
    /// </summary>
    [Table("user", Schema = "subscription")]
    public class UserEntity : BaseEntity
    {
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("role")]
        public string Role { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
    }
}