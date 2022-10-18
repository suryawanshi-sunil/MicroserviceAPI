using Company.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Data
{
    public class CompanyContext : ICompanyContext
    {
        public CompanyContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            companies = database.GetCollection<CompanyModel>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CompanyContextSeed.SeedData(companies);
        }
        public IMongoCollection<Entities.CompanyModel> companies { get; }
    }
}
