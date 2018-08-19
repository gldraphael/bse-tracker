using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BSETracker.Web.Pages
{
    public class IndexModel : PageModel
    {

        public bool? Success { get; set; }

        [BindProperty]
        public IndexRequestVM VM { get; set; }

        public PageResult OnGet()
        {
            return Page();
        }

        public PageResult OnPost()
        {
            Success = ModelState.IsValid;
            return Page();
        }

        public class IndexRequestVM
        {
            [EmailAddress]
            public string Email { get; set; }
        }

    }
}
