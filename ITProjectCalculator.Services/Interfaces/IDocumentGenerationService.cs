using ITProjectCalculator.Data.Entities;

namespace ITProjectCalculator.Services.Interfaces;

public interface IDocumentGenerationService
{
    Task<byte[]> GenerateNMADocumentAsync(int projectId, string format); // PDF, Excel, Word
    Task<byte[]> GenerateCommercialProposalAsync(int projectId, string format); // PDF, Excel, Word
    Task<string> GetDocumentAsHtmlAsync(int projectId, string documentType); // For preview
}
