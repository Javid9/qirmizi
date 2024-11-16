using Domain.Dtos.About;
using Domain.Dtos.Photo;

namespace WebApp.Models
{
    public class AboutVM
    {
        public List<AboutClientDto>? AboutClients { get; set; }
        public List<PhotoDto>? Photos { get; set; }
    }
}
