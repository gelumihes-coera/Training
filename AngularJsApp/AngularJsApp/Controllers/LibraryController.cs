using System.Net;
using System.Web.Mvc;
using AngularJsApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AngularJsApp.Controllers
{
    public class LibraryController : Controller
    {
        LibraryRepository libraryRepository = new LibraryRepository();

        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAuthorDetails()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(libraryRepository.GetAuthors(), settings),
                ContentType = "application/json"
            };

            return jsonResult;
        }

        [HttpPost]
        public ActionResult AddAuthor(AuthorViewModel author)
        {
            libraryRepository.AddAuthor(author);
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Author added");
        }

        public ActionResult GetBookDetails()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(libraryRepository.GetBooks(), settings),
                ContentType = "application/json"
            };

            return jsonResult;
        }
    }
}