using Microsoft.AspNetCore.Mvc;

namespace MongoExample.Application.Queries
{
    public class GetPostQueryHandler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
