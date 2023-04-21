using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly CommentService _commentService;

        public ContactsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.PostCommentAsync(model);

                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    ModelState.Clear();
                    model = new ContactsViewModel()
                    {
                        ConfirmationMessage = "Your comment has been posted, and will be read soon."
                    };
                    return View(model);
                }

                model.ConfirmationMessage = "Something went wrong, try again.";

            }

            return View(model);
        }
    }
}
