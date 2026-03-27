using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services.RequiredDocuments
{
    public class RequiredDocumentService : IRequiredDocumentService
    {
        //
        private readonly IRequiredDocument _requiredDocument;
        
        //Constructor
        public RequiredDocumentService(IRequiredDocument requiredDocument)
        {
            _requiredDocument = requiredDocument;
        }

        //CreateRequiredDocumentAsync
        public async Task CreateRequiredDocumentAsync(CreateRequiredDocumentDTO createRequiredDocumentDTO)
        {
            await _requiredDocument.CreateRequiredDocumentAsync(createRequiredDocumentDTO);
        }

        //UpdateRequiredDocumentAsync
        public async Task UpdateRequiredDocumentAsync(UpdateRequiredDocumentDTO updateRequiredDocumentDTO)
        {
            await _requiredDocument.UpdateRequiredDocumentAsync(updateRequiredDocumentDTO);
        }

        //DeleteRequiredDocumentAsync
        public async Task DeleteRequiredDocumentAsync(int id)
        {
            await _requiredDocument.DeleteRequiredDocumentAsync(id);
        }

        //GetRequiredDocumentByIdAsync
        public async Task<RequiredDocument> GetRequiredDocumentByIdAsync(int id)
        {
            return await _requiredDocument.GetRequiredDocumentByIdAsync(id);
        }

        //GetAllRequiredDocumentsAsync
        public async Task<List<RequiredDocument>> GetAllRequiredDocumentsAsync()
        {
            return await _requiredDocument.GetAllRequiredDocumentsAsync();
        }
    }
}