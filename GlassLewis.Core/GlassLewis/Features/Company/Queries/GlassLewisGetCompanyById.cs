using GlassLewis.Core.Common.Wrappers;
using GlassLewis.Core.GlassLewis.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLewis.Core.GlassLewis.Features.Company.Queries
{
    public class GlassLewisGetCompanyById : IRequest<string>
    {
        public int Id { get; set; }
        public GlassLewisGetCompanyById(int _id)
        {
            Id = _id;
        }
    }

    public class GlassLewisGetCompanyByIdHandler : IRequestHandler<GlassLewisGetCompanyById,string>
    {
        private readonly ICompanyRepository _companyRepository;

        public GlassLewisGetCompanyByIdHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<string> Handle(GlassLewisGetCompanyById request, CancellationToken cancellationToken)
        {
            var result = await this._companyRepository.GetCompanyById(request.Id).ConfigureAwait(false);
            return result;
        }
    }
}
