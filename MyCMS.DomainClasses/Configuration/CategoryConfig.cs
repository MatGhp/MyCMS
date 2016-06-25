using System.Data.Entity.ModelConfiguration;

namespace MyCMS.DomainClasses.Configuration
{
    public class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            Property(cat => cat.Name).HasMaxLength(100);
        }
    }
}
