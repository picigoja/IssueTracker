using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Models;

namespace IssueTracker.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly Data.IssueTrackerContext _context;

        public IndexModel(Data.IssueTrackerContext context)
        {
            _context = context;
        }

        public new IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}
