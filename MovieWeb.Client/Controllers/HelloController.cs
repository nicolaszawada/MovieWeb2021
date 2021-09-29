using Microsoft.AspNetCore.Mvc;
using MovieWeb.Client.Models;

namespace MovieWeb.Client.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult World([FromQuery] string name)
        {
            var vm = new HelloWorldViewModel();
            vm.Name = name;

            return View(vm);
        }
    }
}
