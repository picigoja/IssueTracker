using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IssueTracker.Models;

namespace IssueTracker.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly Data.IssueTrackerContext _context;

        public CreateModel(Data.IssueTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public new User User { get; set; } = default!;

        [BindProperty]
        public bool UserNameTaken { get; set; } = false;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            UserNameTaken = _context.User.FirstOrDefault(u => u.Name == User.Name) != null;
            if (!ModelState.IsValid || _context.User == null || User == null || UserNameTaken)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
