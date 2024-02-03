using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GoogleCaptcha.RecaptchaService;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GoogleCaptcha
{
    public class response
    {

    }
    public partial class MainPage : ContentPage
    {

        //for key setup site
        //https://www.google.com/recaptcha/admin/site/604115686/setup

        private static readonly string SiteKey = DeviceInfo.Platform == DevicePlatform.Android ? "6Led5AEkAAAAAFATOzgiwZcNhHglDjM4OCU3qdpU" : "6Le7GAIkAAAAAFv3mKtMV771eShMT-HRvCLdphNd";
        private static readonly string SiteSecretKey = DeviceInfo.Platform == DevicePlatform.Android ? "6Led5AEkAAAAAMUNfCboIZdbifX91sRpz2bQDVu3" : "6Le7GAIkAAAAAG1SAgWr9sc452cw3rR-TEs3bu_O";
        private const string BaseApiUrl = "https://localhost";
        public const string GoogleCaptchaVerificationUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            IReCaptchaService reCaptchaService = Xamarin.Forms.DependencyService.Get<IReCaptchaService>();

            var captchaToken = await reCaptchaService.Verify(SiteKey, BaseApiUrl);

            if (captchaToken == null)
            {
                return;
            }

            var captchaVerificationUrl = string.Format("{0}{1}{2}",GoogleCaptchaVerificationUrl, SiteSecretKey, captchaToken);

            //using (HttpClient client = new HttpClient())
            //{
            //   HttpResponseMessage response =  await client.GetAsync(captchaVerificationUrl);
            //    var content = await response.Content.ReadAsStringAsync();
            //    var result = JsonConvert.DeserializeObject<response>(content);
            //}
        }
    }
}

