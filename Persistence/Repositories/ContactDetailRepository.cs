using Application.Interfaces.Repository;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class ContactDetailRepository : BaseMongoRepository<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)
        {

        }
    }
}