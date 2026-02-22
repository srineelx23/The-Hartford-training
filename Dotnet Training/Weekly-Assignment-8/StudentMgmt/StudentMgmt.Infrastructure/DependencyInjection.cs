using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Application.Interfaces.Services;
using StudentMgmt.Infrastructure.Persistence;
using StudentMgmt.Infrastructure.Repositories;
using StudentMgmt.Infrastructure.Services;

namespace StudentMgmt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<StudentContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<ITrainerRepository, TrainerRepository>();
        services.AddScoped<IStudyMaterialRepository, StudyMaterialRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();

        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}