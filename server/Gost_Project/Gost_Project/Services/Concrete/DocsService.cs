using Gost_Project.Data.Entities;
using Gost_Project.Data.Entities.Navigations;
using Gost_Project.Data.Repositories.Abstract;
using Gost_Project.Data.Repositories.Concrete;
using Gost_Project.Services.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Gost_Project.Services.Concrete;

public class DocsService(IDocsRepository docsRepository, IFieldsRepository fieldsRepository) : IDocsService
{
    private readonly IDocsRepository _docsRepository = docsRepository;
    private readonly IFieldsRepository _fieldsRepository = fieldsRepository;

    public async Task<long> AddNewDocAsync(FieldEntity primaryField)
    {
        var actualField = new FieldEntity();

        var primaryId = await _fieldsRepository.AddAsync(primaryField);
        var actualId = await _fieldsRepository.AddAsync(actualField);

        var doc = new DocEntity { ActualFieldId = actualId, PrimaryFieldId = primaryId };
        var docId = await _docsRepository.AddAsync(doc);

        return docId;
    }

    public async Task<IActionResult> DeleteDocAsync(long id)
    {
        var doc = await _docsRepository.GetByIdAsync(id);

        if (doc is null)
        {
            return new UnprocessableEntityObjectResult($"Document with id {id} not found.");
        }
        
        await _fieldsRepository.DeleteAsync(doc.PrimaryFieldId);
        await _fieldsRepository.DeleteAsync(doc.ActualFieldId);
        
        await _docsRepository.DeleteAsync(id);

        return new OkObjectResult("Document deleted successfully.");
    }

    public async Task<IActionResult> ChangeStatusAsync(long id, DocStatuses status)
    {
        var doc = await _docsRepository.GetByIdAsync(id);

        if (doc is null)
        {
            return new UnprocessableEntityObjectResult($"Document with id {id} not found.");
        }
        
        var primaryField = await _fieldsRepository.GetByIdAsync(doc.PrimaryFieldId);
        var actualField = await _fieldsRepository.GetByIdAsync(doc.ActualFieldId);
        
        if (primaryField is not null)
        {
            primaryField.Status = status;
            await _fieldsRepository.UpdateAsync(primaryField);
        }
        if (actualField is not null)
        {
            actualField.Status = status;
            await _fieldsRepository.UpdateAsync(actualField);
        }

        return new OkObjectResult("Status changed successfully.");
    }
}