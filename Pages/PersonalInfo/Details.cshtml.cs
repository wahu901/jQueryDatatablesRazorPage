using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jQueryDatatablesRazorPage.Models;
using jQueryDatatablesRazorPage.Repository;

namespace jQueryDatatablesRazorPage
{
    public class DetailsModel : PageModel
    {
        private readonly jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext _context;

        public DetailsModel(jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext context)
        {
            _context = context;
        }

        public PersonalInfo personalInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            personalInfo = await _context.PersonalInfo.FirstOrDefaultAsync(m => m.ID == id);

            if (personalInfo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
