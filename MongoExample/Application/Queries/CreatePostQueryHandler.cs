using Microsoft.AspNetCore.Mvc;

namespace MongoExample.Application.Queries
{
    public class CreatePostQueryHandler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
