﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jQueryDatatablesRazorPage.Models;
using jQueryDatatablesRazorPage.Repository;

namespace jQueryDatatablesRazorPage
{
    public class EditModel : PageModel
    {
        private readonly jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext _context;

        public EditModel(jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonalInfo personalInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(personalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(personalInfo.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(long id)
        {
            return _context.PersonalInfo.Any(e => e.ID == id);
        }
    }
}
