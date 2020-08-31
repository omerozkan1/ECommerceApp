using DreamsBytes.ECommerce.Business.Concrete;
using DreamsBytes.ECommerce.Business.Interfaces;
using DreamsBytes.ECommerce.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using DreamsBytes.ECommerce.DataAccess.Interfaces;
using DreamsBytes.ECommerce.Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace DreamsBytes.ECommerce.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICartDal, EfCartRepository>();


            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDal, EfOrderRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductRepository>();



            
            


        }
    }
}
