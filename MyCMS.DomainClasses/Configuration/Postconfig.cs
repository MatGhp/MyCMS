using System.Data.Entity.ModelConfiguration;

namespace MyCMS.DomainClasses.Configuration
{
    public class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            Property(post => post.Title).HasMaxLength(500);
            Property(post => post.Body).IsMaxLength();
            Property(post => post.MetaDescription).HasMaxLength(300);
            Property(post => post.PostSlug).HasMaxLength(300);
        }
    }
}
