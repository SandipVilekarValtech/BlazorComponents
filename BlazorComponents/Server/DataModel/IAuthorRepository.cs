using BlazorComponents.Shared;

namespace BlazorComponents.Server.DataModel
{
    public interface IAuthorRepository
    {
        Task<AuthorDataResult> GetAll(int skip, int take);
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<IEnumerable<Author>> Search(string firstName);
        Task<Author> GetAuthor(int id);
        Task<Author> GetAuthorByEmail(string email);
    }
}
