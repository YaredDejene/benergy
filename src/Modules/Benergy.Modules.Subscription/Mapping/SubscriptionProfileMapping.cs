using AutoMapper;
using Benergy.Modules.Subscription.Entities;
using Benergy.Modules.Subscription.Models;

namespace Benergy.Modules.Subscription.Mapping
{
    /// <summary>
    /// Automapper mapping for Subscription Entities and DTOs
    /// </summary>
    public class SubscriptionProfileMapping: Profile
    {
        public SubscriptionProfileMapping()
        {
            this.CreateMap<PlanEntity, PlanModel>().ReverseMap();
            this.CreateMap<StatusEntity, StatusModel>().ReverseMap();
            this.CreateMap<UserEntity, UserModel>().ReverseMap();
            this.CreateMap<UserSubscriptionEntity, UserSubscriptionModel>().ReverseMap();
        }

        public override string ProfileName
        {
            get
            {
                return "SubscriptionProfileMapping";
            }
        }
    }
}