using BlazorComponents.Shared;

namespace BlazorComponents.Client.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAll(int skip, int take);
        //Task<int> GetCount();
        Task<IEnumerable<AuthorDto>> Search(string firstName);
        Task<AuthorDto> GetAuthor(int id);
        Task<AuthorDto> GetAuthorByEmail(string email);
    }
}
