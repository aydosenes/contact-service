using Domain.Common;
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Contact : BaseEntity
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactDetailId { get; set; }
        [BsonIgnore]
        public ContactDetail ContactDetail { get; set; }
    }
}
