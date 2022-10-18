using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Data
{
    public interface ICompanyContext
    {
        IMongoCollection<Company.API.Entities.CompanyModel> companies { get; }
    }
}
