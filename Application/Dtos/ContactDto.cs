using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class ContactDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ContactDetailDto ContactDetail { get; set; }
    }
}
