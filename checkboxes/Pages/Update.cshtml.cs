using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkboxes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace checkboxes.Pages
{
    public class UpdateModel : PageModel
    {

        #region db stuff
        private readonly MyContext _db;

        public UpdateModel(MyContext db)
        {
            _db = db;
        }

        #endregion
        [BindProperty]
        public Decor Decor { get; set; }

        [BindProperty]
        public List<bool> ColoursPicked { get; set; } =
        new List<bool> { false, false, false };

        public List<string> ColourChoices { get; set; } =
            new List<string> { "Red", "Blue", "Green" };

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Decor = await _db.Decors.FindAsync(id);

            if (Decor == null)
            {
                return NotFound();
            }

            ColoursPicked = Decor.GenerateBooleanList(ColourChoices);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Decor.GenerateColoursString(ColourChoices, ColoursPicked);

            _db.Attach(Decor).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Student {Decor.ID} not found!");
            }



            return RedirectToPage("/List");
        }
    }
}