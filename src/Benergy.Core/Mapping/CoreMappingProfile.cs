using AutoMapper;
using Benergy.Core.Context;

namespace Benergy.Core.Mapping
{
    /// <summary>
    /// Specifying the AutoMapepr Mapping details
    /// </summary>
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            this.CreateMap<NTContextModel, NTContextModel>();
        }

        public override string ProfileName
        {
            get
            {
                return "CoreMappingProfile";
            }
        }
    }
}