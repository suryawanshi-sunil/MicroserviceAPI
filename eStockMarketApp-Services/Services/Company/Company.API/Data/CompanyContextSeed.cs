using Company.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Company.API.Data
{
    public class CompanyContextSeed
    {
        public static void SeedData(IMongoCollection<CompanyModel> companyColleciton)
        {
            bool existCompany = companyColleciton.Find(p=>true).Any();
            if (!existCompany)
            {
                companyColleciton.InsertManyAsync(GetPreConfigureCompanies());
            }
        }

        private static IEnumerable<CompanyModel> GetPreConfigureCompanies()
        {
            return new List<CompanyModel>()
            {
                new CompanyModel()
                {
                    Company_Code = "003",
                    Company_CEO = "Sundar Pichae",
                    Company_Name = "Google",
                    Company_Turnover = 3000,
                    Company_Listing = "NSE",
                    Company_Website = "WWW.Google.com"
                },
                new CompanyModel()
                {
                    Company_Code = "004",
                    Company_CEO = "Vinit Bansal",
                    Company_Name = "Flipkart",
                    Company_Turnover = 200,
                    Company_Listing = "BSE",
                    Company_Website = "WWW.Flipkart.com"
                }
            };
        }
    }
}
