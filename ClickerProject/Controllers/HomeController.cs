using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ClickerProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello world!";
        }
    }
}
