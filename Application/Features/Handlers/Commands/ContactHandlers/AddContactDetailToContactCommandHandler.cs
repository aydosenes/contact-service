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
    public class AddContactDetailToContactCommandHandler : IRequestHandler<AddContactDetailToContactCommand, IDataResult<Contact>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;
        public AddContactDetailToContactCommandHandler(IContactRepository contactRepository, IMapper mapper, IContactDetailRepository contactDetailRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _contactDetailRepository = contactDetailRepository;
        }
        public async Task<IDataResult<Contact>> Handle(AddContactDetailToContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _contactRepository.GetByIdAsync(request.ContactIdAndContactDetailIdPairDto.ContactId);
                if (request.ContactIdAndContactDetailIdPairDto.ContactDetailId is null)
                {
                    var mapped = _mapper.Map<ContactDetail>(request.ContactIdAndContactDetailIdPairDto.ContactDetail);
                    var detail = await _contactDetailRepository.AddAsync(mapped);
                    contact.ContactDetailIdList.Add(detail.Id);
                }
                else
                {
                    contact.ContactDetailIdList.Add(request.ContactIdAndContactDetailIdPairDto.ContactDetailId);
                }                
                var result = await _contactRepository.UpdateAsync(contact);
                return new SuccessDataResult<Contact>(result, Messages.Success_Added);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Contact>(ex.Message);
            }
        }
    }
}
