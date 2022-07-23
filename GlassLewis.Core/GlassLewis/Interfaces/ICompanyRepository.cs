using GlassLewis.Core.GlassLewis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLewis.Core.GlassLewis.Interfaces
{
    public interface ICompanyRepository
    {
        Task<bool> CreateCompany(Company company);
        Task<List<Company>> GetAllCompanies();
        Task<string> GetCompanyById(int Id);
        Task<string> GetCompanyByISIN(string Isin);
        Task<bool> UpdateCompany(Company company);
    }
}
