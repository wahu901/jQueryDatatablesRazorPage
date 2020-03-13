using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using jQueryDatatablesRazorPage.Models;
using jQueryDatatablesRazorPage.Repository;

namespace jQueryDatatablesRazorPage.PersonalInfoDialog
{
    public class CreateModel : PageModel
    {
        private readonly jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext _context;

        public CreateModel(jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PersonalInfo personalInfo { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /*
        public async Task<string> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                personalInfo.CreatedDate = DateTime.Now;
                personalInfo.CreationUser = "Admin";
                _context.PersonalInfo.Add(personalInfo);
                await _context.SaveChangesAsync();

                var successMessage = "Personal Info Created Successfully. Name: " + personalInfo.FirstName;
                return successMessage;
            }
            return "Failed";
        }
        */

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            personalInfo.CreatedDate = DateTime.Now;
            personalInfo.CreationUser = "Admin";
            _context.PersonalInfo.Add(personalInfo);
            await _context.SaveChangesAsync();

            var successMessage = "Personal Info Created Successfully. Name: " + personalInfo.FirstName;
            TempData["successAlert"] = successMessage;

            return RedirectToPage("./Index");
        }
    }
}
