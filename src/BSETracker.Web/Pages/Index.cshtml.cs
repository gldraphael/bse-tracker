using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BSETracker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BSETracker.Web.Pages
{
    public class IndexModel : PageModel
    {

        public bool? Success { get; set; }
        private readonly AppDbContext db;
        public IndexModel(AppDbContext db) 
        {
            this.db = db;
        }

        [BindProperty]
        public IndexRequestVM VM { get; set; }

        public PageResult OnGet()
        {
            return Page();
        }

        public async Task<PageResult> OnPostAsync()
        {
            if(!ModelState.IsValid) {
                return Page();
            }

            var result = await db.Registrations.AddAsync(VM.ToRegistrationDM());
            Success = await db.SaveChangesAsync() > 0;
            return Page();
        }

        public class IndexRequestVM
        {
            [EmailAddress]
            public string Email { get; set; }

            public Registration ToRegistrationDM() {
                return new Registration {
                    Email = Email
                };
            }
        }

    }
}
