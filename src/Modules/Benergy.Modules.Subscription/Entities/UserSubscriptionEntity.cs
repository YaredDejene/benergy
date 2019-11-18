using System;
using System.ComponentModel.DataAnnotations.Schema;
using Benergy.Core.Entities;

namespace Benergy.Modules.Subscription.Entities
{
    /// <summary>
    /// UserSubscrition DB Entity
    /// </summary>
    [Table("user_subscription", Schema = "subscription")]
    public class UserSubscriptionEntity: BaseEntity
    {
        [Column("plan_id")]
        public int PlanID { get; set; }    
        [Column("user_id")]
        public int UserID { get; set; } 
        [Column("status_id")]
        public int StatusID { get; set; } 
        [Column("start_date")] 
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [ForeignKey("PlanID")]
        public virtual PlanEntity Plan { get; set; }
        [ForeignKey("UserID")]
        public virtual UserEntity User { get; set; }
        [ForeignKey("StatusID")]
        public virtual StatusEntity Status { get; set; }
    }
}