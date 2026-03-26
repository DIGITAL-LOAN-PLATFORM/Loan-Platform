using Application.DTO;
using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Infrastructure.Repositories
{
    //Implements the ILoanApplication interface
    public class LoanApplicationRepository : ILoanApplication
    {
        //Dependency Injection
        private readonly ApplicationDbContext _context;

        //Constructor
        public LoanApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //GetAllLoanApplicationAsync
        public async Task<List<LoanApplication>> GetAllLoanApplicationAsync()
        {
            return await _context.LoanApplications
                .Include(l => l.Borrower)
                .Include(l => l.loanProduct)
                .Include(l => l.paymentModality)
                .ToListAsync();
        }

        //GetLoanApplicationByIdAsync
        public async Task<LoanApplication> GetLoanApplicationByIdAsync(int id)
        {
            return await _context.LoanApplications
                .Include(l => l.Borrower)
                .Include(l => l.loanProduct)
                .Include(l => l.paymentModality)
                .Include(l => l.ProvidedDocuments)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        //CreateLoanApplicationAsync
        public async Task CreateLoanApplicationAsync(CreateLoanApplicationDTO createLoanApplicationDTO)
        {
            // Generate Application Number: LYYMMDD-NN (e.g., L260326-01)
            var datePart = DateTime.Now.ToString("yyMMdd");
            var prefix = $"L{datePart}-";

            // Find the highest sequence number for today to avoid duplicates if applications were deleted
            var countToday = await _context.LoanApplications
                .CountAsync(l => l.ApplicationNumber.StartsWith(prefix));
            
            var applicationNumber = $"{prefix}{(countToday + 1):D2}";

            var loanApplication = new LoanApplication
            {
                ApplicationNumber = applicationNumber,
                ProductId = createLoanApplicationDTO.ProductId,
                BorrowerId = createLoanApplicationDTO.BorrowerId,
                ModalityId = createLoanApplicationDTO.ModalityId,
                RequestedAmount = createLoanApplicationDTO.RequestedAmount,
                Duration = createLoanApplicationDTO.Duration,
                Purpose = createLoanApplicationDTO.Purpose,
                ApplicationDate = DateTime.Now,
                ApprovalStatus = "Pending",
                ProvidedDocuments = new List<ProvidedDocument>()
            };

            // Process uploaded documents
            if (createLoanApplicationDTO.ProvidedDocuments != null && createLoanApplicationDTO.ProvidedDocuments.Any())
            {
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "documents");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                foreach (var doc in createLoanApplicationDTO.ProvidedDocuments)
                {
                    if (!string.IsNullOrEmpty(doc.Base64Content))
                    {
                        var uniqueFileName = $"{Guid.NewGuid()}_{doc.FileName}";
                        var filePath = Path.Combine(uploadsPath, uniqueFileName);
                        var fileBytes = Convert.FromBase64String(doc.Base64Content);
                        await File.WriteAllBytesAsync(filePath, fileBytes);

                        loanApplication.ProvidedDocuments.Add(new ProvidedDocument
                        {
                            DocumentName = doc.DocumentName,
                            DocumentFile = $"/uploads/documents/{uniqueFileName}",
                            CreatedAt = DateTime.Now
                        });
                    }
                }
            }

            _context.LoanApplications.Add(loanApplication);
            await _context.SaveChangesAsync();
        }

        //UpdateLoanApplicationAsync
        public async Task UpdateLoanApplicationAsync(UpdateLoanApplicationDTO updateLoanApplicationDTO)
        {
            var loanApplication = await _context.LoanApplications.FindAsync(updateLoanApplicationDTO.Id);
            if (loanApplication != null)
            {
                loanApplication.ProductId = updateLoanApplicationDTO.ProductId;
                loanApplication.BorrowerId = updateLoanApplicationDTO.BorrowerId;
                loanApplication.ModalityId = updateLoanApplicationDTO.ModalityId;
                loanApplication.RequestedAmount = updateLoanApplicationDTO.RequestedAmount;
                loanApplication.Duration = updateLoanApplicationDTO.Duration;
                loanApplication.Purpose = updateLoanApplicationDTO.Purpose;
                loanApplication.ApplicationDate = updateLoanApplicationDTO.ApplicationDate;
                loanApplication.ApprovalStatus = "Pending"; // Reset status when updated
                
                // Process new uploaded documents if any
                if (updateLoanApplicationDTO.ProvidedDocuments != null && updateLoanApplicationDTO.ProvidedDocuments.Any())
                {
                    var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "documents");
                    if (!Directory.Exists(uploadsPath))
                    {
                        Directory.CreateDirectory(uploadsPath);
                    }

                    if (loanApplication.ProvidedDocuments == null)
                    {
                        loanApplication.ProvidedDocuments = new List<ProvidedDocument>();
                    }

                    foreach (var doc in updateLoanApplicationDTO.ProvidedDocuments)
                    {
                        if (!string.IsNullOrEmpty(doc.Base64Content))
                        {
                            var uniqueFileName = $"{Guid.NewGuid()}_{doc.FileName}";
                            var filePath = Path.Combine(uploadsPath, uniqueFileName);
                            var fileBytes = Convert.FromBase64String(doc.Base64Content);
                            await File.WriteAllBytesAsync(filePath, fileBytes);

                            loanApplication.ProvidedDocuments.Add(new ProvidedDocument
                            {
                                DocumentName = doc.DocumentName,
                                DocumentFile = $"/uploads/documents/{uniqueFileName}",
                                CreatedAt = DateTime.Now
                            });
                        }
                    }
                }

                _context.LoanApplications.Update(loanApplication);
                await _context.SaveChangesAsync();
            }
        }

        //DeleteLoanApplicationAsync
        public async Task DeleteLoanApplicationAsync(int id)
        {
            var loanApplication = await _context.LoanApplications.FindAsync(id);
            if (loanApplication != null)
            {
                _context.LoanApplications.Remove(loanApplication);
                await _context.SaveChangesAsync();
            }
        }

        //ApproveLoanApplicationAsync
        public async Task ApproveLoanApplicationAsync(int id)
        {
            var loanApplication = await _context.LoanApplications.FindAsync(id);
            if (loanApplication != null)
            {
                loanApplication.ApprovalStatus = "Approved";
                loanApplication.ApprovalDate = DateTime.Now;
                _context.LoanApplications.Update(loanApplication);
                await _context.SaveChangesAsync();
            }
        }

        //RejectLoanApplicationAsync
        public async Task RejectLoanApplicationAsync(int id)
        {
            var loanApplication = await _context.LoanApplications.FindAsync(id);
            if (loanApplication != null)
            {
                loanApplication.ApprovalStatus = "Rejected";
                loanApplication.RejectionDate = DateTime.Now;
                _context.LoanApplications.Update(loanApplication);
                await _context.SaveChangesAsync();
            }
        }
    }
}