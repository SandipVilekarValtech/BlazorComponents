using BlazorComponents.Shared;
using Radzen;

namespace BlazorComponents.Server.DataModel
{
    public interface IAuthorRepository
    {
        Task<AuthorDataResult> GetAll(int skip, int take);
        Task<AuthorDataResult> GridSearch(string filterText, DateTime? filterDate, string filter, string orderBy, int skip = 0, int take = 5);
        Task<AuthorDataResult> Search(string filter, DateTime? filterDate, int skip, int take);
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthor(int id);
        Task<Author> GetAuthorByEmail(string email);
    }
}
