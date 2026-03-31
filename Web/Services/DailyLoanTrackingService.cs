using Application.Interfaces;
using Application.DTO;
using Domain.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web.Services
{
    public class DailyLoanTrackingService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DailyLoanTrackingService> _logger;

        public DailyLoanTrackingService(IServiceProvider serviceProvider, ILogger<DailyLoanTrackingService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Daily Loan Tracking Service starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await ProcessDailyTasksAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred executing daily tasks.");
                }

                // Wait 24 hours before running again.
                // In production, this might be scheduled by a library like Quartz or Hangfire,
                // or checked more cleverly. For demonstration, we simply delay.
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }

        private async Task ProcessDailyTasksAsync()
        {
            _logger.LogInformation("Processing daily loan installment tracking...");

            using var scope = _serviceProvider.CreateScope();
            var installmentRepo = scope.ServiceProvider.GetRequiredService<ILoanInstallment>();

            var allInstallments = await installmentRepo.GetAllLoanInstallmentAsync();
            var today = DateTime.Today;

            foreach (var installment in allInstallments)
            {
                if (installment.Status == "Paid") continue;

                var daysUntilDue = (installment.DueDate.Date - today).Days;

                // 1. Mock 3-day reminder
                if (daysUntilDue == 3)
                {
                    var borrowerEmail = installment.LoanDisbursment?.LoanApplication?.Borrower?.Email;
                    
                    if (!string.IsNullOrEmpty(borrowerEmail))
                    {
                        Console.WriteLine($"[EMAIL MOCK] From: akuachille2006@gmail.com | To: {borrowerEmail} | Subject: Payment Reminder | Body: Your loan installment of {installment.AmountDue:C} is due in 3 days on {installment.DueDate.ToShortDateString()}.");
                    }
                }

                // 2. Penalties: 2% of the installment amount daily
                if (daysUntilDue < 0 && installment.Status != "Paid")
                {
                    // Add 2% of original AmountDue
                    decimal penaltyAmount = installment.AmountDue * 0.02m;
                    installment.PenaltyAmount += penaltyAmount;
                    installment.UpdatedAt = DateTime.Now;

                    await installmentRepo.UpdateLoanInstallment(new LoanInstallmentDTO
                    {
                        Id = installment.Id,
                        AmountPaid = installment.AmountPaid,
                        PenaltyAmount = installment.PenaltyAmount,
                        Status = installment.Status
                    });

                    _logger.LogInformation($"Applied {penaltyAmount:C} penalty to Installment {installment.Id}. Total Penalty: {installment.PenaltyAmount:C}");
                }
            }
        }
    }
}
