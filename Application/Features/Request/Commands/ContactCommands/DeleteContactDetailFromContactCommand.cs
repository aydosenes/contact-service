using Application.Dtos;
using Application.Results;
using Domain.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.Features.Request.Commands.ContactCommands
{
    public class DeleteContactDetailFromContactCommand : IRequest<IDataResult<Contact>>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactDetailId { get; set; }
    }
}
