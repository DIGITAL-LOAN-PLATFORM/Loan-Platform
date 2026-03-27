using Application.DTO;

using Domain.Entities;

namespace Application.Services.RequiredDocuments
{
    public interface IRequiredDocumentService
    {
        //Create
        Task CreateRequiredDocumentAsync(CreateRequiredDocumentDTO createRequiredDocumentDTO);
        //Update
        Task UpdateRequiredDocumentAsync(UpdateRequiredDocumentDTO updateRequiredDocumentDTO);
        //Delete
        Task DeleteRequiredDocumentAsync(int id);
        //Get By Id
        Task<RequiredDocument> GetRequiredDocumentByIdAsync(int id);
        //Get All
        Task<List<RequiredDocument>> GetAllRequiredDocumentsAsync();
    }
}