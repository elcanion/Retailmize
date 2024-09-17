using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Retailmize.Application.Interfaces;
using Retailmize.Application.Mappings;
using Retailmize.Application.Services;
using Retailmize.Domain.Account;
using Retailmize.Domain.Interfaces;
using Retailmize.Infra.Data.Context;
using Retailmize.Infra.Data.Identity;
using Retailmize.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMapping));

            services.AddScoped<IAuthenticate, AuthenticateService>();

            var handlers = AppDomain.CurrentDomain.Load("Retailmize.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));

            return services;
        }
    }
}
