using Microsoft.AspNetCore.Http;

namespace Domain.Dtos.Photo;

public class PhotoVM
{
    public PhotoDto? Photo { get; set; }
    public List<PhotoDto>? Photos { get; set; }
    public IFormFileCollection? Files { get; set; }
}
