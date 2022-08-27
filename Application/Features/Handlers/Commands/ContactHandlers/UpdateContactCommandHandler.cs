using Application.Features.Request.Commands.ContactCommands;
using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using System;
using System.Collections.Generic;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Dtos;

namespace Application.Features.Handlers.Commands.ContactHandlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, IDataResult<Contact>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;
        public UpdateContactCommandHandler(IContactRepository contactRepository, IMapper mapper, IContactDetailRepository contactDetailRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _contactDetailRepository = contactDetailRepository;
        }
        public async Task<IDataResult<Contact>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var get = await _contactRepository.GetByIdAsync(request.Contact.Id);
                
                var result = await _contactRepository.UpdateAsync(_mapper.Map<Contact>(request.Contact));

                if (result.ContactDetailIdList != get.ContactDetailIdList )
                {
                    var list = new List<ContactDetail>();
                    var details = await _contactDetailRepository.GetListAsync(g => result.ContactDetailIdList.Contains(g.Id));
                    foreach (var d in details)
                    {
                        d.ContactId = result.Id;
                        list.Add(d);
                    }
                    var update = await _contactDetailRepository.UpdateRangeAsync(list);
                }
                return new SuccessDataResult<Contact>(result, Messages.Success_Updated);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Contact>(ex.Message);
            }
        }
    }
}