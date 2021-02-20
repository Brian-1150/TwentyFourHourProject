namespace TwentyFourHourProject.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TwentyFourHourProject.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TwentyFourHourProject.Data.ApplicationDbContext";
        }

        protected override void Seed(TwentyFourHourProject.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Posts.AddOrUpdate(x => x.PostId,
                new Post() { PostId = 11, Title = "Seeded", Text = "test text" },
                new Post() { Author = Guid.Parse("6c17382b787440438cf7f9da8f5a8873"), Title = "Happy Birthday", Text = "I am 40" });
                //new Post() { Author =   , Title = "Happy Birthday", Text = "I am 40" });

            context.Users.AddOrUpdate(x => x.Id,
                new ApplicationUser() { Email = "abc@abc.com", Id = "5c17382b787440438cf7f9da8f5a8873"  },
                new ApplicationUser() { Email = "abcd@abcd.com", Id = Guid.NewGuid().ToString(), UserName = "abcd@abcd.com"}

                );
        }
    }
}
