using BlazorComponents.Shared;
using Radzen;

namespace BlazorComponents.Client.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthors();
        Task<AuthorDataResult> GetAll(int skip, int take);
        Task<AuthorDataResult> GridSearch(string filterText, DateTime? filterDate, string filter, string orderBy, int skip, int take);
        Task<AuthorDataResult> Search(string filter, DateTime? filterDate, int skip, int take);
        Task<AuthorDto> GetAuthor(int id);
        Task<AuthorDto> GetAuthorByEmail(string email);
    }
}
