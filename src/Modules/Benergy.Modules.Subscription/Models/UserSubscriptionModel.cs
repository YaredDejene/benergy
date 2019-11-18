using System;

namespace Benergy.Modules.Subscription.Models
{
    /// <summary>
    /// DTO for UserSubscription
    /// </summary>
    public class UserSubscriptionModel
    {
        public int ID { get; set; }
        public int PlanID { get; set; }    
        public int UserID { get; set; } 
        public int StatusID { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual PlanModel Plan { get; set; }
        public virtual UserModel User { get; set; }
        public virtual StatusModel Status { get; set; }
    }
}