using AutoMapper;
using MyCMS.DomainClasses;
using MyCMS.ViewModel;


namespace MyCMS.ServiceLayer.AutoMapperProfiles
{
    public class CategoryProfile : Profile
    {
        public override string ProfileName => GetType().Name;

        protected override void Configure()
        {
            
            CreateMap<Category, CategoryViewModel>()
                .ForMember(d => d.PostCount, m => m.MapFrom((s => s.Posts.Count)))
                                .IgnoreAllNonExisting();
            //.ForMember(d=> d.PostedByUserId , m=>m.MapFrom((s=>s.PostedByUserId)))

            CreateMap<CategoryViewModel, Category>()
                .IgnoreAllNonExisting();

        }
    }
}
