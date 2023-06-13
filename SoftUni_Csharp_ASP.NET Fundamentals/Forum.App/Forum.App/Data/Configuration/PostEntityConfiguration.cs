using Forum.App.Data.Models.Post;
using Forum.App.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.App.Data.Configuration
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder postSeeder;

        public PostEntityConfiguration()
        {
            this.postSeeder = new PostSeeder();
        }


        public void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.HasData(this.postSeeder.GeneratePosts());
        }
    }
}
