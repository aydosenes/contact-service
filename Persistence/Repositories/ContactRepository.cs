using Application.Interfaces.Repository;
using Domain.Entities;
using Persistence.DbContexTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class ContactRepository : BaseMongoRepository<Contact>, IContactRepository
    {
        public ContactRepository(DbSetting dbSetting) : base(dbSetting, "Contacts")
        {

        }
    }
}
