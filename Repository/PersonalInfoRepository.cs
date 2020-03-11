using jQueryDatatablesRazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jQueryDatatablesRazorPage.Repository
{
    public class PersonalInfoRepository : GenericRepository<PersonalInfo>, IPersonalInfoRepository
    {
        public PersonalInfoRepository(DataBaseContext context) : base(context)
        {
        }

        public PersonalInfo Get(long Id)
        {
            var query = GetAll().FirstOrDefault(b => b.ID == Id);
            return query;
        }
    }
}
