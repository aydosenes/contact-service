using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class ContactWithContactDetailListDto
    {
        public ContactDto Contact { get; set; }
        public ICollection<ContactDetailDto> ContactDetailList { get; set; }
    }
}
