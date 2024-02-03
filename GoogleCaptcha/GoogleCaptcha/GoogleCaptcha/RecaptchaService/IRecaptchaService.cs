using System;
using System.Threading.Tasks;

namespace GoogleCaptcha.RecaptchaService
{
    public interface IReCaptchaService
    {
        Task<string> Verify(string siteKey, string domainUrl);
    }
}

