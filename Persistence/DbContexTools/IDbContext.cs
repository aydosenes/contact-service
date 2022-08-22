using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DbContexTools
{
    public interface IDbContext
    {
        DatabaseFacade Database { get; }
    }
}
