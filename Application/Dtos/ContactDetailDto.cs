using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.Dtos
{
    public class ContactDetailDto
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }
    }
}
