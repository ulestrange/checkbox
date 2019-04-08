using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkboxes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace checkboxes.Pages
{
    public class IndexModel : PageModel
    {
        #region db stuff
        private readonly MyContext _db;

        public IndexModel(MyContext db)
        {
            _db = db;
        }

        #endregion

        [BindProperty]
        public Decor Decor { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _db.Decors.Add(Decor);
                await _db.SaveChangesAsync();

                return RedirectToPage("List");

            }
            else
            {
                return Page();
            }
        }
    }
}
