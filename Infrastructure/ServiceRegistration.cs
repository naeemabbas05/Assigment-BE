using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Services.Interfaces;
using Application.Services;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISkillSetRepository, SkillSetRepository>();
            services.AddScoped< ISkillSetService, SkillSetService >();
            services.AddScoped<IApplicationDBContext,ApplicationDBContext>();
    
            return services;
        }
    }
}
