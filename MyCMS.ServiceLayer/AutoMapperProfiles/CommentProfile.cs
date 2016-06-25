using AutoMapper;
using MyCMS.DomainClasses;
using MyCMS.ViewModel;

namespace MyCMS.ServiceLayer.AutoMapperProfiles
{
    class CommentProfile : Profile
    {
        public override string ProfileName => GetType().Name;

        protected override void Configure()
        {
            CreateMap<Comment, CommentViewModel>()
                                .IgnoreAllNonExisting();
            

            CreateMap<CommentViewModel, Comment>()
                .IgnoreAllNonExisting();

        }
    }
}
