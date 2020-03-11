using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace jQueryDatatablesRazorPage.Models
{
    public class PersonalInfoDTO 
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }
        public string NID { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
}
