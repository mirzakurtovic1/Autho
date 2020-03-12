using AutoMapper;
using Model;
using AuthoAPI.Models;
namespace AuthoAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AuthoAPI.Models.Role,Model.Role>().ReverseMap();
            CreateMap<AuthoAPI.Models.AuthUser, Model.AuthUser>().ReverseMap();
            CreateMap<AuthoAPI.Models.Event, Model.Event>().ReverseMap();
            CreateMap<AuthoAPI.Models.EventType, Model.EventType>().ReverseMap();
            CreateMap<AuthoAPI.Models.Presence, Model.Presence>().ReverseMap();
            CreateMap<Model.InsertRequests.PresenceInsertRequest, AuthoAPI.Models.Presence>().ReverseMap();
            CreateMap<AuthoAPI.Models.UserGroup, Model.UserGroup>().ReverseMap();
            CreateMap<AuthoAPI.Models.AuthUserImage, Model.AuthUserImage>().ReverseMap();
            CreateMap<Model.InsertRequests.AuthUserFaceInsertRequest, AuthoAPI.Models.AuthUserImage>().ReverseMap();
            CreateMap<Model.InsertRequests.AuthUserFaceInsertRequest, AuthoAPI.Models.AuthUserFace>().ReverseMap();
            CreateMap<AuthoAPI.Models.AuthUserFace, Model.AuthUserFace>().ReverseMap();
            CreateMap<AuthoAPI.Models.AuthUserImage, Model.AuthUserImage>().ReverseMap();
            CreateMap<AuthoAPI.Models.AuthUserFace, Model.AuthUserFace>().ReverseMap();
            //...
        }
    }
}
