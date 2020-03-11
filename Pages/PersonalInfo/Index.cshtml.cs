using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using jQueryDatatablesRazorPage.Models;
using jQueryDatatablesRazorPage.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jQueryDatatablesRazorPage
{
    public class IndexModel : PageModel
    {

        private readonly jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext _context;
        public IndexModel(jQueryDatatablesRazorPage.Models.RazorPagesPersonalInfoContext context)
        {
            _context = context;
            Console.WriteLine("Injected context");
        }

        public IList<PersonalInfo> PersonalInfoList { get; set; }

        public void OnGet()
        {
            
        }

   
        public JsonResult OnGetDataTabelData()
        {
            try
            {
                var result = from m in _context.PersonalInfo
                                           select m; ;
                PersonalInfoList =  result.ToList();
                //Console.WriteLine("OnGet data table data : personalInfoData=" + PersonalInfoList.Count());
                return new JsonResult(PersonalInfoList);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}