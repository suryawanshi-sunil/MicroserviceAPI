using Company.API.Data;
using Company.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ICompanyContext _context;

        public CompanyRepository(ICompanyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateCompany(CompanyModel companyModel)
        {
            await _context.companies.InsertOneAsync(companyModel);
        }

        public async Task<bool> DeleteCompany(string Id)
        {
            FilterDefinition<CompanyModel> filter = Builders<CompanyModel>.Filter.Eq(p => p.Company_Code, Id);
            DeleteResult deleteResult = await _context.companies.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<CompanyModel>> GetCompanies()
        {
            return await _context.companies.Find(p => true).ToListAsync();
        }

        public async Task<CompanyModel> GetCompany(string companycode)
        {
            return await _context.companies.Find(p => p.Company_Code == companycode).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CompanyModel>> GetSearchedCompanyList(string companycode)
        {
            return await _context.companies.Find(p => p.Company_Code == companycode).ToListAsync();
        }
    }
}
