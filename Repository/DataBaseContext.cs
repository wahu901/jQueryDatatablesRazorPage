using jQueryDatatablesRazorPage.Models;
using Microsoft.EntityFrameworkCore;

namespace jQueryDatatablesRazorPage.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<PersonalInfo> PersonalInfo { get; set; }
    }
}
