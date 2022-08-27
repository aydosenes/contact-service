using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using System;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Dtos;
using Application.Features.Request.Commands.ContactCommands;

namespace Application.Features.Handlers.Commands.ContactHandlers
{
    public class DeleteContactDetailFromContactCommandHandler : IRequestHandler<DeleteContactDetailFromContactCommand, IDataResult<Contact>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;
        public DeleteContactDetailFromContactCommandHandler(IContactRepository contactRepository, IMapper mapper, IContactDetailRepository contactDetailRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _contactDetailRepository = contactDetailRepository;
        }
        public async Task<IDataResult<Contact>> Handle(DeleteContactDetailFromContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _contactRepository.GetByIdAsync(request.ContactId);
                contact.ContactDetailIdList.Remove(request.ContactDetailId);
                var detail = await _contactDetailRepository.GetByIdAsync(request.ContactDetailId);
                detail.ContactId = string.Empty;
                var updatedDetail = await _contactDetailRepository.UpdateAsync(detail);
                var result = await _contactRepository.UpdateAsync(contact);
                return new SuccessDataResult<Contact>(result, Messages.Success_Deleted);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Contact>(ex.Message);
            }
        }
    }
}