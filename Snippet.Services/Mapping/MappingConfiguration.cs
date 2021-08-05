using AutoMapper;
using Snippet.Data.Entities;
using Snippet.Services.Models;
using Snippet.Services.Response;

namespace Snippet.Services.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<SnippetEntity, SnippetPost>().ForMember(x => x.Like, 
                opt => opt.MapFrom(
                    c => c.LikedUser!.Count))
                .ReverseMap();

            CreateMap<TagEntity, Tag>().ReverseMap();
            CreateMap<LanguageEntity, Language>().ReverseMap();

            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<UserEntity, UserResponse>().ReverseMap();


            CreateMap<SnippetEntity, ShortSnippetPost>().ForMember(
                c => c.Description,
                opt => opt.MapFrom(
                    x => x.Description.Length > 50 ? x.Description.Substring(0, 50) : x.Description))
                .ForMember(x => x.Like,
                opt => opt.MapFrom(
                    c => c.LikedUser!.Count));

        }
    }
}
