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

        private readonly IPersonalInfoRepository _personalInfoRepository;
        public IndexModel(IPersonalInfoRepository personalInfoRepository)
        {
            _personalInfoRepository = personalInfoRepository;
            Console.WriteLine("Injected PersonalInfoRepository");
        }

        public void OnGet()
        {
            var personalInfoData = _personalInfoRepository.GetAll();
           
        }

   
    public JsonResult OnGetDataTabelData()
    {
        try
        {
                var result = _personalInfoRepository.GetAll();
                Console.WriteLine("OnGet data table data : personalInfoData=" + result.Count());
                return new JsonResult(result);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


/*
    public IActionResult AddEditPersonalInfo(int id)
    {
        PersonalInfo personalInfo = new PersonalInfo();
        if (id > 0) personalInfo = _personalInfoRepository.Find(b => b.ID == id);
        return PartialView("_PersonalInfoForm", personalInfo);
    }
    */

    [HttpPost]
    public async Task<string> Create(PersonalInfo personalInfo)
    {
        if (ModelState.IsValid)
        {
            if (personalInfo.ID > 0)
            {
                personalInfo.LastModifiedDate = DateTime.Now;
                personalInfo.LastUpdateUser = "Admin";
                _personalInfoRepository.Update(personalInfo, personalInfo.ID);
                return "Personal Info Updated Successfully";
            }
            else
            {
                personalInfo.CreatedDate = DateTime.Now;
                personalInfo.CreationUser = "Admin";
                await _personalInfoRepository.AddAsyn(personalInfo);
                var result = await _personalInfoRepository.SaveAsync();

                var successMessage = "Personal Info Created Successfully. Name: " + personalInfo.FirstName;
                TempData["successAlert"] = successMessage;
                return "Personal Info Created Successfully";
            }
        }
        return "Failed";
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        PersonalInfo personalInfo = _personalInfoRepository.Get(id);
        _personalInfoRepository.Delete(personalInfo);
        return RedirectToAction("Index");
    }

    /*
            public FileStreamResult ExportAllDatatoCSV()
            {
                var personalInfoData = (from tblObj in _personalInfoRepository.GetAll() select tblObj).Take(100);
                var result = Common.WriteCsvToMemory(personalInfoData);
                var memoryStream = new MemoryStream(result);
                return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "Personal_Info_Data.csv" };
            }
            */
}
}