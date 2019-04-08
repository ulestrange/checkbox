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

    public class ListModel : PageModel
    {

        private readonly MyContext _db;

        public ListModel(MyContext db)
        {
            _db = db;
        }

        public IList<Decor> Decors { get; private set; }

        public async Task OnGetAsync()
        {
            Decors = await _db.Decors.AsNoTracking().ToListAsync();
        }
    }
}
