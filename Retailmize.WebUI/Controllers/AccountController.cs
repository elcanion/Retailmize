using Microsoft.AspNetCore.Mvc;
using Retailmize.Domain.Account;

namespace Retailmize.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;
        public AccountController(IAuthenticate authentication)
        {
            _authentication = authentication;
        }
    }
}
