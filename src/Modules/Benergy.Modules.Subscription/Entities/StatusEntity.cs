using System.ComponentModel.DataAnnotations.Schema;
using Benergy.Core.Entities;

namespace Benergy.Modules.Subscription.Entities
{
    /// <summary>
    /// Subscrition Status DB Entity
    /// </summary>
    [Table("status", Schema = "subscription")]
    public class StatusEntity: BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }    
        [Column("code")]
        public string Code { get; set; }   
        [Column("description")]
        public string Description { get; set; }  
    }
}