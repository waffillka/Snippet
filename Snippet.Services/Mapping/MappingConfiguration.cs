using AutoMapper;
using Snippet.Data.Entities;
using Snippet.Services.Models;

namespace Snippet.Services.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<SnippetEntity, SnippetPost>().ReverseMap();
            CreateMap<TagEntity, Tag>().ReverseMap();
            CreateMap<LanguageEntity, Language>().ReverseMap();
            CreateMap<UserEntity, User>();
            CreateMap<ShortSnippetPost, SnippetEntity>(); // need fix
        }
    }
}
