using Domain.Dtos.Event;
using Domain.Dtos.Photo;

namespace WebApp.Models
{
    public class EventVM
    {
        public EventDetailDto? GetEvent { get; set; }
        public List<PhotoDto>? Photos { get; set; }
        
    }
}
