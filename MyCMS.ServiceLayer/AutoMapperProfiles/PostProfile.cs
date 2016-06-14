using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

    }



}
