using AkfnyPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkfnyPresentation.Helper
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, string user, string role);
        bool IsTokenValid(string key, string issuer, string token);
    }
}
