
namespace Benergy.Modules.Subscription.Models
{
    /// <summary>
    /// DTO for Plan Entity 
    /// </summary>
    public class PlanModel
    {
        public int ID { get; set; }
        public string Name { get; set; }    
        public string Code { get; set; }  
        public string Description { get; set; }  
    }
}