using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jQueryDatatablesRazorPage.Models
{
    public static class PersonalInfoMapper
    {
        public static PersonalInfoDTO ConvertToDTO(this PersonalInfo person)
        {
            return new PersonalInfoDTO { 
                ID = person.ID, 
                FirstName = person.FirstName, 
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Country = person.Country,
                City = person.City,
                Email = person.Email,
                MobileNo = person.MobileNo,
                NID = person.NID,
            };
        }

        public static IEnumerable<PersonalInfoDTO> ConvertToDTO(this IEnumerable<PersonalInfo> people)
        {
            return people.Select(person => person.ConvertToDTO());
        }
    }
}
