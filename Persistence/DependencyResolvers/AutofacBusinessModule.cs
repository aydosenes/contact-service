using Application.Interfaces.Repository;
using Autofac;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactRepository>().As<IContactRepository>()
                    .WithParameter("connectionString", "mongodb://localhost:27017")
                    .WithParameter("databaseName", "ContactDb")
                    .WithParameter("collectionName", "Contacts")
                    .SingleInstance();

            builder.RegisterType<ContactDetailRepository>().As<IContactDetailRepository>()
                    .WithParameter("connectionString", "mongodb://localhost:27017")
                    .WithParameter("databaseName", "ContactDb")
                    .WithParameter("collectionName", "ContactDetails")
                    .SingleInstance();
        }
    }
}
