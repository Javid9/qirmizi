using Application.Helpers;
using Domain.Dtos.Contact;

namespace Application.Services
{
    public interface IContactService
    {
        Task<ResponseModel<bool>> WriteToUsMessage(CreateContact model);
        Task<ResponseModel<List<ContactDto>>> GetList();
        Task<ResponseModel<ContactDto>> GetById(string id);
        Task<ResponseModel<bool>> Delete(string id);
    }
}
