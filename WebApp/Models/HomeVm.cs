using Domain.Dtos.Event;
using Domain.Dtos.Slider;
using Domain.Dtos.Speaker;

namespace WebApp.Models
{
    public class HomeVm
    {
        public List<SliderClientDto>? SliderClients { get; set; }
        public List<SpeakerClientDto>? SpeakerClients   { get; set; }
        public List<EventClientDto>? EventClinets { get; set; }
    }
}
