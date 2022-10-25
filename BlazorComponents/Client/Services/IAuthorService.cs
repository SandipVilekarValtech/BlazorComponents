using BlazorComponents.Shared;

namespace BlazorComponents.Client.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthors();
        Task<AuthorDataResult> GetAll(int skip, int take);
        Task<AuthorDataResult> Search(string filter, int skip, int take);
        Task<IEnumerable<AuthorDto>> Search(string firstName);
        Task<AuthorDto> GetAuthor(int id);
        Task<AuthorDto> GetAuthorByEmail(string email);
    }
}
