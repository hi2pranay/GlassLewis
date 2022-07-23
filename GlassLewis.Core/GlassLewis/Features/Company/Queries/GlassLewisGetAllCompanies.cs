using GlassLewis.Core.GlassLewis.Interfaces;
using MediatR;

namespace GlassLewis.Core.GlassLewis.Features.Company.Queries
{
    public class GlassLewisGetAllCompanies : IRequest<List<GlassLewis.Models.Company>>
    {
        public GlassLewisGetAllCompanies()
        {
        }
    }

    public class GlassLewisGetAllCompaniesHandler : IRequestHandler<GlassLewisGetAllCompanies, List<GlassLewis.Models.Company>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GlassLewisGetAllCompaniesHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Models.Company>> Handle(GlassLewisGetAllCompanies request, CancellationToken cancellationToken)
        {
            var result = await this._companyRepository.GetAllCompanies().ConfigureAwait(false);
            return result;
        }
    }
}
