using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkboxes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

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


        // The list of booleans is not stored in the
        // database but is needed for the user interface
        // when model binding happens

        [BindProperty]
        public List<bool> ColoursPicked { get; set; } =
        new List<bool> { false, false, false };

        public List<string> ColourChoices { get; set; } =
            new List<string> { "Red", "Blue", "Green" };
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Decor.GenerateColoursString(ColourChoices, ColoursPicked);

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
