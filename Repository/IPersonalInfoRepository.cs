using jQueryDatatablesRazorPage.Models;

namespace jQueryDatatablesRazorPage.Repository
{
    public interface IPersonalInfoRepository: IGenericRepository<PersonalInfo>
    {
        PersonalInfo Get(int blogId);
    }
}
