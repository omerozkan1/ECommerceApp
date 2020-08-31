using DreamsBytes.ECommerce.DTOs.Concrete;
using DreamsBytes.ECommerce.DTOs.Concrete.AppUserDtos;
using DreamsBytes.ECommerce.Entities.Concrete;
using System.Threading.Tasks;

namespace DreamsBytes.ECommerce.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        AppUser CheckUserAsync(AppUserLoginDto appUserLoginDto);
        AppUser FindByNameAsync(string userName);
    }
}
