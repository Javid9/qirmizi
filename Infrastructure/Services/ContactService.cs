using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.Contact;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ContactService(IDatabaseContext _context) : IContactService
    {

        public async Task<ResponseModel<bool>> Delete(string id)
        {
            try
            {
                var entity = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id );
                if (entity == null)
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 400);
                _context.Contacts.Remove(entity);
                await _context.SaveChangesAsync();
                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        public async Task<ResponseModel<ContactDto>> GetById(string id)
        {
            var entity = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return ResponseModel<ContactDto>.Fail(Messages.NoDataFound, 400);
            var result = entity.Adapt<ContactDto>();
            return ResponseModel<ContactDto>.Success(result, 200);
        }



        public async Task<ResponseModel<List<ContactDto>>> GetList()
        {
            var entities = await _context.Contacts.ToListAsync();
            var result = entities.Adapt<List<ContactDto>>();
            return ResponseModel<List<ContactDto>>.Success(result, 200);
        }


        public async Task<ResponseModel<bool>> WriteToUsMessage(CreateContact model)
        {
            try
            {
                var result = model.Adapt<Contact>();
                await _context.Contacts.AddAsync(result);

                await _context.SaveChangesAsync();
                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



    }
}
