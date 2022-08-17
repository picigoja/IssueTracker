using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IssueTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Pages.Projects
{
    [Authorize]
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
        public Project Project { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Project.Created = DateTime.Now;
            Project.CreatedBy = await _context.User.FirstAsync(u => u.Name == User.Identity.Name);

            if (_context.Project == null || Project == null)
            {
                return Page();
            }

            _context.Project.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
