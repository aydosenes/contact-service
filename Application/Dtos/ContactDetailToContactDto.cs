using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class ContactDetailToContactDto
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactDetailId { get; set; }
    }
}
