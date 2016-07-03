using AutoMapper;
using MyCMS.DomainClasses;
using MyCMS.ViewModel;

namespace MyCMS.ServiceLayer.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public override string ProfileName => GetType().Name;

        protected override void Configure()
        {
            CreateMap<Comment, CommentViewModel>()
                                //.ForMember(d=> d.Post , options => options.MapFrom(source => source.Post))
                                .IgnoreAllNonExisting();


            CreateMap<CommentViewModel, Comment>()
                //.ForMember(d => d.Post, options => options.MapFrom(source => source.Post))
                .IgnoreAllNonExisting();

        }
    }
}
