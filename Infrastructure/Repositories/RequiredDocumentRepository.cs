using Application.DTO;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using System;

namespace Infrastructure.Repositories
{
    //Implementation of IRequiredDocument interface
    public class RequiredDocumentRepository : IRequiredDocument
    {
        //Dependency Injection
        private readonly ApplicationDbContext _context;

        //Constructor
        public RequiredDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //CreateRequiredDocumentAsync
        public async Task CreateRequiredDocumentAsync(CreateRequiredDocumentDTO createRequiredDocumentDTO)
        {
            var requiredDocument = new RequiredDocument
            {
                LoanProductId = createRequiredDocumentDTO.LoanProductId,
                DocumentName = createRequiredDocumentDTO.DocumentName,
                DocumentType = Enum.Parse<DocumentType>(createRequiredDocumentDTO.DocumentType, true),
                CreatedAt = DateTime.Now
            };
            await _context.RequiredDocuments.AddAsync(requiredDocument);
            await _context.SaveChangesAsync();
        }

        //UpdateRequiredDocumentAsync
        public async Task UpdateRequiredDocumentAsync(UpdateRequiredDocumentDTO updateRequiredDocumentDTO)
        {
            var requiredDocument = await _context.RequiredDocuments.FindAsync(updateRequiredDocumentDTO.Id);
            if (requiredDocument == null)
            {
                throw new KeyNotFoundException($"Required Document with ID {updateRequiredDocumentDTO.Id} was not found.");
            }
            requiredDocument.LoanProductId = updateRequiredDocumentDTO.LoanProductId;
            requiredDocument.DocumentName =  updateRequiredDocumentDTO.DocumentName;
            requiredDocument.DocumentType = Enum.Parse<DocumentType>(updateRequiredDocumentDTO.DocumentType, true);
            await _context.SaveChangesAsync();  
        }

        //DeleteRequiredDocumentAsync
        public async Task DeleteRequiredDocumentAsync(int id)
        {
            var requiredDocument = await _context.RequiredDocuments.FindAsync(id);
            if (requiredDocument == null)
            {
                throw new KeyNotFoundException($"Required Document with ID {id} was not found.");
            }
            _context.RequiredDocuments.Remove(requiredDocument);
            await _context.SaveChangesAsync();  
        }

        //GetRequiredDocumentByIdAsync
        public async Task<RequiredDocument> GetRequiredDocumentByIdAsync(int id)
        {
            var requiredDocument = await _context.RequiredDocuments.FindAsync(id);
            if (requiredDocument == null)
            {
                throw new KeyNotFoundException($"Required Document with ID {id} was not found.");
            }
            return requiredDocument;
        }

        //GetAllRequiredDocumentsAsync
        public async Task<List<RequiredDocument>> GetAllRequiredDocumentsAsync()
        {
            return await _context.RequiredDocuments.ToListAsync();
        }
    }
}