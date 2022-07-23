using GlassLewis.Core.GlassLewis.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLewis.Core.GlassLewis.Features.Company.Commands
{
    public class UpdateCompany : IRequest<bool>
    {
        public GlassLewis.Models.Company _company { get; set; }
        public UpdateCompany(GlassLewis.Models.Company company)
        {
            _company = company;
        }
    }

    public class UpdateCompanyHandler : IRequestHandler<UpdateCompany, bool>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(UpdateCompany request, CancellationToken cancellationToken)
        {
            var result = await this._companyRepository.UpdateCompany(request._company).ConfigureAwait(false);
            return result;
        }
    }
}
