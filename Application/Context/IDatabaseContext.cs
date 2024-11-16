using Domain.Entities;
using Domain.Entities.Languages;
using Microsoft.EntityFrameworkCore;

namespace Application.Context
{
    public interface IDatabaseContext
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
        public DbSet<FaqFeature> FaqFeatures { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }


        //Languages
        public DbSet<SliderLanguage> SliderLanguages { get; set; }
        public DbSet<EventLanguage> EventLanguages { get; set; }
        public DbSet<SpeakerLanguage> SpeakerLanguages { get; set; }
        public DbSet<BlogLanguage> BlogLanguages { get; set; }
        public DbSet<CategoryLanguage> CategoryLanguages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


    }
}
