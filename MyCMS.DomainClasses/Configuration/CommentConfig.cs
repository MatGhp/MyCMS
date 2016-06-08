using System.Data.Entity.ModelConfiguration;


namespace MyCMS.DomainClasses.Configuration
{
    public class CommentConfig : EntityTypeConfiguration<Comment>
    {
        public CommentConfig()
        {
            Property(comment => comment.AuthorEmail).HasMaxLength(100);
            Property(comment => comment.Body).IsMaxLength();
        }

    }
}
