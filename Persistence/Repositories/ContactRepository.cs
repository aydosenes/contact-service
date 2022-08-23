using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Persistence.DbContexTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class ContactRepository : BaseMongoRepository<Contact>, IContactRepository
    {
        public ContactRepository(IOptions<DbSetting> options) : base(options, "Contacts")
        {

        }
    }
}
