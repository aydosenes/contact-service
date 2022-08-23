using Application.Interfaces.Repository;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class ContactRepository : BaseMongoRepository<Contact>, IContactRepository
    {
        public ContactRepository(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)  
        {

        }
    }
}
