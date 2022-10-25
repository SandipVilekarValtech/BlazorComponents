using BlazorComponents.Shared;

namespace BlazorComponents.Server.DataModel
{
    public interface IAuthorRepository
    {
        Task<AuthorDataResult> GetAll(int skip, int take);
        Task<AuthorDataResult> Search(string filter, int skip, int take);
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthor(int id);
        Task<Author> GetAuthorByEmail(string email);
    }
}
