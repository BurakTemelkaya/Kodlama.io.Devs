using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Application.Pipelines.Validation;
using MediatR;
using FluentValidation;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Auths.Rules;
using Application.Services.Auth;
using Application.Features.SocialMediaAddresses.Rules;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<ProgrammingLanguageTechnologyBusinessRules>();
            services.AddScoped<SocialMediaAddressBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IAuthService, AuthManager>();

            return services;
        }
    }
}
