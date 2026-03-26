using Application.Services.PaymentTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repositories;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            // Add infrastructure services here, e.g., DbContext, Repositories, etc.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DigitalLoanPlatformConnection"))
            );

            // Add repositories
            services.AddScoped<IPaymentType, PaymentTypeRepository>();
            services.AddScoped<IPaymentModality, PaymentModalityRepository>();
            services.AddScoped<IReason, ReasonRepository>();
            services.AddScoped<IGuarantorType, GuarantorTypeRepository>();
            services.AddScoped<IBorrower, BorrowerRepository>();
            services.AddScoped<IAccount, AccountRepository>();
            services.AddScoped<ILoanProduct, LoanProductRepository>();
            services.AddScoped<IRequiredDocument, RequiredDocumentRepository>();
            services.AddScoped<ILoanApplication, LoanApplicationRepository>();

            return services;
        }
    }
}
