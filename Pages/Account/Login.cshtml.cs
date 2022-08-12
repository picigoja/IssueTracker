using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Pages.Account
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public Credential Credential { get; set; } = default!;

        public void OnPost()
        {
            if (!ModelState.IsValid) return;

            //Verify the credentials
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
