using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.SafetyNet;
using GoogleCaptcha.Droid.CaptchaService;
using GoogleCaptcha.RecaptchaService;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(ReCaptchaService))]
namespace GoogleCaptcha.Droid.CaptchaService
{
    public class ReCaptchaService : IReCaptchaService
    {
        private static Context CurrentContext => CrossCurrentActivity.Current.Activity;

        private SafetyNetClient _safetyNetClient;
        private SafetyNetClient SafetyNetClient
        {
            get
            {
                return _safetyNetClient ??= SafetyNetClass.GetClient(CurrentContext);
            }
        }

        public async Task<string> Verify(string siteKey, string domainUrl)
        {
            SafetyNetApiRecaptchaTokenResponse response = await SafetyNetClass.GetClient(CrossCurrentActivity.Current.Activity).VerifyWithRecaptchaAsync(siteKey);
            return response?.TokenResult;
        }
    }
}

