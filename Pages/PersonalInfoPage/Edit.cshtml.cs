using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jQueryDatatablesRazorPage.Models;
using jQueryDatatablesRazorPage.Repository;

namespace jQueryDatatablesRazorPage.PersonalInfoPage
{
    public class EditModel : PageModel
    {
        private readonly jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext _context;

        public EditModel(jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext context)
        {
            _context = context;
        }


        public PersonalInfo personalInfo { get; set; }
        [BindProperty]
        public PersonalInfoDTO personalInfoDTO { get; set; }

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
            personalInfoDTO = PersonalInfoMapper.ConvertToDTO(personalInfo);
           
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

            personalInfo = await _context.PersonalInfo.FirstOrDefaultAsync(m => m.ID == personalInfoDTO.ID);
            personalInfo.FirstName = personalInfoDTO.FirstName;
            personalInfo.LastName = personalInfoDTO.LastName;
            personalInfo.DateOfBirth = personalInfoDTO.DateOfBirth;
            personalInfo.Email = personalInfoDTO.Email;
            personalInfo.LastModifiedDate = DateTime.Now;
            personalInfo.LastUpdateUser = "Admin";
            _context.Attach(personalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                var successMessage = "Personal Info Updated Successfully. Name: " + personalInfo.FirstName;
                TempData["successAlert"] = successMessage;
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
