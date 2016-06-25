using AutoMapper;
using MyCMS.DomainClasses;
using MyCMS.ViewModel;

namespace MyCMS.ServiceLayer.AutoMapperProfiles
{
    public class PostProfile : Profile
    {
        public override string ProfileName => GetType().Name;

        protected override void Configure()
        {
            CreateMap<Post, PostViewModel>()
                                .IgnoreAllNonExisting();
            //.ForMember(d=> d.PostedByUserId , m=>m.MapFrom((s=>s.PostedByUserId)))

            CreateMap<PostViewModel, Post>()
                .IgnoreAllNonExisting();

            CreateMap<AddPostViewModel, Post>().IgnoreAllNonExisting();
            CreateMap<Post, AddPostViewModel>().IgnoreAllNonExisting();

            CreateMap<EditPostViewModel, Post>().IgnoreAllNonExisting();
            CreateMap<Post, EditPostViewModel>().IgnoreAllNonExisting();
        }

    }



}
