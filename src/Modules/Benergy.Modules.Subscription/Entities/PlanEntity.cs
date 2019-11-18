using System.ComponentModel.DataAnnotations.Schema;
using Benergy.Core.Entities;

namespace Benergy.Modules.Subscription.Entities
{
    /// <summary>
    /// Plan DB Entity 
    /// </summary>
    [Table("plan", Schema = "subscription")]
    public class PlanEntity: BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }    
        [Column("code")]
        public string Code { get; set; }  
        [Column("description")]
        public string Description { get; set; }  
    }
}