using IssueTracker.Data;
using IssueTracker.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace IssueTracker.Pages.Account
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public Credential Credential { get; set; } = default!;
        private readonly IssueTrackerContext _context;
        public const string AuthCookie = "MyCookieAuth";

        public LoginModel(IssueTrackerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = await _context.User.FirstOrDefaultAsync(m => m.Name == Credential.UserName);
            if (user == null) return Page();
            if (user.Password == Credential.Password)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                };
                var identity = new ClaimsIdentity(claims, AuthCookie);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(AuthCookie, claimsPrincipal);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }

    public class Credential
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
    }
}
