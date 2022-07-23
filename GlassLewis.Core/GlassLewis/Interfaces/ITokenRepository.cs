using GlassLewis.Core.GlassLewis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLewis.Core.GlassLewis.Interfaces
{
    public interface ITokenRepository
    {
        Task<string> GetToken(UserInfo userinfo);
    }
}
