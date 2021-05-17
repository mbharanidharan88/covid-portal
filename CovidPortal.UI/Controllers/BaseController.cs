using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Linq;
using System;
using System.Net.Http.Headers;

namespace CovidPortal.UI.Controllers
{
    //Works as API Gateway
    public class BaseController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Patient HTTP Client

        private HttpClient _patientClient;
        protected HttpClient PatientClient
        {
            get
            {
                return _patientClient ?? getPatientClient();
            }
        }

        #endregion

        #region Hospital HTTP Client

        private HttpClient _hospitalClient;
        protected HttpClient HospitalClient
        {
            get
            {
                return _hospitalClient ?? getHospitalClient();
            }
        }

        #endregion

        #region Vendor HTTP Client

        private HttpClient _vendorClient;
        protected HttpClient VendorClient
        {
            get
            {
                return _vendorClient ?? getVendorClient();
            }
        }

        #endregion

        private HttpClient getPatientClient()
        {
            var client = new HttpClient();
            var baseurl = _configuration.GetValue<string>("PatientBaseUrl");
            client.BaseAddress = new Uri(baseurl);

            _patientClient = setHeaders(client);

            return _patientClient;
        }

        private HttpClient getHospitalClient()
        {
            var client = new HttpClient();
            var baseurl = _configuration.GetValue<string>("HospitalBaseUrl");
            client.BaseAddress = new Uri(baseurl);

            _hospitalClient = setHeaders(client);

            return _hospitalClient;
        }

        private HttpClient getVendorClient()
        {
            var client = new HttpClient();
            var baseurl = _configuration.GetValue<string>("VendorBaseUrl");
            client.BaseAddress = new Uri(baseurl);

            _vendorClient = setHeaders(client);

            return _vendorClient;
        }

        private HttpClient setHeaders(HttpClient client)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].FirstOrDefault()?.Replace("Bearer", "").Trim();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return client;
        }
    }
}
