using BookApplication.Models;
using BookApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.Controllers
{
    public class HomeController : Controller
    {
        private List<Author> authors = new List<Author>()
        {
            new Author { Id = 1, Name = "Ali", Country = "Pakistan" },
            new Author { Id = 2, Name = "John", Country = "USA" }
        };

        static List<Book> books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "ASP.NET Core MVC",
                Price = 1200,
                AuthorId = 1
            },
            new Book
            {
                Id = 1,
                Title = "Harry Potter",
                Price = 1500,
                AuthorId = 1
            },
            new Book
            {
                Id = 2,
                Title = "1984",
                Price = 1200,
                AuthorId = 2
            },
            new Book
            {
                Id = 3,
                Title = "Animal Farm",
                Price = 1000,
                AuthorId = 2
            }
        };

        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel()
            {
                Books = books,
                Authors = authors
            };

            return View(vm);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(string Title, decimal Price, int AuthorId)
        {
            // Bonus validation
            if (string.IsNullOrWhiteSpace(Title))
            {
                return RedirectToAction("Index");
            }

            books.Add(new Book
            {
                Id = books.Count + 1,
                Title = Title,
                Price = Price,
                AuthorId = AuthorId
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddAuthor(string Name, string Country)
        {
            authors.Add(new Author
            {
                Id = authors.Count + 1,
                Name = Name,
                Country = Country
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
            }

            return RedirectToAction("Index");
        }
    }
}
