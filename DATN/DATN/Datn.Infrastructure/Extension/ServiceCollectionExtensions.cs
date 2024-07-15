using Datn.Application.Interface;
using Datn.Infrastructure.Database.AppDbContext;
using Datn.Infrastructure.Implement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Datn.Infrastructure.Extention
{
	public static class ServiceCollectionExtensions // Khai báo interface
	{
		public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<AppDbContexts>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			return services;
		}
	}
}