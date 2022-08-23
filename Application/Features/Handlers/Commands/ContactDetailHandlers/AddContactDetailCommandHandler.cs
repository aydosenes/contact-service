using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using System;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Dtos;
using Application.Features.Request.Commands.ContactDetailCommands;

namespace Application.Features.Handlers.Commands.ContactDetailHandlers
{
    public class AddContactDetailCommandHandler : IRequestHandler<AddContactDetailCommand, IDataResult<ContactDetail>>
    {
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;
        public AddContactDetailCommandHandler(IContactDetailRepository contactRepository, IMapper mapper)
        {
            _contactDetailRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<ContactDetail>> Handle(AddContactDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapped = _mapper.Map<ContactDetail>(request.ContactDetail);
                var result = await _contactDetailRepository.AddAsync(mapped);
                return new SuccessDataResult<ContactDetail>(result, Messages.Success_Added);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ContactDetail>(ex.Message);
            }
        }
    }
}
