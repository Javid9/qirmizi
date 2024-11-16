using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.Category;
using Domain.Dtos.Event;
using Domain.Dtos.Speaker;
using Domain.Entities;
using Domain.Entities.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Infrastructure.Services
{
    public class EventService(IDatabaseContext context, IStorageService storageService) : IEventService
    {

        public async Task<ResponseModel<List<EventDto>>> GetAllAsync()
        {
            var events = await context.Events
                .Include(e => e.EventLanguages)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    FileCode = e.FileCode,
                    Title = e.EventLanguages!.FirstOrDefault(l => l.Language_Code == "az")!.Title,
                    SlugUrl = e.SlugUrl
                }).ToListAsync();

            return ResponseModel<List<EventDto>>.Success(events, 200);
        }


        public async Task<ResponseModel<List<EventClientDto>>> GetClientAllAsync(string? lang)
        {
            var events = await context.Events
                .Include(e => e.EventLanguages)
                .Include(x=> x.SpeakerEvents)!
                .ThenInclude(x=>x.Speaker)
                .Include(e => e.EventCategories)!
                .ThenInclude(ec => ec.Category)
                 .Select(e => new EventClientDto
                 {
                     Id = e.Id,
                     FileCode = e.FileCode,
                     SlugUrl = e.SlugUrl,
                     EventDay = e.EventDay!.Value.ToString("dd MMMM yyyy", new CultureInfo("az-Latn-AZ")),
                     Clock = e.Clock,
                     Title = e.EventLanguages!.FirstOrDefault(l => l.Language_Code == lang)!.Title,
                     Address = e.EventLanguages!.FirstOrDefault(l => l.Language_Code == lang)!.Address,
                     Speakers = e.SpeakerEvents!.Select(es => new SpeakerDto

                     {
                         Id = es.Speaker!.Id,
                         FileCode = es.Speaker!.FileCode,
                         Facebook = es.Speaker!.Facebook,
                         Instagram = es.Speaker!.Instagram,
                         Linkedin = es.Speaker!.Linkedin,
                         Twitter = es.Speaker!.Twitter,
                         Postion = es.Speaker!.SpeakerLanguages!.FirstOrDefault(sl => sl.Language_Code == lang)!.Postion,
                         FullName = es.Speaker.SpeakerLanguages!.FirstOrDefault(sl => sl.Language_Code == lang)!.FullName

                     }).Take(1).ToList(),

                     Categories = e.EventCategories!.Select(ec => new CategoryDto
                     {
                         Id = ec.Category!.Id,
                         Title = ec.Category.CategoryLanguages!.FirstOrDefault(cl => cl.Language_Code == lang)!.Title
                     }).Take(1).ToList()

                 }).ToListAsync();

            return ResponseModel<List<EventClientDto>>.Success(events, 200);
        }



        public async Task<ResponseModel<UpdateEvenetDto>> GetByIdAsync(string id)
        {
            var entity = await context.Events
                .Include(x => x.EventLanguages)
                .Include(x => x.SpeakerEvents)
                .Include(x => x.EventCategories)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
                return ResponseModel<UpdateEvenetDto>.Fail(Messages.NoDataFound, 404);

            var result = new UpdateEvenetDto
            {
                Id = id,
                FileCode = entity?.FileCode,
                Partnerlogo = entity?.PartnerLogo,
                SlugUrl = entity?.SlugUrl,
                Clock = entity?.Clock,
                Map = entity?.Map,
                EventDay = entity?.EventDay,
                Link = entity?.Link,
                TicketType = entity?.TicketType,

                EventLangauges = entity?.EventLanguages?.Select(x => new EventLangaugeDto
                {
                    LangId = x.Id,
                    EventId = x.EventId,
                    Address = x.Address,
                    Title = x.Title,
                    Text = x.Text,
                    Price = x.Price,
                    Language_Code = x.Language_Code,
                    SeoTitle = x.SeoTitle,
                    SeoDesc = x.SeoDesc,
                    SeoKey = x.SeoKey,

                }).ToList(),

                SpeakerIds = entity?.SpeakerEvents?.Select(x => x.SpeakerId).ToList()!,

                CategoryIds = entity?.EventCategories?.Select(x => x.CategoryId).ToList()!,



            };

            return ResponseModel<UpdateEvenetDto>.Success(result, 200);

        }


        public async Task<ResponseModel<EventDetailDto>> GetBySlugUrlAsync(string slugUrl, string lang)
        {
            var entity = await context.Events
                .Include(x=>x.EventLanguages)
                .Include(x => x.SpeakerEvents)!
                .ThenInclude(x => x.Speaker)
                .ThenInclude(x=>x!.SpeakerLanguages)
                .Include(x => x.EventCategories)!
                .ThenInclude(x => x.Category)
                .ThenInclude(x=>x!.CategoryLanguages)
                  .FirstOrDefaultAsync(e => e.SlugUrl == slugUrl);

            if (entity == null)
                return ResponseModel<EventDetailDto>.Fail("Event not found", 404);

            var result = new EventDetailDto
            {
                Id = entity.Id,
                FileCode = entity.FileCode,
                PartnerLogo = entity.PartnerLogo,
                SlugUrl = entity?.SlugUrl,
                Clock = entity?.Clock,
                Map = entity?.Map,
                Link = entity?.Link,
                TicketType = entity?.TicketType,
                CreateDate = entity?.EventDay!.Value.ToString("dd MMMM yyyy", new CultureInfo("az-Latn-AZ")),
                Title = entity?.EventLanguages?.FirstOrDefault(l => l.Language_Code == lang)!.Title,
                Text = entity?.EventLanguages?.FirstOrDefault(l => l.Language_Code == lang)!.Text,
                Address = entity?.EventLanguages?.FirstOrDefault(l=> l.Language_Code == lang)!.Address,
                Price = entity?.EventLanguages?.FirstOrDefault(l => l.Language_Code == lang)!.Price,


                

                Speakers = entity?.SpeakerEvents!.Select(es => new SpeakerDto
                {
                    Id = es.Speaker!.Id,
                    SlugUrl = es.Speaker!.SlugUrl,
                    FileCode = es.Speaker!.FileCode,
                    Facebook = es.Speaker!.Facebook,
                    Instagram = es.Speaker!.Instagram,
                    Linkedin = es.Speaker!.Linkedin,
                    Twitter = es.Speaker!.Twitter,
                    Postion = es.Speaker!.SpeakerLanguages!.FirstOrDefault(sl => sl.Language_Code == lang)!.Postion,
                    FullName = es.Speaker?.SpeakerLanguages!.FirstOrDefault(sl => sl.Language_Code == lang)!.FullName,
                    Text = es.Speaker!.SpeakerLanguages!.FirstOrDefault(sl => sl.Language_Code == lang)!.Text
                }).ToList(),



                Categories = entity?.EventCategories!.Select(ec => new CategoryDto
                {
                    Id = ec.Category!.Id,
                    Title = ec.Category.CategoryLanguages!.FirstOrDefault(cl => cl.Language_Code == lang)!.Title
                }).ToList(),
            };

            return ResponseModel<EventDetailDto>.Success(result, 200);
        }





        public async Task<ResponseModel<bool>> CreateAsync(CreateEventDto model, IFormFile file, IFormFile partnerLogo)
        {
            try
            {
                var filePhoto = await storageService.UploadAsync(ImageUrl.Event, file);

                if (!filePhoto.IsSuccess)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }


                var fileLogo = await storageService.UploadAsync(ImageUrl.Event, partnerLogo);

                if (!fileLogo.IsSuccess)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }


                var slugUrl = UrlSeoOperation.UrlSeo(model?.EventLangauges?[0].Title!);

                var eventEntity = new Event
                {
                    FileCode = filePhoto?.Data,
                    PartnerLogo = fileLogo?.Data,
                    SlugUrl = slugUrl,
                    Clock = model?.Clock,
                    Map = model?.Map,
                    EventDay = model?.EventDay,
                    Link = model?.Link,
                    TicketType = model?.TicketType,

                    EventLanguages = model?.EventLangauges?.Select(x => new EventLanguage
                    {
                        Language_Code = x.Language_Code,
                        Title = x.Title,
                        Text = x.Text,
                        Price = x.Price,
                        Address = x.Address,
                        SeoDesc = x.SeoDesc,
                        SeoTitle = x.SeoTitle,
                        SeoKey = x.SeoKey,
                    }).ToList(),

                    EventCategories = model?.CategoryIds?.Select(categoryId => new EventCategory
                    {
                        CategoryId = categoryId
                    }).ToList(),

                    SpeakerEvents = model?.SpeakerIds?.Select(speakerId => new SpeakerEvent
                    {
                        SpeakerId = speakerId
                    }).ToList()
                };

                await context.Events.AddAsync(eventEntity);
                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 201);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        public async Task<ResponseModel<bool>> AddSpeakerToEventAsync(string eventId, string speakerId)
        {
            try
            {
                var eventDb = await context.Events
                    .Include(x => x.SpeakerEvents)
                    .FirstOrDefaultAsync(x => x.Id == eventId);

                if (eventDb is null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                var existingSpeaker = eventDb.SpeakerEvents?
                    .FirstOrDefault(x => x.SpeakerId == speakerId);

                if (existingSpeaker != null)
                {
                    return ResponseModel<bool>.Fail("Bu spiker zaten bu evente elave olunub.", 400);
                }

                eventDb?.SpeakerEvents?.Add(new SpeakerEvent
                {
                    EventId = eventId,
                    SpeakerId = speakerId
                });

                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        public async Task<ResponseModel<bool>> AddCategoryToEventAsync(string eventId, string categoryId)
        {
            try
            {
                var eventDb = await context.Events
                    .Include(x => x.EventCategories)
                    .FirstOrDefaultAsync(x => x.Id == eventId);

                if (eventDb is null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                var existingCategory = eventDb?.EventCategories?.FirstOrDefault(x => x.CategoryId == categoryId);

                if (existingCategory != null)
                {
                    return ResponseModel<bool>.Fail("Bu kategori bu etkinliğe eklenmiş.", 400);
                }

                eventDb?.EventCategories?.Add(new EventCategory
                {
                    EventId = eventId,
                    CategoryId = categoryId
                });

                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }


        public async Task<ResponseModel<bool>> UpdateAsync(UpdateEvenetDto model, IFormFile file, IFormFile partnerLogo)
        {
            try
            {
                var eventDb = await context.Events
                    .Include(e => e.EventLanguages)
                    .Include(e => e.EventCategories)
                    .Include(e => e.SpeakerEvents)
                    .FirstOrDefaultAsync(e => e.Id == model.Id);

                if (eventDb == null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                if (file != null)
                {
                    var filePhoto = await storageService.UploadAsync(ImageUrl.Event, file);
                    if (filePhoto.IsSuccess)
                    {

                        if (eventDb.FileCode is not null)
                        {
                            storageService.Delete(eventDb.FileCode);
                        }
                        eventDb.FileCode = filePhoto.Data;
                    }
                }

                if (partnerLogo != null)
                {
                    var fileLogo = await storageService.UploadAsync(ImageUrl.Event, partnerLogo);
                    if (fileLogo.IsSuccess)
                    {

                        if (eventDb.PartnerLogo is not null)
                        {
                            storageService.Delete(eventDb.PartnerLogo);
                        }
                        eventDb.PartnerLogo = fileLogo.Data;
                    }
                }


                eventDb.EventDay = model.EventDay;
                eventDb.Clock = model.Clock;
                eventDb.Map = model.Map;
                eventDb.Link = model.Link;
                eventDb.TicketType = model.TicketType;
                eventDb.SlugUrl = UrlSeoOperation.UrlSeo(model.EventLangauges?[0].Title!);


                eventDb.EventLanguages = model?.EventLangauges?.Select(x => new EventLanguage
                {
                    Language_Code = x.Language_Code,
                    Title = x.Title,
                    Text = x.Text,
                    Price = x.Price,
                    Address = x.Address,
                    SeoDesc = x.SeoDesc,
                    SeoTitle = x.SeoTitle,
                    SeoKey = x.SeoKey,
                }).ToList();


                var existingEventCategories = context.EventCategories.Where(ec => ec.EventId == model!.Id);
                context.EventCategories.RemoveRange(existingEventCategories);

                eventDb!.EventCategories = model?.CategoryIds?.Select(categoryId => new EventCategory
                {
                    CategoryId = categoryId
                }).ToList();


                var existingSpeakerEvent = context.SpeakerEvents.Where(sc => sc.EventId == model!.Id);
                context.SpeakerEvents.RemoveRange(existingSpeakerEvent);
       

                eventDb.SpeakerEvents = model?.SpeakerIds?.Select(speakerId => new SpeakerEvent
                {
                    SpeakerId = speakerId
                }).ToList();

                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        public async Task<ResponseModel<bool>> DeleteAsync(string id)
        {
            try
            {
                var eventDb = await context.Events
                    .Include(e => e.EventLanguages)
                    .Include(e => e.SpeakerEvents)
                    .Include(e => e.EventCategories)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (eventDb == null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                if (eventDb.FileCode is not null)
                {
                    storageService.Delete(eventDb.FileCode);
                }

                if (eventDb.PartnerLogo is not null)
                {
                    storageService.Delete(eventDb.PartnerLogo);
                }

                var result = await RemoveCategoryFromSpeakerAsync(id);

                context.Events.Remove(eventDb);

                await context.SaveChangesAsync();

                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }




        private  async Task<ResponseModel<bool>> RemoveCategoryFromSpeakerAsync(string id)
        {
            try
            {
                var eventDb = await context.Events
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (eventDb is null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                var speakerEvent = eventDb.SpeakerEvents;
                ArgumentNullException.ThrowIfNull(speakerEvent);

                foreach (var speaker in speakerEvent)
                {
                    context.SpeakerEvents.Remove(speaker);
                }


                var eventCategory = eventDb.EventCategories;
                ArgumentNullException.ThrowIfNull(eventCategory);

                foreach (var category in eventCategory)
                {
                    context.EventCategories.Remove(category);
                }

                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }

            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }




    }
}
