using AutoMapper;
using SportNet.Core.Application.ViewModels.Users;
using SportNet.Core.Domain.Entities;


namespace SportNet.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Users, SaveUserViewModel>()
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.EventParticipations, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedEvents, opt => opt.Ignore())
                .ForMember(dest => dest.CreateBy, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Users, UserViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.EventParticipations, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedEvents, opt => opt.Ignore())
                .ForMember(dest => dest.CreateBy, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Users, EditUserViewModel>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.EventParticipations, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedEvents, opt => opt.Ignore())
                .ForMember(dest => dest.CreateBy, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
        }
    }
}
