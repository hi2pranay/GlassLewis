using GlassLewis.Core.GlassLewis.Interfaces;
using GlassLewis.Core.GlassLewis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLewis.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly GlassLewisDbContext _glassLewisDbContext;

        public CompanyRepository(GlassLewisDbContext glassLewisDbContext)
        {
            _glassLewisDbContext = glassLewisDbContext;
        }

        public async Task<bool> CreateCompany(Company company)
        {
            bool isCreate = false;
            try
            {
                IQueryable<Company> companiesQuery = from comp in _glassLewisDbContext.Company
                                                     where comp.ISIN == company.ISIN
                                                     select comp;

                var companies = companiesQuery.ToList();
                if (companies.Count > 0)
                {
                    throw new Exception("Companies with the same Isin already exists");
                }

                var outPut = await _glassLewisDbContext.AddAsync<Company>(company);
                await _glassLewisDbContext.SaveChangesAsync();
                isCreate = outPut != null ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isCreate;
        }

        public Task<List<Company>> GetAllCompanies()
        {
            List<Company> _companies = null;
            try
            {
                IQueryable<Company> companies = from comp in _glassLewisDbContext.Company
                                                select comp;
                _companies = companies.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(_companies);
        }

        public async Task<string> GetCompanyById(int Id)
        {
            string company = string.Empty;
            try
            {
                IQueryable<Company> companies = from comp in _glassLewisDbContext.Company
                                                where comp.Id == Id
                                                select comp;

                Company _company = companies.FirstOrDefault();

                if (_company != null)
                {
                    company = _company.Name;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return company;
        }

        public async Task<string> GetCompanyByISIN(string Isin)
        {
            string company = string.Empty;
            try
            {
                IQueryable<Company> companies = from comp in _glassLewisDbContext.Company
                                                where comp.ISIN == Isin
                                                select comp;

                Company _company = companies.FirstOrDefault();

                if (_company != null)
                {
                    company = _company.Name;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return company;
        }

        public Task<bool> UpdateCompany(Company company)
        {
            bool isUpdate = false;
            try
            {
                Company comp = _glassLewisDbContext.Company.Where(c => c.Id == company.Id).FirstOrDefault();

                if (comp != null)
                {
                    comp.Name = company.Name;
                    comp.Exchange = company.Exchange;
                    comp.Ticker = company.Ticker;
                    comp.ISIN = company.ISIN;
                    comp.Website = company.Website;

                    _glassLewisDbContext.Entry(comp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _glassLewisDbContext.SaveChanges();
                    isUpdate = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(isUpdate);
        }
    }
}
