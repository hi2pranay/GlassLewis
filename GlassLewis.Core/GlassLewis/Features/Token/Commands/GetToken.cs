using GlassLewis.Core.GlassLewis.Interfaces;
using GlassLewis.Core.GlassLewis.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLewis.Core.GlassLewis.Features.Token.Commands
{
    public class GetToken : IRequest<string>
    {
        public UserInfo _userInfo{ get; set; }
        public GetToken(UserInfo userInfo)
        {
            _userInfo = userInfo;
        }
    }

    public class GetTokenHandler : IRequestHandler<GetToken, string>
    {
        private readonly ITokenRepository _tokenRepository;

        public GetTokenHandler(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<string> Handle(GetToken request, CancellationToken cancellationToken)
        {
            var result = await this._tokenRepository.GetToken(request._userInfo).ConfigureAwait(false);
            return result;
        }
    }
}
