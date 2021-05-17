using CovidPortal.IdentityService.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CovidPortal.IdentityService.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly IIdentityServerInteractionService _interaction;
        private readonly ILogger _logger;

        #endregion

        #region Constructor

        public HomeController(IIdentityServerInteractionService interaction,
                                ILogger<HomeController> logger)
        {
            _interaction = interaction;
            _logger = logger;
        }

        #endregion


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;

                //if (!_environment.IsDevelopment())
                //{
                //    // only show in development
                //    message.ErrorDescription = null;
                //}
            }

            return View("Error", vm);
        }
    }
}
