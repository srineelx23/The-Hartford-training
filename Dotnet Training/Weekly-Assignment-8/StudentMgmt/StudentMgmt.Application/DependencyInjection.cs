using Microsoft.Extensions.DependencyInjection;
using StudentMgmt.Application.Interfaces.Repositories;
using StudentMgmt.Application.Interfaces.Services;
using StudentMgmt.Application.Services;

namespace StudentMgmt.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<ITrainerService, TrainerService>();
        services.AddScoped<IStudyMaterialService, StudyMaterialService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}