using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace jQueryDatatablesRazorPage.Models
{
    public class RazorPagesPersonalInfoContext : DbContext
    {
        public RazorPagesPersonalInfoContext (DbContextOptions<RazorPagesPersonalInfoContext> options)
            : base(options)
        {
        }

        public DbSet<jQueryDatatablesRazorPage.Models.PersonalInfo> PersonalInfo { get; set; }
    }
}
