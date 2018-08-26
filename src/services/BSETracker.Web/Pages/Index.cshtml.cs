using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BSETracker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BSETracker.Web.Pages
{
    public class IndexModel : PageModel
    {
        public bool? Success { get; set; }
        public string Error { get; set; }
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
            VM.Email = VM.Email.Trim().ToLowerInvariant();
            if(!ModelState.IsValid) {
                return Page();
            }

            try{
                var result = await db.Registrations.AddAsync(VM.ToRegistrationDM());
                Success = await db.SaveChangesAsync() > 0;
            }
            catch(DbUpdateException ex)
            {
                Success = false;
                if(ex.InnerException is PostgresException)
                {
                    var inner = ex.InnerException as PostgresException;
                    if(inner.SqlState == "23505")
                    {
                        Error = "You're already registered 😎";
                    }
                }
            }
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
