using GlassLewis.Core.GlassLewis.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GlassLewis.Core.GlassLewis.Features.Company.Commands
{
    public class CreateCompany : IRequest<bool>
    {
        public GlassLewis.Models.Company _company { get; set; }
        public CreateCompany(GlassLewis.Models.Company company)
        {
            _company = company;
        }
    }

    public class CreateCompanyHandler : IRequestHandler<CreateCompany, bool>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(CreateCompany request, CancellationToken cancellationToken)
        {
            string isin = request._company.ISIN;
            if (!string.IsNullOrWhiteSpace(isin))
            {
                if (!Regex.IsMatch(isin[0].ToString(), "[A-Za-z]") || !Regex.IsMatch(isin[1].ToString(), "[A-Za-z]"))
                {
                    throw new Exception("The first two characters of an ISIN must be letters / non numeric.");
                }
            }

            var result = await this._companyRepository.CreateCompany(request._company).ConfigureAwait(false);
            return result;
        }
    }
}
