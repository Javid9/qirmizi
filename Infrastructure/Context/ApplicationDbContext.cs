using Application.Context;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.Languages;
using Infrastructure.CustomMigrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options), IDatabaseContext
    {

        public DbSet<Language> Languages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<FaqFeature> FaqFeatures { get; set; }


        //Languages
        public DbSet<SliderLanguage> SliderLanguages { get; set; }
        public DbSet<EventLanguage> EventLanguages { get; set; }
         public DbSet<SpeakerLanguage> SpeakerLanguages { get; set; }
        public DbSet<BlogLanguage> BlogLanguages { get; set; }
        public DbSet<CategoryLanguage> CategoryLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataSeed.Seed(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entries)
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedTime = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        Entry(entity.Entity).Property(x => x.CreatedTime).IsModified = false;
                        entity.Entity.UpdatedTime = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
