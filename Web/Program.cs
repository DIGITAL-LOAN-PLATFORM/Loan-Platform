using LoanPlatform.Components;
using Application.Interfaces;
using Infrastructure.Services;
using MudBlazor.Services;
using Infrastructure.DependencyInjection;
using Microsoft.Extensions.FileProviders;
//Application Services
using Application.Services.PaymentTypes;
using Application.Services.PaymentModalities;
using Application.Services.Reasons;
using Application.Services.GuarantorTypes;
using Application.Services.Borrowers;
using Application.Services.Accounts;
using Application.Services.LoanProducts;
using Application.Services.RequiredDocuments;
using Application.Services.LoanApplications;
using Application.Services.LoanDisbursments;
using Application.Services.Guarantors;
using Application.Services.LoanInstallments;
using Application.Services.LoanPayments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();

//Add Services implementations
builder.Services.AddScoped<IPaymentTypeService, PaymentTypeService>();
builder.Services.AddScoped<IPaymentModalityService, PaymentModalityService>();
builder.Services.AddScoped<IReasonService, ReasonService>();
builder.Services.AddScoped<IGuarantorTypeService, GuarantorTypeService>();
builder.Services.AddScoped<IGuarantorService, GuarantorService>();
builder.Services.AddScoped<IBorrowerService, BorrowerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILoanProductService, LoanProductService>();
builder.Services.AddScoped<IRequiredDocumentService, RequiredDocumentService>();
builder.Services.AddScoped<ILoanApplicationService, LoanApplicationService>();
builder.Services.AddScoped<ILoanDisbursmentService, LoanDisbursmentServices>();
builder.Services.AddScoped<ILoanInstallmentService, LoanInstallmentService>();
builder.Services.AddScoped<ILoanPaymentService, LoanPaymentService>();

// Register Background Service for Daily Tracking
builder.Services.AddHostedService<Web.Services.DailyLoanTrackingService>();



    builder.Services.AddInfrastructureService(builder.Configuration);
    builder.Services.AddSingleton<IFileProvider>(builder.Environment.WebRootFileProvider);
builder.Services.AddSingleton<ILocationService, JsonLocationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
