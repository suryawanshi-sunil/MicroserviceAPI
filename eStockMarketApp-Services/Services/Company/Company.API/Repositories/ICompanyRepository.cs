using Company.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyModel>> GetCompanies();
        Task<CompanyModel> GetCompany(string companycode);
        Task CreateCompany(CompanyModel companyModel);
        Task<bool> DeleteCompany(string Id);
        Task<IEnumerable<CompanyModel>> GetSearchedCompanyList(string companycode);
    }
}
