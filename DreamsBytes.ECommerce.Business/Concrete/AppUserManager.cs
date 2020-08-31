using DreamsBytes.ECommerce.Business.Interfaces;
using DreamsBytes.ECommerce.DataAccess.Interfaces;
using DreamsBytes.ECommerce.DTOs.Concrete;
using DreamsBytes.ECommerce.DTOs.Concrete.AppUserDtos;
using DreamsBytes.ECommerce.Entities.Concrete;
using System.Threading.Tasks;

namespace DreamsBytes.ECommerce.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
        public AppUser CheckUserAsync(AppUserLoginDto appUserLoginDto)
        {
            return _genericDal.GetOne(I => I.UserName == appUserLoginDto.UserName && I.Password == appUserLoginDto.Password);
        }

        public AppUser FindByNameAsync(string userName)
        {
            return _genericDal.GetOne(I => I.UserName == userName);
        }
    }
}
