using GlassLewis.Core.GlassLewis.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLewis.Core.GlassLewis.Features.Company.Queries
{
    public class GlassLewisGetCompanyByISIN : IRequest<string>
    {
        public string Isin { get; set; }
        public GlassLewisGetCompanyByISIN(string _isin)
        {
            Isin = _isin;
        }
    }

    public class GlassLewisGetCompanyByISINHandler : IRequestHandler<GlassLewisGetCompanyByISIN, string>
    {
        private readonly ICompanyRepository _companyRepository;

        public GlassLewisGetCompanyByISINHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<string> Handle(GlassLewisGetCompanyByISIN request, CancellationToken cancellationToken)
        {
            var result = await this._companyRepository.GetCompanyByISIN(request.Isin).ConfigureAwait(false);
            return result;
        }
    }
}
