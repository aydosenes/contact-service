using Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ContactDetail : BaseEntity
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }
    }
}
